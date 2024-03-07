CREATE OR REPLACE PROCEDURE PRC_MTMD_PEDIDO_PADRAO_ITENS_S
   (
    pMTMD_PEDPAD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_ID%type,
    pCAD_MTMD_ID IN TB_MTMD_PEDIDO_PADRAO_ITENS.CAD_MTMD_ID%type DEFAULT NULL,
    pCAD_MTMD_PRIATI_ID IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_ID%type DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
   )
   is
  /********************************************************************
  *    Procedure: PRC_MTMD_PEDIDO_PADRAO_ITENS_S
  *
  *    Data Criacao: 	11/2009   Por: RICARDO COSTA
  *    Data Alteracao:	01/02/2010  Por: RICARDO COSTA
            Alterac?o: Cometario na chamada de algumas func?es para
                       melhorar performance da query ( lentid?o)
  *    Data Alteracao:  24/10/2017  Por: Andre S. Monaco
  *         Alteracao:  Adicao funcao SOUND ALIKE na descricao
  *    Data Alteracao:  28/08/2019  Por: Andre S. Monaco
  *         Alteracao:  Ajuste Query com string (sem is null or)
  *
  *    Funcao: LISTA ITENS DO PEDIDO PADR?O (ESTOQUE FIXO) DA UNIDADE
  *    CHAMADA: TELA PEDIDO PADR?O ITENS
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(5000);
  V_SELECT  varchar2(5000);
BEGIN
    V_WHERE := NULL;
    IF pMTMD_PEDPAD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITENS.MTMD_PEDPAD_ID = ' || pMTMD_PEDPAD_ID; END IF;
    IF pCAD_MTMD_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ITENS.CAD_MTMD_ID = ' || pCAD_MTMD_ID; END IF;
    IF pCAD_MTMD_PRIATI_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND MATMED.CAD_MTMD_PRIATI_ID = ' || pCAD_MTMD_PRIATI_ID; END IF;
    
    V_SELECT := 'SELECT ITENS.CAD_MTMD_ID,
                        ITENS.MTMD_PEDPAD_ID,
                        ITENS.MTMD_PEDPAD_QTDE,
                        FNC_MTMD_SOUNDALIKE(MATMED.CAD_MTMD_NOMEFANTASIA,MATMED.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,
                        MATMED.CAD_MTMD_PRIATI_ID,
                        ITENS.MTMD_PEDPAD_PERCENT_RESSUP,
                        NVL(FNC_MTMD_EST_PADRAO_UNIDADE(MATMED.CAD_MTMD_PRIATI_ID,
                                                        ITENS.CAD_MTMD_ID,
                                                        PADRAO.CAD_UNI_ID_UNIDADE,
                                                        PADRAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                                                        PADRAO.CAD_SET_ID,
                                                        PADRAO.CAD_MTMD_FILIAL_ID,
                                                        NULL
                                                        ),0) QTDE_ESTOQUE_LOCAL,
                        NULL QTDE_CONSUMIDA,
                        NULL OUTROS_CONSUMOS,
                        NULL PERCENTUAL_CONSUMIDO,
                        NULL QTD_FORNECER,        
                        ITENS.MTMD_DT_ATUALIZACAO,
                        PADRAO.MTMD_DT_DISPENSACAO,
                        MATMED.CAD_MTMD_GRUPO_ID,
                        MATMED.CAD_MTMD_SUBGRUPO_ID
                FROM TB_MTMD_PEDIDO_PADRAO_ITENS ITENS JOIN 
                     TB_MTMD_PEDIDO_PADRAO PADRAO ON PADRAO.MTMD_PEDPAD_ID = ITENS.MTMD_PEDPAD_ID JOIN
                     TB_CAD_MTMD_MAT_MED MATMED ON MATMED.CAD_MTMD_ID = ITENS.CAD_MTMD_ID     
                WHERE NULL IS NULL ' || V_WHERE ||
                ' ORDER BY MATMED.CAD_MTMD_NOMEFANTASIA';

    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
END PRC_MTMD_PEDIDO_PADRAO_ITENS_S;