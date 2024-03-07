

--PRC_CAD_PSF_PROF_SERV_FREQ_S
create or replace procedure PRC_CAD_PSF_PROF_SERV_FREQ_S 
(
     pCAD_PSF_ID IN TB_CAD_PSF_PROF_SERV_FREQ.CAD_PSF_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_PSF_PROF_SERV_FREQ_S
* 
*    Data Criacao: 	15/07/2010   Por: André Souza Monaco
*    Data Alteracao:	  Por: 
*
*    Funcao: Obtem serviço freq. do profissional
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_PSF_ID,
       CAD_PSF_NM_SERVICO_FREQ,
       CAD_PSF_NR_TELEFONE,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PSF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
FROM TB_CAD_PSF_PROF_SERV_FREQ
WHERE
        CAD_PSF_ID = pCAD_PSF_ID;          
io_cursor := v_cursor;
end PRC_CAD_PSF_PROF_SERV_FREQ_S;
