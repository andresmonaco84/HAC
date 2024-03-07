create or replace FUNCTION "FNC_PES_SOUNDEX_NOME" (PNOME IN VARCHAR2,
                                                pDELIMITADOR IN VARCHAR2) return VARCHAR2 IS
v_parte VARCHAR2(200);
v_nome VARCHAR2(200);
posicao NUMBER;
indice NUMBER;
v_retorno VARCHAR2(100);

FUNCTION dicionario_nomes( p IN VARCHAR2) RETURN VARCHAR2 IS
v_dic_nome VARCHAR2(100);
BEGIN
   v_dic_nome := p;
     IF ( SUBSTR(v_dic_nome,1,2) = 'DE' AND LENGTH(v_dic_nome) = 2 ) THEN
          v_dic_nome := '';
     ELSIF ( SUBSTR(v_dic_nome,1,2) = 'DA' AND LENGTH(v_dic_nome) = 2  ) THEN
          v_dic_nome := '';
     ELSIF ( SUBSTR(v_dic_nome,1,2) = 'DO' AND LENGTH(v_dic_nome) = 2  ) THEN
          v_dic_nome := '';          
     ELSIF ( SUBSTR(v_dic_nome,1,2) = 'DU' AND LENGTH(v_dic_nome) = 2  ) THEN
          v_dic_nome := '';          
     ELSIF ( SUBSTR(v_dic_nome,1,3) = 'DOS' AND LENGTH(v_dic_nome) = 3  ) THEN
          v_dic_nome := '';          
     ELSIF ( SUBSTR(v_dic_nome,1,2) = 'RN' AND LENGTH(v_dic_nome) = 2 ) THEN
          v_dic_nome := '';          
     END IF;
 RETURN v_dic_nome;
END;
FUNCTION REMOVE_ESPECIAIS(p IN VARCHAR) RETURN VARCHAR2 IS
v_corrigido VARCHAR2(100);
BEGIN
   v_corrigido := UPPER(p);
   v_corrigido := LTRIM(v_corrigido);
   v_corrigido := RTRIM(v_corrigido);
   v_corrigido := REGEXP_REPLACE(v_corrigido,'[^[:alnum:]'' '']', ' ');
   v_corrigido := REGEXP_REPLACE(v_corrigido,'[[:digit:]]', ' ');
   RETURN v_corrigido;
END;

