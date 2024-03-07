create or replace procedure PRC_CAD_PRO_PROF_CBOS_S
  (
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type default null,     
     pASS_PCB_FL_STATUS IN TB_ASS_PCB_PROFISSIONAL_CBOS.ASS_PCB_FL_STATUS%type default null,
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL ,      
     pCAD_PRO_NR_CONSELHO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NR_CONSELHO%type DEFAULT NULL,
     pCAD_PRO_SG_UF_CONSELHO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_SG_UF_CONSELHO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PRO_PROF_CBOS_S
  * 
  *    Data Criacao: 	  10/07/2007           Por: Carlos Araujo
  *
  *    Data Alteracao:	26/10/2007           Por: Andrea Cazuca
  *    Alteracao:  Incluido parametro Crm na pesquisa
  *
  *    Funcao: Lista Profissional por Especialidade
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alteração: Remoção de Upper em campo, no where
  *
  *    Data Alteracao: 15/01/2008  Por: Andrea Cazuca
  *    Alteração: Incluindo parametro UF na pesquisa
  *
  *    Data Alteracao: 12/02/2009  Por: pEDRO
  *    Alteração: Incluindo parametro PRO.CAD_PRO_FL_PERM_EXAME_OK,
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
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
       PES.*
    FROM TB_CAD_PRO_PROFISSIONAL PRO,
         TB_ASS_PCB_PROFISSIONAL_CBOS PCB,
         TB_CAD_PES_PESSOA PES
    WHERE
        PRO.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA   
    AND PRO.CAD_PRO_ID_PROFISSIONAL = PCB.CAD_PRO_ID_PROFISSIONAL
    AND (pTIS_CBO_CD_CBOS is null OR PCB.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
    AND (pASS_PCB_FL_STATUS is null OR PCB.ASS_PCB_FL_STATUS = pASS_PCB_FL_STATUS)        
    AND (pCAD_PES_NM_PESSOA IS NULL OR PES.CAD_PES_NM_PESSOA LIKE UPPER( pCAD_PES_NM_PESSOA ) )
    AND (pCAD_PRO_NR_CONSELHO is null or PRO.CAD_PRO_NR_CONSELHO = pCAD_PRO_NR_CONSELHO)
    AND (pCAD_PRO_SG_UF_CONSELHO is null or PRO.CAD_PRO_SG_UF_CONSELHO = pCAD_PRO_SG_UF_CONSELHO)
    ORDER BY PES.CAD_PES_NM_PESSOA;
        
    io_cursor := v_cursor;
  end PRC_CAD_PRO_PROF_CBOS_S;
/
