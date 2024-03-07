using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Prescricao : Control, IPrescricao
    {
        private Model.Prescricao entity = new Model.Prescricao();

        public PrescricaoDTO Gravar(PrescricaoDTO dto)
        {
            entity.Gravar(dto);
            return dto;
        }

        public void GravarInformacoesExtras(PrescricaoDTO dto)
        {
            entity.GravarInformacoesExtras(dto);
        }

        public void GravarItem(PrescricaoDTO dto)
        {
            this.GravarItem(dto, false);
        }

        public void GravarItem(PrescricaoDTO dto, bool enviaSMSDataLimiteAlterada)
        {
            bool dataLimiteAlterada = false;
            
            if (enviaSMSDataLimiteAlterada &&
                !dto.IdPrescricao.Value.IsNull && !dto.IdMedicamentoPrescricaoMedica.Value.IsNull && !dto.IdAtendimento.Value.IsNull)
            {
                PrescricaoDTO dtoPesquisaDtLimite = new PrescricaoDTO();
                dtoPesquisaDtLimite.IdPrescricao.Value = dto.IdPrescricao.Value;
                dtoPesquisaDtLimite.IdProduto.Value = dto.IdProduto.Value;
                PrescricaoDataTable dtbPesquisa = entity.ListarItem(dtoPesquisaDtLimite, false);

                DateTime? dtLimiteBD = null;
                dtoPesquisaDtLimite = dtbPesquisa.TypedRow(0);
                if (!dtoPesquisaDtLimite.DataLimiteConsumo.Value.IsNull)
                    dtLimiteBD = dtoPesquisaDtLimite.DataLimiteConsumo.Value;

                DateTime? dtLimiteNova = null;
                if (!dto.DataLimiteConsumo.Value.IsNull)
                    dtLimiteNova = dto.DataLimiteConsumo.Value;

                if (dtLimiteBD != dtLimiteNova)
                    dataLimiteAlterada = true;
            }

            entity.GravarItem(dto);

            if (enviaSMSDataLimiteAlterada && dataLimiteAlterada)
            {
                //Enviar SMS caso haja mudança na data limite de consumo
                Utilitario util = new Utilitario();
                MaterialMedicamentoDTO dtoMed = new MaterialMedicamentoDTO();
                dtoMed.Idt.Value = dto.IdProduto.Value;
                string sal = this.FormatarSal(new MaterialMedicamento().SelChave(dtoMed).Sal.Value);
                string textoDtFimAlterada = "MEDICAMENTO " + sal + " TEVE DATA LIMITE DE ADMINISTRACAO ALTERADA PELO SCIH, VERIFICAR INTERNACAO " + dto.IdAtendimento.Value;
                string telefoneMedico = new RequisicaoItens().ObterTelefoneUsuarioMedicoInt((int)dto.IdMedicamentoPrescricaoMedica.Value);
                if (!string.IsNullOrEmpty(telefoneMedico))
                {
                    telefoneMedico = BasicFunctions.RemoverFormatacao(telefoneMedico.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", ""));
                    util.EnviarSMS(telefoneMedico, textoDtFimAlterada);
                }
                else
                {
                    util.EnviarSMS(util.CelularResponsavelTI(), "MEDICO CRM " + dto.CRM.Value + " SEM CELULAR CADASTRADO.");
                }
                //util.EnviarSMS(util.CelularResponsavelTI(), textoDtFimAlterada);
                util.EnviarSMS(util.CelularResponsavelFarmacia(), textoDtFimAlterada);

                Model.Paciente Pac = new Model.Paciente();                
                DataTable dtPaciente = Pac.ObterPaciente(decimal.Parse(dto.IdAtendimento.Value));
                if (dtPaciente.Rows.Count > 0)                
                    textoDtFimAlterada += " / NOME: " + dtPaciente.Rows[0]["CAD_PES_NM_PESSOA"].ToString();
                
                dtPaciente = Pac.ObterPacienteSetor(decimal.Parse(dto.IdAtendimento.Value));
                if (dtPaciente.Rows.Count > 0)
                {
                    textoDtFimAlterada += " / SETOR: " + dtPaciente.Rows[0][SetorDTO.FieldNames.Descricao].ToString();
                }

                util.EnviarEmail(util.EmailFarmaciaClinica(), textoDtFimAlterada, "AVISO: ALTERACAO DATA LIMITE MEDICAMENTO PRESCRICAO");
            }
        }

        private string FormatarSal(string sal)
        {
            sal = sal.Replace(" ", "XXXXX");
            sal = BasicFunctions.RemoverFormatacao(sal);
            sal = sal.Replace("XXXXX", " ");
            return sal;
        }

        public void GravarParecerSCIH(PrescricaoDTO dto)
        {
            entity.GravarParecerSCIH(dto);
            
            if (!dto.IdMedicamentoPrescricaoMedica.Value.IsNull && !dto.IdAtendimento.Value.IsNull)
            {
                Utilitario util = new Utilitario();
                if (!dto.FlAutorizado.Value.IsNull && dto.FlAutorizado.Value == 0) //Enviar SMS de MEDICAMENTO NAO AUTORIZADO
                {
                    MaterialMedicamentoDTO dtoMed = new MaterialMedicamentoDTO();
                    dtoMed.Idt.Value = dto.IdProduto.Value;
                    string sal = this.FormatarSal(new MaterialMedicamento().SelChave(dtoMed).Sal.Value);
                    string textoNaoAutoriza = "MEDICAMENTO " + sal + " NAO AUTORIZADO PELO SCIH, INTERNACAO " + dto.IdAtendimento.Value;
                    string telefoneMedico = new RequisicaoItens().ObterTelefoneUsuarioMedicoInt((int)dto.IdMedicamentoPrescricaoMedica.Value);
                    if (!string.IsNullOrEmpty(telefoneMedico))
                    {
                        telefoneMedico = BasicFunctions.RemoverFormatacao(telefoneMedico.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", ""));
                        util.EnviarSMS(telefoneMedico, textoNaoAutoriza);
                    }
                    else
                    {
                        util.EnviarSMS(util.CelularResponsavelTI(), "MEDICO CRM " + dto.CRM.Value + " SEM CELULAR CADASTRADO.");
                    }
                    //util.EnviarSMS(util.CelularResponsavelTI(), textoNaoAutoriza);
                    util.EnviarSMS(util.CelularResponsavelFarmacia(), textoNaoAutoriza);

                    Model.Paciente Pac = new Model.Paciente();
                    DataTable dtPaciente = Pac.ObterPaciente(decimal.Parse(dto.IdAtendimento.Value));
                    if (dtPaciente.Rows.Count > 0)
                        textoNaoAutoriza += " / NOME: " + dtPaciente.Rows[0]["CAD_PES_NM_PESSOA"].ToString();

                    dtPaciente = Pac.ObterPacienteSetor(decimal.Parse(dto.IdAtendimento.Value));
                    if (dtPaciente.Rows.Count > 0)
                    {
                        textoNaoAutoriza += " / SETOR: " + dtPaciente.Rows[0][SetorDTO.FieldNames.Descricao].ToString();
                    }

                    util.EnviarEmail(util.EmailFarmaciaClinica(), textoNaoAutoriza, "AVISO: MEDICAMENTO NAO AUTORIZADO PELO SCIH");
                }
            }
        }

        public void ExcluirItem(PrescricaoDTO dto)
        {
            entity.ExcluirItem(dto);
        }

        public void GravarCultura(PrescricaoDTO dto)
        {
            entity.GravarCultura(dto);
        }

        public void ExcluirCultura(PrescricaoDTO dto)
        {
            entity.ExcluirCultura(dto);
        }

        public PrescricaoDataTable ListarCultura(PrescricaoDTO dto)
        {
            return entity.ListarCultura(dto);
        }

        public PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias)
        {
            return entity.ListarItem(dto, pendencias, false, null, null);
        }

        public PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias, bool trazerSetorPaciente, PacienteDTO dtoPaciente)
        {
            return entity.ListarItem(dto, pendencias, trazerSetorPaciente, dtoPaciente, null);
        }

        public void AssociarDoencaDiagnostico(PrescricaoDTO dto)
        {
            entity.AssociarDoencaDiagnostico(dto);
        }

        public void DesassociarDoencaDiagnostico(PrescricaoDTO dto)
        {
            entity.DesassociarDoencaDiagnostico(dto);
        }

        public PrescricaoDataTable ListarDoencaDiagnostico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi)
        {
            return entity.ListarDoencaDiagnostico(dto, dtoDoDi);
        }

        public PrescricaoDataTable ListarItensPrescricoesAnterioresPaciente(PrescricaoDTO dto)
        {
            return entity.ListarItensPrescricoesAnterioresPaciente(dto);
        }

        public DataTable ListarProfissionalCorpoClinico(string numConselho, string ufConselho, string codConselho, decimal? idProfissional)
        {
            return entity.ListarProfissionalCorpoClinico(numConselho, ufConselho, codConselho, idProfissional);
        }

        public DataTable ListarProfissionalSolicitante(string numConselho, string ufConselho, string codConselho)
        {
            return entity.ListarProfissionalSolicitante(numConselho, ufConselho, codConselho);
        }

        public DataTable ListarPacientesSetor(PrescricaoDTO dto, decimal? idUnidade, decimal? idLocal, decimal? idSetor, int? idadeDe, int? idadeAte, char? sexo)
        {
            return entity.ListarPacientesSetor(dto, idUnidade, idLocal, idSetor, idadeDe, idadeAte, sexo);
        }

        public DataTable ListarPacientesClinico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi, bool? comCultura)
        {
            return entity.ListarPacientesClinico(dto, dtoDoDi, comCultura);
        }

        public DataTable ListarMedicamentosEstatisticaAnalitico(PrescricaoDTO dto, bool? comModificacao, int? qtdDiasDe, int? qtdDiasAte)
        {
            return entity.ListarMedicamentosEstatisticaAnalitico(dto, comModificacao, qtdDiasDe, qtdDiasAte);
        }

        public DataTable ListarMedicamentosEstatisticaPercentual(PrescricaoDTO dto)
        {
            return entity.ListarMedicamentosEstatisticaPercentual(dto);
        }

        public DataTable ListarFormulariosCompletos(PrescricaoDTO dto)
        {
            return entity.ListarFormulariosCompletos(dto);
        }

        public DataTable ListarDataAtualizacaoItemPrescricao(decimal idtPrescricao)
        {
            return entity.ListarDataAtualizacaoItemPrescricao(idtPrescricao);
        }
    }
}