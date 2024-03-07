create or replace procedure PRC_CAD_END_ENDERECO_S
  (
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type DEFAULT NULL,
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type DEFAULT NULL,
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_END_ENDERECO_S
  * 
  *    Data Alteracao:  18/2/2009   Por: pedro
  *    Alteracao:  incluido 
  *
  *    Data Alteracao:  04/01/2011   Por: Rafael Coimbra
  *    Alteracao:  Incluido atributo CAD_END_NM_ENDERECO_NF
  *
  *    Funcao: Obtem Endereco(s)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(2000);
  begin
    V_WHERE := NULL;
    IF pCAD_PES_ID_PESSOA IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND END.CAD_PES_ID_PESSOA = '|| pCAD_PES_ID_PESSOA;
    END IF;
    IF pCAD_END_ID_ENDERECO IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND END.CAD_END_ID_ENDERECO = ' || pCAD_END_ID_ENDERECO;
    END IF;
    IF pAUX_TTE_CD_TP_TEL_END IS NOT NULL THEN
       V_WHERE := V_WHERE || ' AND END.AUX_TTE_CD_TP_TEL_END = ' || pAUX_TTE_CD_TP_TEL_END;
    END IF;
    V_SELECT := 'SELECT
       END.CAD_END_ID_ENDERECO,
       END.CAD_END_NM_LOGRADOURO,
       END.CAD_END_NM_BAIRRO,
       END.CAD_END_SG_UF,
       END.CAD_END_CD_CEP,
       END.CAD_END_DS_NUMERO,
       END.TIS_TLG_CD_TPLOGRADOURO,
       END.CAD_END_DT_ULTIMA_ATUALIZACAO,
       END.AUX_MUN_CD_IBGE,
       END.CAD_END_DS_COMPLEMENTO,
       END.SEG_USU_ID_USUARIO,
       END.AUX_TTE_CD_TP_TEL_END,
       END.CAD_PES_ID_PESSOA,
       END.CAD_END_NM_ENDERECO_NF
    FROM TB_CAD_END_ENDERECO END
    WHERE 1 = 1 ' || V_WHERE;
    
    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_CAD_END_ENDERECO_S;
