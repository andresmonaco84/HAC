create or replace procedure PRC_ASS_PLC_DESASSOC_CBOS_CNV
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pTIS_CBO_CD_CBOS     IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_DESASSOC_CBOS_CNV
  *
  *    Data Criacao:   02/09/2009   Por: Alexandre M. Muniz
  *    Funcao: Associa uma especialidade a todos os planos de um convênio.
  *
  *    Data Alteracao:  data da altera???#o  Por: Nome do Analista
  *
  *
  *******************************************************************/
  
  begin
  
       DELETE TB_ASS_PLC_PLANO_CBOS PLC
        WHERE PLC.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
          AND PLC.CAD_PLA_ID_PLANO IN (SELECT PLA.CAD_PLA_ID_PLANO
                                         FROM TB_CAD_PLA_PLANO PLA
                                        WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                                          AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'A' 
                                          AND (PLA.CAD_PLA_DT_FIM_VIGENCIA IS NULL OR PLA.CAD_PLA_DT_FIM_VIGENCIA > TO_DATE(TO_CHAR(SYSDATE, 'dd/mm/yyyy'))));

  end PRC_ASS_PLC_DESASSOC_CBOS_CNV;
