create or replace procedure PRC_CAD_PRO_PROF_UNI_LOC_CBO_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.TIS_CBO_CD_CBOS%type default null,          
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_PRO_ID_PROFISSIONAL%type default null,
     pASS_UCP_FL_STATUS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_FL_STATUS%type default null,
     pCAD_PRO_FL_ATIVO_OK IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_FL_ATIVO_OK%type default null,
     pID_PROFISSIONAL_EXCECAO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PRO_PROF_UNI_LOC_CBO_S
  * 
  *    Data Criacao: 	  10/07/2007           Por: Carlos Araujo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Lista Profissional por Unidade, Local Atendimento e Especialidade
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteracao: 27/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do modificador 'DISTINCT', na consulta
  *
  *    Data Alteracao: 12/02/2009  Por: pEDRO
  *    Alteração: Incluindo parametro PRO.CAD_PRO_FL_PERM_EXAME_OK,
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT DISTINCT
       PRO.CAD_PRO_ID_PROFISSIONAL,
       PRO.CAD_PRO_CD_CODCOOMED,
       PRO.CAD_PRO_CD_COD_PRO,
       PRO.CAD_PRO_NR_CONSELHO,
       PRO.CAD_PRO_SG_UF_CONSELHO,
       PRO.CAD_PRO_FL_ATIVO_OK,
       PRO.CAD_PRO_NM_APELIDO,
       PRO.CAD_PRO_DS_BIP_PAGER,
       PRO.CAD_PRO_FL_IMPR_RECIBO_OK,
       PRO.CAD_PRO_FL_STAFF_OK,
       PRO.CAD_PRO_CD_BANCO,
       PRO.CAD_PRO_CD_AGENCIA,
       PRO.CAD_PRO_CD_CONTA,
       PRO.CAD_PRO_FL_PERM_INTERN_OK,
       PRO.CAD_PRO_FL_PERM_ASS_LAUDO_OK,
       PRO.CAD_PRO_CD_MATRICULA,
       PRO.SEG_USU_ID_USUARIO,
       PRO.CAD_PES_ID_PESSOA,
       PRO.TIS_CPR_CD_CONSELHOPROF,
       PRO.CAD_PRO_FL_RESIDENTE_OK,
       PRO.CAD_PRO_NR_ANO_INI_RESIDENCIA,
       PRO.CAD_PRO_DT_INI_RESIDENCIA,
       PRO.CAD_PRO_DT_FIM_RESIDENCIA,
       PRO.CAD_PRO_FL_PERM_EXAME_OK,
       PRO.CAD_PRO_FL_PERM_EXAME_OK,
       PES.*
    FROM TB_CAD_PRO_PROFISSIONAL PRO,
         TB_ASS_UCP_UNID_LOC_CBO_PROF UCP,
         TB_CAD_PES_PESSOA PES
    WHERE
        PRO.CAD_PRO_ID_PROFISSIONAL = UCP.CAD_PRO_ID_PROFISSIONAL
    AND UCP.CAD_UNI_ID_UNIDADE      = pCAD_UNI_ID_UNIDADE
    AND UCP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND (pTIS_CBO_CD_CBOS is null or UCP.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)    
    AND PES.CAD_PES_ID_PESSOA            = PRO.CAD_PES_ID_PESSOA
    AND (pCAD_PRO_ID_PROFISSIONAL is null OR PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)        
    AND (pASS_UCP_FL_STATUS is null OR UCP.ASS_UCP_FL_STATUS = UPPER(pASS_UCP_FL_STATUS))
    AND (pCAD_PRO_FL_ATIVO_OK is null or PRO.CAD_PRO_FL_ATIVO_OK = UPPER(pCAD_PRO_FL_ATIVO_OK))
    AND (pID_PROFISSIONAL_EXCECAO is null or pro.cad_pro_id_profissional<> pID_PROFISSIONAL_EXCECAO);
    io_cursor := v_cursor;
  end PRC_CAD_PRO_PROF_UNI_LOC_CBO_S;
/
