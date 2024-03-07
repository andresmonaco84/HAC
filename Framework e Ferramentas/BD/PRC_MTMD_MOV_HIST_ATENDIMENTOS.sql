create or replace procedure PRC_MTMD_MOV_HIST_ATENDIMENTOS
(
/*     pATD_ATE_ID                   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%TYPE,
     pATD_ATE_TP_PACIENTE          IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_TP_PACIENTE%TYPE,*/
     pDATAINI                      IN DATE DEFAULT NULL,
     pDATAFIM                      IN DATE DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO          IN TB_ASS_PAT_PACIEATEND.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     io_cursor                     OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *  Procedure: PRC_MTMD_MOV_HIST_ATENDIMENTOS
  *
  *  Data Criacao:  05/10/2010   Por: André Souza Monaco
  *  Data Alteração: 09/11/2010   Por: André Souza Monaco
  *       Alteração: Adição do parâmetro Convênio e da query hard code se
  *                  não for passado nenhum parâmetro
  *
  *  Funcao: RETORNA ATENDIMENTOS COM MOVIMENTAÇÕES DE BAIXA NO PERÍODO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
  
   IF (NOT pDATAINI IS NULL AND NOT pDATAFIM IS NULL) THEN
        OPEN v_cursor FOR
        SELECT DISTINCT MOVIMENTACAO.ATD_ATE_ID, MOVIMENTACAO.ATD_ATE_TP_PACIENTE, PAT.CAD_CNV_ID_CONVENIO, PAC.CAD_CNV_ID_CONVENIO CAD_CNV_ID_CONVENIO_AMB
        FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO,
             TB_ASS_PAT_PACIEATEND PAT, 
             TB_CAD_PAC_PACIENTE   PAC
        WHERE
        --AND   MOVIMENTACAO.ATD_ATE_ID                   = pATD_ATE_ID
        --AND   MOVIMENTACAO.ATD_ATE_TP_PACIENTE          = pATD_ATE_TP_PACIENTE
             (TRUNC(MOVIMENTACAO.MTMD_MOV_DATA) BETWEEN TRUNC(pDATAINI) AND TRUNC(pDATAFIM))
        AND   MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 25, 26, 36)
        AND   MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0
        AND   NOT MOVIMENTACAO.ATD_ATE_ID IS NULL
        AND   MOVIMENTACAO.ATD_ATE_ID IN (SELECT ATD_ATE_ID FROM TB_ATD_ATE_ATENDIMENTO ATE WHERE TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) >= TRUNC(pDATAINI)) 
        AND   PAT.ATD_ATE_ID = MOVIMENTACAO.ATD_ATE_ID 
        AND   PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
        AND  (pCAD_CNV_ID_CONVENIO   IS NULL OR (PAT.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO))
        ORDER BY MOVIMENTACAO.ATD_ATE_ID ASC;
        io_cursor := v_cursor;
   ELSE
       -- UTILIZA QUERY HARD CODE
       OPEN v_cursor FOR
       select  I.CODCON, I.NR_SEQINTER ATD_ATE_ID, I.In_Int_Ext ATD_ATE_TP_PACIENTE, I.DT_INT CONSUINI,I.DT_ALTA CONSUFIM ,CNV.CAD_CNV_ID_CONVENIO
        from
         TB_INTERNADO I,   
         TB_INTERNADO_FATURADO F, 
         TB_ATD_ATE_ATENDIMENTO ATD, 
         TB_CAD_CNV_CONVENIO CNV 
        where I.DT_ALTA between  '01-JUL-2010' and '09-NOV-2010'
        and I.CD_ALTA not in ( 1000, 999)
        and I.CODCON in ('SW38','SW32')
        and F.NR_SEQINTER = I.NR_SEQINTER
        and F.TP_COBRANCA = 'N'
        and F.DT_FATURAMENTO IS NULL 
        AND ATD.ATD_ATE_ID=F.NR_SEQINTER 
        AND I.CODCON=CNV.CAD_CNV_CD_HAC_PRESTADOR
        UNION
        select
         I.CODCON, I.NR_SEQINTER ATD_ATE_ID, I.In_Int_Ext ATD_ATE_TP_PACIENTE, I.DT_INT,I.DT_ALTA,CNV.CAD_CNV_ID_CONVENIO
        from
        TB_INTERNADO I,   TB_CAD_CNV_CONVENIO CNV
        where I.DT_ALTA between  '01-JUL-2010' and '09-NOV-2010'
        and I.CD_ALTA not in ( 1000, 999)
        and I.CODCON in ('SW38','SW32') 
        AND CNV.CAD_CNV_CD_HAC_PRESTADOR=I.CODCON
        and not exists (   select 'x' from TB_INTERNADO_PARCELA P
            where P.NR_SEQINTER = I.NR_SEQINTER)
        and not exists ( select 'X' from TB_INTERNADO_FATURADO F
            where F.NR_SEQINTER = I.NR_SEQINTER)
        UNION
        select I.CODCON, I.NR_SEQINTER ATD_ATE_ID, I.In_Int_Ext ATD_ATE_TP_PACIENTE, P.DT_INT,P.DT_ALTA,CNV.CAD_CNV_ID_CONVENIO
        from
        TB_INTERNADO I,  TB_CAD_CNV_CONVENIO CNV,     TB_INTERNADO_PARCELA P,
        TB_INTERNADO_FATURADO F, TB_ATD_ATE_ATENDIMENTO ATD 
        where P.DT_ALTA between  '01-JUL-2010' and '09-NOV-2010'
        and I.CD_ALTA NOT IN ( 1000, 999)
        and I.CODCON = CNV.CAD_CNV_CD_HAC_PRESTADOR
        and I.CODCON in ('SW38','SW32')
        and I.NR_SEQINTER = P.NR_SEQINTER
        and F.NR_SEQINTER= P.NR_SEQINTER
        and F.TP_COBRANCA = P.TP_COBRANCA
        and F.DT_FATURAMENTO IS NULL 
        AND ATD.ATD_ATE_ID=F.NR_SEQINTER
        UNION
        select I.CODCON,I.NR_SEQINTER ATD_ATE_ID, I.In_Int_Ext ATD_ATE_TP_PACIENTE, P.DT_INT,P.DT_ALTA,CNV.CAD_CNV_ID_CONVENIO        
        from
        TB_INTERNADO I,   TB_CAD_CNV_CONVENIO CNV,     TB_INTERNADO_PARCELA P, TB_ATD_ATE_ATENDIMENTO ATD
        where P.DT_ALTA between '01-MAR-2010' and '09-NOV-2010'
        and I.CD_ALTA NOT IN ( 1000, 999)
        and I.CODCON = CNV.CAD_CNV_CD_HAC_PRESTADOR
        and I.CODCON in ('SW38','SW32')
        and I.NR_SEQINTER = P.NR_SEQINTER 
        AND I.NR_SEQINTER=ATD.ATD_ATE_ID
        and not exists ( select 'X'  from TB_INTERNADO_FATURADO F
        where F.NR_SEQINTER= P.NR_SEQINTER
        and F.TP_COBRANCA = P.TP_COBRANCA);
        io_cursor := v_cursor;
   END IF;
end PRC_MTMD_MOV_HIST_ATENDIMENTOS;
