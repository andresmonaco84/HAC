  --PRC_CAD_GME_GRUPOMEDICO_I
  create or replace procedure PRC_CAD_GME_GRUPOMEDICO_I
  (
     pNewIdt OUT integer,
     pCAD_GME_ID_GRUPOMEDICO IN TB_CAD_GME_GRUPOMEDICO.CAD_GME_ID_GRUPOMEDICO%type default NULL,
     pCAD_GME_DT_INI_VIGENCIA IN TB_CAD_GME_GRUPOMEDICO.CAD_GME_DT_INI_VIGENCIA%type,
     pCAD_GEM_DT_FIM_VIGENCIA IN TB_CAD_GME_GRUPOMEDICO.CAD_GEM_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PES_ID_PESSOA IN TB_CAD_GME_GRUPOMEDICO.CAD_PES_ID_PESSOA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GME_GRUPOMEDICO_I
  * 
  *    Data Criacao: 	19/06/2007             Por: Carlos Araujo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Realiza a inclusão de Grupo Médico
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_CAD_GME_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_GME_GRUPOMEDICO
    (
       CAD_GME_ID_GRUPOMEDICO,
       CAD_GME_DT_INI_VIGENCIA,
       CAD_GEM_DT_FIM_VIGENCIA,
       CAD_PES_ID_PESSOA
    )
    VALUES
    (
	     lIdtRetorno,
	     pCAD_GME_DT_INI_VIGENCIA,
	     pCAD_GEM_DT_FIM_VIGENCIA,
	     pCAD_PES_ID_PESSOA
    );
    pNewIdt := lIdtRetorno;	
  end PRC_CAD_GME_GRUPOMEDICO_I;
/
