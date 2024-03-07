create or replace function FNC_ATS_EXAMES_LAUDO
(
     pATS_APR_NR_SEQ_LOTE IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_APR_NR_SEQ_LOTE%TYPE,
     pATS_ATE_CD_INTLIB IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ATE_CD_INTLIB%TYPE,
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%TYPE,
     pATS_ARP_DT_RESULTADO IN TB_ATS_ARP_ATEN_RESULT_PROCED.ATS_ARP_DT_RESULTADO%TYPE
) 
  /********************************************************************
  *    Procedure: FNC_ATS_EXAMES_LAUDO
  * 
  *    Data Criacao:   02/03/2009   Por: Davi Silvestre M. dos Reis
  *    Data Alteracao:  data        Por: Nome do Analista
  *
  *    Funcao: Funcao que retorna os procedimentos de determinado 
  *            atendimento e endereco
  *
  *    Data Alteracao:  19/03/2009  Por: Davi Silvestre M. dos reis
  *    Alteracao: Retorna, também, o ATS_ATE_ID concatenado
  *
  *******************************************************************/  
return varchar2 is Result varchar2(256);
BEGIN
  FOR Exame IN
  (
    SELECT PRD.CAD_PRD_NM_MNEMONICO, ARP.ATS_ATE_ID
      FROM TB_ATS_ARP_ATEN_RESULT_PROCED ARP  
     INNER JOIN TB_ATS_ATE_ATENDIMENTO_SADT ATS
        ON ATS.ATS_ATE_CD_INTLIB = ARP.ATS_ATE_CD_INTLIB
       AND ATS.ATS_ATE_IN_INTLIB = ARP.ATS_ATE_IN_INTLIB
       AND ATS.ATS_ATE_ID = ARP.ATS_ATE_ID
       AND ATS.CAD_PRD_ID = ARP.CAD_PRD_ID
       AND ATS.AUX_EPP_CD_ESPECPROC = ARP.ATS_EPP_CD_ESPECPROC
     INNER JOIN TB_CAD_UNI_UNIDADE UNI
        ON UNI.CAD_UNI_ID_UNIDADE = ARP.CAD_UNI_ID_UNIDADE
     INNER JOIN TB_CAD_PES_PESSOA PES
        ON PES.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
--     INNER JOIN TB_ASS_PEE_PESSOA_ENDERECO PEE
--        ON PEE.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
     INNER JOIN TB_CAD_END_ENDERECO ENDE
        ON ENDE.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
     INNER JOIN TB_CAD_PRD_PRODUTO PRD
        ON PRD.CAD_PRD_ID = ARP.CAD_PRD_ID
     WHERE ARP.ATS_APR_NR_SEQ_LOTE = pATS_APR_NR_SEQ_LOTE
       AND ENDE.CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO
       AND ARP.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
       AND ARP.ATS_ARP_DT_RESULTADO = pATS_ARP_DT_RESULTADO
       AND ATS.ATS_ATE_FL_STATUS != 'C'
  )
  LOOP           
     Result := CONCAT(Result, CONCAT(Exame.CAD_PRD_NM_MNEMONICO, '-'));     
     Result := CONCAT(Result, CONCAT(Exame.ATS_ATE_ID, ';'));     
  END LOOP;
  
      Result := SUBSTR(Result, 1, LENGTH(Result) - 1);
  return(Result);
  
end FNC_ATS_EXAMES_LAUDO;
