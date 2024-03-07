create or replace procedure PRC_ATD_IEP_INT_EVOL_PAC_SID
  (
     pATD_IEP_ID IN TB_ATD_IEP_INT_EVOL_PACIENTE.ATD_IEP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IEP_INT_EVOL_PAC_SID
  *
  *    Data Criacao:  02/09/2009         Por: Fabiola Lopes
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ATD_IEP_ID,
       ATD_ATE_ID,
       ATD_IEP_DT_EVOLUCAO,
       ATD_IEP_HR_EVOLUCAO,
       CAD_CID_CD_CID10,
       ATD_IEP_DS_EVOLUCAO,
       ATD_IEP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRO_ID_PROFISSIONAL,
       TIS_CBO_CD_CBOS

    FROM TB_ATD_IEP_INT_EVOL_PACIENTE
    WHERE
        ATD_IEP_ID = pATD_IEP_ID;
    io_cursor := v_cursor;
  end PRC_ATD_IEP_INT_EVOL_PAC_SID;
 