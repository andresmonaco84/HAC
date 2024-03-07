create or replace procedure PRC_ATS_AUX_REL_PROTOCOLO_I
  (
     pIDT                   IN TB_ATS_AUX_REL_PROTOCOLO.IDT%type,
     pINTAMB                IN TB_ATS_AUX_REL_PROTOCOLO.INTAMB%type default NULL,
     pPACIENTE              IN TB_ATS_AUX_REL_PROTOCOLO.PACIENTE%type default NULL,
     pCONVENIOPLANO         IN TB_ATS_AUX_REL_PROTOCOLO.CONVENIOPLANO%type default NULL,
     pEXAME                 IN TB_ATS_AUX_REL_PROTOCOLO.EXAME%type default NULL,
     pSETORLEITO            IN TB_ATS_AUX_REL_PROTOCOLO.SETORLEITO%type default NULL,
     pLOCALENTREGA          IN TB_ATS_AUX_REL_PROTOCOLO.Localentrega%type default NULL  ,
     pNUMEROEXAME           IN TB_ATS_AUX_REL_PROTOCOLO.NUMEROEXAME%type DEFAULT NULL,
     pUSUARIOPROTOCOLO      IN TB_ATS_AUX_REL_PROTOCOLO.USUARIOPROTOCOLO%type DEFAULT NULL,
     pIDTLAUDO              IN TB_ATS_AUX_REL_PROTOCOLO.IDTLAUDO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_AUX_REL_PROTOCOLO_I
  *
  *    Data Criacao:   21/02/2009   Por: Andrea Cazuca
  *    Data Alteracao:  20/03/2009  Por: Pedro
  *    Alteracao:      inclusao do pNUMEROEXAME
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_ATS_AUX_REL_PROTOCOLO
    (
       IDT,
       INTAMB,
       PACIENTE,
       CONVENIOPLANO,
       EXAME,
       SETORLEITO,
       LOCALENTREGA,
       NUMEROEXAME,
       USUARIOPROTOCOLO,
       IDTLAUDO 
    )
    VALUES
    (
       pIDT,
       pINTAMB,
       pPACIENTE,
       pCONVENIOPLANO,
       pEXAME,
       pSETORLEITO,
       pLOCALENTREGA,
       pNUMEROEXAME,
       pUSUARIOPROTOCOLO,
       pIDTLAUDO 
    );

  end PRC_ATS_AUX_REL_PROTOCOLO_I;
