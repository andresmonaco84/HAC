CREATE OR REPLACE PROCEDURE PRC_MTMD_EMAIL_FARM_ALMOX
(
   pCAD_MTMD_FILIAL_ID IN TB_CAD_MTMD_FILIAL.CAD_MTMD_FILIAL_ID%TYPE,
   pCAD_SET_ID_ORIGEM  IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
   pCAD_SET_ID_DESTINO IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
   pCAD_MTMD_ID        IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
   pQTD_produto        IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
   pSEG_USU_ID_USUARIO IN TB_MTMD_MOV_MOVIMENTACAO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_MTMD_EMAIL_FARM_ALMOX
*
*    Data Criacao:   FEB/2020  Por: PEDRO
*
*    Funcao: ENVIAR E-MAIL QUANDO
*    transferencia envolvendo farmacia, unitarizaco, almoxarifado, c.cir., almox. uti e almox. ps
*******************************************************************/
pEmail_Corpo   varchar2(5000);

pTitulo varchar2(200);
pOrigem varchar2(200);
pDestino varchar2(200);
pProduto varchar2(300);
pIDProduto varchar2(300);
pUsuario varchar2(50);
pUnidadeDestino varchar2(200);
pEmailDestino varchar2(200);
pEnvia boolean;
begin
select UNI.CAD_UNI_DS_UNIDADE into pUnidadeDestino from tb_cad_set_setor s 
JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = S.CAD_UNI_ID_UNIDADE 
where s.cad_set_id = pCAD_SET_ID_DESTINO;

IF (pCAD_SET_ID_DESTINO IN (2592,29) AND pCAD_SET_ID_ORIGEM NOT IN (29,2632,2592,61,2092,2713)) THEN --Para evitar enviar e-mail de devolução
  return;
ELSIF (pCAD_SET_ID_DESTINO IN (2092) AND pCAD_SET_ID_ORIGEM NOT IN (29,2632,2592,61,2713)) THEN --Para evitar enviar e-mail de devolução pro Almox. UTI
  return;
ELSIF (pCAD_SET_ID_DESTINO IN (2592,2632) AND pCAD_SET_ID_ORIGEM IN (2592,2632)) THEN --Nao enviar entre Farm. e Unit.
  return;
END IF;

--Farmaceuticos PS PG      251    ¿ farmaceuticos.pspg@anacosta.com.br
--PS Praia Grande ¿ Pronto Socorro ¿ Almoxarifado 2052

--Farmaceuticos SaoVicente 247    ¿ farmaceuticos.saovicente@anacosta.com.br
--Unidade São Vicente ¿ Ambulatório ¿ Almoxarifado 32

--Farmaceuticos Enseada    401    ¿ farmaceuticos.enseada@anacosta.com.br
--Unidade Guarujá Enseada ¿ Pronto Socorro ¿ Almoxarifado 1714

--Farmaceuticos Cubatão    246    ¿ farmaceuticos.cubatao@anacosta.com.br
--Unidade Cubatão ¿ Ambulatório - Almoxarifado 31


pEnvia := false;
IF (pCAD_MTMD_FILIAL_ID = 1 AND pCAD_SET_ID_ORIGEM IN (29,2592,2632) AND pCAD_SET_ID_DESTINO IN (1714)) --pUnidadeDestino IN (401)) 
  THEN pEmailDestino:='farmaceuticos.enseada@anacosta.com.br';
       pEnvia := true;
else IF (pCAD_MTMD_FILIAL_ID = 1 AND pCAD_SET_ID_ORIGEM IN (29,2592,2632) AND pCAD_SET_ID_DESTINO IN (32)) --pUnidadeDestino IN (247)) 
  THEN pEmailDestino:='farmaceuticos.saovicente@anacosta.com.br';
       pEnvia := true;
else IF (pCAD_MTMD_FILIAL_ID = 1 AND pCAD_SET_ID_ORIGEM IN (29,2592,2632) AND pCAD_SET_ID_DESTINO IN (2052)) --pUnidadeDestino IN (251)) 
  THEN pEmailDestino:='farmaceuticos.pspg@anacosta.com.br';
       pEnvia := true;
