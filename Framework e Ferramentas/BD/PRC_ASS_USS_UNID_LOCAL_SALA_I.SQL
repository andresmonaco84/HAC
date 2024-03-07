create or replace procedure PRC_ASS_USS_UNID_LOCAL_SALA_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_SET_ID%type,
     pAGE_SAU_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.AGE_SAU_ID%type,
     pASS_USS_FL_STATUS IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USS_UNID_LOC_SET_SALA.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USS_UNID_LOCAL_SALA_I
  *
  *    Data Criacao:   14/01/2008           Por: Davi S. M. dos Reis
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Incluir Associacao de Unidade x Local x Setor x Sala
  *
  *    Data Alteracao: 27/08/2008           Por: Fabíola Lopes
  *    Alteracao: Alteração do nome do parâmetro de pCAD_SET_ID_SETOR para pCAD_SET_ID
  *
  *    Data Alteracao: 11/11/2008           Por: Pedro
  *    Alteracao: não permitir cadastrar salas ja associadas
  * 
  *******************************************************************/
  lIdtRetorno integer;
  nCount integer;
  
  begin
  
   SELECT COUNT(*)
       INTO nCount
       FROM TB_ASS_USS_UNID_LOC_SET_SALA USS
     WHERE  USS.AGE_SAU_ID = pAGE_SAU_ID;

 IF nCount > 0 THEN
       raise_application_error (-20000, 'Já existe associação para essa Sala!');
    END IF;

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
       pAGE_SAU_ID,
       pASS_USS_FL_STATUS,
       sysdate,
       pSEG_USU_ID_USUARIO
    );
    

  pNewIdt := lIdtRetorno;
  end PRC_ASS_USS_UNID_LOCAL_SALA_I;
  /
