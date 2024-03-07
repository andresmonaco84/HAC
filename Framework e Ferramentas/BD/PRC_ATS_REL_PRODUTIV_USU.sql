 CREATE OR REPLACE PROCEDURE "PRC_ATS_REL_PRODUTIV_USU"
  (
     PDT_INI_CONSULTA IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_DT_REALIZ_PROCED%TYPE,
     PDT_FIM_CONSULTA    IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_DT_REALIZ_PROCED%TYPE,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_PRODUTIV_USU
  *
  *   Data Criação:   22/06/2012    Por: Eduardo Hyppolito/PEDRO
  *   Função: Mostrar Produtividade por Usuario - Agendamentos
  *
  * ATENÇÃO: SE NÃO PASSAR O CAD_UNI_ID_UNIDADE VAI CAUSAR CARTESIANO POIS UM USUÁRIO PODE
  *          TER 1 OU + ASSOCIAÇÕES EM UNIDADES.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
 -- if pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    OPEN v_cursor FOR

SELECT DISTINCT ATS.SEG_USU_ID_USUARIO,
                --UUN.CAD_UNI_ID_UNIDADE,
                SETOR.CAD_UNI_ID_UNIDADE,
                SETOR.CAD_SET_DS_SETOR,
                UNI.CAD_UNI_DS_UNIDADE,
                USU.SEG_USU_DS_NOME,
                USU.SEG_USU_CD_MATRICULA,
                USU.SEG_USU_DS_LOGIN,
                NVL(ATENDIMENTOS_CANCELADOS.TOTAL_CANCELADOS,0) TOTAL_CANCELADOS,
                NVL(SUM(COUNT(ATS.ATS_ATE_ID|| ATS.ATS_ATE_CD_INTLIB|| ATS.ATS_ATE_IN_INTLIB|| ATS.CAD_PRD_ID|| ATS.AUX_EPP_CD_ESPECPROC||
                     ATS.TIS_MED_CD_TABELAMEDICA||ATS.SEG_USU_ID_USUARIO)
                ) OVER  (PARTITION BY  ATS.SEG_USU_ID_USUARIO||SETOR.CAD_UNI_ID_UNIDADE,SETOR.CAD_SET_ID),0) TOTAL_ATENDIDOS

            FROM   TB_ATS_ATE_ATENDIMENTO_SADT ATS,
                   TB_CAD_UNI_UNIDADE         UNI,
                   TB_CAD_SET_SETOR           SETOR,
                   TB_SEG_USU_USUARIO         USU,
                    (SELECT COUNT(ATE.ATD_ATE_ID) TOTAL_CANCELADOS, ATE.CAD_UNI_ID_UNIDADE,ATE.CAD_SET_ID, ACS.SEG_USU_ID_USUARIO
                      FROM   TB_ATS_ACS_ATEND_CANCE_SADT ACS,
                             TB_ATD_ATE_ATENDIMENTO      ATE,
                             TB_CAD_UNI_UNIDADE          UNI
                      WHERE  ATE.ATD_ATE_ID            = ACS.ATS_ATE_CD_INTLIB
                      AND    ATE.CAD_UNI_ID_UNIDADE    = UNI.CAD_UNI_ID_UNIDADE
                         AND (ATE.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                      --   AND (ATE.CAD_SET_ID = pCAD_SET_ID)
                      AND    TRUNC(ACS.ATS_ACS_DT_CANCELAMENTO) BETWEEN PDT_INI_CONSULTA AND pDT_FIM_CONSULTA
                      GROUP BY ATE.CAD_UNI_ID_UNIDADE, ATE.CAD_SET_ID, ACS.SEG_USU_ID_USUARIO
                    )  ATENDIMENTOS_CANCELADOS

            WHERE  TRUNC(ATS.ATS_ATE_DT_REALIZ_PROCED) BETWEEN PDT_INI_CONSULTA AND pDT_FIM_CONSULTA
                   AND SETOR.CAD_SET_ID          = ATS.CAD_SET_ID_ATEN
                   AND SETOR.CAD_UNI_ID_UNIDADE  = UNI.CAD_UNI_ID_UNIDADE
                   AND USU.SEG_USU_ID_USUARIO   = ATS.SEG_USU_ID_USUARIO
                   AND (SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
                 --   AND (SETOR.CAD_SET_ID         = pCAD_SET_ID)
                   AND ATENDIMENTOS_CANCELADOS.SEG_USU_ID_USUARIO (+)= ATS.SEG_USU_ID_USUARIO
                   AND ATENDIMENTOS_CANCELADOS.CAD_SET_ID         (+)= ATS.CAD_SET_ID_ATEN
            GROUP BY  ATS.SEG_USU_ID_USUARIO,SETOR.CAD_UNI_ID_UNIDADE,SETOR.CAD_SET_ID,SETOR.CAD_SET_DS_SETOR,UNI.CAD_UNI_DS_UNIDADE,USU.SEG_USU_DS_NOME,
                      USU.SEG_USU_CD_MATRICULA,
                      USU.SEG_USU_DS_LOGIN,
                      ATENDIMENTOS_CANCELADOS.TOTAL_CANCELADOS,ATS.TIS_MED_CD_TABELAMEDICA,
                      ATS.AUX_EPP_CD_ESPECPROC,
                      ATS.CAD_PRD_ID,
                      ATS.ATS_ATE_IN_INTLIB,
                      ATS.ATS_ATE_CD_INTLIB,
                      ATS.ATS_ATE_ID;
   io_cursor := v_cursor;
  /* ELSE
      OPEN v_cursor FOR

select distinct usu.seg_usu_id_usuario, usu.seg_usu_ds_nome NOME_USUARIO, usu.seg_usu_cd_matricula MATRICULA,
        pes.cad_pes_nm_pessoa NOME_UNIDADE,
        nvl(agendamentos_marcados.total_agendados,0) total_agendados,
        fnc_ats_usu_cancelados(PDT_INI_CONSULTA,PDT_FIM_CONSULTA,ATS.Seg_Usu_Id_Usuario,ATS.CAD_UNI_ID_UNIDADE_LIBERACAO,null )
           total_cancelados
           from tb_ats_ate_atendimento_sadt ats,
           tb_cad_uni_unidade uni,
           tb_cad_pes_pessoa pes,
           tb_seg_usu_usuario usu,
           (select ats.ats_ate_id,ats.seg_usu_id_usuario,ats.cad_uni_id_unidade_liberacao,
                 Sum(count(ats.seg_usu_id_usuario)) over
                 (partition by ats.seg_usu_id_usuario||ats.cad_uni_id_unidade_liberacao) total_agendados
          from   tb_ats_ate_atendimento_sadt ats
          where  trunc(ats.ats_ate_dt_realiz_proced) between PDT_INI_CONSULTA and PDT_FIM_CONSULTA
          group by ats.seg_usu_id_usuario, ats.cad_uni_id_unidade_liberacao,ats.ats_ate_id)
          agendamentos_MARCADOS
    where trunc(ats.ats_ate_dt_realiz_proced) between PDT_INI_CONSULTA and PDT_FIM_CONSULTA
          and usu.seg_usu_id_usuario = ats.seg_usu_id_usuario
          and uni.cad_uni_id_unidade = ats.cad_uni_id_unidade_liberacao
          and pes.cad_pes_id_pessoa = uni.cad_pes_id_pessoa
          and agendamentos_marcados.ats_ate_id   (+) =  ats.ats_ate_id
          and agendamentos_marcados.seg_usu_id_usuario   (+) =  ats.seg_usu_id_usuario
         and (agendamentos_marcados.total_agendados is not null or fnc_ats_usu_cancelados(PDT_INI_CONSULTA,PDT_FIM_CONSULTA,ATS.SEG_USU_ID_USUARIO,ATS.CAD_UNI_ID_UNIDADE_LIBERACAO,null) is not null)
  ;

   io_cursor := v_cursor;*/

--END IF;
 end PRC_ATS_REL_PRODUTIV_USU;
