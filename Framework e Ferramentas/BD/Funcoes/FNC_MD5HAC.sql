CREATE OR REPLACE FUNCTION "FNC_MD5HAC" (pNome in varchar, pSexo in varchar, pDataNascimento in date)
 return varchar is
  Result varchar2(200);
begin

SELECT md5(replace(pNome,' ', '') || to_char(pDataNascimento,'ddMMyyyy') || pSexo)
INTO RESULT
FROM dual;

 return(Result);

end FNC_MD5HAC;
  