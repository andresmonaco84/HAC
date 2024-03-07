using HospitalAnaCosta.Framework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework.Data;
using System.IO;
using System.Configuration;
using System.Data;

namespace SGS.AgenteService
{
    public static class PendenciasBradesco
    {
        public static void Executa()
        {

            var dtb = new GenericModel().GetData(@"SELECT DISTINCT PRD.CAD_PRD_CD_CODIGO, PRD.CAD_PRD_DS_DESCRICAO, 
                                            PRD.CAD_PRD_CD_TABELA_MATMED, PRD.CAD_PRD_CD_TUSS                                            
                             FROM TB_FAT_CCI_CONTA_CONSU_ITEM I
                            JOIN TB_ASS_PAT_PACIEATEND PAT 
                                 ON I.ATD_ATE_ID = PAT.ATD_ATE_ID 
                                 AND I.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
                            JOIN TB_CAD_PAC_PACIENTE PAC ON PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
                            JOIN TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA     
                            JOIN TB_CAD_CNV_CONVENIO CNV ON PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
                            JOIN TB_CAD_PRD_PRODUTO PRD ON PRD.CAD_PRD_ID = I.CAD_PRD_ID
                            WHERE I.CAD_MPF_ID = 996
                            AND I.FAT_CCI_FL_STATUS = 'A'
                            AND PRD.CAD_PRD_CODIGO_ORIZON IS NULL
                            AND I.CAD_TAP_TP_ATRIBUTO IN ('MAT', 'MED')
                            AND I.FAT_CCI_TP_DESTINO_ITEM = 'C'
                            AND I.CAD_CNV_ID_CONVENIO IN (3422, 876, 740, 796)");


            var html = "";
            html += "<table><tr>";
            html += "<td><strong>Código</strong></td>";
            html += "<td><strong>Descrição</strong></td>";
            html += "<td><strong>TUSS</strong></td>";
            html += "<td><strong>Tabela</strong></td></tr>";
            foreach (DataRow row in dtb.Rows)
            {
                html += "<tr>";
                html += string.Format("<td>{0}</td>", row["CAD_PRD_CD_CODIGO"]);
                html += string.Format("<td>{0}</td>", row["CAD_PRD_DS_DESCRICAO"]);
                html += string.Format("<td>{0}</td>", row["CAD_PRD_CD_TUSS"]);
                html += string.Format("<td>{0}</td>", row["CAD_PRD_CD_TABELA_MATMED"]);
                html += "</tr>";
            }
            html += "</table>";

            GravarMensagemOracle("cintia.faccini@anacosta.com.br,kelly.jesus@anacosta.com.br,interfacesmonitoramento@anacosta.com.br", html, "Material não cadastrado");


        }

        private static void GravarMensagemOracle(string destino, string mensagem, string assunto)
        {
            try
            {                
                string query = @"insert into tb_sgs_eml_envia_email 
                            (SGS_EML_ID, SGS_EML_STATUS, SGS_EML_TEXTO, SGS_EML_DESTINO, SGS_EML_DT_ULTIMA_ATUALIZACAO, SGS_EML_ASSUNTO)
                            values
                            (sgs.seq_sgs_eml_01.nextval, 'N', :mensagem, :destino, sysdate, :assunto)";

                var param = new GenericModel().CreateParameterCollecion();
                param.Add(new GenericModel().CreateParameter("mensagem", mensagem));
                param.Add(new GenericModel().CreateParameter("destino", destino));
                param.Add(new GenericModel().CreateParameter("assunto", assunto));
                new GenericModel().ExecuteCommand(query, param);
            }
            catch (Exception ex)
            {


                throw ex;
            }


        }
    }

}
