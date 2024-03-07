CREATE OR REPLACE PROCEDURE PRC_CAD_EMAIL_CENTRO_PESQ
(
   pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_EMAIL_CENTRO_PESQ
*
*    Data Criacao:   21/9/2015  Por: Andre
*
*    Funcao: ENVIAR E-MAIL PARA CENTRO DE PESQUISA
*******************************************************************/
vDSC_UNIDADE   TB_CAD_UNI_UNIDADE.CAD_UNI_DS_UNIDADE%type;
vDT_ATD        TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type;
vHR_ATD        TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%type;
vID_LOCAL      TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type;
vFL_STATUS     TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_STATUS%type;
vID_PACIENTE   TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%type;
vNOME_PAC      TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type;
vID_PESSOA     TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type;
vCD_HAC_PREST  TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%type;
pEmail_Corpo  varchar2(5000);
BEGIN
  BEGIN
    SELECT PAT.CAD_PAC_ID_PACIENTE, NVL(CNV_PAT.CAD_CNV_CD_HAC_PRESTADOR, CNV_PAC.CAD_CNV_CD_HAC_PRESTADOR)
      INTO vID_PACIENTE,            vCD_HAC_PREST
      FROM (SELECT * FROM TB_ASS_PAT_PACIEATEND PAT
             WHERE PAT.ATD_ATE_ID = pATD_ATE_ID
             ORDER BY PAT.ASS_PAT_DT_SAIDA DESC) PAT JOIN
            TB_CAD_PAC_PACIENTE PAC     ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN 
            TB_CAD_CNV_CONVENIO CNV_PAC ON CNV_PAC.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO LEFT JOIN
            TB_CAD_CNV_CONVENIO CNV_PAT ON CNV_PAT.CAD_CNV_ID_CONVENIO = PAT.CAD_CNV_ID_CONVENIO
     WHERE ROWNUM = 1; 
    /*SELECT CAD_PAC_ID_PACIENTE, (SELECT CNV.CAD_CNV_CD_HAC_PRESTADOR FROM TB_CAD_CNV_CONVENIO CNV WHERE CNV.CAD_CNV_ID_CONVENIO = PAT.CAD_CNV_ID_CONVENIO)
      INTO vID_PACIENTE,        vCD_HAC_PREST
      FROM (SELECT * FROM TB_ASS_PAT_PACIEATEND PAT
             WHERE PAT.ATD_ATE_ID = pATD_ATE_ID
             ORDER BY PAT.ASS_PAT_DT_SAIDA DESC) PAT
     WHERE ROWNUM = 1;*/
  EXCEPTION WHEN NO_DATA_FOUND THEN
    NULL;--Nao realizar nenhuma acao na origem (tela de atendimento)
  END;
  IF (TRIM(vCD_HAC_PREST) = 'CPJR') THEN
      SELECT U.CAD_UNI_DS_UNIDADE, ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO, ATD.ATD_ATE_DT_ATENDIMENTO, ATD.ATD_ATE_HR_ATENDIMENTO, ATD.ATD_ATE_FL_STATUS
        INTO vDSC_UNIDADE,         vID_LOCAL,                        vDT_ATD,                    vHR_ATD,                    vFL_STATUS
        FROM TB_ATD_ATE_ATENDIMENTO ATD,
             TB_CAD_UNI_UNIDADE U
       WHERE U.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE AND
             ATD.ATD_ATE_ID = pATD_ATE_ID;   
      
      IF (vID_LOCAL IN (30,34) AND vFL_STATUS = 'A') THEN --So envia para PS e PA
          SELECT PAC.CAD_PES_ID_PESSOA
            INTO vID_PESSOA
            FROM TB_CAD_PAC_PACIENTE PAC
           WHERE PAC.CAD_PAC_ID_PACIENTE = vID_PACIENTE;      

           SELECT P.CAD_PES_NM_PESSOA
             INTO vNOME_PAC
             FROM TB_CAD_PES_PESSOA P
            WHERE P.CAD_PES_ID_PESSOA = vID_PESSOA;

           pEmail_Corpo :=  '<html><body>
                             <b><span style="font-size:10.0pt;font-family:Verdana,sans-serif;color:green">Aviso de registro de atendimento de urgencia para paciente participante do protocolo de pesquisa</span></b><P>
                             <span style="font-size:10.0pt;font-family:Verdana,sans-serif">                     
                               Mensagem Automatica<P>
                               Foi registrado o atendimento de urgencia do paciente participante do protocolo de pesquisa #NOME_PAC em #DT_ATD as #HR_ATD na unidade #DSC_UNIDADE.<P>
                               Sistema de Atendimento SGS</B>
                             </span><P>
                             <span style="font-size:13.0pt;font-family:Verdana,sans-serif;color:green">Hospital Ana Costa</span>
                             </html></body>';

           pEmail_Corpo := Replace(pEmail_Corpo, '#NOME_PAC', vNOME_PAC);
           pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_UNIDADE', vDSC_UNIDADE);
           pEmail_Corpo := Replace(pEmail_Corpo, '#DT_ATD', TO_CHAR(vDT_ATD, 'DD/MM/YYYY'));
           pEmail_Corpo := Replace(pEmail_Corpo, '#HR_ATD', SUBSTR(TO_CHAR(LPAD(vHR_ATD, 4, 0)), 0, 2) || ':' || SUBSTR(TO_CHAR(LPAD(vHR_ATD, 4, 0)), 3, 2));

           PRC_ENVIA_EMAIL('sgs@anacosta.com.br',
                           'centrodepesquisa@anacosta.com.br',
                           NULL,
                           'Aviso - Reg. atendimento ' || TO_CHAR(pATD_ATE_ID) || ' de urgencia p/ pac. participante do protocolo de pesquisa',
                           pEmail_Corpo);
      END IF;
  END IF; 
END PRC_CAD_EMAIL_CENTRO_PESQ;
