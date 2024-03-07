create or replace procedure PRC_ASS_PLC_PLANO_CBOS_U
  (
     pCAD_PLA_ID_PLANO         IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type,
     pTIS_CBO_CD_CBOS          IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type,
     pSEG_USU_ID_USUARIO       IN TB_ASS_PLC_PLANO_CBOS.SEG_USU_ID_USUARIO%type,
     pASS_PLC_FL_STATUS        IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_STATUS%type,
     pASS_PLC_FL_ENCAMINHA_OK  IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_ENCAMINHA_OK%type DEFAULT NULL,
     pASS_PLC_FL_EXIGE_SENHA_OK IN TB_ASS_PLC_PLANO_CBOS.ASS_PLC_FL_EXIGE_SENHA_OK%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_PLANO_CBOS_U
  *
  *    Data Criacao: 	16/08/2007   Por: Adnrea Cazuca
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Altera Associacao Plano X Especialidade
  *
  *    Data Alteragco:	09/11/07	Por: Bruno Costa
  *	   Ateragco:		Inclusco de um campo
  *
  *	   Data Alteragco:  23/11/2007  Por: Fabmola
  *    Alteragco:       Corregco - Inclusco do campo ASS_PLC_FL_STATUS no UPDATE que recebe como parbmetro
  *                     na procedure e nco era atualizado no update.
  *******************************************************************/
  begin
    UPDATE TB_ASS_PLC_PLANO_CBOS
    SET
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_PLC_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        ASS_PLC_FL_STATUS = pASS_PLC_FL_STATUS,
        ASS_PLC_FL_ENCAMINHA_OK = pASS_PLC_FL_ENCAMINHA_OK,
        ASS_PLC_FL_EXIGE_SENHA_OK = pASS_PLC_FL_EXIGE_SENHA_OK
    WHERE
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;
  end PRC_ASS_PLC_PLANO_CBOS_U;