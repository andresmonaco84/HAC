 
  --PRC_AUT_EXC_ESPECIALIDADE_S
  create or replace procedure PRC_AUT_EXC_ESPECIALIDADE_S 
  (
     pCD_PLANO_BENEFICIARIO IN TB_AUT_EXC_ESPECIALIDADE.CD_PLANO_BENEFICIARIO%type DEFAULT NULL,
     pCD_ESPECIALIDADE IN TB_AUT_EXC_ESPECIALIDADE.CD_ESPECIALIDADE%type DEFAULT NULL,
     pCODTIPEMP IN TB_AUT_EXC_ESPECIALIDADE.CODTIPEMP%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_ESPECIALIDADE_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CD_PLANO_BENEFICIARIO,
       CD_ESPECIALIDADE,
       CODTIPEMP
    FROM TB_AUT_EXC_ESPECIALIDADE
    WHERE
        (pCD_PLANO_BENEFICIARIO is null OR CD_PLANO_BENEFICIARIO = pCD_PLANO_BENEFICIARIO) AND 
        (pCD_ESPECIALIDADE is null OR CD_ESPECIALIDADE = pCD_ESPECIALIDADE) AND 
        (pCODTIPEMP is null OR CODTIPEMP = pCODTIPEMP);          
    io_cursor := v_cursor;
  end PRC_AUT_EXC_ESPECIALIDADE_S;
