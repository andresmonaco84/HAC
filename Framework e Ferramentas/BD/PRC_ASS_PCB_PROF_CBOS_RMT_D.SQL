

--PRC_ASS_PCB_PROF_CBOS_RMT_D
create or replace procedure PRC_ASS_PCB_PROF_CBOS_RMT_D
(
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCB_PROFISSIONAL_CBOS.CAD_PRO_ID_PROFISSIONAL%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_PCB_PROFISSIONAL_CBOS.TIS_CBO_CD_CBOS%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PCB_PROF_CBOS_RMT_D
* 
*    Data Criacao: 	15/07/2010   Por: André Souza Monaco
*    Data Alteracao:	  Por: 
*
*    Funcao: Exclui especialidade do profissional
*
*******************************************************************/    
begin
DELETE TB_ASS_PCB_PROFISSIONAL_CBOS
WHERE  
        CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	   
end PRC_ASS_PCB_PROF_CBOS_RMT_D;
