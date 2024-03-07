create or replace procedure PRC_CAD_TEL_TELEFONE_S(pCAD_TEL_ID_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%type DEFAULT NULL,
                                                   pCAD_PES_ID_PESSOA   IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type DEFAULT NULL,
                                                   io_cursor            OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_TELEFONE_S
  *  
  *    Data Alteracao:  18/2/2010  Por: PEDRO       
  *
  *    Funcao: Lista telefone
  *
  *    Alteracao: 1) Desconsiderar parametros nulos para nao usar OR
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(2000);
begin
  V_WHERE := NULL;
  IF pCAD_PES_ID_PESSOA IS NOT NULL THEN
           V_WHERE := V_WHERE || ' AND TEL.CAD_PES_ID_PESSOA = ' || pCAD_PES_ID_PESSOA; 
  END IF;
  IF pCAD_TEL_ID_TELEFONE IS NOT NULL THEN
           V_WHERE := V_WHERE || ' AND TEL.CAD_TEL_ID_TELEFONE = ' || pCAD_TEL_ID_TELEFONE;    
  END IF;
  V_SELECT := 'SELECT TEL.CAD_TEL_ID_TELEFONE,
           TEL.CAD_TEL_NR_NUM_TEL,
           TEL.CAD_TEL_NR_RAMAL_TEL,
           TEL.CAD_TEL_NM_CONTATO,
           TEL.CAD_TEL_DT_ULTIMA_ATUALIZACAO,
           TEL.SEG_USU_ID_USUARIO,
           TEL.AUX_TTE_CD_TP_TEL_END,
           TEL.CAD_PES_ID_PESSOA
      FROM TB_CAD_TEL_TELEFONE TEL
     WHERE 1 = 1' 
     || V_WHERE; 
  OPEN v_cursor FOR
    V_SELECT;
  io_cursor := v_cursor;
end PRC_CAD_TEL_TELEFONE_S;

