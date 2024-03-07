PROCEDURE PRC_SEG_PERMISSAO_USUARIO
  (     
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_FUN_FUNCIONALIDADE.SEG_FUN_ID_FUNCIONALIDADE%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type,
--     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PERMISSAO_USUARIO
  * 
  *    Data Criacao:   data da  criação   Por: Alexandre M. Muniz
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
   -- RETORNA AS PERMISSAO QUE O USUARIO TEM NA TELA ????
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  begin
  
    OPEN v_cursor FOR    
    SELECT PERMISSAO.SEG_PER_ID_PERFIL
      FROM (SELECT PUS.SEG_PER_ID_PERFIL, 
                   PUS.SEG_USU_ID_USUARIO,
                   PUS.CAD_UNI_ID_UNIDADE,
                   PUS.SEG_MOD_ID_MODULO
              FROM TB_SEG_USU_USUARIO USU,
                   TB_SEG_PEU_PERMISSAO_USUARIO PUS,
                   TB_SEG_PER_PERFIL PER,
                   TB_SEG_PFU_PERFIL_FUNCIONALID PFU,
                   TB_SEG_FUN_FUNCIONALIDADE FUN,
                   TB_SEG_MOD_MODULO MDL
--                   TB_SEG_SISTEMA SIS
             WHERE USU.SEG_USU_ID_USUARIO        = PUS.SEG_USU_ID_USUARIO
               AND PUS.SEG_PER_ID_PERFIL         = PER.SEG_PER_ID_PERFIL
               AND PER.SEG_PER_ID_PERFIL         = PFU.SEG_PER_ID_PERFIL
               AND PFU.SEG_FUN_ID_FUNCIONALIDADE = FUN.SEG_FUN_ID_FUNCIONALIDADE
               AND PFU.SEG_MOD_ID_MODULO         = FUN.SEG_MOD_ID_MODULO
               AND FUN.SEG_MOD_ID_MODULO         = MDL.SEG_MOD_ID_MODULO
--               AND FUN.SEG_ID_SISTEMA = SIS.SEG_ID_SISTEMA
--               AND SIS.SEG_ID_SISTEMA = pSEG_ID_SISTEMA
               AND USU.SEG_USU_ID_USUARIO        = pSEG_USU_ID_USUARIO
               AND FUN.SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE) PERMISSAO
     WHERE PERMISSAO.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND PERMISSAO.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO;  --Gest�o de Materiais
    
    io_cursor := v_cursor;
    
  end PRC_SEG_PERMISSAO_USUARIO; 