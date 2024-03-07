create or replace package sgs.PKG_LEGADO is
  -- variaveis globais e constantes
  CGS_TIPO_SP   CONSTANT VARCHAR2(2) := 'SP';
  CGS_TIPO_GB   CONSTANT VARCHAR2(2) := 'GB';
  CGS_TIPO_FUNC CONSTANT VARCHAR2(2) := 'FU';
  CGS_TIPO_PL   CONSTANT VARCHAR2(2) := 'PL';
  CGS_TIPO_PA   CONSTANT VARCHAR2(2) := 'PA';
  CGS_COD_LOC   CONSTANT VARCHAR2(3) := 'AMB';
  --
  CGS_LOCAL_AMB         CONSTANT VARCHAR2(3) := 'AMB';
  --
  CGN_CODATR_ANEST     CONSTANT NUMBER(2) := 4;
  CGS_CODINDHOS_ANEST  CONSTANT VARCHAR2(3) := 'PA';
  --
  PROCEDURE GRAVAR_ITEM_CONTA(PCODUNIHOS IN NUMBER,
                              PCODPAC    IN NUMBER,
                              PCODATE    IN NUMBER,
                              PCODATO    IN NUMBER,
                              PQTD       IN NUMBER,
                              PCODMED    IN NUMBER,
                              PPERC      IN NUMBER,
--                              PUSUARIO   IN VARCHAR2,
                              PRETORNO   OUT NUMBER,
                              PMSG       OUT VARCHAR2);
  --
  FUNCTION TROCA_INDCLACON(pn_codatomed IN NUMBER,
                           ps_indclacon IN VARCHAR2) RETURN VARCHAR2;
  --
  PROCEDURE VERIFICA_ATOMEDICO(pnCodateamb IN NUMBER,
                               psCodcon    IN CHAR,
                               pnCodatomed IN NUMBER,
                               psCodloc    IN VARCHAR2,
                               pd_datexa   IN DATE,
                               pnRetorno   IN OUT NUMBER);
  --
  PROCEDURE CALC_EXA_AMB_SADT(pn_atomedico   IN NUMBER,
                              ps_codcon      IN VARCHAR2,
                              pd_datexa      IN DATE,
                              pn_codunihos   IN NUMBER,
                              ps_codpadpac   IN VARCHAR2,
                              pn_codateamb   IN NUMBER,
                              pn_cd_clinica  IN NUMBER,
                              ps_codindhos   IN OUT VARCHAR2,
                              pn_qtdch       IN OUT NUMBER,
                              pn_valorch     IN OUT NUMBER,
                              pn_percobtab   IN OUT NUMBER,
                              pn_valor_exame IN OUT NUMBER,
                              ps_codtab      IN OUT VARCHAR2);
  --
  PROCEDURE DESCONTO_SADT(pn_atomedico   IN NUMBER,
                          ps_codcon      IN VARCHAR2,
                          pn_qtdch       IN NUMBER,
                          pn_percobtab   IN NUMBER,
                          pn_valorch     IN OUT NUMBER,
                          pn_valor_exame IN OUT NUMBER);
  --
  PROCEDURE CALC_M2_FILME_ITEM(PN_CODUNIHOS IN NUMBER,
                               PN_CODPAC    IN NUMBER,
                               PN_CODATE    IN NUMBER,
                               PN_CODATO    IN NUMBER,
                               PD_DATEXA    IN DATE,
                               PN_VL_FILME  OUT NUMBER,
                               PN_VL_TAXA   OUT NUMBER);
  --
  PROCEDURE CLASSAMB(pnCODATOMED IN NUMBER,
                     psCODCON    IN VARCHAR2,
                     psINDCLACON IN VARCHAR2,
                     pnCODSER    IN NUMBER,
                     pnCODCLACTB IN OUT NUMBER);
  --
  PROCEDURE CALC_HE_AMB(pn_codateamb IN NUMBER,
                        pn_codclactb IN NUMBER,
                        pn_codatomed IN NUMBER,
                        ps_codtab    IN VARCHAR2,
                        pn_perext    IN OUT NUMBER);
  --
  FUNCTION RET_TAXA_ADM(ps_codcon     IN VARCHAR2,
                        pn_codunihos  IN NUMBER,
                        ps_codloc     IN VARCHAR2,
                        ps_in_int_ext IN CHAR,
                        pd_datexa     IN DATE) RETURN NUMBER;
  ---
  PROCEDURE Busca_Indclacon(pn_codatomed IN NUMBER,
                            ps_indclacon OUT VARCHAR2);
  --
  PROCEDURE VERIFICA_BRADESCO(ps_codcon    IN VARCHAR2,
                              pn_codateamb IN NUMBER,
                              ps_local     IN VARCHAR2,
                              pd_data      IN DATE,
                              ps_tipo      IN OUT VARCHAR2);
  --
  PROCEDURE BUSCA_PRIORIDADE_SP(pn_codser     IN NUMBER,
                                ps_local      IN VARCHAR2,
                                ps_codcon     IN VARCHAR2,
                                pn_prioridade IN NUMBER,
                                ps_codpadpac  IN VARCHAR2,
                                pd_datexa     IN DATE,
                                ps_codtab     IN OUT VARCHAR2,
                                pn_percobtab  IN OUT NUMBER);
  --
  PROCEDURE BUSCA_CODIGO_INDICE(ps_codtab    IN VARCHAR2,
                                ps_codindhos IN OUT VARCHAR2);
  --
  PROCEDURE VERIFICA_PRODUTO(ps_codcon    IN VARCHAR2,
                             pn_codateamb IN NUMBER,
                             pn_atomedico IN NUMBER,
                             pn_codser    IN NUMBER,
                             ps_local     IN VARCHAR2,
                             pd_data      IN DATE,
                             pn_valorch   IN OUT NUMBER);
  --
  PROCEDURE CALC_DESCONTO(pn_atomedico   IN NUMBER,
                          ps_codcon      IN VARCHAR2,
                          pn_qtdch       IN NUMBER,
                          pn_percobtab   IN NUMBER,
                          pn_valorch     IN OUT NUMBER,
                          pn_valor_exame IN OUT NUMBER);
  --
  PROCEDURE VERIFICA_ATOMEDICO_CLINICA(pnCodateamb   IN NUMBER,
                                       psCodcon      IN CHAR,
                                       pnCodatomed   IN NUMBER,
                                       psCodloc      IN VARCHAR2,
                                       pd_datexa     IN DATE,
                                       pn_cd_clinica IN NUMBER,
                                       pnRetorno     IN OUT NUMBER);
end PKG_LEGADO;
