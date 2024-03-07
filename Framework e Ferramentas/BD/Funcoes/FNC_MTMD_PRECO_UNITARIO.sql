CREATE OR REPLACE FUNCTION "FNC_MTMD_PRECO_UNITARIO"
(
     pCAD_MTMD_ID         IN sgs.tb_mtmd_historico_nota_fiscal.cad_mtmd_id%TYPE,
     pCAD_MTMD_FILIAL_ID  IN sgs.tb_mtmd_historico_nota_fiscal.CAD_MTMD_FILIAL_ID%TYPE
)
 RETURN NUMBER IS
 -- RETORNA ÚLTIMO PREÇO UNITÁRIO DO PRODUTO (VALOR QUE ENTROU NA NOTA)
 nFilial  NUMBER;
 nRetorno NUMBER;
BEGIN

    nFilial := FNC_MTMD_RETORNA_FILIAL (pCAD_MTMD_ID, pCAD_MTMD_FILIAL_ID, NULL);

    BEGIN
        select nvl(mtmd_preco_unitario,0)
        into   nRetorno
        from (select mtmd_preco_unitario
        from tb_mtmd_historico_nota_fiscal t
        where cad_mtmd_id = pCAD_MTMD_ID and
              CAD_MTMD_FILIAL_ID = nFilial
        order by t.mtmd_data_prc_medio desc)
        where rownum = 1;
    EXCEPTION WHEN NO_DATA_FOUND THEN
       nRetorno := 0;
    END;

   RETURN nRetorno;
END FNC_MTMD_PRECO_UNITARIO;

 
