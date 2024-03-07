using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Paciente : Control, IPaciente
    {
        private Model.Paciente entity = new Model.Paciente();

        public PacienteDataTable Sel(PacienteDTO dto)
        {
            try
            {
                dto.TpAtendimento = this.ObterTipoAtendimento(dto).TpAtendimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return entity.Sel(dto);
        }

        /// <summary>
        /// Listar todos os registros NÃO limitando pela data da alta
        /// </summary>
        public PacienteDTO SelChave(PacienteDTO dto)
        {
            try
            {
                dto.TpAtendimento = this.ObterTipoAtendimento(dto).TpAtendimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return entity.SelChave(dto);
        }

        /// <summary>
        /// Configura o tipo de atendimento pelo local de atendimento
        /// </summary>
        /// <param name="dtoAtendimento"></param>
        /// <returns></returns>
        public PacienteDTO ObterTipoAtendimento(PacienteDTO dtoAtendimento)
        {
            if (dtoAtendimento.TpAtendimento.Value.IsNull)
            {
                switch ((int)dtoAtendimento.IdtLocalAtendimento.Value)
                {
                    case (int)PacienteDTO.LocalAtendimento.CENTRO_CIRURGICO:
                    case (int)PacienteDTO.LocalAtendimento.ATENDIMENTO_DOMICILIAR:
                    case (int)PacienteDTO.LocalAtendimento.INTERNADO:
                        dtoAtendimento.TpAtendimento.Value = PacienteDTO.TipoAtendimentoSGS.INTERNADO;
                        break;
                    case (int)PacienteDTO.LocalAtendimento.CONSULTORIO:
                    case (int)PacienteDTO.LocalAtendimento.AMBULATORIO:
                        dtoAtendimento.TpAtendimento.Value = PacienteDTO.TipoAtendimentoSGS.AMBULATORIO;
                        break;
                    case (int)PacienteDTO.LocalAtendimento.PRONTO_SOCORRO:
                        dtoAtendimento.TpAtendimento.Value = PacienteDTO.TipoAtendimentoSGS.URGENCIA;
                        break;
                }
            }            
            return dtoAtendimento;    
        }

        /// <summary>
        /// ObterDataHoraAlta - Se não achar DataHoraAlta, retorna atual
        /// </summary>
        /// <param name="dto"></param>
        public void ObterDataHoraAlta(MovimentacaoDTO dto, out DateTime data, out string hora)
        {
            DataTable dtDataHora = entity.SelDataHoraAlta(dto);
            if (dtDataHora.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtDataHora.Rows[0]["DATA_ALTA"].ToString()) &&
                    !string.IsNullOrEmpty(dtDataHora.Rows[0]["HORA_ALTA"].ToString()))
                {
                    data = DateTime.Parse(dtDataHora.Rows[0]["DATA_ALTA"].ToString());
                    hora = dtDataHora.Rows[0]["HORA_ALTA"].ToString();
                    return;
                }
            }
            
            data = DateTime.Now.Date;
            hora = DateTime.Now.ToString("HHmm");
        }

        public int ObterQtdeRegistrosContaFaturadaComNF(decimal idtAtendimento)
        {
            return entity.ObterQtdeRegistrosContaFaturadaComNF(idtAtendimento);
        }

        public DataTable ObterPaciente(decimal idAtendimento)
        {
            return entity.ObterPaciente(idAtendimento);
        }

        public string ObterPacienteEndereco(decimal idAtendimento)
        {
            DataTable dtb = entity.ObterPacienteEndereco(idAtendimento);
            if (dtb.Rows.Count > 0)
                return dtb.Rows[0][0].ToString();
            else
                return null;
        }

        public DataTable ListarInternacoesAnterioresPaciente(decimal idAtendimento)
        {
            return entity.ListarInternacoesAnterioresPaciente(idAtendimento);
        }

        public bool ControlaConsumoPacienteSetor(decimal idAtendimento, MatMedSetorConfigDTO dtoSetorConfig)
        {            
            DataTable dtPac = ObterPaciente(idAtendimento);
            DateTime dtAtendimento = DateTime.Parse(DateTime.Parse(dtPac.Rows[0]["DT_INT"].ToString()).ToString("dd/MM/yyyy") + " " + 
                                                    dtPac.Rows[0]["HR_TRANSF"].ToString().PadLeft(4, '0').Insert(2, ":"));            
            DateTime? dtInicioControle;

            if (new MatMedSetorConfig().ControlaConsumoPacienteSetor(dtoSetorConfig, out dtInicioControle))
            {
                if (dtAtendimento >= dtInicioControle)
                    return true;
            }
            
            return false;
        }

        public bool AnteriorControleConsumo(int idAtendimento)
        {
            return entity.AnteriorControleConsumo(idAtendimento);
        }
    }
}