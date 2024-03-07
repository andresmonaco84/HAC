CREATE OR REPLACE PROCEDURE PRC_FAT_REPASSE_MEDICO(psCdProf        IN VARCHAR2,
                                   pnCodatomed      IN NUMBER,
                                   pnCd_Pacote      IN NUMBER DEFAULT NULL,
                                   pnCd_Item_Pacote IN NUMBER DEFAULT NULL,
                                   psCodcon         IN VARCHAR2,
                                   pnCodunihos      IN NUMBER,
                                   psCodespmed      IN VARCHAR2 DEFAULT NULL,
                                   psCodloc         IN VARCHAR2,
                                   pnCodcladesamb   IN NUMBER,
                                   pdData           IN DATE,            
                                   psTpConselho     in VARCHAR2, 
                                   psSgUfProf       IN VARCHAR2,                      
                                   io_cursor OUT PKG_CURSOR.t_cursor) IS
v_cursor PKG_CURSOR.t_cursor;
pnPc_Hospital   NUMBER;
psTp_Cred       VARCHAR2(2);
pnCd_Clinica    NUMBER;
v_erro          number;
psMensagem      VARCHAR2(300);
psFlPergunta    CHAR(1);
BEGIN
v_erro := 0;
psFlPergunta  := 'N';
  BEGIN              
     dsadt.pkg_credencia.VALIDA_PROFISSIONAL_REPASSE (psTpConselho,
                                                    psCdProf,
                                                    pnCodatomed,
                                                    pnCd_Pacote,
                                                    pnCd_Item_Pacote,
                                                    psCodCon,
                                                    psCodLoc,
                                                    pnCodUniHos,
                                                    pdData,
                                                    psTp_Cred,
                                                    psMensagem);
     IF psTp_Cred IS NULL AND psMensagem IS NULL THEN                                             
--                                                    
        IF psTpConselho = 'CRM' or psTpConselho = 'CRO'  THEN
           dsadt.pkg_credencia.calcula_repasse_medico(psCdProf,
                                                      pncodatomed,
                                                      pncd_pacote,
                                                      pncd_item_pacote,
                                                      pscodcon,
                                                      pncodunihos,
                                                      pscodespmed,
                                                      pscodloc,
                                                      pncodcladesamb,
                                                      pddata,
                                                      pnpc_hospital,
                                                      pstp_cred,
                                                      pncd_clinica); 
        ELSE
            -- Call the procedure
            dsadt.pkg_credencia.calcula_repasse_prof(psCdProf,
                                                     psTpConselho,
                                                     psSgUfProf,
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
         END IF;
      END IF;                                                                                                                                       
 --  EXCEPTION WHEN OTHERS THEN                                            
 ---            v_erro := 1;
   --
      IF pstp_cred = 'PA' AND psCdProf <> '99999' AND psTpConselho = 'CRM' THEN
         psMensagem := 'Este medico ' || psCdProf ||', foi identificado como PA-Paticular.'
         ||' Ao inves disso, deseja gravar o medico externo com crm 99999?';
         psFlPergunta := 'S';
      ELSE
         IF psCdProf = '99999' AND psTpConselho = 'CRM' AND (pstp_cred = 'PA' OR pstp_cred IS NULL) THEN
            psMensagem := 'Este procedimento pertence a uma empresa medica. Informando crm 99999 '||
            '- medico externo, a empresa medica n?o recebera este procedimento. Deseja continuar?';
             psFlPergunta := 'S';
         END IF;
      END IF;
   END;                                                       
   OPEN v_cursor FOR
   SELECT pnpc_hospital as pnpc_hospital,
          pstp_cred     as pstp_cred,
          pncd_clinica  as pncd_clinica,
          psFlPergunta  as psFlPergunta,
          psMensagem    as psMensagem          
   FROM DUAL;
   io_cursor := v_cursor;
END PRC_FAT_REPASSE_MEDICO;
