CREATE OR REPLACE PROCEDURE "PRC_FAT_CCI_GERA_PARC_LOTE"
(
    pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
    pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE,
    pFAT_CCP_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCP_ID%TYPE
)
IS
/* Marcus Relva 23/05/2011 */
qtdItem number := 0;
BEGIN
--Verificar se existem itens
select count(cci.fat_cci_id)
into qtdItem
from tb_fat_cci_conta_consu_item cci, tb_cad_mpf_moti_pend_faturar mpf
where cci.atd_ate_id = pATD_ATE_ID
and   cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
and   cci.cad_mpf_id = mpf.cad_mpf_id(+)
and   cci.fat_cci_fl_status = 'A'
--and   cci.fat_cci_fl_faturado = 'N'
and   cci.fat_ccp_id is null
--and   (cci.fat_fl_pendente_autoriza is null or cci.fat_fl_pendente_autoriza = 'A')
and   (cci.cad_mpf_id is null or mpf.cad_mpf_fl_motivo = 'J')
and   cci.fat_cci_tp_destino_item not in ('H','T');

if(qtdItem = 0) then
     raise_application_error(-20000,'NENHUM ITEM ENCONTRADO');
end if;
FOR ITENS IN ( select cci.fat_cci_id
    from tb_fat_cci_conta_consu_item cci, tb_cad_mpf_moti_pend_faturar mpf
    where cci.atd_ate_id = pATD_ATE_ID
    and   cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
    and   cci.cad_mpf_id = mpf.cad_mpf_id(+)
    and   cci.fat_cci_fl_status = 'A'
--    and   cci.fat_cci_fl_faturado = 'N'
    and   cci.fat_ccp_id is null
    --and   (cci.fat_fl_pendente_autoriza is null or cci.fat_fl_pendente_autoriza = 'A')
    and   (cci.cad_mpf_id is null or mpf.cad_mpf_fl_motivo = 'J')
    and   cci.fat_cci_tp_destino_item not in ('H','T'))
LOOP
  update tb_fat_cci_conta_consu_item cci
  SET --CCI.FAT_CCI_FL_FATURADO = 'S', 
	CCI.FAT_COC_ID = 1, 
	CCI.FAT_CCP_ID = pFAT_CCP_ID        
  WHERE CCI.FAT_CCI_ID = ITENS.FAT_CCI_ID;
END LOOP;

END PRC_FAT_CCI_GERA_PARC_LOTE;
