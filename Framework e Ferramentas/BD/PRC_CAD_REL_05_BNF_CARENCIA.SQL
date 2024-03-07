CREATE OR REPLACE PROCEDURE "PRC_CAD_REL_05_BNF_CARENCIA" (
     pCODCON in BNF_BENEFICIARIO.CODCON%TYPE DEFAULT NULL,
     pCODEST in BNF_BENEFICIARIO.CODEST%TYPE DEFAULT NULL,
     pCODBEN in BNF_BENEFICIARIO.CODBEN%TYPE DEFAULT NULL,
     pCODSEQBEN in BNF_BENEFICIARIO.CODSEQBEN%TYPE DEFAULT NULL,

     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/*********************************************************************************
*    Procedure: PRC_CAD_REL_05_BNF_CARENCIA
*
*    Data Criacao:  10/10/2014  Por: PEDRO
*
*    Funcao: Carregar os Tipos de Saida
*
**********************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR


    SELECT 'C' TIPO, -- CARENCIAS
           TO_CHAR(B.CODSER) CODSER,
           S.NOMSER,
           B.DATFIMCAR,
           BNF.NOMBEN,
           to_date(BNF.DATNASBEN) DATNASBEN,
           BNF.SEXBEN
    FROM   BNF_CARENCIA_BENEFICIARIO B,
           BNF_SERVICO S,
           BNF_BENEFICIARIO BNF

    WHERE  B.CODCON = pCODCON
    AND    B.CODEST = pCODEST
    AND    B.CODBEN = pCODBEN
    AND    B.CODSEQBEN = pCODSEQBEN
    AND    S.CODSER = B.CODSER

    AND    B.CODCON = BNF.CODCON
    AND    B.CODEST = BNF.CODEST
    AND    B.CODBEN = BNF.CODBEN
    AND    B.CODSEQBEN = BNF.CODSEQBEN


    UNION

    SELECT 'CPT' TIPO, --COBERTURA PARCIAL TEMPORARIA CPT
           A.CID,
           B.CAD_CID_DS_CID10 DESCID,
           A.DATLIMITE,

           BNF.NOMBEN,
           to_date(BNF.DATNASBEN) DATNASBEN,
           BNF.SEXBEN

   FROM   BNF_BENDEPAGRAV A
    JOIN   BNF_BENEFICIARIO BNF ON A.CODCON = BNF.CODCON
                               AND A.CODEST = BNF.CODEST
                               AND A.CODBEN = BNF.CODBEN
                               AND A.CODSEQBEN = BNF.CODSEQBEN 
    LEFT JOIN TB_CAD_CID_CID10 B ON TRIM(A.CID) = TRIM(B.CAD_CID_CD_CID10)

    WHERE  A.CODCON = pCODCON
    AND    A.CODEST = pCODEST
    AND    A.CODBEN = pCODBEN
    AND    A.CODSEQBEN = pCODSEQBEN
    
    ORDER BY 1,3;

io_cursor := v_cursor;
end PRC_CAD_REL_05_BNF_CARENCIA;
