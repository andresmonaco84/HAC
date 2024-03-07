  --PRC_CAD_ECC_ESCALA_CTRL_CIRC_I
  create or replace procedure PRC_AGE_ECC_ESCALA_CTRL_CIRC_I
  (
     pNewIdt OUT integer,
     pNumeroCircularRetorno OUT INTEGER,
     pAGE_ECC_ID IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_ID%type default NULL,
     --pAGE_ECC_NR_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_NR_CIRCULAR%type,
     pAGE_ECC_DT_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_CIRCULAR%type,
     pAGE_ECC_DS_OBS_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DS_OBS_CIRCULAR%type default NULL,
     pAGE_ECC_TP_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_TP_CIRCULAR%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.SEG_USU_ID_USUARIO%type,
     pAGE_ECC_CD_fISICO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_CD_fISICO%TYPE,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_ECC_ESCALA_CTRL_CIRC.CAD_UNI_ID_UNIDADE%type
     
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ECC_ESCALA_CTRL_CIRC_I
  * 
  *    Data Criacao: 	02/07/2007           Por: Guilherme Holdack
  *    Data Alteracao: 11/10/2007          Por: Guilherme Holdack
  *    Alteração: Inclusão de um parâmetro que retorna o número da Circular.
  *
  *    Funcao: Inserção de registros na tabela TB_AGE_ECC_ESCALA_CTRL_CIRC
  *
  *    Data Alteração: 19/10/2007          Por: Guilherme
  *    Alteração:  Inclusão de parâmetro e novo campo de código físico de circular
  *    Data Alteracao: 07/11/2007        	  Por: Guilherme Holdack
  *    Inclusão de Upper para campos.
  *******************************************************************/  
    lIdtRetorno integer;
    pNumeroCircular INTEGER;
   
  begin

    SELECT SEQ_AGE_ECC_01.NextVal INTO lIdtRetorno FROM DUAL;
    SELECT SEQ_AGE_ECC_NR_CIRCULAR_01.NEXTVAL INTO pNumeroCircular FROM dual;
    INSERT INTO TB_AGE_ECC_ESCALA_CTRL_CIRC
    (
       AGE_ECC_ID,
       AGE_ECC_NR_CIRCULAR,
       AGE_ECC_DT_CIRCULAR,
       AGE_ECC_DS_OBS_CIRCULAR,
       AGE_ECC_TP_CIRCULAR,
       SEG_USU_ID_USUARIO,
       AGE_ECC_DT_ULTIMA_ATUALIZACAO,
       CAD_UNI_ID_UNIDADE,
       AGE_ECC_CD_fISICO
    )
    VALUES
    (
	     lIdtRetorno,
	   
       LPAD(pNumeroCircular,6,'0'),
	     pAGE_ECC_DT_CIRCULAR,
	     upper(pAGE_ECC_DS_OBS_CIRCULAR),
	     pAGE_ECC_TP_CIRCULAR,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE,
	     pCAD_UNI_ID_UNIDADE,
       pAGE_ECC_CD_fISICO
    );
    pNewIdt := lIdtRetorno;	
    pNumeroCircularRetorno:= pNumeroCircular;
  end PRC_AGE_ECC_ESCALA_CTRL_CIRC_I;
/
