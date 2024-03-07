create or replace procedure PRC_CAD_PSF_PROF_SERV_FREQ_I
(
     pCAD_PSF_ID IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_ID%type,
     pCAD_PSF_NM_SERVICO_FREQ IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_NM_SERVICO_FREQ%type,
     pCAD_PSF_NR_TELEFONE IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_NR_TELEFONE%type default NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_PSF_DT_ULTIMA_ATUALIZACAO IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_PSF_PROF_SERV_FREQ.SEG_USU_ID_USUARIO%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_PSF_PROF_SERV_FREQ_I
*
*    Data Criacao: 	15/07/2010   Por: André Souza Monaco
*    Data Alteracao:	  Por: 
*
*    Funcao: Insere serviços frequentados de profissional
*
*******************************************************************/
Idt integer;
begin

SELECT SEQ_PROF_SERV_FREQ.NextVal INTO Idt FROM DUAL;

INSERT INTO TB_CAD_PSF_PROF_SERV_FREQ
(
       CAD_PSF_ID,
       CAD_PSF_NM_SERVICO_FREQ,
       CAD_PSF_NR_TELEFONE,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PSF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     Idt,
	     pCAD_PSF_NM_SERVICO_FREQ,
	     pCAD_PSF_NR_TELEFONE,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pCAD_PSF_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
);

end PRC_CAD_PSF_PROF_SERV_FREQ_I;
