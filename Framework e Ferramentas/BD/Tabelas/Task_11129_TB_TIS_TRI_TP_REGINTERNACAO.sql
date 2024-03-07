-- Add/modify columns
alter table TB_TIS_TRI_TP_REGINTERNACAO add tis_tri_fl_status char(1) default 'A';
-- Add comments to the columns
comment on column TB_TIS_TRI_TP_REGINTERNACAO.tis_tri_fl_status 
is 'Status';
-- Create/Recreate check constraints
alter table TB_TIS_TRI_TP_REGINTERNACAO
add constraint CK_TIS_TRI_FL_STATUS
check (TIS_TRI_FL_STATUS in ('A','I'));
-- INATIVAR REGIME DE INTERNAÇÃO NÃO DEFINIDO
UPDATE TB_TIS_TRI_TP_REGINTERNACAO
SET TIS_TRI_FL_STATUS = 'I'
WHERE TIS_TRI_CD_TP_REGINTERNACAO = 0;
COMMIT;