declare
  md5_id_out integer;
  md5_id number;
  id_usuario_desativacao number;
  dt_usuario_desativacao date; 
  msg_erro varchar(2000);
begin

  FOR cursor_MD5 IN(
    SELECT DISTINCT fnc_hash_md5(LTRIM(RTRIM(PES.CAD_PES_NM_PESSOA)) || 
                                 TO_CHAR(PES.CAD_PES_DT_NASCIMENTO, 'ddMMyyyy') || 
                                 PES.CAD_PES_TP_SEXO) AS MD5,
           PES.CAD_PES_ID_PESSOA,
           LTRIM(RTRIM(PES.CAD_PES_NM_PESSOA)) AS CAD_PES_NM_PESSOA,
           PES.CAD_PES_DT_NASCIMENTO AS DT_NASC,
           PES.CAD_PES_TP_SEXO,
           TRUNC(SYSDATE) DT_CRIACAO,
           1 AS USUARIO_ID                  
      FROM TB_CAD_PES_PESSOA PES
     INNER JOIN TB_CAD_PAC_PACIENTE PAC
        ON PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA 
     WHERE PES.CAD_PES_FL_JURIDICA_OK = 'N'
        -- *********** A T E N Ç Ã O ************************
        -- a linha abaixo é somente para não atualizar todos!
--       AND PES.CAD_PES_DT_ULTIMA_ATUALIZACAO BETWEEN TRUNC(SYSDATE -340) AND TRUNC(SYSDATE-1) -- somente para não atualizar todos!
        -- a linha acima é somente para não atualizar todos!
        -- *********** A T E N Ç Ã O ************************
       AND PES.CAD_PES_ID_PESSOA NOT IN (SELECT PES_MD5.CAD_PES_ID_PESSOA FROM TB_ASS_PMD_PESSOA_MD5 PES_MD5))

  LOOP
       BEGIN
         prc_ass_pmd_pessoa_md5_i(md5_id_out,
                                  md5_id,
                                  cursor_MD5.MD5,
                                  cursor_MD5.CAD_PES_ID_PESSOA,
                                  cursor_MD5.CAD_PES_NM_PESSOA,
                                  cursor_MD5.DT_NASC,
                                  cursor_MD5.CAD_PES_TP_SEXO,
                                  cursor_MD5.DT_CRIACAO,
                                  dt_usuario_desativacao,
                                  cursor_MD5.USUARIO_ID,
                                  id_usuario_desativacao);
/*          dbms_output.put_line('Criando registro... ' || 
                                       '' || cursor_MD5.MD5 || ',  ' ||
                                       '' || cursor_MD5.CAD_PES_ID_PESSOA || ',  ' ||
                                       '' || cursor_MD5.CAD_PES_NM_PESSOA || ',  ' ||
                                       '' || cursor_MD5.DT_NASC || ',  ' ||
                                       '' || cursor_MD5.CAD_PES_TP_SEXO || ',  ' ||
                                       '' || cursor_MD5.DT_CRIACAO || ',  ' ||
                                       '' || cursor_MD5.USUARIO_ID ); */
        EXCEPTION
          WHEN OTHERS THEN
            msg_erro := 'ERRO AO GERAR: ' || 
                                         '' || cursor_MD5.MD5 || ',  ' ||
                                         '' || cursor_MD5.CAD_PES_ID_PESSOA || ',  ' ||
                                         '' || cursor_MD5.CAD_PES_NM_PESSOA || ',  ' ||
                                         '' || cursor_MD5.DT_NASC || ',  ' ||
                                         '' || cursor_MD5.CAD_PES_TP_SEXO || ',  ' ||
                                         '' || cursor_MD5.DT_CRIACAO || ',  ' ||
                                         '' || cursor_MD5.USUARIO_ID;  
            dbms_output.put_line(msg_erro); 
            -- raise_application_error(-2000, msg_erro);
          END;
  END LOOP;
end;
