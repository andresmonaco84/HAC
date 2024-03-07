create or replace procedure PRC_REP_RCD_REGRA_CRED_I
(
     pNewIdt OUT integer,
     pREP_RCD_ID IN TB_REP_RCD_REGRA_CRED.REP_RCD_ID%type,
     pREP_RCD_TP_CREDENCIA_PROF IN TB_REP_RCD_REGRA_CRED.REP_RCD_TP_CREDENCIA_PROF%type,
     pREP_RCD_PC_CONTA IN TB_REP_RCD_REGRA_CRED.REP_RCD_PC_CONTA%type,
     pSEG_USU_ID_USUARIO IN TB_REP_RCD_REGRA_CRED.SEG_USU_ID_USUARIO%type,
     pREP_RCD_DT_ULTIMA_ATUALIZACAO IN TB_REP_RCD_REGRA_CRED.REP_RCD_DT_ULTIMA_ATUALIZACAO%type,
     pREP_RCD_DS_DESCRICAO IN TB_REP_RCD_REGRA_CRED.REP_RCD_DS_DESCRICAO%type
)
is
/********************************************************************
*    Procedure: PRC_REP_RCD_REGRA_CRED_I
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/

    lIdtRetorno integer;
begin
    SELECT seq_rep_rcd_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_REP_RCD_REGRA_CRED
(
       REP_RCD_ID,
       REP_RCD_TP_CREDENCIA_PROF,
       REP_RCD_PC_CONTA,
       SEG_USU_ID_USUARIO,
       REP_RCD_DT_ULTIMA_ATUALIZACAO,
			 REP_RCD_DS_DESCRICAO
)
VALUES
(
	     lIdtRetorno,
	     pREP_RCD_TP_CREDENCIA_PROF,
	     pREP_RCD_PC_CONTA,
	     pSEG_USU_ID_USUARIO,
	     pREP_RCD_DT_ULTIMA_ATUALIZACAO,
			 pREP_RCD_DS_DESCRICAO
);

  pNewIdt := lIdtRetorno;

end PRC_REP_RCD_REGRA_CRED_I;
