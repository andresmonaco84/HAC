 BEGIN

FOR ATD IN 
(select a.atd_ate_id from tb_atd_ate_atendimento a where a.atd_ate_id
in (
18810385	,
19139962	,
19234072	,
19132018	,
19289157	,
19280317	,
19295727	,
19165093	,
19306553	,
19281787	,
19337753	,
19268525	,
19217167	,
19336234	,
19353450	,
19316820	,
19301845	,
19342238	,
19492506	,
19178571	,
19240293	,
19289072	,
19309778	,
19309472	,
19312538	,
19392898	
))
LOOP

  FOR MOVI IN
  (SELECT MOV.MTMD_MOV_ID,
          TRUNC(MOV.mtmd_mov_data) mtmd_mov_data,
          MOV.CAD_MTMD_FILIAL_ID,
          MOV.cad_mtmd_id,
          MM.CAD_MTMD_NOMEFANTASIA,
          MOV.mtmd_mov_qtde
     FROM  TB_MTMD_MOV_MOVIMENTACAO MOV,
           TB_CAD_MTMD_MAT_MED MM
     WHERE MM.CAD_MTMD_ID = MOV.CAD_MTMD_ID
     AND   MOV.CAD_MTMD_TPMOV_ID = 2
     AND   MOV.cad_mtmd_subtp_id IN( 35, 18 )
     AND   MOV.CAD_UNI_ID_UNIDADE = 244
     AND   MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29
     AND   MOV.CAD_SET_ID = 61
     AND   MOV.mtmd_mov_fl_estorno = 0
     AND MOV.mtmd_mov_data >= TO_DATE('01022011','DDMMYYYY')
     AND MOV.atd_ate_id = ATD.ATD_ATE_ID) 
  LOOP
      PRC_MTMD_MOV_ESTOQUE_EST_CONS(MOVI.MTMD_MOV_ID,
                                    MOVI.CAD_MTMD_ID,
                                    MOVI.CAD_MTMD_FILIAL_ID,
                                    244,
                                    29,
                                    61,
                                    MOVI.MTMD_MOV_QTDE,
                                    1,
                                    NULL);     
                                    
       DBMS_OUTPUT.put_line('ESTOQUE ' || MOVI.CAD_MTMD_FILIAL_ID ||
                            ' PRODUTO ' || MOVI.CAD_MTMD_ID || ' - ' || MOVI.CAD_MTMD_NOMEFANTASIA ||
                            ' QTDE. ' || MOVI.MTMD_MOV_QTDE);
  END LOOP;
END LOOP;

END;