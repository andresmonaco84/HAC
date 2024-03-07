create or replace procedure PRC_ASS_USS_UNID_LOCAL_SALA_S
  (
     pASS_USS_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.ASS_USS_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_SET_ID IN TB_ASS_USS_UNID_LOC_SET_SALA.CAD_SET_ID%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USS_UNID_LOCAL_SALA_S
  *
  *    Data Criacao:   13/01/2008           Por: Davi S. M. dos Reis
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Listar as Associacoes de Unidade x Local x Setor x Sala
  *
  *    Data Alteracao:  08/07/2008  Por: Davi S. M. dos Reis
  *    Alteração: Acerto na comparacao do setor
  *
  *    Data Alteracao:  05/08/2008  Por: Fabiola R. Lopes
  *    Alteracao:       ref. task 3471 - A tela deixou de ser listbox
  *
  *    Data Alteracao:  15/10/2008  Por: Fabiola R. Lopes
  *    Alteracao:       trazer a descrição da sala ref. task  4183   
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  begin
      OPEN v_cursor FOR
      SELECT DISTINCT
         USS.ASS_USS_ID,
         USS.CAD_UNI_ID_UNIDADE,
         USS.CAD_LAT_ID_LOCAL_ATENDIMENTO,
         USS.CAD_SET_ID,
         USS.AGE_SAU_ID,
         USS.ASS_USS_FL_STATUS,
         USS.SEG_USU_ID_USUARIO,
         USS.ASS_USS_DT_ULTIMA_ATUALIZACAO,
         SAU.AGE_SAU_CD_ANDAR,
         SAU.AGE_SAU_NR_SALA,
         SAU.AGE_SAU_DS_SALA
      FROM TB_ASS_USS_UNID_LOC_SET_SALA USS
     INNER JOIN TB_AGE_SAU_SALA_UNID_AND SAU
        ON USS.AGE_SAU_ID = SAU.AGE_SAU_ID
     WHERE 
            (pASS_USS_ID is null OR ASS_USS_ID = pASS_USS_ID)
       AND  (pCAD_UNI_ID_UNIDADE IS NULL OR USS.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
       AND  (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR USS.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
       AND  (pCAD_SET_ID IS NULL OR USS.CAD_SET_ID = pCAD_SET_ID)
       AND  (USS.ASS_USS_FL_STATUS = 'A');
       
    io_cursor := v_cursor;
    
  end PRC_ASS_USS_UNID_LOCAL_SALA_S;
/  
