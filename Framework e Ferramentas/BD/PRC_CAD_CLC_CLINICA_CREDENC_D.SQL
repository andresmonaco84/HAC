  --PRC_CAD_CLC_CLINICA_CREDENC_D
  create or replace procedure PRC_CAD_CLC_CLINICA_CREDENC_D 
  (
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CLC_CLINICA_CREDENC_D
  * 
  *    Data Criacao: 	24/01/2008         Por: Davi S. M. dos Reis
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Excluir clinica credenciada
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_CLC_CLINICA_CREDENCIADA
    WHERE  
        CAD_CLC_ID = pCAD_CLC_ID;	   
  end PRC_CAD_CLC_CLINICA_CREDENC_D;
/

