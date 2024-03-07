CREATE OR REPLACE PROCEDURE PRC_CAD_END_MIGRA_ASSOC
IS
  /********************************************************************
  *    Procedure: PRC_CAD_END_MIGRA_ASSOC
  *
  *    Data Criacao:   15/04/2009   Por: Cristiane Gomes da Silva
  *    Data Alteracao:              Por: 
  *
  *    Funcao: Migra ID pessoa de associação para a tabela de enderecos
  *
  *******************************************************************/
BEGIN
 FOR PEE IN
 (SELECT PEE.CAD_END_ID_ENDERECO, PEE.CAD_PES_ID_PESSOA
 FROM TB_ASS_PEE_PESSOA_ENDERECO PEE) LOOP
      BEGIN
            UPDATE TB_CAD_END_ENDERECO ENDERECO
            SET ENDERECO.CAD_PES_ID_PESSOA = PEE.CAD_PES_ID_PESSOA
            WHERE ENDERECO.CAD_END_ID_ENDERECO = PEE.CAD_END_ID_ENDERECO;
      EXCEPTION WHEN NO_DATA_FOUND THEN
                NULL;
      END;
 END LOOP;
 commit;
END PRC_CAD_END_MIGRA_ASSOC;
/