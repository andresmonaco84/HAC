create or replace procedure PRC_CAD_SPL_SUB_PLANO_I
  (
     pNewIdt OUT integer,
     pCAD_SPL_CD_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_CD_SUB_PLANO%type,
     pCAD_SPL_DS_SUB_PLANO IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_DS_SUB_PLANO%type,
     pCAD_SPL_FL_STATUS IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_FL_STATUS%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_SPL_SUB_PLANO.CAD_CNV_ID_CONVENIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_I
  *
  *    Data Criacao: 	04/07/2008			Por: Fabmola Lopes
  *    Data Alteracao:	data da alteragco	Por: Nome do Analista
  *
  *    Funcao: Inclui os Sub-Planos
  *
  *******************************************************************/
  lIdtRetorno integer;

  begin

    SELECT SEQ_CAD_SPL_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_SPL_SUB_PLANO
    (
       CAD_SPL_ID,
       CAD_SPL_CD_SUB_PLANO,
       CAD_SPL_DS_SUB_PLANO,
       CAD_SPL_FL_STATUS,
       CAD_CNV_ID_CONVENIO
    )
    VALUES
    (
       lIdtRetorno,
       UPPER(pCAD_SPL_CD_SUB_PLANO),
       UPPER(pCAD_SPL_DS_SUB_PLANO),
       pCAD_SPL_FL_STATUS,
       pCAD_CNV_ID_CONVENIO
    );
  
  pNewIdt := lIdtRetorno;
  
  end PRC_CAD_SPL_SUB_PLANO_I;
/
