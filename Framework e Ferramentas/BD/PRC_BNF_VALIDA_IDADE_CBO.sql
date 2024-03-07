CREATE OR REPLACE PROCEDURE PRC_BNF_VALIDA_IDADE_CBO
(
       pCODCON IN BNF_CARENCIA_BENEFICIARIO.CODCON%TYPE,
       pCODEST IN BNF_BENEFICIARIO.CODEST%TYPE,
       pCODBEN IN BNF_BENEFICIARIO.CODBEN%TYPE,
       pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%TYPE,
       pCD_ESPECIALIDADE IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
       io_cursor OUT PKG_CURSOR.t_cursor
)

IS
       v_cursor PKG_CURSOR.t_cursor;
       vCBOHAC varchar2(3);
       vIdade number;
       vRetorno number;
       vRET VARCHAR2(3);
BEGIN

   SELECT CBO.TIS_CBO_CD_CBOS_HAC INTO vCBOHAC FROM TB_TIS_CBO_CBOS CBO
   WHERE CBO.TIS_CBO_CD_CBOS = pCD_ESPECIALIDADE;
    
   SELECT cast((cast((sysdate - BNF.DATNASBEN) as integer) / 365.25)as integer) INTO vIdade
   FROM BNF_BENEFICIARIO BNF
   WHERE
       BNF.CODCON = pCODCON
   AND BNF.CODEST = pCODEST
   AND BNF.CODBEN = pCODBEN
   AND BNF.CODSEQBEN = pCODSEQBEN;
  
   BEGIN   
   SELECT IDADE.CODESPMED INTO vRET 
   FROM TB_AUT_ESPEC_IDADE IDADE
   WHERE IDADE.CODESPMED = vCBOHAC
   AND vIdade BETWEEN IDADE.IDADE_INI AND IDADE.IDADE_FIM;

   SELECT COUNT(*) INTO vRetorno 
   FROM TB_AUT_ESPEC_IDADE IDADE
   WHERE IDADE.CODESPMED = vCBOHAC
   AND vIdade BETWEEN IDADE.IDADE_INI AND IDADE.IDADE_FIM;
   
   EXCEPTION WHEN NO_DATA_FOUND THEN
    vRetorno := 1;
   END;

   OPEN v_cursor FOR
   SELECT vRetorno AS RETORNO FROM DUAL;
   io_cursor := v_cursor;
END PRC_BNF_VALIDA_IDADE_CBO;
 