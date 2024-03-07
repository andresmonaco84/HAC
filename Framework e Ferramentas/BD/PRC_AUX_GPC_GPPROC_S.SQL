 create or replace procedure PRC_AUX_GPC_GPPROC_S 
  (
     pAUX_GPC_CD_GRUPOPROC IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_CD_GRUPOPROC%type DEFAULT NULL,
     pAUX_GPC_DS_DESCRICAO IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_DS_DESCRICAO%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_GPC_GRUPOPROC.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_GPC_GPPROC_S
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       AUX_GPC_CD_GRUPOPROC,
       AUX_GPC_DS_DESCRICAO,
       AUX_EPP_CD_ESPECPROC
    FROM TB_AUX_GPC_GRUPOPROC
    WHERE
        (pAUX_GPC_CD_GRUPOPROC is null OR AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC) AND 
        (pAUX_GPC_DS_DESCRICAO is null OR AUX_GPC_DS_DESCRICAO = pAUX_GPC_DS_DESCRICAO) AND 
        (pAUX_EPP_CD_ESPECPROC is null OR AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC);          
    io_cursor := v_cursor;
  end PRC_AUX_GPC_GPPROC_S;

