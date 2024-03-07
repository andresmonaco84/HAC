create or replace procedure PRC_ASS_PLC_PESQ_CBO
  (
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_PESQ_CBO
  *
  *    Data Criacao:   27/11/2008   Por: Andrea Cazuca
  *    Funcao: Verifica se existe uma determinada especialidade nas unidades
  *            diferentes da passada como parametro
  *
  *******************************************************************/
is
  v_cursor PKG_CURSOR.t_cursor;
begin
  
  OPEN v_cursor FOR

       SELECT COUNT(*) QTD
       FROM   TB_ASS_CLP_CNV_UND_LOC_PLANO CLP,
              TB_ASS_CUL_CONV_UNI_LOCATEND CUL,
              TB_ASS_CNU_CONVENIO_UNIDADE CNU,
              TB_CAD_CNV_CONVENIO CNV,
              TB_ASS_PLC_PLANO_CBOS PLC,
              TB_ASS_ULC_UNID_LOCAL_CBOS ULC,
              TB_TIS_CBO_CBOS CBO
       WHERE  CLP.ASS_CUL_ID = CUL.ASS_CUL_ID
       AND    CUL.ASS_CNU_ID = CNU.ASS_CNU_ID
       AND    CNV.CAD_CNV_ID_CONVENIO = CNU.CAD_CNV_ID_CONVENIO
       AND    (CLP.ASS_CLP_DT_FIM_VIGENCIA IS NULL OR TRUNC(CLP.ASS_CLP_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE))
       AND    CNU.CAD_UNI_ID_UNIDADE != pCAD_UNI_ID_UNIDADE
       AND    CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO = 27
       AND    CLP.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
       AND    CLP.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK = 'N'
       AND    PLC.CAD_PLA_ID_PLANO = CLP.CAD_PLA_ID_PLANO
       AND    PLC.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
       AND    ULC.CAD_UNI_ID_UNIDADE = CNU.CAD_UNI_ID_UNIDADE
       AND    ULC.CAD_LAT_ID_LOCAL_ATENDIMENTO = CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO
       AND    ULC.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
       AND    ULC.TIS_CBO_CD_CBOS = PLC.TIS_CBO_CD_CBOS;
       
  io_cursor := v_cursor;
  
  end PRC_ASS_PLC_PESQ_CBO;
