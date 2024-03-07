-- Add/modify columns 
alter table TB_CAD_CNV_CONVENIO add cad_cnv_fl_atendeexameocupa char(1) default 'N';
-- Add comments to the columns 
comment on column TB_CAD_CNV_CONVENIO.cad_cnv_fl_atendeexameocupa
  is 'FlagAtendeExameSaudeOcupacional';
-- Create/Recreate check constraints 
alter table TB_CAD_CNV_CONVENIO
  add constraint CK_CAD_CNV_FL_ATENDEEXAMEOCUPA
  check (CAD_CNV_FL_ATENDEEXAMEOCUPA IN ('S','N'));
