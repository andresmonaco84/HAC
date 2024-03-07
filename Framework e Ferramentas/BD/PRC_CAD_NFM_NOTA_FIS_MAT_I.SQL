

--PRC_CAD_NFM_NOTA_FIS_MAT_I
create or replace procedure PRC_CAD_NFM_NOTA_FIS_MAT_I
(
     pNewIdt OUT integer,
     pCAD_NFM_ID IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_ID%type default NULL,
     pCAD_NFM_NR_NF IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_NR_NF%type default NULL,
     pCAD_NFM_DS_SERIE IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_DS_SERIE%type default NULL,
     pCAD_NFM_DT_EMISSAO IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_DT_EMISSAO%type default NULL,
     pCAD_NFM_NM_FORNECEDOR IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_NM_FORNECEDOR%type default NULL,
     pCAD_NFM_NR_CNPJ IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_NR_CNPJ%type default NULL,
     pCAD_NFM_VL_NF IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_VL_NF%type default NULL,
     pCAD_NFM_VL_CALCULADO IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_VL_CALCULADO%type default NULL,
     pCAD_PRD_ID IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_PRD_ID%type default NULL,
     pCAD_NFM_DS_OBSERVACAO IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_DS_OBSERVACAO%type default NULL,
     pCAD_NFM_DT_ULT_ATUALIZACAO IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_DT_ULT_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_NFM_NOTA_FIS_MAT.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_NFM_PC_IPI IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_PC_IPI%type default NULL,
     pATD_ATE_ID IN TB_CAD_NFM_NOTA_FIS_MAT.ATD_ATE_ID%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_NFM_NOTA_FIS_MAT_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_CAD_NFM_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_CAD_NFM_NOTA_FIS_MAT
(
       CAD_NFM_ID,
       CAD_NFM_NR_NF,
       CAD_NFM_DS_SERIE,
       CAD_NFM_DT_EMISSAO,
       CAD_NFM_NM_FORNECEDOR,
       CAD_NFM_NR_CNPJ,
       CAD_NFM_VL_NF,
       CAD_NFM_VL_CALCULADO,
       CAD_PRD_ID,
       CAD_NFM_DS_OBSERVACAO,
       CAD_NFM_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_NFM_PC_IPI,
       ATD_ATE_ID
)
VALUES
(
      lIdtRetorno,
	     pCAD_NFM_NR_NF,
	     pCAD_NFM_DS_SERIE,
	     pCAD_NFM_DT_EMISSAO,
	     pCAD_NFM_NM_FORNECEDOR,
	     pCAD_NFM_NR_CNPJ,
	     pCAD_NFM_VL_NF,
	     pCAD_NFM_VL_CALCULADO,
	     pCAD_PRD_ID,
	     pCAD_NFM_DS_OBSERVACAO,
	     pCAD_NFM_DT_ULT_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO,
	     pCAD_NFM_PC_IPI,
	     pATD_ATE_ID
);
    pNewIdt := lIdtRetorno;	
end PRC_CAD_NFM_NOTA_FIS_MAT_I;

