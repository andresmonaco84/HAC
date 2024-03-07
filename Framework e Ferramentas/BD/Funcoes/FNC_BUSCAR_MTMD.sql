create or replace function FNC_BUSCAR_MTMD(
 pCAD_MTMD_PRIATI_SAL_DSC in TB_CAD_MTMD_MAT_MED.CAD_MTMD_PRIATI_SAL_DSC%type,
 pCAD_MTMD_FORMA_FARMACEUTICA  in TB_CAD_MTMD_MAT_MED.CAD_MTMD_FORMA_FARMACEUTICA%type,
 pCAD_MTMD_DOSAGEM_PADRONIZADA  in TB_CAD_MTMD_MAT_MED.CAD_MTMD_DOSAGEM_PADRONIZADA%type

)
/*
Buscar o paciente atual (com alta ou nao) de uma internacao
*/
 return NUMBER is
 Result NUMBER;
begin


    SELECT M.CAD_MTMD_ID
                          into result
                 FROM TB_CAD_MTMD_MAT_MED m

                 WHERE m.CAD_MTMD_PRIATI_SAL_DSC = pCAD_MTMD_PRIATI_SAL_DSC
                 AND M.CAD_MTMD_FORMA_FARMACEUTICA = pCAD_MTMD_FORMA_FARMACEUTICA
                 AND M.CAD_MTMD_DOSAGEM_PADRONIZADA = pCAD_MTMD_DOSAGEM_PADRONIZADA
                 AND M.CAD_MTMD_FL_ATIVO = 1 AND M.CAD_MTMD_GRUPO_ID = 1
                 and rownum =1
           ;


  return(Result);
end FNC_BUSCAR_MTMD;
