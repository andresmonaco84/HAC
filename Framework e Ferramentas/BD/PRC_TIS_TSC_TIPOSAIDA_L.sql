create or replace procedure PRC_TIS_TSC_TIPOSAIDA_L(
     pTIS_TSC_CD_TIPOSAIDACONSULTA in TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_CD_TIPOSAIDACONSULTA%TYPE DEFAULT NULL,     
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/*********************************************************************************
*    Procedure: PRC_TIS_TSC_TIPOSAIDA_L
* 
*    Data Criacao: 	16/08/2010   Por: Marcus Relva
*
*    Funcao: Carregar os Tipos de Saida
*
**********************************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR

select tsc.tis_tsc_cd_tiposaidaconsulta, tsc.tis_tsc_ds_tiposaidaconsulta
  from tb_tis_tsc_tiposaidaconsulta tsc
 where (pTIS_TSC_CD_TIPOSAIDACONSULTA is null or
       tsc.tis_tsc_cd_tiposaidaconsulta = pTIS_TSC_CD_TIPOSAIDACONSULTA);

io_cursor := v_cursor;
end PRC_TIS_TSC_TIPOSAIDA_L;
