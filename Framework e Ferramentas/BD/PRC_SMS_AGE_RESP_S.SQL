CREATE OR REPLACE PROCEDURE PRC_SMS_AGE_RESP_S
(
  io_cursor OUT PKG_CURSOR.t_cursor
)
IS
  /********************************************************************
  *    Procedure: PRC_SMS_AGE_RESP_S
  *
  *    Data Criacao:   dd/mm/yyyy        Por: Bruno Alvares
  *
  *    Funcao: recuperar os telefones que cancelaram exames
  *
  *    Data Alteracao: 17/12/2008   Por: Davi Silvestre M. dos Reis
  *    Alteração: Acerto na consulta para retornar as informações de quem  
  *               solicitou cancelamento de consulta
  * 
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
       
  BEGIN
 OPEN v_cursor FOR 
  SELECT DISTINCT
    PES.CAD_PES_NM_PESSOA,
    SMSR.SMS_MRE_DT_RECEBIMENTO,
    SMSR.SMS_MRE_HR_RECEBIMENTO,
    SMSR.SMS_MRE_DS_RESPOSTA_OPERACAO,
    SMSR.SMS_MRE_TELEFONE_RECEBIMENTO
--    AGD.AGE_AGD_DT_ATENDIMENTO,
--    AGD.AGE_AGD_HR_ATENDIMENTO,
--    CBO.TIS_CBO_DS_CBOS,
--    AGD.AGE_AGD_ID,
--    PAC.CAD_PAC_ID_PACIENTE,
--    PES.CAD_PES_ID_PESSOA,
--    SMSE.SMS_MEN_ID,
--    ESM.AGE_ESM_ID,
--    AGD.AGE_AGG_ID
   FROM TB_SMS_MEN_MENSAGEM_ENVIADA SMSE
   INNER JOIN TB_SMS_MRE_MENSAGEM_RECEBIDA SMSR
--    ON SMSR.SMS_MEN_ID = SMSE.SMS_MEN_ID
      ON SMSR.SMS_MRE_TELEFONE_RECEBIMENTO = SMSE.SMS_MEN_TELEFONE_ENVIO
   INNER JOIN TB_AGE_AGD_AGENDA AGD
     ON AGD.AGE_AGD_ID = SMSE.SMS_MEN_ID_TB_MODULO_ENVIO
    AND AGD.AGE_AGD_FL_STATUS != 'C'
    AND SMSE.SMS_MEN_ID_MODULO_ENVIO = 3
   INNER JOIN TB_CAD_PAC_PACIENTE PAC
     ON PAC.CAD_PAC_ID_PACIENTE = AGD.CAD_PAC_ID_PACIENTE
   INNER JOIN TB_CAD_PES_PESSOA PES
     ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA;
--   INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
--     ON ESM.AGE_ESM_ID = AGD.AGE_ESM_ID
--   INNER JOIN TB_TIS_CBO_CBOS CBO
--     ON CBO.TIS_CBO_CD_CBOS = ESM.TIS_CBO_CD_CBOS;
     

io_cursor := v_cursor;

END PRC_SMS_AGE_RESP_S;
/
