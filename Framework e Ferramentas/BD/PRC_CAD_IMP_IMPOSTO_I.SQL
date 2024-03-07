  --PRC_CAD_IMP_IMPOSTO_I
  create or replace procedure PRC_CAD_IMP_IMPOSTO_I
  (
	 pNewIdt OUT integer,
     pCAD_IMP_NM_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_NM_IMPOSTO%type,
     pCAD_IMP_DS_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_DS_IMPOSTO%type,
     pCAD_IMP_FL_ATIVO_OK IN TB_CAD_IMP_IMPOSTO.CAD_IMP_FL_ATIVO_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_IMP_IMPOSTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_IMP_IMPOSTO_I
  * 
  *    Data Criacao: 	24/05/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Inclusão de Impostos
  *
  *******************************************************************/  
 lIdtRetorno integer;
	  
  begin
    SELECT SEQ_CAD_IMP_01.NextVal INTO lIdtRetorno FROM DUAL;
    
    INSERT INTO TB_CAD_IMP_IMPOSTO
    (
       CAD_IMP_ID_IMPOSTO,
       CAD_IMP_NM_IMPOSTO,
       CAD_IMP_DS_IMPOSTO,
       CAD_IMP_FL_ATIVO_OK,
       SEG_USU_ID_USUARIO,
       CAD_IMP_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pCAD_IMP_NM_IMPOSTO),
	     UPPER(pCAD_IMP_DS_IMPOSTO),
	     pCAD_IMP_FL_ATIVO_OK,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE
    );
    pNewIdt := lIdtRetorno;	
	
  end PRC_CAD_IMP_IMPOSTO_I;
/
