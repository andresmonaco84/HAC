create or replace procedure PRC_ATD_IMS_MOV_PAC_S
(
  pATD_ATE_ID                         IN TB_ATD_IML_INT_MOV_LEITO.ATD_ATE_ID%TYPE,
  io_cursor                     OUT PKG_CURSOR.t_cursor
)
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IMS_MOV_PAC_S
  *
  *    Data Criacao:   02/06/2011          Por: Fabiola Lopes
  *    Data Alteracao:                     Por:
  *
  *    Funcao: Listar a movimentacao do paciente atual
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
BEGIN
  OPEN V_CURSOR FOR
 SELECT IMS.ATD_ATE_ID,
        IMS.ATD_IMS_DT_ENTRADA,
        IMS.ATD_IMS_HR_ENTRADA,
        IMS.ATD_IMS_DT_SAIDA,
        IMS.ATD_IMS_HR_SAIDA,
        IMS.CAD_SET_ID_SETOR,
        IMS.ATD_IMS_DT_ULTIMA_ATUALIZACAO,
        IMS.SEG_USU_ID_USUARIO,
        IMS.ATD_IMS_DS_OBSERVACAO,
        IMS.ATD_IMS_ID,
        IMS.ATD_IMS_FL_STATUS,
	      IMS.TIS_TAC_CD_TIPO_ACOMOD_AUT,
        IMS.ATD_IMS_DT_INI_ACOMOD_AUT,
        IMS.ATD_IMS_HR_INI_ACOMOD_AUT

   FROM TB_ATD_IMS_INT_MOV_SETOR IMS,
        TB_ASS_PAT_PACIEATEND PAT

  WHERE IMS.ATD_ATE_ID = PAT.ATD_ATE_ID
    AND PAT.ASS_PAT_DT_SAIDA IS NULL
    AND PAT.ASS_PAT_HR_SAIDA IS NULL
    AND IMS.ATD_IMS_DT_ENTRADA >= PAT.ASS_PAT_DT_ENTRADA
    AND (IMS.ATD_IMS_DT_SAIDA >= PAT.ASS_PAT_DT_ENTRADA OR IMS.ATD_IMS_DT_SAIDA IS NULL)
    AND IMS.ATD_IMS_HR_ENTRADA >= PAT.ASS_PAT_HR_ENTRADA
    AND (IMS.ATD_IMS_HR_SAIDA >= PAT.ASS_PAT_HR_ENTRADA OR IMS.ATD_IMS_HR_SAIDA IS NULL)
    AND IMS.ATD_ATE_ID = pATD_ATE_ID;

  IO_CURSOR := V_CURSOR;
END PRC_ATD_IMS_MOV_PAC_S;