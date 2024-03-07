

  --PRC_AUT_EXC_ESPECIALIDADE_I
  create or replace procedure PRC_AUT_EXC_ESPECIALIDADE_I
  (
     pCD_PLANO_BENEFICIARIO IN TB_AUT_EXC_ESPECIALIDADE.CD_PLANO_BENEFICIARIO%type,
     pCD_ESPECIALIDADE IN TB_AUT_EXC_ESPECIALIDADE.CD_ESPECIALIDADE%type,
     pCODTIPEMP IN TB_AUT_EXC_ESPECIALIDADE.CODTIPEMP%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_ESPECIALIDADE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_EXC_ESPECIALIDADE
    (
       CD_PLANO_BENEFICIARIO,
       CD_ESPECIALIDADE,
       CODTIPEMP
    )
    VALUES
    (
	     pCD_PLANO_BENEFICIARIO,
	     pCD_ESPECIALIDADE,
	     pCODTIPEMP
    );
	
  end PRC_AUT_EXC_ESPECIALIDADE_I;

