 create or replace procedure PRC_ASS_CUT_ACOMOD_CNU_UTA_ID
  (
     pCAD_CNV_ID_CONVENIO         IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE          IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pTIS_TAC_CD_TIPO_ACOMODACAO  IN TB_ASS_UTA_UNID_TPACOMOD.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     pUSUARIO                     IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_ACOMOD_CNU_UTA_ID
  *
  *    Data Criacao: 27/10/2010   Por: André Souza Monaco
  *
  *    Funcao: Retorna ID de associação (ASS_CUT_ID) para inclusão na
  *            TB_ASS_CTP_CNV_UN_TPACOM_PLA
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  pNewIdt integer;
  pNewIdtCNU integer;
  pNewIdtUTA integer;
  begin

    BEGIN

      SELECT CUT.ASS_CUT_ID INTO pNewIdt FROM TB_ASS_CUT_CONV_UNI_TPACOMOD CUT
         WHERE CUT.ASS_CNU_ID               = (SELECT CNU.ASS_CNU_ID
                                                 FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
                                                WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO AND
                                                      CNU.CAD_UNI_ID_UNIDADE  = pCAD_UNI_ID_UNIDADE AND
                                                      FNC_VALIDAR_VIGENCIA(CNU.ASS_CNU_DT_INI_VIGENCIA, CNU.ASS_CNU_DT_FIM_VIGENCIA) = 1) AND
               CUT.ASS_UTA_ID_UNID_TPACOMOD = (SELECT UTA.ASS_UTA_ID_UNID_TPACOMOD
                                                 FROM TB_ASS_UTA_UNID_TPACOMOD    UTA
                                                WHERE UTA.ASS_UTA_FL_ATIVO_OK = 'S' AND
                                                      UTA.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE  AND
                                                      UTA.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO) AND
               FNC_VALIDAR_VIGENCIA(TRUNC(CUT.ASS_CUT_DT_INI_VIGENCIA), TRUNC(CUT.ASS_CUT_DT_FIM_VIGENCIA)) = 1;

    EXCEPTION WHEN NO_DATA_FOUND THEN
                  
         BEGIN
              SELECT UTA.ASS_UTA_ID_UNID_TPACOMOD INTO pNewIdtUTA
                FROM TB_ASS_UTA_UNID_TPACOMOD    UTA
               WHERE UTA.ASS_UTA_FL_ATIVO_OK = 'S' AND
                     UTA.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE  AND
                     UTA.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;
         EXCEPTION WHEN NO_DATA_FOUND THEN
              PRC_ASS_UTA_UNID_TPACOMOD_I(pNewIdtUTA,
                                          0,
                                          pTIS_TAC_CD_TIPO_ACOMODACAO,
                                          'S',
                                          pCAD_UNI_ID_UNIDADE);
         END;
         
         BEGIN
              SELECT CNU.ASS_CNU_ID INTO pNewIdtCNU
                FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
               WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO AND
                     CNU.CAD_UNI_ID_UNIDADE  = pCAD_UNI_ID_UNIDADE AND
                     FNC_VALIDAR_VIGENCIA(CNU.ASS_CNU_DT_INI_VIGENCIA, CNU.ASS_CNU_DT_FIM_VIGENCIA) = 1;
         EXCEPTION WHEN NO_DATA_FOUND THEN
              PRC_ASS_CNU_CONVENIO_UNIDADE_I(pNewIdtCNU,
                                             TRUNC(SYSDATE),
                                             NULL,
                                             NULL,
                                             pCAD_CNV_ID_CONVENIO,
                                             pCAD_UNI_ID_UNIDADE,
                                             pUSUARIO);
         END;
         
         BEGIN
  
           SELECT CUT.ASS_CUT_ID INTO pNewIdt FROM TB_ASS_CUT_CONV_UNI_TPACOMOD CUT
             WHERE CUT.ASS_CNU_ID               = (SELECT CNU.ASS_CNU_ID
                                                     FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
                                                    WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO AND
                                                          CNU.CAD_UNI_ID_UNIDADE  = pCAD_UNI_ID_UNIDADE AND
                                                          FNC_VALIDAR_VIGENCIA(CNU.ASS_CNU_DT_INI_VIGENCIA, CNU.ASS_CNU_DT_FIM_VIGENCIA) = 1) AND
                   CUT.ASS_UTA_ID_UNID_TPACOMOD = (SELECT UTA.ASS_UTA_ID_UNID_TPACOMOD
                                                     FROM TB_ASS_UTA_UNID_TPACOMOD    UTA
                                                    WHERE UTA.ASS_UTA_FL_ATIVO_OK = 'S' AND
                                                          UTA.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE  AND
                                                          UTA.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO) AND
                   FNC_VALIDAR_VIGENCIA(TRUNC(CUT.ASS_CUT_DT_INI_VIGENCIA), TRUNC(CUT.ASS_CUT_DT_FIM_VIGENCIA)) = 1;

         EXCEPTION WHEN NO_DATA_FOUND THEN
              PRC_ASS_CUT_CONV_UNI_TPACOM_I(pNewIdt,
                                            TRUNC(SYSDATE),
                                            NULL,
                                            NULL,
                                            pNewIdtUTA,
                                            pUSUARIO,
                                            pNewIdtCNU);              
         END;
    END;
    
    OPEN v_cursor FOR
    
    SELECT CUT.ASS_CUT_ID FROM TB_ASS_CUT_CONV_UNI_TPACOMOD CUT
                 WHERE CUT.ASS_CNU_ID               = (SELECT CNU.ASS_CNU_ID
                                                         FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU
                                                        WHERE CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO AND
                                                              CNU.CAD_UNI_ID_UNIDADE  = pCAD_UNI_ID_UNIDADE AND
                                                              FNC_VALIDAR_VIGENCIA(CNU.ASS_CNU_DT_INI_VIGENCIA, CNU.ASS_CNU_DT_FIM_VIGENCIA) = 1) AND
                       CUT.ASS_UTA_ID_UNID_TPACOMOD = (SELECT UTA.ASS_UTA_ID_UNID_TPACOMOD
                                                         FROM TB_ASS_UTA_UNID_TPACOMOD    UTA
                                                        WHERE UTA.ASS_UTA_FL_ATIVO_OK = 'S' AND
                                                              UTA.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE  AND
                                                              UTA.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO) AND
                       FNC_VALIDAR_VIGENCIA(TRUNC(CUT.ASS_CUT_DT_INI_VIGENCIA), TRUNC(CUT.ASS_CUT_DT_FIM_VIGENCIA)) = 1;
    
    io_cursor := v_cursor;

  end PRC_ASS_CUT_ACOMOD_CNU_UTA_ID;
