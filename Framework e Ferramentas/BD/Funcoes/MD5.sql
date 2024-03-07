CREATE OR REPLACE 
FUNCTION MD5 (param1 IN VARCHAR2) RETURN VARCHAR2
AS LANGUAGE JAVA
NAME 'MD5Encoder.encode (java.lang.String) return java.lang.String'; 