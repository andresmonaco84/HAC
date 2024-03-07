alter table TB_COB_TXT_COBRANCA add COB_TXT_FL_PROCESSAR char(1);
-- Add comments to the columns 
comment on column TB_COB_TXT_COBRANCA.COB_TXT_FL_PROCESSAR  is 'FlagProcessar';