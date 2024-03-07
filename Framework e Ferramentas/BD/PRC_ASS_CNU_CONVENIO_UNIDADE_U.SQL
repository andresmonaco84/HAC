create or replace procedure PRC_ASS_CNU_CONVENIO_UNIDADE_U
  (
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type,
     pASS_CNU_DT_INI_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_INI_VIGENCIA%type,
     pASS_CNU_DT_FIM_VIGENCIA IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DT_FIM_VIGENCIA%type default NULL,
     pASS_CNU_DS_MOTIVO_FIM_VIGEN IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_DS_MOTIVO_FIM_VIGENCIA%type default NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_CONVENIO_UNIDADE_U
  *
  *    Data Criacao: 	25/05/2007   Por: Andrea Cazuca
  *    Funcao: Altera a associacao Convenio X Unidade
  *
  *
  *    Data Alteracao:	13/06/2007  Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela tb_ass_cui_conv_uni_imposto
  *               e tb_ass_cul_conv_uni_locatend nos campos
  *               fim de vigencia e motivo fim vigencia, para fechar vigencia
  *
  *    Data Alteracao: 19/06/2007   Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela TB_ASS_CUT_CONV_UNI_TPACOMOD
  *               nos campos fim de vigencia e motivo fim vigencia, para fechar vigencia
  *
  *    Data Alteracao: 27/06/2007   Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela TB_ASS_CLP_CNV_UND_LOC_PLANO
  *               nos campos fim de vigencia e motivo fim vigencia, para fechar vigencia
  *
  *    Data Alteracao: 28/06/2007   Por: Andrea Cazuca
  *    Alteracao: Inclui update na tabela TB_ASS_CTP_CNV_UN_TPACOM_PLA
  *               nos campos fim de vigencia e motivo fim vigencia, para fechar vigencia
  *
  *    Data Alteracao: 28/11/2007   Por: Silmara Helena
  *	   Alteracao: Comentei a finalização das associações.	
  *
  *******************************************************************/
--  cursor ASS_CUL_ID is
--     SELECT ASS_CUL_ID
--     FROM   TB_ASS_CUL_CONV_UNI_LOCATEND
--     WHERE  ASS_CNU_ID = pASS_CNU_ID;

--  cursor ASS_CUT_ID is
--    SELECT ASS_CUT_ID
--    FROM   TB_ASS_CUT_CONV_UNI_TPACOMOD
--     WHERE  ASS_CNU_ID = pASS_CNU_ID;

  begin

    UPDATE TB_ASS_CNU_CONVENIO_UNIDADE
    SET
        ASS_CNU_DT_INI_VIGENCIA = pASS_CNU_DT_INI_VIGENCIA,
        ASS_CNU_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
        ASS_CNU_DS_MOTIVO_FIM_VIGENCIA = upper(pASS_CNU_DS_MOTIVO_FIM_VIGEN),
        ASS_CNU_DT_ULTIMA_ATUALIZACAO = sysdate,
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO,
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        ASS_CNU_ID = pASS_CNU_ID;

    -- Verifica se a data de fim de vigencia esta preenchida
   -- IF pASS_CNU_DT_FIM_VIGENCIA is not null then

       -- Fecha a vigencia da associacao convenio x unidade x imposto
   --    UPDATE TB_ASS_CUI_CONV_UNI_IMPOSTO
   --    SET
   --     ASS_CUI_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
   --     ASS_CUI_DS_MOTIVO_FIM_VIGENCIA = UPPER(pASS_CNU_DS_MOTIVO_FIM_VIGEN),
   --     ASS_CUI_DT_ULTIMA_ATUALIZACAO = SYSDATE,
   --     SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
   --    WHERE
   --    ASS_CNU_ID = pASS_CNU_ID;

       -- Fecha a vigencia da associacao convenio x unidade x local atendimento
 --      UPDATE TB_ASS_CUL_CONV_UNI_LOCATEND
 --     SET
 --         ASS_CUL_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
 --         ASS_CUL_DS_MOTIVO_FIM_VIGENCIA = UPPER(pASS_CNU_DS_MOTIVO_FIM_VIGEN),
 --         ASS_CUL_DT_ULTIMA_ATUALIZACAO = SYSDATE,
 --         SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
 --     WHERE
--        ASS_CNU_ID = pASS_CNU_ID;

       -- Fecha a vigencia da associacao convenio x unidade x tipo acomodac?o
 --      UPDATE TB_ASS_CUT_CONV_UNI_TPACOMOD
 --      SET
 --         ASS_CUT_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
 --        ASS_CUT_DS_MOTIVO_FIM_VIGENCIA = UPPER(pASS_CNU_DS_MOTIVO_FIM_VIGEN),
 --         ASS_CUT_DT_ULTIMA_ATUALIZACAO = SYSDATE,
 --        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
 --      WHERE
 --         ASS_CNU_ID = pASS_CNU_ID;

       -- Fecha a vigencia da associacao convenio x plano x unidade x local atendimento
 --      begin
 --           for x in ASS_CUL_ID loop

 --             UPDATE TB_ASS_CLP_CNV_UND_LOC_PLANO
 --            SET
 --                ASS_CLP_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
 --               ASS_CLP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
 --               SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
 --            WHERE
 --               ASS_CUL_ID = x.ASS_CUL_ID;
 --           end loop;
 --     end;

       -- Fecha a vigencia da associacao convenio x plano x unidade x tipo acomodacao
 --      begin
 --           for y in ASS_CUT_ID loop
 --             UPDATE TB_ASS_CTP_CNV_UN_TPACOM_PLA
 --             SET
 --                ASS_CTP_DT_FIM_VIGENCIA = pASS_CNU_DT_FIM_VIGENCIA,
 --                ASS_CTP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
 --                SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
 --             WHERE
 --                ASS_CUT_ID = y.ASS_CUT_ID;
 --           end loop;
 --      end;
 --   END IF;

  end PRC_ASS_CNU_CONVENIO_UNIDADE_U;