FUNCTION TO_SOUNDEX(p IN VARCHAR) RETURN VARCHAR2 IS
tamanho NUMBER;
palavra VARCHAR2(100);
letra CHAR(1);
contador NUMBER := 1;
retorno VARCHAR2(100);
segunda_letra CHAR(1);
primeira_letra CHAR(1);
ultima_letra char(1);
totalCaracteresRetornar number := 6;
BEGIN
   palavra := UPPER(P);
   -- BUSCA ULTIMA LETRA, SE A ULTIMA LETRA FOR 'M' SUBSTITUI POR N, 
   -- ESTAVA COM PROBLEMA QUANDO O NOME INICIAVA COM 'M' ELE SUBSTITUIA O PRIMEIRO 'M' E ELIMINAVA TODOS DEPOIS DANDO DIFERENÇA SE OPERADORA DIGITASSE ERRADO O FINAL COM 'N'
   ultima_letra := substr(palavra,LENGTH(palavra),1 );
   IF (ultima_letra = 'M') THEN
      palavra := regexp_replace(palavra,'M', '5', LENGTH(palavra),1 );
   END IF;
   -- PEGA PRIMEIRA LETRA
   -- primeira_letra := SUBSTR(palavra,1,1);
   -- REMOVE PRIMEIRA LETRA DA PALAVRA
   -- palavra := SUBSTR(palavra,2);
   --SEGUNDA LETRA, PARA NOMES COMO MARIA, MARIZA, MURILO, MARLY(I) SE RETIRAR AS VOGAIS O CODIGO FICA QUASE TUDO IGUAL, ENTAO ACRESCENDO A SEGUNDA LETRA PARA TENTAR DIFERENCIAR
   -- segunda_letra := SUBSTR(palavra,1,1);
   -- palavra := CONVERTE(palavra);
   -- CORRIGE FONETICA
   palavra := REPLACE(palavra, 'EI', 'E'); -- ANDREA>ANDREIA LEIA>LEA
   palavra := REPLACE(palavra, 'AI', '!');
   palavra := REPLACE(palavra, 'IA', '!');
   palavra := REPLACE(palavra, 'CH', 'C');
   palavra := REPLACE(palavra, 'SH', 'C');
   palavra := REPLACE(palavra, 'PH', 'F');
   palavra := REPLACE(palavra, 'HE', 'E');
   palavra := REPLACE(palavra, 'TH', 'T');
   palavra := REPLACE(palavra, 'AU', 'L');
   palavra := REPLACE(palavra, 'AO', 'L');
   palavra := REPLACE(palavra, 'EU', 'L');
   palavra := REPLACE(palavra, 'IU', 'L');
   palavra := REPLACE(palavra, 'OU', 'L');
   palavra := REPLACE(palavra, 'K',  'C');
   palavra := REPLACE(palavra, 'QU', 'C');
   palavra := REPLACE(palavra, 'CR', 'CL');
   palavra := REPLACE(palavra, 'CE', 'S');
   palavra := REPLACE(palavra, 'CI', 'S');
   palavra := REPLACE(palavra, 'BR', 'B');
   palavra := REPLACE(palavra, 'PR', 'P');
   palavra := REPLACE(palavra, 'WH', 'U');
   
   -- REMOVE a, e, h, i, o, u, w, y.
   palavra := REGEXP_REPLACE(palavra,'A', '9', 1, 1 );  
   palavra := REGEXP_REPLACE(palavra,'E', '9', 1, 1 ); 
   palavra := REGEXP_REPLACE(palavra,'I', '9', 1, 1 ); 
   palavra := REGEXP_REPLACE(palavra,'O', '#', 1, 1 ); 
   palavra := REGEXP_REPLACE(palavra,'U', '#', 1, 1 );
   palavra := REPLACE(palavra, 'A', '');
   palavra := REPLACE(palavra, 'E', '');
   palavra := REPLACE(palavra, 'I', '');
   palavra := REPLACE(palavra, 'O', '');   
   palavra := REPLACE(palavra, 'U', '');
   palavra := REPLACE(palavra, 'W', 'V');
   palavra := REPLACE(palavra, 'Y', '9'); -- TRATA COMO VOGAL
   palavra := REPLACE(palavra, 'H', '');
   -- substitui a primeira ocorrencia do caracter         -- exclui as outras ocorrencias
   palavra := REGEXP_REPLACE(palavra,'B', '1', 1, 1 );   palavra := REPLACE(palavra, 'B', '');      
   palavra := REGEXP_REPLACE(palavra,'F', '1', 1, 1 );   palavra := REPLACE(palavra, 'F', '');
   palavra := REGEXP_REPLACE(palavra,'P', '1', 1, 1 );   palavra := REPLACE(palavra, 'P', '');
   palavra := REGEXP_REPLACE(palavra,'V', '1', 1, 1 );   palavra := REPLACE(palavra, 'V', '');
   palavra := REGEXP_REPLACE(palavra,'G', '2', 1, 1 );   palavra := REPLACE(palavra, 'G', '');
   palavra := REGEXP_REPLACE(palavra,'J', '2', 1, 1 );   palavra := REPLACE(palavra, 'J', '');
   palavra := REGEXP_REPLACE(palavra,'K', '2', 1, 1 );   palavra := REPLACE(palavra, 'K', '');
   palavra := REGEXP_REPLACE(palavra,'Q', '2', 1, 1 );   palavra := REPLACE(palavra, 'Q', '');
   palavra := REGEXP_REPLACE(palavra,'C', '2', 1, 1 );   palavra := REPLACE(palavra, 'C', '');   
   palavra := REGEXP_REPLACE(palavra,'D', '3', 1, 1 );   palavra := REPLACE(palavra, 'D', '');
   palavra := REGEXP_REPLACE(palavra,'L', '4', 1, 1 );   palavra := REPLACE(palavra, 'L',''); -- TRATA COMO VOGAL
   palavra := REGEXP_REPLACE(palavra,'M', '5', 1, 1 );   palavra := REPLACE(palavra, 'M', '');
   palavra := REGEXP_REPLACE(palavra,'N', '5', 1, 1 );   palavra := REPLACE(palavra, 'N', '');
   palavra := REGEXP_REPLACE(palavra,'R', '6', 1, 1 );   palavra := REPLACE(palavra, 'R', '');
   palavra := REGEXP_REPLACE(palavra,'T', '7', 1, 1 );   palavra := REPLACE(palavra, 'T', '');
   palavra := REGEXP_REPLACE(palavra,'S', '8', 1, 1 );   palavra := REPLACE(palavra, 'S', '');
   palavra := REGEXP_REPLACE(palavra,'Z', '8', 1, 1 );   palavra := REPLACE(palavra, 'Z', '');   
   palavra := REGEXP_REPLACE(palavra,'X', '8', 1, 1 );   palavra := REPLACE(palavra, 'X', '');
   -- palavra := primeira_letra||palavra;
   retorno := retorno||RPAD(palavra,totalCaracteresRetornar,'0');
   retorno := SUBSTR(retorno,1,totalCaracteresRetornar);
   RETURN retorno; 
END;
BEGIN
   v_retorno := '';
   v_nome := REMOVE_ESPECIAIS(PNOME);
   indice :=1;
   LOOP
      posicao := INSTR(v_nome, pDELIMITADOR); -- ACHA PRIMEIRO DELIMITADOR
      IF posicao > 0 THEN
         -- BUSCA PARTE ATÉ DELIMITADOR E ENVIA PARA CORREÇAO
         v_parte := substr(v_nome, 1, posicao-1);
         v_parte := dicionario_nomes(v_parte);
         v_parte := TO_SOUNDEX(v_parte);
         v_nome := SUBSTR(v_nome,posicao+length(pDELIMITADOR)); -- EXCLUI PARTE JA CORRIGIDA DO TEXTO
      ELSE
         v_parte := dicionario_nomes(v_nome);
         v_parte := TO_SOUNDEX(v_parte);
         v_nome := NULL;
      END IF;
      v_retorno := v_retorno||v_parte;
      indice := indice+1;
      IF ( LENGTH(v_nome) = 0 OR v_nome IS NULL ) THEN
         EXIT;
      END IF;
   END LOOP;
   RETURN v_retorno;
END FNC_PES_SOUNDEX_NOME;