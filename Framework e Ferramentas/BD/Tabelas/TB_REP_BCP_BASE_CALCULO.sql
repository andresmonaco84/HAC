-- Create table
create table TB_REP_BCP_BASE_CALCULO
(
  REP_BCP_NM_MNEMONICO     VARCHAR2(6)    NOT NULL, -- mneumonico que identifica a base de calculo
  REP_BCP_DS_BASE_CALCULO  VARCHAR2(50)   NOT NULL, -- descricao da base de calculo
  REP_BCP_DS_CAMPO         VARCHAR2(100)  NOT NULL, -- descricao do campo
  REP_BCP_NM_CONTROLE      VARCHAR2(100)  NOT NULL  -- nome do controle
);
