CREATE OR REPLACE PROCEDURE PRC_AGS_REL_AVISO_PAC_AGE
(pDT_INI_CONSULTA           in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
 pDT_FIM_CONSULTA              in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
 pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
 pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
 pCAD_SET_ID                   in TB_CAD_SET_SETOR.CAD_SET_ID%type default null,
 pAGE_SAU_ID             IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_ID%type default null,
 pAGE_ESM_HR_INI_ESCALA        in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
 pAGE_ESM_HR_FIM_ESCALA        in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
 pATENDIDOS CHAR default null,
 pPENDENTES CHAR default null,
 pFALTAS CHAR default null,
 io_cursor                     OUT PKG_CURSOR.t_cursor
 ) is
  /********************************************************************
  *    Procedure: PRC_AGS_REL_AVISO_PAC_AGE
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT 
           AGD.AGS_AGE_TP_HORARIO,
           AGD.AGS_AGE_FL_STATUS ,
           SAU.AGE_SAU_CD_ANDAR,
           SAU.AGE_SAU_NR_SALA,           
           AGD.AGS_AGE_DT_ATENDIMENTO,
           AGD.AGS_AGE_HR_ATENDIMENTO,
           ESM.AGS_ESM_HR_INI_ESCALA,
           ESM.AGS_ESM_HR_FIM_ESCALA,

           AGG.AGS_AGG_HR_AGENDA_GERADA,
           PES.CAD_PES_NM_PESSOA ,
           PAC.CAD_PAC_NR_PRONTUARIO,

           PLA.CAD_PLA_CD_PLANO_HAC,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           PAC.CAD_PAC_CD_CREDENCIAL,
           PAC.CAD_PAC_NM_TITULAR,
           FNC_CAD_PES_TELEFONE_LISTA_S(PAC.CAD_PES_ID_PESSOA) TEL,
           FNC_CAD_PES_EMAIL_S(PAC.CAD_PES_ID_PESSOA) EMAIL,
           FNC_CAD_PES_MUNICIPIO_S(PAC.CAD_PES_ID_PESSOA, 1) MUNICIPIO,
           FNC_CAD_PES_ENDERECO_S(PAC.CAD_PES_ID_PESSOA, 1) ENDERECO,
           AGD.AGS_AGE_DS_OBSERVACAO ,

           TO_CHAR(pes.cad_pes_dt_nascimento, 'dd/MM/yyyy') data_nascimento_pac,
           CASE WHEN AGD.AGS_AGE_FL_STATUS = 'P' THEN 1 ELSE 0 END P, 
           CASE WHEN AGD.AGS_AGE_FL_STATUS = 'A' THEN 1 ELSE 0 END A


      FROM TB_AGS_AGG_AGE_GERADA_SADT AGG,
           TB_CAD_PAC_PACIENTE      PAC,
           TB_CAD_PES_PESSOA        PES,
           TB_AGS_ESM_ESCALA_SADT ESM,
           TB_AGE_SAU_SALA_UNID_AND SAU,
           TB_AGS_AGE_AGENDA_SADT   AGD,
           TB_CAD_PLA_PLANO         PLA,
           TB_CAD_CNV_CONVENIO      CNV

      WHERE AGG.AGS_AGG_ID = AGD.AGS_AGG_ID
       AND AGG.AGS_ESM_ID = ESM.AGS_ESM_ID
       AND ESM.AGE_SAU_ID = SAU.AGE_SAU_ID
       AND AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
       AND AGD.AGS_ESM_ID = ESM.AGS_ESM_ID

       AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
       AND PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
    
       and agd.agS_agE_dt_atendimento between pDT_INI_CONSULTA AND pDT_FIM_CONSULTA
       and (pAGE_ESM_HR_INI_ESCALA is null OR agd.agS_agE_hr_atendimento between pAGE_ESM_HR_INI_ESCALA AND pAGE_ESM_HR_FIM_ESCALA)
       and (esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
       and (esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
       AND (pCAD_SET_ID IS NULL OR ESM.CAD_SET_ID = pCAD_SET_ID)
       AND (pAGE_SAU_ID IS NULL OR ESM.AGE_SAU_ID = pAGE_SAU_ID)
     
       AND (pATENDIDOS IS NOT NULL AND AGD.AGS_AGE_FL_STATUS = 'A'
       OR pPENDENTES IS NOT NULL AND AGD.AGS_AGE_FL_STATUS = 'P')
       --OR pFALTAS IS NOT NULL AND AGD.AGS_AGE_FL_STATUS = 'F'

     
     ORDER BY agd.agS_agE_dt_atendimento,
              agd.ags_age_hr_atendimento,
              agd.ags_age_fl_status;
  io_cursor := v_cursor;
end PRC_AGS_REL_AVISO_PAC_AGE;
