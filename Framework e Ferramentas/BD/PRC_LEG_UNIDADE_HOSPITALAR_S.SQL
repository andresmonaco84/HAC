  --PRC_LEG_UNIDADE_HOSPITALAR_S
  create or replace procedure PRC_LEG_UNIDADE_HOSPITALAR_S 
  (
     pCODHOS IN UNIDADE_HOSPITALAR.CODHOS%type DEFAULT NULL,
     pCODUNIHOS IN UNIDADE_HOSPITALAR.CODUNIHOS%type DEFAULT NULL,
     pIN_SIT_UNIDADE IN UNIDADE_HOSPITALAR.IN_SIT_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_LEG_UNIDADE_HOSPITALAR_S
  * 
  *    Data Criacao: 	22/08/2007       Por: Guilherme Holdack
  *    Data Alteracao:	                 Por:                  
  *
  *    Funcao: Listar Unidades Hospitalares a partir da base de legado
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODHOS,
       CODUNIHOS,
       DESUNIHOS,
       CODENDHOS,
       CGCUNIHOS,
       INSMUNUNIHOS,
       CODLOC,
       CODFILIAL,
       CD_GRAVA_ATEND,
       IN_AGENDA_LIB_25,
       IN_GRAVA_CODPAC,
       IN_SIT_UNIDADE,
       DT_INI_VIGENCIA,
       DT_FIM_VIGENCIA,
       CD_CNES
    FROM UNIDADE_HOSPITALAR
    WHERE
        (pCODHOS is null OR CODHOS = pCODHOS) AND 
        (pCODUNIHOS is null OR CODUNIHOS = pCODUNIHOS)
        AND (pIN_SIT_UNIDADE is null OR IN_SIT_UNIDADE = Upper(pIN_SIT_UNIDADE))
        ORDER BY CODUNIHOS;          
    io_cursor := v_cursor;
  end PRC_LEG_UNIDADE_HOSPITALAR_S;
/
