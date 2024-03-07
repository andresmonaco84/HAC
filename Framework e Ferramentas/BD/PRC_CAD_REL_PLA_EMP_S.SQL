create or replace procedure PRC_CAD_REL_PLA_EMP_S
(
  pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
  pCAD_PLA_FL_SITUACAO_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_FL_SITUACAO_PLANO%TYPE DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
)
is
  /********************************************************************
*    Procedure: PRC_CAD_REL_PLA_EMP_S
*
*    Data Criacao: 18/03/2010     Por: Eduardo Hyppolito
*    Data Alteracao: 21/06/2010   Por: Eduardo Hyppolito
*    Alteração: Foi retirada a tabela Empresa e colocada a Plano
*
*    Funcao: Listar as Empresas
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR

  SELECT  PLA.CAD_PLA_NM_NOME_PLANO,
          pla.cad_pla_cd_plano_hac,
          DECODE(PLA.CAD_PLA_CD_TIPOPLANO,'GB','GLOBAL','PA','PARTICULAR','FU','FUNCIONÁRIO','SP','SERVIÇO PRESTADO','PL','FÍSICA')CAD_PLA_CD_TIPOPLANO,
          DECODE(PLA.CAD_PLA_FL_SITUACAO_PLANO, 'A', 'ATIVO', 'S', 'SUSPENSO', 'I', 'INATIVO') CAD_PLA_FL_SITUACAO_PLANO                  
  FROM   TB_CAD_PLA_PLANO PLA
  where  ((pCAD_PLA_FL_SITUACAO_PLANO = 'A' AND PLA.CAD_PLA_FL_SITUACAO_PLANO IN ('A','S'))
          OR (pCAD_PLA_FL_SITUACAO_PLANO IS NULL OR PLA.CAD_PLA_FL_SITUACAO_PLANO = pCAD_PLA_FL_SITUACAO_PLANO))
   and    (pCAD_PLA_CD_TIPOPLANO is null or pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO)
  ;
  io_cursor := v_cursor;
end PRC_CAD_REL_PLA_EMP_S;
/
