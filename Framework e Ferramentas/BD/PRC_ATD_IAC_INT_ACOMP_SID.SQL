
  --PRC_ATD_IAC_INT_ACOMPANHANTE_SID
  create or replace procedure PRC_ATD_IAC_INT_ACOMP_SID 
  (
     pATD_ATE_ID IN TB_ATD_IAC_INT_ACOMPANHANTE.ATD_ATE_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IAC_INT_ACOMP_SID
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       ATD_ATE_ID,
       ATD_IAC_NM_NOME,
       ATD_IAC_NR_RG,
       ATD_IAC_DS_LOGRADOURO,
       ATD_IAC_DS_BAIRRO,
       ATD_IAC_DS_CIDADE,
       ATD_IAC_CD_CEP,
       ATD_IAC_NM_TESTEMUNHA1,
       ATD_IAC_DS_DOC_TESTEMUNHA1,
       ATD_IAC_NM_TESTEMUNHA2,
       ATD_IAC_DS_DOC_TESTEMUNHA2,
       ATD_IAC_NR_CPF,
       ATD_IAC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ATD_IAC_DS_TELEFONE
    FROM TB_ATD_IAC_INT_ACOMPANHANTE
    WHERE
        ATD_ATE_ID = pATD_ATE_ID;          
    io_cursor := v_cursor;
  end PRC_ATD_IAC_INT_ACOMP_SID;
