  --PRC_AGE_ECC_ESCALA_CTRL_CIRC_U
  create or replace procedure PRC_AGE_ECC_ESCALA_CTRL_CIRC_U
  (
     pAGE_ECC_ID IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_ID%type,
     pAGE_ECC_NR_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_NR_CIRCULAR%type,
     pAGE_ECC_DT_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_CIRCULAR%type,
     pAGE_ECC_DS_OBS_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DS_OBS_CIRCULAR%type default NULL,
     pAGE_ECC_TP_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_TP_CIRCULAR%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.SEG_USU_ID_USUARIO%type,
     pAGE_ECC_DT_ULTIMA_ATUALIZACAO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_ULTIMA_ATUALIZACAO%type,
     pAGE_ECC_CD_fISICO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_CD_fISICO%TYPE,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_ECC_ESCALA_CTRL_CIRC.CAD_UNI_ID_UNIDADE%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ECC_ESCALA_CTRL_CIRC_U
  * 
  *    Data Criacao: 	02/07/2007           Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Atualização de registros na tabela TB_AGE_ECC_ESCALA_CTRL_CIRC
  *
  *    Data Alteração: 19/10/2007          Por: Guilherme
  *    Alteração:  Inclusão de parâmetro e novo campo de código físico de circular
  *    Data Alteracao: 07/11/2007        	  Por: Guilherme Holdack
  *    Inclusão de Upper para campos.
  *******************************************************************/  
  begin
    UPDATE TB_AGE_ECC_ESCALA_CTRL_CIRC
    SET	   
        AGE_ECC_NR_CIRCULAR = pAGE_ECC_NR_CIRCULAR,
        AGE_ECC_DT_CIRCULAR = pAGE_ECC_DT_CIRCULAR,
        AGE_ECC_DS_OBS_CIRCULAR = upper(pAGE_ECC_DS_OBS_CIRCULAR),
        AGE_ECC_TP_CIRCULAR = pAGE_ECC_TP_CIRCULAR,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        AGE_ECC_DT_ULTIMA_ATUALIZACAO = pAGE_ECC_DT_ULTIMA_ATUALIZACAO,
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        AGE_ECC_CD_fISICO = pAGE_ECC_CD_fISICO
    WHERE
        AGE_ECC_ID = pAGE_ECC_ID;	
  end PRC_AGE_ECC_ESCALA_CTRL_CIRC_U;
/
