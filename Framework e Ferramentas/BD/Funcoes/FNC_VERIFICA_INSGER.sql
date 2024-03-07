CREATE OR REPLACE FUNCTION BENEFICIARIO.FNC_VERIFICA_INSGER
(
  sCodCon in char,
  nCodEst in number,
  nCodBen in number,
  nCodSeqBen in number
)
RETURN NUMBER
AS
nQtd number(2) := 0;
nIdade number(3);
--
BEGIN
--
  IF substr(sCodCon,1,3) = 'PVS' OR sCodCon = 'AE02' THEN
    return 1; -- Todos do Plano Viva Saude (PVS) participam do Instituto de Geriatria // 1 = Viva Saude
  ELSE
   SELECT COUNT(*)
   into nQtd
   FROM BNF_BENEFICIARIO b, BNF_BENEF_PROGRAMA p
   WHERE b.CODCON = sCodCon
   and b.CODEST = nCodEst
   and b.CODBEN = nCodBen
   and b.CODSEQBEN = nCodSeqBen
   and b.CODCON = p.CODCON
   and b.CODEST = p.CODEST
   and b.CODBEN = p.CODBEN
   and b.CODSEQBEN = p.CODSEQBEN
   and p.CD_PROGRAMA = 8 -- Estac?o Saude
   and p.DT_FIM_PROGRAMA is null; -- Ativo no programa
   IF nQtd > 0 THEN
     return 2; -- Todos Estac?o Saude participam do Instituto de Geriatria // 2 = Estac?o Saude/Cronicos
   ELSE
     SELECT trunc((months_between(sysdate, b.datnasben))/12)
     into nIdade
     FROM bnf_beneficiario b
     WHERE b.CODCON = sCodCon
       and b.CODEST = nCodEst
       and b.CODBEN = nCodBen
       and b.CODSEQBEN = nCodSeqBen;
     if nIdade >= 60 then
      return 3; -- Implantac?o para o instituto de geriatria 27/08/2013 - Fonseca
     else
      return 0; -- N?o participante
     end if;
   END IF; -- Fim Estac?o Saude
  END IF; -- Fim PVS
END;
 