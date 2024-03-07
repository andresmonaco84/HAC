  create or replace procedure PRC_SEG_PEU_PERMISSAO_ORFAO_D 
  (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type default null,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type default null
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PEU_PERMISSAO_ORFAO_D 
  *
  *    Data Criacao: 	22/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Exclui as permissões órfãos decorrente de uma possível
  *            desassociação de usuário à uma determinada unidade
  *            ou
  *            Exclui as permissões órfãos decorrente de uma possível
  *            desassociação de perfil à um determinado módulo
  *
  *******************************************************************/
  begin
  
    --Se Unidade <> null, então exclui todas as permissões orfãos da unidade informada
    IF (pCAD_UNI_ID_UNIDADE IS NOT NULL) THEN
        DELETE
        FROM   TB_SEG_PEU_PERMISSAO_USUARIO PEU
        WHERE  PEU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
        AND    PEU.SEG_USU_ID_USUARIO
        NOT IN (SELECT UUN.SEG_USU_ID_USUARIO
                FROM   TB_SEG_UUN_USUARIO_UNIDADE UUN
                WHERE  UUN.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE);    
    END IF;

    --Se Módulo <> null, então exclui todas as permissões orfãos do módulo informado
    IF (pSEG_MOD_ID_MODULO IS NOT NULL) THEN
        DELETE 
        FROM   TB_SEG_PEU_PERMISSAO_USUARIO PEU
        WHERE  PEU.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
        AND    PEU.SEG_MOD_ID_MODULO
        NOT IN (SELECT PER.SEG_MOD_ID_MODULO PER
                FROM   TB_SEG_MPF_MODULO_PERFIL PER
                WHERE  PER.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO);    
    END IF;
  end PRC_SEG_PEU_PERMISSAO_ORFAO_D;
/
