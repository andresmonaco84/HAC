create or replace procedure prc_cob_txt_guia_atu_mgc
                ( pCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%type,
                  pCAD_PES_ID_PESSOA IN TB_COB_TXT_COBRANCA.CAD_PES_ID_PESSOA%TYPE ,
                  pSEG_USU_ID_USUARIO_REG IN TB_COB_MGC_MOV_GUIA_COBRANCA.SEG_USU_ID_USUARIO_REG%TYPE,
                  pCAD_MGC_DT_REGISTRO IN TB_COB_MGC_MOV_GUIA_COBRANCA.CAD_MGC_DT_REGISTRO%TYPE  ) is
----
CURSOR ATU IS
Select
fat_nof_id                 FAT_NOF_ID                 ,
atd_ate_id                 ATD_ATE_ID                 ,
cad_pac_id_paciente        CAD_PAC_ID_PACIENTE        ,
cob_coc_id                 COB_COC_ID                 ,
cob_ccp_id                 COB_CCP_ID                 ,
atd_gui_cd_codigo          ATD_GUI_CD_CODIGO          ,
atd_gui_dt_validade        ATD_GUI_DT_VALIDADE        ,
cob_txt_dt_pagto           COB_MGC_DT_MOVIMENTO       ,
SUM(nvl(cob_txt_vl_movimento,0) ) COB_MGC_VL_MOVIMENTO       ,
cob_txt_pc_iss             COB_MGC_PC_ISS             ,
SUM( nvl(cob_txt_vl_iss,0) )        COB_MGC_VL_ISS             ,
cob_txt_pc_ir              COB_MGC_PC_IR              ,
SUM( nvl(cob_txt_vl_ir,0) )         COB_MGC_VL_IR              ,
cob_txt_pc_csll            COB_MGC_PC_CSLL            ,
SUM( nvl(cob_txt_vl_csll,0))       COB_MGC_VL_CSLL            ,
cob_txt_pc_cofins          COB_MGC_PC_COFINS          ,
SUM( nvl(cob_txt_vl_cofins,0) )     COB_MGC_VL_COFINS          ,
cob_txt_pc_pis             COB_MGC_PC_PIS             ,
SUM( nvl(cob_txt_vl_pis,0) )        COB_MGC_VL_PIS             ,
ass_bct_id                 ASS_BCT_ID ,
case
 when upper(txt.cob_txt_ds_servico) = 'NOTA DE CREDITO' then txt.cob_txt_cd_servico
 else null
end nota_de_credito,
case
 when upper(txt.cob_txt_ds_servico) = 'NOTA DE CREDITO' then 2 
 else 1 
end  CAD_TMC_ID
 
from tb_cob_txt_cobranca txt
where txt.cob_txt_id        =  pCOB_TXT_ID
  and txt.cad_pes_id_pessoa =  pCAD_PES_ID_PESSOA
  and txt.fat_nof_id > 0
  and txt.cob_txt_fl_status = 'A'
  and txt.cob_txt_dt_atualiza_mgc is null
GROUP BY  fat_nof_id                  ,
          atd_ate_id                  ,
          cad_pac_id_paciente         ,
          cob_coc_id                  ,
          cob_ccp_id                  ,
          atd_gui_cd_codigo           ,
          atd_gui_dt_validade         ,
          cob_txt_dt_pagto            ,
          cob_txt_pc_iss              ,
          cob_txt_pc_ir               ,
          cob_txt_pc_csll             ,
          cob_txt_pc_cofins           ,
          cob_txt_pc_pis              ,
          ass_bct_id ,
          case  when upper(txt.cob_txt_ds_servico) = 'NOTA DE CREDITO' then txt.cob_txt_cd_servico
                else null end ,
          case
                when upper(txt.cob_txt_ds_servico) = 'NOTA DE CREDITO' then 2 
                else 1  end 
order by fat_nof_id, atd_ate_id, cob_ccp_id ;
---
VALOR NUMBER(18,4 );
---
begin
FOR A IN ATU
LOOP
---
VALOR := A.COB_MGC_VL_MOVIMENTO +
         A.COB_MGC_VL_ISS + A.COB_MGC_VL_IR + A.COB_MGC_VL_CSLL + A.COB_MGC_VL_COFINS + A.COB_MGC_VL_PIS;