else IF (pCAD_MTMD_FILIAL_ID = 1 AND pCAD_SET_ID_ORIGEM IN (29,2592,2632) AND pCAD_SET_ID_DESTINO IN (31)) --pUnidadeDestino IN (246)) 
  THEN pEmailDestino:='farmaceuticos.cubatao@anacosta.com.br';
       pEnvia := true;
ELSE IF (pCAD_MTMD_FILIAL_ID = 1 AND (pCAD_SET_ID_ORIGEM IN (29,2632,2592,61,2092,2713) OR pCAD_SET_ID_DESTINO IN (29,2632,2592,61,2092,2713))) THEN
       pEmailDestino:='paula.carvalho@anacosta.com.br';
       pEnvia := true;
   
end if;     
end if;
end if;              
end if;   
end if;

if(pEnvia = true) then

      SELECT S.CAD_SET_DS_SETOR INTO pOrigem FROM TB_CAD_SET_SETOR S WHERE S.CAD_SET_ID = pCAD_SET_ID_ORIGEM;
      SELECT S.CAD_SET_DS_SETOR INTO pDestino FROM TB_CAD_SET_SETOR S WHERE S.CAD_SET_ID = pCAD_SET_ID_DESTINO;
      SELECT A.CAD_MTMD_DESCRICAO, A.CAD_MTMD_ID INTO pProduto, pIDProduto FROM TB_CAD_MTMD_MAT_MED A WHERE A.CAD_MTMD_ID = pCAD_MTMD_ID;
      
      IF (pSEG_USU_ID_USUARIO IS NOT NULL) THEN
         SELECT SEG_USU_DS_NOME INTO pUsuario FROM TB_SEG_USU_USUARIO U WHERE U.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;
      END IF;

      pTitulo:= 'AVISO DE TRANSFERENCIA DE #ORIGEM PARA #DESTINO';
      pTitulo:= Replace(pTitulo, '#ORIGEM', pOrigem);
      if(pCAD_SET_ID_DESTINO in (31,32,1714,2052)) then
            pTitulo:= Replace(pTitulo, '#DESTINO', pUnidadeDestino || ' ' || pDestino);
      else  pTitulo:= Replace(pTitulo, '#DESTINO', pDestino);
      end if;

      pEmail_Corpo :=  '<B>#TITULO</B><BR><P>
                        ORIGEM: <B>#ORIGEM</B><BR><BR>
                        DESTINO: <B>#DESTINO</B><BR><BR>
                        USUARIO REGISTRO: <B>#USUARIO</B><BR><BR>
                        QUANTIDADE: <B>#QUANTIDADE</B><BR><BR>
                        PRODUTO: <B>#CODIGOPRODUTO - #PRODUTO</B><BR><BR><BR><BR>
                        ESTE E-MAIL FOI ENVIADO DE FORMA AUTOMATICA PELO SISTEMA DE GESTAO DE ESTOQUE (SGS)';
      pEmail_Corpo := Replace(pEmail_Corpo, '#TITULO', pTitulo);
      pEmail_Corpo := Replace(pEmail_Corpo, '#ORIGEM', pOrigem);
      
      if(pCAD_SET_ID_DESTINO in (31,32,1714,2052)) then
           pEmail_Corpo := Replace(pEmail_Corpo, '#DESTINO', pUnidadeDestino || ' ' || pDestino);            
      else pEmail_Corpo := Replace(pEmail_Corpo, '#DESTINO', pDestino);
      end if;
      
      pEmail_Corpo := Replace(pEmail_Corpo, '#USUARIO',pUsuario);
      pEmail_Corpo := Replace(pEmail_Corpo, '#CODIGOPRODUTO', pIDProduto);
      pEmail_Corpo := Replace(pEmail_Corpo, '#PRODUTO', pProduto);
      pEmail_Corpo := Replace(pEmail_Corpo, '#QUANTIDADE', pQTD_produto);

      PRC_ENVIA_EMAIL_N('sgs@anacosta.com.br',
                        pEmailDestino,
                        pTitulo,
                        pEmail_Corpo);
end if;

end PRC_MTMD_EMAIL_FARM_ALMOX;