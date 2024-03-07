  --PRC_CAD_GME_GRUPOMEDICO_U
  create or replace procedure PRC_CAD_GME_GRUPOMEDICO_U
  (
     pCAD_GME_ID_GRUPOMEDICO IN TB_CAD_GME_GRUPOMEDICO.CAD_GME_ID_GRUPOMEDICO%type,
     pCAD_GME_DT_INI_VIGENCIA IN TB_CAD_GME_GRUPOMEDICO.CAD_GME_DT_INI_VIGENCIA%type,
     pCAD_GEM_DT_FIM_VIGENCIA IN TB_CAD_GME_GRUPOMEDICO.CAD_GEM_DT_FIM_VIGENCIA%type default NULL,
     pCAD_PES_ID_PESSOA IN TB_CAD_GME_GRUPOMEDICO.CAD_PES_ID_PESSOA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GME_GRUPOMEDICO_U
  * 
  *    Data Criacao: 	19/06/2007             Por: Carlos Araujo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Altera o Grupo Médico
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_GME_GRUPOMEDICO
    SET	   
        CAD_GME_DT_INI_VIGENCIA = pCAD_GME_DT_INI_VIGENCIA,
        CAD_GEM_DT_FIM_VIGENCIA = pCAD_GEM_DT_FIM_VIGENCIA,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA 
    WHERE
        CAD_GME_ID_GRUPOMEDICO = pCAD_GME_ID_GRUPOMEDICO;	
  end PRC_CAD_GME_GRUPOMEDICO_U;
/
