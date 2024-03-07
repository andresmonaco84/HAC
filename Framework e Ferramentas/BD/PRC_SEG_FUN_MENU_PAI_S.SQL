create or replace procedure PRC_SEG_FUN_MENU_PAI_S
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_FUN_MENU_PAI_S
  *
  *    Data Criacao:  06/03/2007             Por: Carlos Eduardo
  *    Data Alteracao: 30/11/2010            Por: Rafael Coimbra
  *
  *    Funcao: Obtem as funcionalidades pertencentes aos Perfis (Ativos)
  *            associados ao Usuario logado em uma determinada Unidade (Ativa).
  *            Sera usado para montar a raiz do Menu
  *    Alteração: Incluir o filtro para buscar apenas as funcionalidades não são
  *               do Faturamento, Internação e Gestão de Materiais          
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT DISTINCT
           FUN.SEG_FUN_ID_FUNCIONALIDADE,
           FUN.SEG_FUN_DS_DESCRICAO,
           FUN.SEG_FUN_FL_ITEM_MENU_OK,
           FUN.SEG_FUN_ID_FUNCIONALIDADE_PAI,
           FUN.SEG_FUN_DS_NOME_PAGINA,
           FUN.SEG_FUN_NM_NOME
    FROM   TB_SEG_PEU_PERMISSAO_USUARIO PEU,
           TB_SEG_PFU_PERFIL_FUNCIONALID PFU,
           TB_SEG_PER_PERFIL PER,
           TB_SEG_FUN_FUNCIONALIDADE FUN
    WHERE PEU.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    AND   PEU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND   PER.SEG_PER_FL_STATUS = 'A'
    AND   (FUN.SEG_MOD_ID_MODULO NOT IN (421, 43, 7) OR FUN.SEG_MOD_ID_MODULO IS NULL)
    AND   PEU.SEG_PER_ID_PERFIL = PFU.SEG_PER_ID_PERFIL
    AND   PEU.SEG_MOD_ID_MODULO = PFU.SEG_MOD_ID_MODULO
    AND   PEU.SEG_PER_ID_PERFIL = PER.SEG_PER_ID_PERFIL
    AND   FUN.SEG_FUN_ID_FUNCIONALIDADE = PFU.SEG_FUN_ID_FUNCIONALIDADE
    AND   FUN.SEG_FUN_ID_FUNCIONALIDADE_PAI IS NULL
    ORDER BY FUN.SEG_FUN_NM_NOME;

    io_cursor := v_cursor;
-- Atualizado 30/10/07 9:06
  end PRC_SEG_FUN_MENU_PAI_S;
