  create or replace procedure PRC_AGE_ECC_ESCALA_CIRC_DISP_S 
  (
     pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type, 
     pCAD_UNI_ID_UNIDADE IN TB_AGE_ECC_ESCALA_CTRL_CIRC.CAD_UNI_ID_UNIDADE%type,
     pDATA_INICIO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_CIRCULAR%type default null,
     pDATA_FIM IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_CIRCULAR%type default null,  
     pAGE_ECC_NR_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_NR_CIRCULAR%type default null,
     pAGE_ECC_CD_fISICO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_CD_fISICO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ECC_ESCALA_CIRC_DISP_S
  * 
  *    Data Criacao: 	 17/07/2007            Por: Carlos Eduardo
  *    Data Alteracao:	                     Por:                 
  *
  *    Função: Lista as circulares de uma determinada Unidade pelo período e 
  *            que ainda não estão associadas à 1 determinada escala médica
  *
  *    Data Alteração: 19/10/2007          Por: Guilherme
  *    Alteração:  Inclusão de parâmetro e novo campo de código físico de circular
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
           ECC.AGE_ECC_ID,
           ECC.AGE_ECC_NR_CIRCULAR,
           ECC.AGE_ECC_DT_CIRCULAR,
           ECC.AGE_ECC_DS_OBS_CIRCULAR,
           ECC.AGE_ECC_TP_CIRCULAR,
           ECC.SEG_USU_ID_USUARIO,
           ECC.AGE_ECC_DT_ULTIMA_ATUALIZACAO,
           ECC.CAD_UNI_ID_UNIDADE,
           ecc.AGE_ECC_CD_fISICO
    FROM TB_AGE_ECC_ESCALA_CTRL_CIRC ECC
    WHERE 
        NOT EXISTS ( SELECT 1
                     FROM 
                          TB_ASS_CIE_CIRCULAR_ESCALA CIE
                     WHERE
                          CIE.AGE_ESM_ID         = pAGE_ESM_ID
                     AND  ECC.AGE_ECC_ID         = CIE.AGE_ECC_ID
                     )
    AND (ECC.CAD_UNI_ID_UNIDADE  = pCAD_UNI_ID_UNIDADE)                     
    AND (pDATA_INICIO is null or ECC.AGE_ECC_DT_CIRCULAR >= pDATA_INICIO)                 
    AND (pDATA_FIM is null or ECC.AGE_ECC_DT_CIRCULAR <= pDATA_FIM)
    and (pAGE_ECC_NR_CIRCULAR is null or ecc.age_ecc_nr_circular = pAGE_ECC_NR_CIRCULAR)
    AND (pAGE_ECC_CD_FISICO IS NULL OR ECC.AGE_ECC_CD_FISICO = pAGE_ECC_CD_fISICO)
    ORDER BY ECC.AGE_ECC_DT_CIRCULAR desc, ecc.age_ecc_nr_circular desc;    
    
    io_cursor := v_cursor;
  end PRC_AGE_ECC_ESCALA_CIRC_DISP_S;
/
