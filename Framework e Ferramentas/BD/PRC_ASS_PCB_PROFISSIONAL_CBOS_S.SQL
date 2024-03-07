  create or replace procedure PRC_ASS_PCB_PROF_CBOS_S 
  (
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCB_PROFISSIONAL_CBOS.CAD_PRO_ID_PROFISSIONAL%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /**********************************************************************
  *    Procedure: PRC_ASS_PCB_PROF_CBOS_S
  * 
  *    Data Criacao: 	 29/06/2007           Por: Guilherme Holdack
  *    Data Alteracao: 02/10/2007           Por: Carlos Araujo
  *    Alteração: Inclusão de retorno dos campos de Especialidade para melhorar performance 
  *               e diminuir o acesso as classes dao
  *
  *    Funcao: Selecionar registros da tabela TB_ASS_PCB_PROFISSIONAL_CBOS                                                   
  *
  ***********************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       PCB.ASS_PCB_DS_OBS,
       PCB.ASS_PCB_FL_STATUS,
       PCB.TIS_CBO_CD_CBOS,
       PCB.CAD_PRO_ID_PROFISSIONAL,
       PCB.SEG_USU_ID_USUARIO,
       PCB.ASS_PCB_DT_ULTIMA_ATUALIZACAO,
       CBO.*
    FROM TB_ASS_PCB_PROFISSIONAL_CBOS PCB,
         TB_TIS_CBO_CBOS CBO
    WHERE
        PCB.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
    AND (pTIS_CBO_CD_CBOS is null OR PCB.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
    AND (pCAD_PRO_ID_PROFISSIONAL is null OR PCB.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL);          
    io_cursor := v_cursor;
  end PRC_ASS_PCB_PROF_CBOS_S;