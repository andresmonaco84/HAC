CREATE OR REPLACE PROCEDURE PRC_PARCELAMENTO_SGS ( vd_dt_dia     DATE)

IS
vn_periodo        NUMBER;
vn_parcela        NUMBER;                                   -- parcela do periodo atual
vn_DiasInternado  NUMBER;
vn_qtdParcelas    NUMBER;
vd_dt_alta        DATE;                                     -- ultimo dia do periodo
vd_dt_int         DATE;
vn_cont           NUMBER;

BEGIN
--
DELETE tb_tmp_cpr_conta_parc_rel;
COMMIT;
--
FOR parc IN (
    SELECT  DISTINCT cnv.cad_cnv_id_convenio,
    cnv.cad_cnv_cd_hac_prestador,
    atd.atd_ate_dt_atendimento DT_INT,
    atd.atd_ate_id,
    cnv.cad_cnv_qt_dia_conta_parcial PERIODO,
   atd.cad_uni_id_unidade ,
   PAT.CAD_PAC_ID_PACIENTE 
   FROM
            tb_atd_ate_atendimento atd,
            tb_ass_pat_pacieatend pat,
            tb_atd_aic_ate_int_compl aic,
            tb_cad_cnv_convenio cnv ,
            TB_CAD_PAC_PACIENTE PAC
   where atd.atd_ate_tp_paciente='I'
   AND      AIC.ATD_AIC_TP_SITUACAO_PAC = 'I'
   AND      ATD.ATD_ATE_FL_STATUS='A'
   AND      CNV.CAD_CNV_CD_HAC_PRESTADOR!='PA__'
   AND      ATD.ATD_ATE_ID=AIC.ATD_ATE_ID
   AND      ATD.ATD_ATE_ID=PAT.ATD_ATE_ID
   AND      PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
   AND      PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
   )
LOOP
   -- verifica periodo do convenio
   vn_periodo := parc.PERIODO;
   --
   IF vn_periodo > 0 THEN
      vn_parcela  := 0;
      -- qtde de dias da internacao
      vn_DiasInternado :=  vd_dt_dia - parc.DT_INT;
      IF vn_DiasInternado >= vn_periodo THEN
         -- qtd de parcelas
             vn_qtdParcelas   := ( vn_DiasInternado / vn_periodo );
              vd_dt_int  := parc.DT_INT;
            -- ############################################################################
            LOOP
               vd_dt_alta := vd_dt_int + vn_periodo;
               vn_parcela := vn_parcela + 1;

               SELECT COUNT(*) INTO vn_cont
               FROM TB_FAT_CCP_CONTA_CONS_PARC CCP
               WHERE CCP.ATD_ATE_ID = parc.atd_ate_id
               AND CCP.CAD_PAC_ID_PACIENTE = PARC.CAD_PAC_ID_PACIENTE
               AND   CCP.FAT_CCP_ID = vn_parcela;
               --
               IF vn_cont = 0 THEN
                    --
                    BEGIN
                        INSERT INTO tb_tmp_cpr_conta_parc_rel
                        ( atd_ate_id,cad_pac_id_paciente,fat_ccp_id,seg_usu_id_usuario,tmp_cpr_dt_ultima_atualizacao,tmp_cpr_dt_int,tmp_cpr_dt_alta) 
                        VALUES
                        ( parc.atd_ate_id, parc.cad_pac_id_paciente, vn_parcela, 7, sysdate,vd_dt_int, vd_dt_alta );
                    EXCEPTION
                        WHEN DUP_VAL_ON_INDEX THEN
                            ROLLBACK;
                    END;
               COMMIT;
               vd_dt_int := vd_dt_alta;
            END IF;   
            END LOOP;
            --
              SELECT COUNT(*) INTO vn_cont
               FROM TB_FAT_CCP_CONTA_CONS_PARC CCP
               WHERE CCP.ATD_ATE_ID = parc.atd_ate_id
               AND CCP.CAD_PAC_ID_PACIENTE = PARC.CAD_PAC_ID_PACIENTE
               AND   CCP.FAT_CCP_ID = vn_parcela;
            --
            IF vn_cont = 0 THEN
                BEGIN
                     INSERT INTO tb_tmp_cpr_conta_parc_rel
                        ( atd_ate_id,cad_pac_id_paciente,fat_ccp_id,seg_usu_id_usuario,tmp_cpr_dt_ultima_atualizacao,tmp_cpr_dt_int,tmp_cpr_dt_alta) 
                        VALUES
                        ( parc.atd_ate_id, parc.cad_pac_id_paciente, vn_parcela, 7, sysdate,vd_dt_int, vd_dt_alta );
                    EXCEPTION
                        WHEN DUP_VAL_ON_INDEX THEN
                            ROLLBACK;
                END;--
            COMMIT;
         END IF;  -- fim verificacao de vn_qtdParcelas < 50
      END IF;   -- fim verificacao diasinternado > periodo
   END IF;   -- fim verificacao periodo > 0
END LOOP;
END PRC_PARCELAMENTO_SGS;
/