

--PRC_CAD_CPR_CREDENCIA_PROF_I
create or replace procedure PRC_CAD_CPR_CREDENCIA_PROF_I
(
     pCAD_CPR_TP_CREDENCIA_PROF IN TB_CAD_CPR_CREDENCIA_PROF.CAD_CPR_TP_CREDENCIA_PROF%type,
     pCAD_CPR_DS_CREDENCIA_PROF IN TB_CAD_CPR_CREDENCIA_PROF.CAD_CPR_DS_CREDENCIA_PROF%type default NULL	
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CPR_CREDENCIA_PROF_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_CAD_CPR_CREDENCIA_PROF
(
       CAD_CPR_TP_CREDENCIA_PROF,
       CAD_CPR_DS_CREDENCIA_PROF
)
VALUES
(
	     pCAD_CPR_TP_CREDENCIA_PROF,
	     pCAD_CPR_DS_CREDENCIA_PROF
);
	
end PRC_CAD_CPR_CREDENCIA_PROF_I;

