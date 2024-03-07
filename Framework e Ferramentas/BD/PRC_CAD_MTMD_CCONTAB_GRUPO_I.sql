 create or replace procedure PRC_CAD_MTMD_CCONTAB_GRUPO_I
(
     pCAD_MTMD_TIPO_MOV IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_TIPO_MOV%type,
     pCAD_MTMD_GRUPO_ID IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_GRUPO_ID%type,
     pCAD_MTMD_DT_INI_VIG IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_DT_INI_VIG%type,
     pCAD_MTMD_DT_FIM_VIG IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_DT_FIM_VIG%type default NULL,
     pCAD_MTMD_COD_COLIGADA IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_MTMD_COD_COLIGADA%type,
     pCAD_SET_ID IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_SET_ID%type,
     pCAD_COD_CONTA_CRED IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_COD_CONTA_CRED%type default NULL,
     pCAD_COD_CONTA_CRED_DESCRICAO IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_COD_CONTA_CRED_DESCRICAO%type default NULL,
     pCAD_COD_CONTA_DEB IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_COD_CONTA_DEB%type default NULL,
     pCAD_COD_CONTA_DEB_DESCRICAO IN TB_CAD_MTMD_CCONTAB_GRUPO.CAD_COD_CONTA_DEB_DESCRICAO%type default NULL,
     pSEG_DT_ATUALIZACAO IN TB_CAD_MTMD_CCONTAB_GRUPO.SEG_DT_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_MTMD_CCONTAB_GRUPO.SEG_USU_ID_USUARIO%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_MTMD_CCONTAB_GRUPO_I
*
*    Data Criacao: 	31/01/2012   Por: Andr� S. Monaco
*
*    Funcao: Insere conta do grupo
*
*******************************************************************/

begin

INSERT INTO TB_CAD_MTMD_CCONTAB_GRUPO
(
       CAD_MTMD_TIPO_MOV,
       CAD_MTMD_GRUPO_ID,
       CAD_MTMD_DT_INI_VIG,
       CAD_MTMD_DT_FIM_VIG,
       CAD_MTMD_COD_COLIGADA,
       CAD_SET_ID,
       CAD_COD_CONTA_CRED,
       CAD_COD_CONTA_CRED_DESCRICAO,
       CAD_COD_CONTA_DEB,
       CAD_COD_CONTA_DEB_DESCRICAO,
       SEG_DT_ATUALIZACAO,
       SEG_USU_ID_USUARIO
)
VALUES
(
	     pCAD_MTMD_TIPO_MOV,
	     pCAD_MTMD_GRUPO_ID,
	     pCAD_MTMD_DT_INI_VIG,
	     pCAD_MTMD_DT_FIM_VIG,
	     pCAD_MTMD_COD_COLIGADA,
	     pCAD_SET_ID,
	     pCAD_COD_CONTA_CRED,
	     pCAD_COD_CONTA_CRED_DESCRICAO,
	     pCAD_COD_CONTA_DEB,
	     pCAD_COD_CONTA_DEB_DESCRICAO,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO
);

end PRC_CAD_MTMD_CCONTAB_GRUPO_I;
