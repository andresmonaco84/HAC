CREATE OR REPLACE PROCEDURE PRC_CAD_TEL_MIGRA_ASSOC
IS
  /********************************************************************
  *    Procedure: PRC_CAD_TEL_MIGRA_ASSOC
  *
  *    Data Criacao:   15/04/2009   Por: Cristiane Gomes da Silva
  *    Data Alteracao:              Por: 
  *
  *    Funcao: Migra ID pessoa de associação para a tabela de telefones
  *
  *******************************************************************/
BEGIN
 FOR PTE IN
 (SELECT PTE.CAD_TEL_ID_TELEFONE, PTE.CAD_PES_ID_PESSOA
 FROM TB_ASS_PTE_PESSOA_TELEFONE PTE) LOOP
      BEGIN
            UPDATE TB_CAD_TEL_TELEFONE TEL
            SET TEL.CAD_PES_ID_PESSOA = PTE.CAD_PES_ID_PESSOA
            WHERE TEL.CAD_TEL_ID_TELEFONE = PTE.CAD_TEL_ID_TELEFONE;
      EXCEPTION WHEN NO_DATA_FOUND THEN
                NULL;
      END;
 END LOOP;
 commit;
END PRC_CAD_TEL_MIGRA_ASSOC;
/