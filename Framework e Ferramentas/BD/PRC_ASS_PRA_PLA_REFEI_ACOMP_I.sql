create or replace procedure PRC_ASS_PRA_PLA_REFEI_ACOMP_I
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PRA_PLA_REFEI_ACOMP.CAD_PLA_ID_PLANO%type,
     pASS_PRA_FL_CAFEMANHA IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_FL_CAFEMANHA%type default NULL,
     pASS_PRA_FL_ALMOCO IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_FL_ALMOCO%type default NULL,
     pASS_PRA_FL_CAFETARDE IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_FL_CAFETARDE%type default NULL,
     pASS_PRA_FL_JANTAR IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_FL_JANTAR%type default NULL,
     pASS_PRA_NR_IDADE_PAC_MENOR IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_NR_IDADE_PAC_MENOR%type default NULL,
     pASS_PRA_NR_IDADE_PAC_MAIOR IN TB_ASS_PRA_PLA_REFEI_ACOMP.ASS_PRA_NR_IDADE_PAC_MAIOR%type default NULL,     
     pSEG_USU_ID_USUARIO IN TB_ASS_PRA_PLA_REFEI_ACOMP.SEG_USU_ID_USUARIO%type default NULL  
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRA_PLA_REFEI_ACOMP_I
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  
  lIdtRetorno integer;
    
  begin
    
    SELECT SEQ_ASS_PRA_01.NextVal INTO lIdtRetorno FROM DUAL;
    
    INSERT INTO TB_ASS_PRA_PLA_REFEI_ACOMP
    (
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
    )
    VALUES
    (
       lIdtRetorno,
       pCAD_PLA_ID_PLANO,
       pASS_PRA_FL_CAFEMANHA,
       pASS_PRA_FL_ALMOCO,
       pASS_PRA_FL_CAFETARDE,
       pASS_PRA_FL_JANTAR,
       pASS_PRA_NR_IDADE_PAC_MENOR,
       pASS_PRA_NR_IDADE_PAC_MAIOR,
       SYSDATE,
       pSEG_USU_ID_USUARIO
    );
  
  end PRC_ASS_PRA_PLA_REFEI_ACOMP_I;
/
