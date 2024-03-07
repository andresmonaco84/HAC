create or replace procedure PRC_ASS_PPR_PLANOPRODUTO_D
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROC IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
     pCAD_PRD_ID IN TB_ASS_PPR_PLANOPRODUTO.CAD_PRD_ID %type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPR_PLANOPRODUTO_D
  *
  *    Data Criacao: 	04/01/2008   Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Data Alteracao:  08/04/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao da opção de excluir a associação plano x produto 
  *               pelos atributos especialidade/grupo/procedimento.
  *
  *    Funcao: Exclusao das associacoes de produtos com plano x convenio
  *
  *******************************************************************/
  begin

    DELETE FROM TB_ASS_PPR_PLANOPRODUTO
     WHERE EXISTS (
                   SELECT 1 
                     FROM TB_ASS_PPR_PLANOPRODUTO PPR
                    INNER JOIN TB_CAD_PRD_PRODUTO PRD
                            ON PPR.CAD_PRD_ID = PRD.CAD_PRD_ID
                         WHERE (pAUX_EPP_CD_ESPECPROC IS NULL OR PRD.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
                           AND (pAUX_GPC_CD_GRUPOPROC IS NULL OR PRD.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
                           AND (pCAD_PRD_ID IS NULL OR PPR.CAD_PRD_ID = pCAD_PRD_ID)
                   )
       AND CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
       AND CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
       AND CAD_PRD_ID = pCAD_PRD_ID;
        
  end PRC_ASS_PPR_PLANOPRODUTO_D; 
/
