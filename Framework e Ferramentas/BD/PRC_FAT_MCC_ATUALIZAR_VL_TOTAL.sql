CREATE OR REPLACE PROCEDURE "PRC_FAT_MCC_ATUALIZAR_VL_TOTAL"
(
       pFAT_MCC_ID            IN TB_FAT_MCC_MOV_COM_CONSUMO.FAT_MCC_ID%TYPE
)
is
/********************************************************************
*    Procedure: PRC_FAT_MCC_ATUALIZAR_VL_TOTAL
*
*    Data Criacao:  02/07/2010 Marcus Relva
*
*    Funcao: Atualizar o Total das Comandas
*
*******************************************************************/
vl_total number;
qtd      number;

begin

   select sum(inteiros_fracionados.qtd), sum(inteiros_fracionados.val)
   into qtd, vl_total
  from (
        -- Inteiros e Fracionados
        select sum(cci.fat_cci_qt_consumo) as qtd, sum(cci.fat_cci_vl_faturado) as val
          from tb_fat_cci_conta_consu_item cci
         where cci.fat_cci_fl_status = 'A'
           and (cci.fat_cci_fl_pacote <> 'S' OR cci.fat_cci_fl_pacote IS NULL)
           and cci.fat_mcc_id = pFAT_MCC_ID					 
			 ) inteiros_fracionados;

    if (vl_total is null) then
      vl_total := 0;
    end if;

    if (qtd is null) then
      qtd := 0;
    end if;

    update tb_fat_mcc_mov_com_consumo mcc
       set mcc.fat_mcc_vl_tot_mov_comanda = (vl_total),
           mcc.fat_mcc_qt_tot_item_mov_com = qtd
     where mcc.fat_mcc_id = pFAT_MCC_ID;

end PRC_FAT_MCC_ATUALIZAR_VL_TOTAL;
 