  create or replace procedure PRC_ASS_PLC_PLANO_CBOS_D 
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_PLANO_CBOS_D
  * 
  *    Data Criacao: 	16/08/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui associacao Plano X Especialidade 
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PLC_PLANO_CBOS
    WHERE  
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO;	   
  end PRC_ASS_PLC_PLANO_CBOS_D;
/
