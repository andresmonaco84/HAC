  create or replace procedure PRC_CAD_EMP_EMPRESA_S 
  (
     pCAD_EMP_ID_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_ID_EMPRESA%type DEFAULT NULL,
     pCAD_PES_NR_CNPJ_CPF IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type DEFAULT NULL,          
     pCAD_PES_NM_RAZAOSOCIAL IN TB_CAD_PES_PESSOA.CAD_PES_NM_RAZAOSOCIAL%type DEFAULT NULL,
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,
     pCAD_EMP_FL_STATUS IN TB_CAD_EMP_EMPRESA.CAD_EMP_FL_STATUS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_EMP_EMPRESA_S 
  * 
  *    Data Criacao: 	 21/06/2007   Por: Cristiane Gomes da Silva       
  *    Data Alteracao: 27/07/2007   Por: Carlos Araujo
  *    Alteração: Inclusão de campo Status
  *
  *    Funcao: Obtém Empresa(s) por filtros específicos
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteração: 20/11/2007  Por: Guilherme Holdack
  *    Alteração: Retorno de dados de Pessoa.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       EMP.CAD_EMP_ID_EMPRESA,
       EMP.CAD_EMP_CD_EMPRESA,
       EMP.CAD_PES_ID_PESSOA,
       EMP.CAD_GPE_ID_GRUPO_EMPRESA,
       EMP.CAD_EMP_FL_COPART_OK,
       EMP.CAD_EMP_FL_STATUS,
       pes.*
    FROM TB_CAD_EMP_EMPRESA EMP,
         TB_CAD_PES_PESSOA PES
    WHERE    
        EMP.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
    AND (pCAD_EMP_ID_EMPRESA is null OR EMP.CAD_EMP_ID_EMPRESA = pCAD_EMP_ID_EMPRESA)
    AND (pCAD_PES_NM_PESSOA is null OR PES.CAD_PES_NM_PESSOA LIKE UPPER(pCAD_PES_NM_PESSOA))
    AND (pCAD_PES_NM_RAZAOSOCIAL is null OR PES.CAD_PES_NM_RAZAOSOCIAL LIKE UPPER(pCAD_PES_NM_RAZAOSOCIAL))
    AND (pCAD_PES_NR_CNPJ_CPF is null OR PES.CAD_PES_NR_CNPJ_CPF = pCAD_PES_NR_CNPJ_CPF)    
    AND (pCAD_EMP_FL_STATUS is null OR EMP.CAD_EMP_FL_STATUS = pCAD_EMP_FL_STATUS)
    ORDER BY PES.CAD_PES_NM_PESSOA;         
    io_cursor := v_cursor;
  end PRC_CAD_EMP_EMPRESA_S;
/
