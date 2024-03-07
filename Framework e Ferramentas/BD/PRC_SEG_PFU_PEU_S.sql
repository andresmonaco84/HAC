﻿CREATE OR REPLACE PROCEDURE PRC_SEG_PFU_PEU_S
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pSEG_MOD_ID_MODULO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type DEFAULT NULL,
     pSEG_ID_SISTEMA  IN TB_SEG_SISTEMA.seg_id_sistema%TYPE DEFAULT NULL,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PFU_PEU_S
  * 
  *    Data Criacao:   31/07/2009   Por: Pedro
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
   SELECT  
       ASS.SEG_PER_ID_PERFIL,
       ASS.SEG_MOD_ID_MODULO,
       ASS.SEG_FUN_ID_FUNCIONALIDADE,
       PERFIL.SEG_PER_NM_PERFIL,
       FUNC.SEG_FUN_NM_NOME,
       PERFIL.SEG_ID_SISTEMA,
       PERFIL.SEG_USU_ID_USUARIO
    FROM TB_SEG_PFU_PERFIL_FUNCIONALID ASS,
         TB_SEG_PER_PERFIL             PERFIL,
         TB_SEG_FUN_FUNCIONALIDADE     FUNC,  
         TB_SEG_PEU_PERMISSAO_USUARIO PERUSU       
    WHERE        
        PERFIL.SEG_PER_ID_PERFIL   = ASS.SEG_PER_ID_PERFIL
    AND FUNC.SEG_FUN_ID_FUNCIONALIDADE = ASS.SEG_FUN_ID_FUNCIONALIDADE
    AND FUNC.SEG_MOD_ID_MODULO   = ASS.SEG_MOD_ID_MODULO
    AND PERFIL.seg_per_id_perfil   = PERUSU.SEG_PER_ID_PERFIL 
    AND (pSEG_PER_ID_PERFIL is null OR  ASS.SEG_PER_ID_PERFIL  = pSEG_PER_ID_PERFIL)  
    AND (pSEG_MOD_ID_MODULO is null OR  ASS.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)  
    AND (pSEG_MOD_ID_MODULO IS NULL OR PERUSU.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO)
    AND (pCAD_UNI_ID_UNIDADE IS NULL OR PERUSU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (pSEG_FUN_ID_FUNCIONALIDADE is null OR ASS.SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE)  
    AND (pSEG_USU_ID_USUARIO is null OR PERUSU.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)  
    AND (pSEG_ID_SISTEMA IS NULL OR FUNC.seg_id_sistema  = pSEG_ID_SISTEMA) 
    AND (PERFIL.SEG_PER_FL_STATUS = 'A');
    io_cursor := v_cursor;
  end PRC_SEG_PFU_PEU_S;
