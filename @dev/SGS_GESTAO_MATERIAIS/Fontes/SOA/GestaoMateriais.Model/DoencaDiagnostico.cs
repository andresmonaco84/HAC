using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class DoencaDiagnostico : Entity    
    {
        public DoencaDiagnosticoDTO Gravar(DoencaDiagnosticoDTO dto)
        {
            string query;
            if (dto.Id.Value.IsNull)
            {
                DataTable dtNewID = new DataTable();
                string queryID = "SELECT SEQ_CAD_MTMD_DODI.NEXTVAL FROM DUAL";

                //Executa o procedimento
                Connection.RecordSet(queryID, dtNewID, CommandType.Text);
                dto.Id.Value = dtNewID.Rows[0][0].ToString();

                query = string.Format("INSERT INTO TB_CAD_MTMD_DOENCA_DIAGNOSTICO(cad_mtmd_dodi_id, cad_mtmd_dodi_tipo, cad_mtmd_dodi_dsc, seg_usu_id_usuario) " +
                                      "VALUES ({0}, '{1}', '{2}', {3})", dto.Id.Value,
                                                                         dto.Tipo.Value,
                                                                         dto.Descricao.Value,
                                                                         dto.IdUsuario.Value);
            }
            else
            {
                query = "UPDATE TB_CAD_MTMD_DOENCA_DIAGNOSTICO SET " +
                            "   cad_mtmd_dodi_dsc = '" + dto.Descricao.Value + "'" +
                            " , seg_usu_id_usuario = " + dto.IdUsuario.Value +
                            " WHERE cad_mtmd_dodi_id = " + dto.Id.Value;
            }
            Connection.ExecuteCommand(query);
            return dto;
        }

        public void Excluir(DoencaDiagnosticoDTO dto)
        {
            string queryExec = "DELETE TB_CAD_MTMD_DOENCA_DIAGNOSTICO\n" +
                                "WHERE cad_mtmd_dodi_id = " + dto.Id.Value;
            Connection.ExecuteCommand(queryExec);
        }

        public DoencaDiagnosticoDataTable Listar(DoencaDiagnosticoDTO dto)
        {
            string queryExec = "SELECT DODI.CAD_MTMD_DODI_ID,\n" +
                                "       DODI.CAD_MTMD_DODI_TIPO,\n" +
                                "       DODI.CAD_MTMD_DODI_DSC,\n" +
                                "       DODI.SEG_USU_ID_USUARIO\n" +
                                "  FROM TB_CAD_MTMD_DOENCA_DIAGNOSTICO DODI\n" +
                                "WHERE DODI.CAD_MTMD_DODI_TIPO = '" + dto.Tipo.Value + "' \n" +
                                "ORDER BY DODI.CAD_MTMD_DODI_DSC";

            DoencaDiagnosticoDataTable result = new DoencaDiagnosticoDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }
    }
}