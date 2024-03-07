

  --PRC_AUT_EXC_ESPECIALIDADE_U
  create or replace procedure PRC_AUT_EXC_ESPECIALIDADE_U
  (
     pCD_PLANO_BENEFICIARIO IN TB_AUT_EXC_ESPECIALIDADE.CD_PLANO_BENEFICIARIO%type,
     pCD_ESPECIALIDADE IN TB_AUT_EXC_ESPECIALIDADE.CD_ESPECIALIDADE%type,
     pCODTIPEMP IN TB_AUT_EXC_ESPECIALIDADE.CODTIPEMP%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_ESPECIALIDADE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_EXC_ESPECIALIDADE
    SET	   
 
    WHERE
        CD_ESPECIALIDADE = pCD_ESPECIALIDADE
    AND CD_PLANO_BENEFICIARIO = pCD_PLANO_BENEFICIARIO
    AND CODTIPEMP = pCODTIPEMP;	
  end PRC_AUT_EXC_ESPECIALIDADE_U;

