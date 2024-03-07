CREATE OR REPLACE PROCEDURE prc_fat_mcc_cci_aud_l
(
  pATD_ATE_ID IN TB_FAT_MCC_MOV_COM_CONSUMO.ATD_ATE_ID%TYPE,
  IO_CURSOR   OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: prc_fat_mcc_cci_aud_l
  *
  *    Data Criacao: 16/08/2010      Por: Marcus Relva
  * 
  *    Funcao: Tela Faturamento - Listar Comandas emitidas (combo comandas auditoria)
  *
  *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;

BEGIN

  OPEN V_CURSOR FOR

    select distinct mcc.fat_mcc_id
      from tb_fat_cci_conta_consu_item cci, tb_fat_mcc_mov_com_consumo mcc
     where mcc.fat_mcc_id = cci.fat_mcc_id       
       and cci.fat_ccp_id is not null
       and mcc.atd_ate_id = pATD_ATE_ID;

  IO_CURSOR := V_CURSOR;

END prc_fat_mcc_cci_aud_l;