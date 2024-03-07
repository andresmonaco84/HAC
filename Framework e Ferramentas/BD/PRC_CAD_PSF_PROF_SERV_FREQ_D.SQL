

--PRC_CAD_PSF_PROF_SERV_FREQ_D
create or replace procedure PRC_CAD_PSF_PROF_SERV_FREQ_D 
(
     pCAD_PSF_ID IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_PSF_PROF_SERV_FREQ_D
* 
*    Data Criacao: 	15/07/2010   Por: André Souza Monaco
*    Data Alteracao:	  Por: 
*
*    Funcao: Exclui serv. freq. do profissional
*
*******************************************************************/    
begin
DELETE TB_CAD_PSF_PROF_SERV_FREQ
WHERE  
        CAD_PSF_ID = pCAD_PSF_ID;	   
end PRC_CAD_PSF_PROF_SERV_FREQ_D;
