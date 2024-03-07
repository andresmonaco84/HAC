create or replace procedure PRC_ASS_USS_UNID_LOCAL_SALAT_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pCAD_SET_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_SET_ID%TYPE,
     pASS_USS_FL_STATUS IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_FL_STATUS%TYPE,
     pSEG_USU_ID_USUARIO IN TB_ASS_USS_UNID_LOC_SET_SALA.SEG_USU_ID_USUARIO%TYPE,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%TYPE
  )
  IS

  /********************************************************************
  *    Procedure: PRC_ASS_USS_UNID_LOCAL_SALAT_I
  *
  *    Data Criacao:   21/07/2008   Por: Fabiola Lopes
  *    Data Alteracao:  data da alteracao  Por: Nome do Analista
  *  
  *    Data Alteracao:  11/11/2008  Por: Pedro
  *    Alteração: Não permitir associar uma Sala já associada.
  *
  *    Funcao: Inclui a Associacao de todas as Salas para Unidade x Local
  *******************************************************************/

    lIdtRetorno integer;
   -- nCount integer;
    nCount2 integer;
    v_AGE_SAU_ID NUMBER;

  CURSOR cursor_salas is

    SELECT  SAU.AGE_SAU_ID
      FROM  TB_AGE_SAU_SALA_UNID_AND SAU
     WHERE  SAU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND  SAU.AGE_SAU_CD_ANDAR = pAGE_SAU_CD_ANDAR
       AND  SAU.AGE_SAU_FL_STATUS = 'A';

   BEGIN

   FOR X IN cursor_salas LOOP
    v_AGE_SAU_ID := X.AGE_SAU_ID;

   /* SELECT  COUNT(*)
      INTO  nCount
      FROM  TB_ASS_USS_UNID_LOC_SET_SALA USS
     WHERE  USS.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND  USS.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND  USS.CAD_SET_ID = pCAD_SET_ID
       AND  USS.AGE_SAU_ID = v_AGE_SAU_ID;
*/
    SELECT COUNT(*)
       INTO nCount2
       FROM TB_ASS_USS_UNID_LOC_SET_SALA USS
     WHERE  USS.AGE_SAU_ID = v_AGE_SAU_ID;

     IF (nCount2 > 0) then
       raise_application_error (-20001, 'Já existe associação para uma das Salas!');
     END IF;

    IF (nCount2 = 0) then

        SELECT SEQ_ASS_USS_01.NextVal INTO lIdtRetorno FROM DUAL;

        INSERT INTO TB_ASS_USS_UNID_LOC_SET_SALA
        (
          ASS_USS_ID,
          CAD_UNI_ID_UNIDADE,
          CAD_LAT_ID_LOCAL_ATENDIMENTO,
          CAD_SET_ID,
          AGE_SAU_ID,
          ASS_USS_FL_STATUS,
          ASS_USS_DT_ULTIMA_ATUALIZACAO,
          SEG_USU_ID_USUARIO
        )
        VALUES
        (
	        lIdtRetorno,
	        pCAD_UNI_ID_UNIDADE,
	        pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	        pCAD_SET_ID,
	        v_AGE_SAU_ID,
	        pASS_USS_FL_STATUS,
	        sysdate,
	        pSEG_USU_ID_USUARIO
        );

    END IF;

   END LOOP;

  EXCEPTION
   WHEN OTHERS THEN
        raise_application_error(SQLCODE, SQLERRM);

  pNewIdt := lIdtRetorno;

  end PRC_ASS_USS_UNID_LOCAL_SALAT_I;
/