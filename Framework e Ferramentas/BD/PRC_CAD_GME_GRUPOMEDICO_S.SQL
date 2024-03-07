  --PRC_CAD_GME_GRUPOMEDICO_S
  create or replace procedure PRC_CAD_GME_GRUPOMEDICO_S 
  (
     pCAD_GME_ID_GRUPOMEDICO IN TB_CAD_GME_GRUPOMEDICO.CAD_GME_ID_GRUPOMEDICO%type DEFAULT NULL,
     pCAD_PES_NR_CNPJ_CPF IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type DEFAULT NULL,          
     pCAD_PES_NM_RAZAOSOCIAL IN TB_CAD_PES_PESSOA.CAD_PES_NM_RAZAOSOCIAL%type DEFAULT NULL,
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,          
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GME_GRUPOMEDICO_S
  * 
  *    Data Criacao: 	19/06/2007             Por: Carlos Araujo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Obtém ou Lista grupos médicos
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       GME.CAD_GME_ID_GRUPOMEDICO,
       GME.CAD_GME_DT_INI_VIGENCIA,
       GME.CAD_GEM_DT_FIM_VIGENCIA,
       GME.CAD_PES_ID_PESSOA
    FROM TB_CAD_GME_GRUPOMEDICO GME,
         TB_CAD_PES_PESSOA PES
    WHERE
        GME.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
    AND (pCAD_GME_ID_GRUPOMEDICO is null OR CAD_GME_ID_GRUPOMEDICO = pCAD_GME_ID_GRUPOMEDICO)
    AND (pCAD_PES_NM_PESSOA is null OR PES.CAD_PES_NM_PESSOA LIKE UPPER(pCAD_PES_NM_PESSOA))
    AND (pCAD_PES_NM_RAZAOSOCIAL is null OR PES.CAD_PES_NM_RAZAOSOCIAL LIKE UPPER(pCAD_PES_NM_RAZAOSOCIAL))
    AND (pCAD_PES_NR_CNPJ_CPF is null OR PES.CAD_PES_NR_CNPJ_CPF = pCAD_PES_NR_CNPJ_CPF)       
    ORDER BY PES.CAD_PES_NM_PESSOA;
    io_cursor := v_cursor;
  end PRC_CAD_GME_GRUPOMEDICO_S;
/
