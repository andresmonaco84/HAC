create or replace procedure PRC_ATE_REL_ESTAT_ESPEC
  (
     pCAD_UNI_ID_UNIDADE in TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
     pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     pATD_DT_INICIO in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type,
     pATD_DT_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATE_REL_ESTAT_ESPEC
  *
  *    Data Criacao:  22/05/2009   Por: Pedro
  *    Funcao: Alimentar relatorio das estatisticas do Atendimento DE ABSENTEISMO por Especialidade
  *
  *    Data Alteracao:  09/06/2009   Por: Pedro
  *    Alteracao:     refiz tudo :)
  *
  *    Data Alteracao:  14/03/2011   Por: Davi Silvestre M. dos Reis
  *    Alteracao:     acerto no calculo do absenteismo
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT
     ESM.CAD_UNI_ID_UNIDADE ID_UNIDADE,
     UNI.CAD_UNI_DS_UNIDADE DS_UNIDADE,
     ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO ID_LOCAL,
     LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO DS_LOCAL,
     CBO.TIS_CBO_CD_CBOS ID_ESPEC,
     CBO.TIS_CBO_DS_CBOS_HAC DS_ESPEC,
      DECODE(TO_CHAR(AGD.AGE_AGD_DT_ATENDIMENTO, 'MM'),'01','JAN','02','FEV','03','MAR','04','ABR','05','MAI',
     '06','JUN','07','JUL','08','AGO','09','SET','10','OUT','11','NOV','12','DEZ') MES,     
    CASE WHEN COUNT(DECODE(AGD.AGE_AGD_FL_STATUS,'F','F')) > 0 THEN
              NVL(ROUND((COUNT(DECODE(AGD.AGE_AGD_FL_STATUS,'F','F')) * 100) / COUNT(AGD.AGE_AGD_ID),2),0)
     END ABSENTEISMO
       FROM     
          TB_AGE_AGD_AGENDA AGD,
          TB_AGE_ESM_ESCALA_MEDICA ESM,
          TB_CAD_UNI_UNIDADE UNI,
          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
          TB_TIS_CBO_CBOS CBO,
          TB_CAD_SET_SETOR SETOR,
          TB_CAD_PAC_PACIENTE PAC,
          TB_CAD_CNV_CONVENIO CNV 
        WHERE (AGD.AGE_AGD_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
        AND (pTIS_CBO_CD_CBOS IS NULL OR ESM.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
        AND (pCAD_UNI_ID_UNIDADE IS NULL OR ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
        AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
        AND (pCAD_SET_ID IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
        AND PAC.CAD_PAC_ID_PACIENTE = AGD.CAD_PAC_ID_PACIENTE
        AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
        AND ESM.AGE_ESM_ID = AGD.AGE_ESM_ID
        AND ESM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
        AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
        AND ESM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
        AND SETOR.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
        AND SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO

         AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)
        
GROUP BY (ESM.CAD_UNI_ID_UNIDADE ,
     UNI.CAD_UNI_DS_UNIDADE,
     ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO ,
     LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
     CBO.TIS_CBO_CD_CBOS,
     CBO.TIS_CBO_DS_CBOS_HAC,    
     TO_CHAR(AGD.AGE_AGD_DT_ATENDIMENTO, 'MM')
)
 HAVING  (COUNT(DECODE(AGD.AGE_AGD_FL_STATUS,'F','F')) > 0) 
 ORDER BY TO_CHAR(AGD.AGE_AGD_DT_ATENDIMENTO, 'MM')
;    io_cursor := v_cursor;
  end PRC_ATE_REL_ESTAT_ESPEC;

 