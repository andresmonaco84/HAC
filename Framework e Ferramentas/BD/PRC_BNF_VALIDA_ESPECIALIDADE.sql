CREATE OR REPLACE PROCEDURE PRC_BNF_VALIDA_ESPECIALIDADE
(
       pCODCON IN BNF_CARENCIA_BENEFICIARIO.CODCON%TYPE,
       pCD_ESPECIALIDADE IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
       io_cursor OUT PKG_CURSOR.t_cursor
)

IS
       v_cursor PKG_CURSOR.t_cursor;
       vCBOHAC varchar2(3);
       vCodPlano char(1);
       vCodTipoEmp varchar2(20);
BEGIN
   
   SELECT DECODE(TO_NUMBER( TO_CHAR( DATCON, 'YYYY')) - 1999, ABS(TO_NUMBER( TO_CHAR( DATCON, 'YYYY')) - 1999 ), 'P', 'A'), CODTIPEMP 
   INTO vCodPlano, vCodTipoEmp
   FROM EMPRESA   
   WHERE CODCON = (pCODCON);
   
   SELECT CBO.TIS_CBO_CD_CBOS_HAC INTO vCBOHAC FROM TB_TIS_CBO_CBOS CBO WHERE CBO.TIS_CBO_CD_CBOS = pCD_ESPECIALIDADE;

   OPEN v_cursor FOR
   SELECT COUNT(*) AS RETORNO
   FROM TB_AUT_EXC_ESPECIALIDADE
   WHERE CD_PLANO_BENEFICIARIO = vCodPlano
   AND CD_ESPECIALIDADE = vCBOHAC
   AND CODTIPEMP = vCodTipoEmp;
   
   io_cursor := v_cursor;
   
END PRC_BNF_VALIDA_ESPECIALIDADE;
