 create or replace procedure PRC_CAD_PROFPESQUISA_S
(
     pTIS_CPR_CD_CONSELHOPROF IN TB_CAD_PRO_PROFISSIONAL.TIS_CPR_CD_CONSELHOPROF%type,
     pCAD_PRO_NM_NOME IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NM_NOME%type,
     pCAD_PRO_SG_UF_CONSELHO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_SG_UF_CONSELHO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/* Pesquisa Profissional Like */
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PRO_CD_CODCOOMED,
       CAD_PRO_CD_COD_PRO,
       CAD_PRO_NR_CONSELHO,
       CAD_PRO_SG_UF_CONSELHO,
       CAD_PRO_FL_ATIVO_OK,
       CAD_PRO_NM_APELIDO,
       CAD_PRO_DS_BIP_PAGER,
       CAD_PRO_FL_IMPR_RECIBO_OK,
       CAD_PRO_FL_STAFF_OK,
       CAD_PRO_CD_BANCO,
       CAD_PRO_CD_AGENCIA,
       CAD_PRO_CD_CONTA,
       CAD_PRO_FL_PERM_INTERN_OK,
       CAD_PRO_FL_PERM_ASS_LAUDO_OK,
       CAD_PRO_CD_MATRICULA,
       CAD_PRO_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_ID_PESSOA,
       TIS_CPR_CD_CONSELHOPROF,
       CAD_PRO_FL_RESIDENTE_OK,
       CAD_PRO_NR_ANO_INI_RESIDENCIA,
       CAD_PRO_DT_INI_RESIDENCIA,
       CAD_PRO_DT_FIM_RESIDENCIA,
       CAD_PRO_FL_PERM_EXAME_OK,
       CAD_PRO_NM_NOME,
       CAD_PRO_NM_SOCIEDADE_MEDICA,
       CAD_PRO_NM_HOSP_INTERNATO,
       CAD_PRO_NR_ANO_INTERNATO,
       CAD_PRO_NM_HOSP_RESIDENCIA,
       CAD_PRO_NR_ANO_RESIDENCIA,
       CAD_PRO_FL_RECONHECIDA_MEC,
       CAD_PRO_NM_ENTIDADE_CRED,
       CAD_PRO_NM_CARGO_ENSINO,
       CAD_PRO_DS_TRAB_PUBLICADO,
       CAD_PRO_NM_MED_REFERENCIA,
       CAD_PRO_DT_SOLICITACAO,
       CAD_PRO_DT_CADASTRO,
       CAD_PRO_DT_APROVACAO,
       CAD_PRO_NM_RESPONS_APROV,
       CAD_PRO_DT_INGR_CORPO_CLIN,
       CAD_PRO_FL_CRED_DIRETO_CONV,
       CAD_PRO_FL_TIPO_VINCULO,
       CAD_PRO_FL_STATUS_SOLIC,
       CAD_PRO_DS_OBSERVACAO
FROM TB_CAD_PRO_PROFISSIONAL
WHERE
        (TIS_CPR_CD_CONSELHOPROF = pTIS_CPR_CD_CONSELHOPROF) AND 
        (CAD_PRO_SG_UF_CONSELHO = pCAD_PRO_SG_UF_CONSELHO) AND
        (CAD_PRO_NM_NOME like pCAD_PRO_NM_NOME);
                
io_cursor := v_cursor;
end PRC_CAD_PROFPESQUISA_S;
