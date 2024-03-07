create or replace procedure PRC_FAT_CCI_OBTER_DESC_CLINICA
(       pCD_CLINICA  IN NUMBER,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_CCI_OBTER_DESC_CLINICAS
* 
*    Data Criacao: 	09/09/2010
*    
*    Funcao: Obter descricao da Clínica na tabela do Legado
*
*******************************************************************/  
v_cursor PKG_CURSOR.t_cursor;

begin

OPEN v_cursor FOR
     select cli.ds_clinica from hospital.rep_clinicas cli      
     where cli.cd_clinica = pCD_CLINICA;     
     
io_cursor := v_cursor;

end PRC_FAT_CCI_OBTER_DESC_CLINICA;
/
