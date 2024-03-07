  --PRC_ASS_CUL_CONV_UNI_LOCATEN_U
  create or replace procedure PRC_ASS_CUL_CONV_UNI_LOCATEN_U
  (
     pASS_CUL_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_ID%type,
     pASS_CUL_DT_INI_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_INI_VIGENCIA%type,
     pASS_CUL_DS_MOTIVO_FIM_VIGENCI IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pASS_CUL_DT_FIM_VIGENCIA IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_DT_FIM_VIGENCIA%type default NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CUL_CONV_UNI_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CUL_CONV_UNI_LOCATEND.SEG_USU_ID_USUARIO%type,
     pASS_CNU_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CNU_ID%type  
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUL_CONV_UNI_LOCATEN_U
  * 
  *    Data Criacao: 	05/06/2007  Por: Silmara
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *    Data Alteracao: 27/06/2007   Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela TB_ASS_CLP_CNV_UND_LOC_PLANO
  *               nos campos fim de vigencia para fechar vigência
  *******************************************************************/  
  begin
    UPDATE TB_ASS_CUL_CONV_UNI_LOCATEND
    SET	   
        ASS_CUL_DT_INI_VIGENCIA = pASS_CUL_DT_INI_VIGENCIA,
        ASS_CUL_DS_MOTIVO_FIM_VIGENCIA = UPPER(pASS_CUL_DS_MOTIVO_FIM_VIGENCI),
        ASS_CUL_DT_FIM_VIGENCIA = pASS_CUL_DT_FIM_VIGENCIA,
        ASS_CUL_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,       
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_CNU_ID = pASS_CNU_ID       
    WHERE
        ASS_CUL_ID = pASS_CUL_ID;
    
    -- Verifica se a data de fim de vigencia está preenchida
    IF pASS_CUL_DT_FIM_VIGENCIA is not null then
    
       -- Fecha a vigencia da associacao convenio x plano x unidade x local atendimento
       UPDATE TB_ASS_CLP_CNV_UND_LOC_PLANO
       SET    ASS_CLP_DT_FIM_VIGENCIA = pASS_CUL_DT_FIM_VIGENCIA,
              ASS_CLP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
              SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
       WHERE  ASS_CUL_ID = pASS_CUL_ID;
       
    END IF;
  end PRC_ASS_CUL_CONV_UNI_LOCATEN_U;
/
