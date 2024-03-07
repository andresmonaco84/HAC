create or replace procedure PRC_ASS_PLC_ASSOC_CBOS_CNV
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pTIS_CBO_CD_CBOS     IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type,
     pSEG_USU_ID_USUARIO  IN TB_ASS_PLC_PLANO_CBOS.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_ASSOC_CBOS_CNV
  *
  *    Data Criacao:   02/09/2009   Por: Alexandre M. Muniz
  *    Funcao: Associa uma especialidade a todos os planos de um convênio.
  *
  *    Data Alteracao:  data da altera???#o  Por: Nome do Analista
  *
  *
  *******************************************************************/

  vASSOCIAR boolean;

  begin

       FOR vREC_PLANO IN (SELECT PLA.CAD_PLA_ID_PLANO
                            FROM TB_CAD_PLA_PLANO PLA
                           WHERE PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                             AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'A' 
                             AND (PLA.CAD_PLA_DT_FIM_VIGENCIA IS NULL OR PLA.CAD_PLA_DT_FIM_VIGENCIA > TO_DATE(TO_CHAR(SYSDATE, 'dd/mm/yyyy'))))
       LOOP
       
           vASSOCIAR := true;
       
           --Se a especialidade já está associada ao plano, não associa novamente.
           FOR vREC_PLANO_CBOS IN (SELECT PLC.CAD_PLA_ID_PLANO
                                     FROM TB_ASS_PLC_PLANO_CBOS PLC
                                    WHERE PLC.CAD_PLA_ID_PLANO = vREC_PLANO.CAD_PLA_ID_PLANO
                                      AND PLC.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
           LOOP
           
               vASSOCIAR := false;
           
           END LOOP;
       
           IF vASSOCIAR THEN
             PRC_ASS_PLC_PLANO_CBOS_I (vREC_PLANO.CAD_PLA_ID_PLANO, 
                                       pTIS_CBO_CD_CBOS,
                                       'A',
                                       pSEG_USU_ID_USUARIO,
                                       'N',
                                       'N');
           END IF;  
       
       END LOOP;

  end PRC_ASS_PLC_ASSOC_CBOS_CNV;