---- insert no mgc quando valor <> zeros
IF VALOR <> 0.00 THEN
      INSERT INTO TB_COB_MGC_MOV_GUIA_COBRANCA 
       ( COB_MGC_ID ,
         FAT_NOF_ID ,
         ATD_ATE_ID ,
         CAD_PAC_ID_PACIENTE    ,
         COB_COC_ID             ,
         COB_CCP_ID             ,
         ATD_GUI_CD_CODIGO      ,
         ATD_GUI_DT_VALIDADE    ,
         CAD_TMC_ID             ,
         COB_MGC_DT_MOVIMENTO   ,
         COB_MGC_VL_MOVIMENTO   ,
         CAD_MGC_DT_REGISTRO    ,
         SEG_USU_ID_USUARIO_REG ,
         COB_MGC_DT_ULTIMA_ATUALIZACAO,
         SEG_USU_ID_USUARIO_ATUALIZ   ,
         COB_MGC_PC_ISS               ,
         COB_MGC_VL_ISS               ,
         COB_MGC_PC_IR                ,
         COB_MGC_VL_IR                ,
         COB_MGC_PC_CSLL              ,
         COB_MGC_VL_CSLL              ,
         COB_MGC_PC_COFINS            ,
         COB_MGC_VL_COFINS            ,
         COB_MGC_PC_PIS               ,
         COB_MGC_VL_PIS               ,
         ASS_BCT_ID                   ,
         COB_MGC_NR_NOTA_CREDITO   )
      VALUES
        ( SEQ_COB_MGC_01.NEXTVAL  ,
          A.FAT_NOF_ID ,
          A.ATD_ATE_ID ,
          A.CAD_PAC_ID_PACIENTE,
          A.COB_COC_ID         ,
          A.COB_CCP_ID         ,
          A.ATD_GUI_CD_CODIGO  ,
          A.ATD_GUI_DT_VALIDADE,
          A.CAD_TMC_ID           ,
          A.COB_MGC_DT_MOVIMENTO,
          A.COB_MGC_VL_MOVIMENTO,
          pCAD_MGC_DT_REGISTRO  ,
          pSEG_USU_ID_USUARIO_REG  ,
          pCAD_MGC_DT_REGISTRO  ,
          pSEG_USU_ID_USUARIO_REG  ,
          A.COB_MGC_PC_ISS               ,
          A.COB_MGC_VL_ISS               ,
          A.COB_MGC_PC_IR                ,
          A.COB_MGC_VL_IR                ,
          A.COB_MGC_PC_CSLL              ,
          A.COB_MGC_VL_CSLL              ,
          A.COB_MGC_PC_COFINS            ,
          A.COB_MGC_VL_COFINS            ,
          A.COB_MGC_PC_PIS               ,
          A.COB_MGC_VL_PIS               ,
          A.ASS_BCT_ID                   ,
          A.NOTA_DE_CREDITO   ) ;
END IF;
---
---
--- marcar os registros que foram transportados para mgc
--- inclusive os com valor zero
update tb_cob_txt_cobranca txt
set txt.cob_txt_dt_atualiza_mgc   = pCAD_MGC_DT_REGISTRO
where txt.cob_txt_id              = pCOB_TXT_ID
  and txt.cad_pes_id_pessoa       = pCAD_PES_ID_PESSOA
  and txt.cob_txt_fl_status       = 'A'
  and txt.cob_txt_dt_atualiza_mgc is null
  and txt.fat_nof_id              = a.fat_nof_id
  and txt.atd_ate_id              = a.atd_ate_id
  and txt.cad_pac_id_paciente     = a.cad_pac_id_paciente
  and txt.cob_coc_id              = a.cob_coc_id
  and txt.cob_ccp_id              = a.cob_ccp_id;
---
---
---
END LOOP;
---
  COMMIT;
---
end prc_cob_txt_guia_atu_mgc;
