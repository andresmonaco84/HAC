CREATE OR REPLACE PROCEDURE PRC_ATE_REGRA_PSICOLOGIA
(
       pTIS_CBO_CD_CBOS in TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
        io_cursor OUT PKG_CURSOR.t_cursor--,
 )
 IS
         v_cursor PKG_CURSOR.t_cursor;
begin 
 
OPEN v_cursor FOR

    select RMP.TIS_CBO_CD_CBOS 
  from SGS.TB_SEG_RMP_REST_MOD_PER_ESPEC RMP
  WHERE RMP.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
   ;   
   
 io_cursor := v_cursor;
 
end PRC_ATE_REGRA_PSICOLOGIA;
