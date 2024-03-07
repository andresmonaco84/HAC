CREATE OR REPLACE PROCEDURE "PRC_MTMD_MOV_CONSUMO_EST_CCUST" (
      pMTMD_MOV_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type,
      pMTMD_ID_USUARIO_ESTORNO   IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_ID_USUARIO_ESTORNO%type
    )   IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_CONSUMO_EST_CCUST
  *
  *    Data Criacao: 16/06/2009     Por: Alexandre M. Muniz
  *    Data Alteracao:  04/02/2010  Por: RICARDO COSTA
  *         Alterac?o: Adicionada exception e teste de delec?o
  *
  *    Funcao: ESTORNA MOVIMENTAC?O DE DESPESA NO CENTRO DE CUSTO E DA ENTRADA NO MATMED NO ESTOQUE
  *
  *******************************************************************/
TIPO_MOV_ENTRADA             CONSTANT NUMBER := 1;
TIPO_MOV_BAIXA               CONSTANT NUMBER := 2;
SUB_MOV_ESTORNO_CONS_CCUSTO  CONSTANT NUMBER := 29;
SUB_MOV_BAIXA_CONSUMO_CCUSTO CONSTANT NUMBER := 19;
ID_MOV_BAIXA                 TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type;
--
vMTMD_MOV_ID                  TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type;
vCAD_MTMD_ID                  TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type;
vCAD_MTMD_FILIAL_ID           TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%type;
vCAD_UNI_ID_UNIDADE           TB_MTMD_MOV_MOVIMENTACAO.CAD_UNI_ID_UNIDADE%type;
vCAD_LAT_ID_LOCAL_ATENDIMENTO TB_MTMD_MOV_MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vCAD_SET_ID                   TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type;
vMTMD_MOV_DATA                TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type;
vMTMD_ESTLOC_QTDE             TB_MTMD_ESTOQUE_LOCAL.MTMD_ESTLOC_QTDE%type;
-- vMTMD_ID_USUARIO_ESTORNO      TB_MTMD_MOV_MOVIMENTACAO.MTMD_ID_USUARIO_ESTORNO%type;
BEGIN
   -- EXCLUI MOVIMENTACAO DE DISTRIBUIC?O DE DESPESA
   /*BEGIN
      DELETE FROM SGS.TB_MTMD_MOV_MOVIMENTACAO
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
      IF SQL%NOTFOUND THEN
         RAISE_APPLICATION_ERROR(-20000,' MOVIMENTO N?O ENCONTRADO PARA EXCLUS?O MOVIMENTO: '||TO_CHAR(pMTMD_MOV_ID));
      END IF;
   END;*/   
   -- BUSCA MOVIMENTAC?O DE BAIXA
   BEGIN
      SELECT MOV.mtmd_mov_id,        MOV.cad_mtmd_id,                  MOV.cad_mtmd_filial_id,
             MOV.cad_uni_id_unidade, MOV.cad_lat_id_local_atendimento, MOV.cad_set_id,
             MOV.mtmd_mov_qtde,      MOV.MTMD_MOV_DATA
      INTO   vMTMD_MOV_ID,           vCAD_MTMD_ID,                     vCAD_MTMD_FILIAL_ID,
             vCAD_UNI_ID_UNIDADE,    vCAD_LAT_ID_LOCAL_ATENDIMENTO,    vCAD_SET_ID,
             vMTMD_ESTLOC_QTDE,      vMTMD_MOV_DATA
      FROM SGS.TB_MTMD_MOV_MOVIMENTACAO MOV
      WHERE MOV.mtmd_mov_id_ref   = pMTMD_MOV_ID
      AND   MOV.cad_mtmd_subtp_id = SUB_MOV_BAIXA_CONSUMO_CCUSTO;
      
      IF (vMTMD_MOV_DATA < SYSDATE-5) THEN
          RAISE_APPLICATION_ERROR(-20090, 'NAO PERMITIDO ESTORNO DE ITEM BAIXADO HA MAIS DE 5 DIAS.');  
      END IF;
      
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
            MTMD_MOV_FL_ESTORNO     = 1,
            MTMD_MOV_ID_REF         = (SELECT M.MTMD_MOV_ID 
                                         FROM TB_MTMD_MOV_MOVIMENTACAO M 
                                        WHERE M.MTMD_MOV_ID_REF = pMTMD_MOV_ID)         
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
      
      -- GERA MOVIMENTAC?O DE ESTORNO DA BAIXA DO CONSUMO NO CENTRO DE CUSTO
      PRC_MTMD_MOV_ESTOQUE_EST_CONS ( vMTMD_MOV_ID,
                                      vCAD_MTMD_ID,
                                      vCAD_MTMD_FILIAL_ID,
                                      vCAD_UNI_ID_UNIDADE,
                                      vCAD_LAT_ID_LOCAL_ATENDIMENTO,
                                      vCAD_SET_ID,
                                      vMTMD_ESTLOC_QTDE,
                                      pMTMD_ID_USUARIO_ESTORNO,
                                      SUB_MOV_ESTORNO_CONS_CCUSTO );
   EXCEPTION WHEN NO_DATA_FOUND THEN
      RAISE_APPLICATION_ERROR(-20001, 'NAO ACHOU MOVIMENTAC?O DE BAIXA DO CENTRO DE CUSTO');
   --WHEN OTHERS THEN
     -- RAISE_APPLICATION_ERROR(-20000, 'ESTORNO CCUSTO '||SQLERRM);
   END;
END PRC_MTMD_MOV_CONSUMO_EST_CCUST;