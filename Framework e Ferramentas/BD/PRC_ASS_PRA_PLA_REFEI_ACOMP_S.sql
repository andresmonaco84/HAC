create or replace procedure PRC_ASS_PRA_PLA_REFEI_ACOMP_S
  (
     pASS_PRA_ID IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_PRA_PLA_REFEI_ACOMP.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRA_PLA_REFEI_ACOMP_S
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       ASS_PRA_ID,
       CAD_PLA_ID_PLANO,
       ASS_PRA_FL_CAFEMANHA,
       ASS_PRA_FL_ALMOCO,
       ASS_PRA_FL_CAFETARDE,
       ASS_PRA_FL_JANTAR,
       ASS_PRA_NR_IDADE_PAC_MENOR,
       ASS_PRA_NR_IDADE_PAC_MAIOR,
       ASS_PRA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_PRA_PLA_REFEI_ACOMP
    WHERE
        (pASS_PRA_ID is null OR ASS_PRA_ID = pASS_PRA_ID)          
    AND (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO);
    io_cursor := v_cursor;
  end PRC_ASS_PRA_PLA_REFEI_ACOMP_S;
/
