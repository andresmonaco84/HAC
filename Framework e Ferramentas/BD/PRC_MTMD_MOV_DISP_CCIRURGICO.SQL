CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_DISP_CCIRURGICO" (
   pCAD_MTMD_ID                  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type,
   pCAD_UNI_ID_UNIDADE           IN TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type,
   pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
   pCAD_SET_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%TYPE,
   pCAD_MTMD_FILIAL_ID           IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type,
   pMTMD_LOTEST_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_LOTEST_ID%type default null,   
   pMTMD_ESTLOC_QTDE             IN TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type,
   pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%TYPE,
   pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%TYPE,
   pCAD_MTMD_TPMOV_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_TPMOV_ID%TYPE DEFAULT NULL,
   pCAD_MTMD_SUBTP_ID            IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_SUBTP_ID%type,   
   pSEG_USU_ID_USUARIO           IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE,   
   pMTMD_MOV_DATA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type  DEFAULT NULL,     
   pMTMD_MOV_HORA_FATURAMENTO    IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type  DEFAULT NULL,     
   pNewIdt                       OUT INTEGER      
) IS
nFilial NUMBER;
BEGIN
  nFilial := fnc_mtmd_retorna_filial(pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, pCAD_SET_ID);
   -- baixa do estoque centro disp.
   PRC_MTMD_MOV_BAIXA_CENT_DISP(pCAD_MTMD_ID,
                                pMTMD_LOTEST_ID,
                                nFilial,
                                NULL, -- pMTMD_REQ_ID,
                                pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                2, -- pCAD_MTMD_TPMOV_ID,
                                PKG_MTMD_CONSTANTES.MOV_BXA_AUTO_CCIRURGICO,
                                pMTMD_ESTLOC_QTDE,
                                pATD_ATE_ID,
                                pATD_ATE_TP_PACIENTE,
                                1, -- pMTMD_MOV_FL_FINALIZADO,
                                pSEG_USU_ID_USUARIO,
                                0, -- pEntrada, (baixa do estoque)
                                pNewIdt);
   -- ENTRA ESTOQUE UNIDADE
   PRC_MTMD_MOV_ENTRADA_UNIDADE(pCAD_MTMD_ID,
                                pMTMD_LOTEST_ID,
                                nFilial,
                                NULL, -- pMTMD_REQ_ID,
                                pCAD_UNI_ID_UNIDADE,
                                pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                pCAD_SET_ID,
                                1,-- pCAD_MTMD_TPMOV_ID,
                                PKG_MTMD_CONSTANTES.MOV_ENT_AUTO_CCIRURGICO, -- pCAD_MTMD_SUBTP_ID,
                                pMTMD_ESTLOC_QTDE,
                                pATD_ATE_ID,
                                pATD_ATE_TP_PACIENTE,
                                1, -- pMTMD_MOV_FL_FINALIZADO,
                                pSEG_USU_ID_USUARIO,
                                NULL, -- pMTMD_ID_ORIGINAL,
                                pNewIdt);
   -- CONSOME PARA O PACIENTE
   PRC_MTMD_MOV_ESTOQUE_BAIXA(pCAD_MTMD_ID,
                              NULL, -- pMTMD_REQ_ID,
                              pMTMD_LOTEST_ID,
                              nFilial,
                              pCAD_UNI_ID_UNIDADE,
                              pCAD_LAT_ID_LOCAL_ATENDIMENTO,
                              pCAD_SET_ID,
                              pMTMD_ESTLOC_QTDE,
                              pATD_ATE_ID,
                              pATD_ATE_TP_PACIENTE,
                              2, -- pCAD_MTMD_TPMOV_ID,
                              pCAD_MTMD_SUBTP_ID,
                              0, -- pCAD_MTMD_FL_FRACIONA,
                              pSEG_USU_ID_USUARIO,     
                              pMTMD_MOV_DATA_FATURAMENTO,     
                              pMTMD_MOV_HORA_FATURAMENTO,     
                              pNewIdt);
END PRC_MTMD_MOV_DISP_CCIRURGICO;
