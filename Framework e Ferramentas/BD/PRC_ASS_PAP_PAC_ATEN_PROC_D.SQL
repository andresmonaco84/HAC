  --PRC_ASS_PAP_PAC_ATEN_PROC_D
  create or replace procedure PRC_ASS_PAP_PAC_ATEN_PROC_D 
  (
     pASS_PAP_ID IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PAP_PAC_ATEN_PROC_D
  * 
  *    Data Criacao: 	22/02/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui o Procedimento do Paciente
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PAP_PAC_ATEN_PROC
    WHERE  
        ASS_PAP_ID = pASS_PAP_ID;	   
  end PRC_ASS_PAP_PAC_ATEN_PROC_D;
/
