  --PRC_ASS_PPT_PESSOA_PRONTUARIO_U
  create or replace procedure PRC_ASS_PPT_PESSOA_PRONTUA_U
  (
     pASS_PPT_ID_PESSOA_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.ASS_PPT_ID_PESSOA_PRONTUARIO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PES_ID_PESSOA%type,
     pCAD_PAC_NR_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PAC_NR_PRONTUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPT_PESSOA_PRONTUA_U
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PPT_PESSOA_PRONTUARIO
    SET     
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA,
        CAD_PAC_NR_PRONTUARIO = pCAD_PAC_NR_PRONTUARIO 
    WHERE
        ASS_PPT_ID_PESSOA_PRONTUARIO = pASS_PPT_ID_PESSOA_PRONTUARIO;  
  end PRC_ASS_PPT_PESSOA_PRONTUA_U;
