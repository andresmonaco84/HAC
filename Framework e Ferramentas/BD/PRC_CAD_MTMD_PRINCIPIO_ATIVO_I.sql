create or replace procedure PRC_CAD_MTMD_PRINCIPIO_ATIVO_I
  (
     pCAD_MTMD_PRIATI_ID IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_PRIATI_ID%type default NULL,
     pCAD_MTMD_PRIATI_DESCRICAO IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_PRIATI_DESCRICAO%type default NULL,
     pCAD_MTMD_FL_IRRITANTE IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_FL_IRRITANTE%type default NULL,
     pCAD_MTMD_FL_VESICANTE IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_FL_VESICANTE%type default NULL,
     pCAD_MTMD_FL_FLEBITANTE IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_FL_FLEBITANTE%type default NULL,
     pCAD_MTMD_ORIENTACAO IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.CAD_MTMD_ORIENTACAO%type default NULL,
     pNewIdt OUT integer,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_PRIATI_PRINC_ATIVO.SEG_USU_ID_USUARIO%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_PRIATI_PATIVO_I
  *
  *    Data Criacao: 	data da  criaÃ§Ã£o   Por: Nome do Analista
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: DescriÃ§Ã£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  vCAD_MTMD_PRIATI_ID TB_CAD_MTMD_SIMILAR.CAD_MTMD_PRIATI_ID%type := pCAD_MTMD_PRIATI_ID;
  begin
    SELECT P.CAD_MTMD_PRIATI_ID 
      INTO vCAD_MTMD_PRIATI_ID
      FROM TB_CAD_MTMD_PRIATI_PRINC_ATIVO P 
     WHERE P.CAD_MTMD_PRIATI_ID NOT IN (SELECT S.CAD_MTMD_PRIATI_ID FROM TB_CAD_MTMD_SIMILAR S) AND
           P.CAD_MTMD_PRIATI_ID NOT IN (SELECT S.CAD_MTMD_PRIATI_ID FROM TB_CAD_MTMD_MAT_MED S)
       AND ROWNUM = 1;
      
    PRC_CAD_MTMD_PRINCIPIO_ATIVO_U(vCAD_MTMD_PRIATI_ID,
                                   pCAD_MTMD_PRIATI_DESCRICAO,
                                   pCAD_MTMD_FL_IRRITANTE,
                                   pCAD_MTMD_FL_VESICANTE,
                                   pCAD_MTMD_FL_FLEBITANTE,
                                   pCAD_MTMD_ORIENTACAO,
                                   pSEG_USU_ID_USUARIO);    
    pNewIdt := vCAD_MTMD_PRIATI_ID;
    /*INSERT INTO TB_CAD_MTMD_PRIATI_PRINC_ATIVO
    (
       CAD_MTMD_PRIATI_ID,
       CAD_MTMD_PRIATI_DESCRICAO,
       CAD_MTMD_FL_IRRITANTE,
       CAD_MTMD_FL_VESICANTE,
       CAD_MTMD_FL_FLEBITANTE,
       CAD_MTMD_ORIENTACAO
    )
    VALUES
    (
	     pCAD_MTMD_PRIATI_ID,
	     pCAD_MTMD_PRIATI_DESCRICAO,
       pCAD_MTMD_FL_IRRITANTE,
       pCAD_MTMD_FL_VESICANTE,
       pCAD_MTMD_FL_FLEBITANTE,
       pCAD_MTMD_ORIENTACAO
    );*/
  end PRC_CAD_MTMD_PRINCIPIO_ATIVO_I;