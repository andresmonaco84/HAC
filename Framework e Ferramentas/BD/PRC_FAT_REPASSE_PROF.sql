CREATE OR REPLACE PROCEDURE PRC_FAT_REPASSE_PROF(psCD_PROF        IN VARCHAR2,
                                 psCD_CONS_PROF   IN VARCHAR2,
                                 psSG_UF_PROF     IN VARCHAR2,
                                 pnCodatomed      IN NUMBER,
                                 pnCd_Pacote      IN NUMBER,
                                 pnCd_Item_Pacote IN NUMBER,
                                 psCodcon         IN VARCHAR2,
                                 pnCodunihos      IN NUMBER,
                                 psCodloc         IN VARCHAR2,
                                 pnCodcladesamb   IN NUMBER,
                                 pdData           IN DATE,                                
                                   io_cursor OUT PKG_CURSOR.t_cursor) IS

v_cursor PKG_CURSOR.t_cursor;


pnPc_Hospital   NUMBER;
psTp_Cred       VARCHAR2(2);
pnCd_Clinica    NUMBER;
v_erro          number;

BEGIN

  v_erro := 0;                                                    
  
  begin       
    -- Call the procedure
    dsadt.pkg_credencia.calcula_repasse_prof(pscd_prof,
                                             pscd_cons_prof,
                                             pssg_uf_prof,
                                             pncodatomed,
                                             pncd_pacote,
                                             pncd_item_pacote,
                                             pscodcon,
                                             pncodunihos,
                                             pscodloc,
                                             pncodcladesamb,
                                             pddata,
                                             pnpc_hospital,
                                             pstp_cred,
                                             pncd_clinica);                                      
                                           
  EXCEPTION WHEN OTHERS THEN                                            
    v_erro := 1;
  END;
  
OPEN v_cursor FOR

SELECT pnpc_hospital as pnpc_hospital,
       pstp_cred     as pstp_cred,
       pncd_clinica  as pncd_clinica
  FROM DUAL;

io_cursor := v_cursor;

END PRC_FAT_REPASSE_PROF;
