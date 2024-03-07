create or replace procedure PRC_CAD_CTX_S
  (
     pCAD_CTX_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_CTX_ID%type DEFAULT NULL,
     pCAD_PRD_ID_TX IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID_TX%type DEFAULT NULL,    
     pCAD_PRD_ID IN TB_CAD_CTX_COMPOSICAO_TAXA.CAD_PRD_ID%type DEFAULT NULL,    
     pTIS_MED_CD_TABELAMEDICA IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,    
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CTX_S
  *
  *    Data Criacao:   '24-nov-09'   Por: PEDRO
  *    Data Alteracao:  data da alteração  Por: PEDRO
  *
  *    Funcao: Pesquisa =D
  *
  *******************************************************************/
  
  -- Alteracao Marcus - inclusao do campo CTX.CAD_CTX_FL_STATUS '02-feb-10' 
  
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
     SELECT
       CTX.CAD_CTX_ID,
       CTX.CAD_PRD_ID_TX,
       PRD_TX.CAD_PRD_NM_MNEMONICO MNEMONICO_TAXA,
       PRD_TX.CAD_PRD_DS_DESCRICAO DESCRICAO_TAXA,       
       CTX.CAD_PRD_ID,
       PRD.CAD_PRD_DS_DESCRICAO DS_PROCEDIMENTO,
       PRD.CAD_PRD_NM_MNEMONICO CD_PROCEDIMENTO,
       TAB.TIS_MED_DS_TABELAMEDICA DS_TABELA,
       EPP.AUX_EPP_DS_DESCRICAO,
       CTX.CAD_CTX_FL_STATUS

    FROM       TB_CAD_CTX_COMPOSICAO_TAXA CTX
    LEFT JOIN  TB_CAD_PRD_PRODUTO         PRD
    ON         PRD.CAD_PRD_ID           = CTX.CAD_PRD_ID
    LEFT JOIN  TB_TIS_MED_TABELAMEDICA    TAB
    ON         TAB.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA
    LEFT JOIN  TB_AUX_EPP_ESPECPROC       EPP
    ON         EPP.AUX_EPP_CD_ESPECPROC = PRD.AUX_EPP_CD_ESPECPROC
    LEFT JOIN  TB_CAD_PRD_PRODUTO         PRD_TX
    ON         PRD_TX.CAD_PRD_ID        = CTX.CAD_PRD_ID_TX
   
   
    WHERE
        (pCAD_CTX_ID is null OR CTX.CAD_CTX_ID = pCAD_CTX_ID) AND
        (pCAD_PRD_ID_TX is null OR CTX.CAD_PRD_ID_TX = pCAD_PRD_ID_TX) AND        
        (pCAD_PRD_ID is null OR CTX.CAD_PRD_ID = pCAD_PRD_ID) AND        
        (pAUX_EPP_CD_ESPECPROC IS NULL OR EPP.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC) AND
        (pTIS_MED_CD_TABELAMEDICA IS NULL OR TAB.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
     
        ;
    io_cursor := v_cursor;
  end PRC_CAD_CTX_S;