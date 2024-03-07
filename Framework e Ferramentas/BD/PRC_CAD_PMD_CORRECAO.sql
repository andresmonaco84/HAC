CREATE OR REPLACE PROCEDURE "PRC_CAD_PMD_CORRECAO"
  (
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PAT_PACIEATEND.CAD_PAC_ID_PACIENTE%type
  )
  is
  /********************************************************************
  *    Procedure: CAD_PMD_CORRECAO
  *
  *    Data Criacao:  09/01/2012   Por: Pedro
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Utilidade: Corrigir problemas de cadastro com MD5 não detectados na aplicação
  *
  *
  *******************************************************************/

  begin

--DESATIVA MD5 DUPLICADO
declare
  cursor md5_DESATIVA  is
    select pmd.cad_pes_id_pessoa, count(pmd.CAD_PES_ID_PESSOA)
      from tb_ass_pmd_pessoa_md5 pmd, TB_CAD_PAC_PACIENTE PAC
     where pmd.ass_pmd_dt_desativacao is null
     AND   PAC.CAD_PES_ID_PESSOA = PMD.CAD_PES_ID_PESSOA
     AND   PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE     ------------
     group by pmd.cad_pes_id_pessoa
    having count(pmd.CAD_PES_ID_PESSOA) > 1;
  v_ass_pmd_id               number;
  v_cad_pes_id_pessoa        number;
  v_ass_pmd_dt_desativacao   date;
  v_ass_pmd_id_usuario_desat number;
begin
  for i in md5_DESATIVA loop
    v_cad_pes_id_pessoa        := i.cad_pes_id_pessoa;
    v_ass_pmd_id               := null;
    v_ass_pmd_dt_desativacao   := null;
    v_ass_pmd_id_usuario_desat := null;
    for j in (select pmd.cad_pes_id_pessoa,
                     pmd.ass_pmd_id,
                     pmd.ass_pmd_dt_criacao,
                     pmd.seg_usu_id_usuario_criacao
                from tb_ass_pmd_pessoa_md5 pmd
               where pmd.cad_pes_id_pessoa = i.cad_pes_id_pessoa
               order by pmd.ass_pmd_id desc) loop
      if v_cad_pes_id_pessoa != j.cad_pes_id_pessoa then
        v_ass_pmd_id := null;
      end if;
      if (v_cad_pes_id_pessoa = j.cad_pes_id_pessoa and
         v_ass_pmd_id != j.ass_pmd_id and v_ass_pmd_id is not null) then
        update tb_ass_pmd_pessoa_md5 pmd
           set pmd.ass_pmd_dt_desativacao         = v_ass_pmd_dt_desativacao,
               pmd.seg_usu_id_usuario_desativacao = v_ass_pmd_id_usuario_desat
         where pmd.ass_pmd_id = j.ass_pmd_id;
      end if;
      v_ass_pmd_id               := j.ass_pmd_id;
      v_ass_pmd_dt_desativacao   := j.ass_pmd_dt_criacao;
      v_ass_pmd_id_usuario_desat := j.seg_usu_id_usuario_criacao;
    end loop;
  end loop;
end;



--REATIVAR ULTIMO MD4 DA PESSOA
declare
  cursor md5_REATIVA is
    select distinct pac.cad_pes_id_pessoa,
                    pes.cad_pes_nm_pessoa,
                    pes.cad_pes_dt_nascimento,
                    pes.cad_pes_tp_sexo,
                    pes.cad_pes_dt_ultima_atualizacao
      from tb_cad_pac_paciente pac, tb_cad_pes_pessoa pes
     where not exists (select pmd.cad_pes_id_pessoa
              from tb_ass_pmd_pessoa_md5 pmd
             where pmd.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
               and pmd.ass_pmd_dt_desativacao is null)
       and pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
       and pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE ; ----------
  v_ass_pmd_id     number;
  v_ASS_PMD_CD_MD5 varchar2(32);
begin
  for i in md5_REATIVA loop
    SELECT MAX(PMD.ASS_PMD_ID)
      INTO v_ass_pmd_id
      FROM TB_ASS_PMD_PESSOA_MD5 PMD
     WHERE PMD.CAD_PES_ID_PESSOA = I.cad_pes_id_pessoa;
--
    UPDATE TB_ASS_PMD_PESSOA_MD5 PMD
       SET PMD.ASS_PMD_DT_DESATIVACAO         = NULL,
           PMD.SEG_USU_ID_USUARIO_DESATIVACAO = NULL
     WHERE PMD.CAD_PES_ID_PESSOA = I.cad_pes_id_pessoa
     and pmd.ass_pmd_id = v_ass_pmd_id;
  end loop;
end;

--GERA MD5 PARA PESSOA SEM NENHUM MD5
declare
  cursor md5_GERACAO is
    select distinct pac.cad_pes_id_pessoa,
                    pes.cad_pes_nm_pessoa,
                    pes.cad_pes_dt_nascimento,
                    pes.cad_pes_tp_sexo,
                    pes.cad_pes_dt_ultima_atualizacao
      from tb_cad_pac_paciente pac, tb_cad_pes_pessoa pes
     where not exists (select pmd.cad_pes_id_pessoa
              from tb_ass_pmd_pessoa_md5 pmd
             where pmd.cad_pes_id_pessoa = pes.cad_pes_id_pessoa)
       and pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
       and pac.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE ;     ------------
  v_ass_pmd_id     number;
  v_ASS_PMD_CD_MD5 varchar2(32);
begin
  for i in md5_GERACAO loop
    SELECT fnc_hash_md5(REPLACE(UPPER(i.cad_pes_nm_pessoa), ' ', '') ||
                        TO_CHAR(i.cad_pes_dt_nascimento, 'ddMMyyyy') ||
                        i.cad_pes_tp_sexo)
      into v_ASS_PMD_CD_MD5
      FROM DUAL;
    select seq_ass_pmd_01.nextval into v_ass_pmd_id from dual;
    insert into tb_ass_pmd_pessoa_md5 pmd
      (ASS_PMD_ID,
       ASS_PMD_CD_MD5,
       CAD_PES_ID_PESSOA,
       ASS_PMD_NM_PESSOA,
       ASS_PMD_DT_NASCIMENTO,
       ASS_PMD_TP_SEXO,
       ASS_PMD_DT_CRIACAO,
       ASS_PMD_DT_DESATIVACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       SEG_USU_ID_USUARIO_DESATIVACAO)
    values
      (v_ass_pmd_id,
       v_ASS_PMD_CD_MD5,
       i.cad_pes_id_pessoa,
       i.cad_pes_nm_pessoa,
       i.cad_pes_dt_nascimento,
       i.cad_pes_tp_sexo,
       sysdate,
       null,
       1,
       null);
  end loop;
end;
   

  end PRC_CAD_PMD_CORRECAO;
 