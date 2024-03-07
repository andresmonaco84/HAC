create or replace procedure sgs.PRC_CAD_PLA_LISTAR_VIGENTES
  (
     pCAD_CNV_ID_CONVENIO in TB_CAD_PLA_PLANO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type DEFAULT NULL,
     pCAD_PLA_NM_NOME_PLANO in TB_CAD_PLA_PLANO.CAD_PLA_NM_NOME_PLANO%type DEFAULT NULL,
     pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%type default NULL,
     pSOMENTE_VIGENTES VARCHAR default null,
          pSOMENTE_NAOVIGENTES VARCHAR default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_LISTAR_VIGENTES
  *
  *    Data Criacao:   26/08/2009   Por: Alexandre M. Muniz
  *    Funcao: Lista planos em vigência de um convênio.
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;

  begin

    OPEN v_cursor FOR
    SELECT
       PLA.CAD_PLA_ID_PLANO,
       PLA.CAD_PLA_CD_PLANO_HAC,
       PLA.CAD_PLA_NM_NOME_PLANO,
       PLA.CAD_PLA_FL_SITUACAO_PLANO,
       PLA.CAD_PLA_DT_INICIO_VIGENCIA,
        PLA.CAD_PLA_DT_FIM_VIGENCIA
       
    FROM TB_CAD_PLA_PLANO PLA
    WHERE
        PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    AND ((pSOMENTE_VIGENTES IS NOT NULL AND PLA.CAD_PLA_FL_SITUACAO_PLANO in ('A','S') 
                                        AND  (PLA.CAD_PLA_DT_FIM_VIGENCIA IS NULL OR PLA.CAD_PLA_DT_FIM_VIGENCIA >= TRUNC(SYSDATE)))
        OR (pSOMENTE_NAOVIGENTES IS NOT NULL AND PLA.CAD_PLA_FL_SITUACAO_PLANO in ('I') )
       )
    
    AND (pCAD_PLA_CD_PLANO_HAC IS NULL OR UPPER(PLA.CAD_PLA_CD_PLANO_HAC) = UPPER((pCAD_PLA_CD_PLANO_HAC)) )
    AND (pCAD_PLA_NM_NOME_PLANO IS NULL OR UPPER(PLA.CAD_PLA_NM_NOME_PLANO) LIKE UPPER(pCAD_PLA_NM_NOME_PLANO) )
        AND (pCAD_PLA_CD_TIPOPLANO IS NULL OR UPPER(PLA.CAD_PLA_CD_TIPOPLANO) = UPPER(pCAD_PLA_CD_TIPOPLANO) )
    ORDER BY PLA.CAD_PLA_NM_NOME_PLANO;

    io_cursor := v_cursor;

  end PRC_CAD_PLA_LISTAR_VIGENTES;
 