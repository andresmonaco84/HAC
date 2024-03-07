--PRC_ATD_IFV_INT_FALTA_VAGA_I
create or replace procedure PRC_ATD_IFV_INT_FALTA_VAGA_I
(
     pNewIdt OUT integer,
     pATD_IFV_ID IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_ID%type default NULL,
     pATD_ATE_ID IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_ATE_ID%type default NULL,
     pATD_IML_ID IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IML_ID%type default NULL,
     pATD_IFV_DS_JUSTIFICATIVA IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DS_JUSTIFICATIVA%type default NULL,
     pSEG_USU_ID_USUARIO_DESB IN TB_ATD_IFV_INT_FALTA_VAGA.SEG_USU_ID_USUARIO_DESB%type default NULL,
     pATD_IFV_DT_FALTA_VAGA IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DT_FALTA_VAGA%type default NULL,
     pSEG_USU_ID_USUARIO_REG IN TB_ATD_IFV_INT_FALTA_VAGA.SEG_USU_ID_USUARIO_REG%type default NULL,
     pATD_IFV_DT_ULTIMA_ATUALIZACAO IN TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DT_ULTIMA_ATUALIZACAO%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_ATD_IFV_INT_FALTA_VAGA_I
* 
*    Data Criacao: 	  24/01/2011           Por: Fabiola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Inclui registro da TB_ATD_IFV_INT_FALTA_VAGA
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_ATD_IFV_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_ATD_IFV_INT_FALTA_VAGA
(
       ATD_IFV_ID,
       ATD_ATE_ID,
       ATD_IML_ID,
       ATD_IFV_DS_JUSTIFICATIVA,
       SEG_USU_ID_USUARIO_DESB,
       ATD_IFV_DT_FALTA_VAGA,
       SEG_USU_ID_USUARIO_REG,
       ATD_IFV_DT_ULTIMA_ATUALIZACAO
)
VALUES
(
       lIdtRetorno,
	     pATD_ATE_ID,
	     pATD_IML_ID,
	     pATD_IFV_DS_JUSTIFICATIVA,
	     pSEG_USU_ID_USUARIO_DESB,
	     pATD_IFV_DT_FALTA_VAGA,
	     pSEG_USU_ID_USUARIO_REG,
	     pATD_IFV_DT_ULTIMA_ATUALIZACAO
);
    pNewIdt := lIdtRetorno;	
end PRC_ATD_IFV_INT_FALTA_VAGA_I;
