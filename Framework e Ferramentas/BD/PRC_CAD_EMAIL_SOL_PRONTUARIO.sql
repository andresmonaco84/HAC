CREATE OR REPLACE PROCEDURE PRC_CAD_EMAIL_SOL_PRONTUARIO
(
   pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type
)
is
/********************************************************************
*    Procedure: PRC_CAD_EMAIL_SOL_PRONTUARIO
*
*    Data Criacao:	 17/4/2012  Por: André
*
*    Funcao: ENVIAR E-MAIL DE SOLICITAÇÃO DE PRONTUÁRIO
*******************************************************************/

--pID_Setor      TB_ATD_ATE_ATENDIMENTO.CAD_SET_ID%type;
vDSC_SETOR     TB_CAD_SET_SETOR.CAD_SET_DS_SETOR%type;
vID_PACIENTE   TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%type;
vNR_PRONTUARIO TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%type;
vID_CONVENIO   TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type;
vCOD_CONVENIO  TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%type;
vNOME_CONVENIO  TB_CAD_CNV_CONVENIO.CAD_CNV_NM_FANTASIA%type;
vID_PLANO      TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type;
vCOD_PLANO     TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type;
vNOME_PLANO    TB_CAD_PLA_PLANO.CAD_PLA_NM_NOME_PLANO%type;
vNOME_PAC      TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type;
vTP_SEXO       TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%type;
vDT_NASC       TB_CAD_PES_PESSOA.CAD_PES_DT_NASCIMENTO%type;
vID_PESSOA     TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type;
vNOME_PROF     TB_CAD_PRO_PROFISSIONAL.CAD_PRO_NM_NOME%type;

pEmail_Corpo  varchar2(5000);

FUNCTION RETIRAR_ACENTO(texto IN varchar) RETURN varchar IS  
semAcento varchar(8000) := LOWER(texto);
BEGIN
   semAcento := replace(semAcento,'á','a');
   semAcento := replace(semAcento,'à','a');   
   semAcento := replace(semAcento,'ã','a');
   semAcento := replace(semAcento,'â','a');
   semAcento := replace(semAcento,'é','e');
   semAcento := replace(semAcento,'è','e');
   semAcento := replace(semAcento,'ê','e');
   semAcento := replace(semAcento,'í','i');
   semAcento := replace(semAcento,'ì','i');
   semAcento := replace(semAcento,'î','i');
   semAcento := replace(semAcento,'ó','o');
   semAcento := replace(semAcento,'ò','o');
   semAcento := replace(semAcento,'ô','o');
   semAcento := replace(semAcento,'õ','o');
   semAcento := replace(semAcento,'ú','u');
   semAcento := replace(semAcento,'ù','u');
   semAcento := replace(semAcento,'û','u');
   semAcento := replace(semAcento,'ü','u');
   semAcento := replace(semAcento,'ç','c');
   return (UPPER(semAcento));
END;

begin

  SELECT CAD_PAC_ID_PACIENTE, CAD_CNV_ID_CONVENIO, CAD_PLA_ID_PLANO
    INTO vID_PACIENTE,        vID_CONVENIO,        vID_PLANO
   FROM (SELECT * FROM TB_ASS_PAT_PACIEATEND PAT
         WHERE PAT.ATD_ATE_ID = pATD_ATE_ID
         ORDER BY PAT.ASS_PAT_DT_SAIDA DESC) WHERE ROWNUM = 1;

  IF (vID_CONVENIO IS NULL) THEN
     SELECT PAC.CAD_CNV_ID_CONVENIO, PAC.CAD_PLA_ID_PLANO
       INTO vID_CONVENIO,            vID_PLANO
       FROM TB_CAD_PAC_PACIENTE PAC
      WHERE PAC.CAD_PAC_ID_PACIENTE = vID_PACIENTE;
  END IF;

  SELECT PAC.CAD_PAC_NR_PRONTUARIO, PAC.CAD_PES_ID_PESSOA
    INTO vNR_PRONTUARIO,            vID_PESSOA
    FROM TB_CAD_PAC_PACIENTE PAC
   WHERE PAC.CAD_PAC_ID_PACIENTE = vID_PACIENTE;

  SELECT C.CAD_CNV_CD_HAC_PRESTADOR, C.CAD_CNV_NM_FANTASIA
    INTO vCOD_CONVENIO,              vNOME_CONVENIO
   FROM TB_CAD_CNV_CONVENIO C
   WHERE C.CAD_CNV_ID_CONVENIO = vID_CONVENIO;

  SELECT P.CAD_PLA_CD_PLANO_HAC, P.CAD_PLA_NM_NOME_PLANO
    INTO vCOD_PLANO,             vNOME_PLANO
   FROM TB_CAD_PLA_PLANO P
   WHERE P.CAD_PLA_ID_PLANO = vID_PLANO;

  SELECT S.CAD_SET_DS_SETOR, P.CAD_PRO_NM_NOME
    INTO vDSC_SETOR,         vNOME_PROF
    FROM TB_ATD_ATE_ATENDIMENTO ATD,
         TB_CAD_SET_SETOR S,
         TB_CAD_PRO_PROFISSIONAL P
   WHERE S.CAD_SET_ID = ATD.CAD_SET_ID AND
         P.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC AND
         ATD.ATD_ATE_ID = pATD_ATE_ID;
         
   SELECT P.CAD_PES_NM_PESSOA, P.CAD_PES_DT_NASCIMENTO, P.CAD_PES_TP_SEXO
     INTO vNOME_PAC,           vDT_NASC,                vTP_SEXO
     FROM TB_CAD_PES_PESSOA P
    WHERE P.CAD_PES_ID_PESSOA = vID_PESSOA;

   pEmail_Corpo :=  '<FONT FACE="ARIAL">
                     Setor solicitante: <B>#DSC_SETOR</B><BR>
                     Prontuario: <B>#NR_PRONTUARIO</B><BR>
                     Nome Paciente: <B>#NOME_PAC</B><BR>                     
                     Data de Nascimento: <B>#DT_NASC</B> Sexo: <B>#TP_SEXO</B><BR>                    
                     Atendimento: <B>#NR_ATENDIMENTO</B><BR>
                     Convenio: <B>#COD_CONVENIO #NOME_CONVENIO</B><BR>
                     Plano: <B>#COD_PLANO #NOME_PLANO</B><P>
                     Nome do Profissional: <B>#NOME_PROF</B><P>                     
                     <span style="color:green">Hospital Ana Costa</span><br>
                     <span style="font-size: 7pt">&nbsp;&nbsp;&nbsp;Sua saude em boas maos</span>
                     </FONT>';

   pEmail_Corpo := Replace(pEmail_Corpo, '#DSC_SETOR', RETIRAR_ACENTO(vDSC_SETOR));
   pEmail_Corpo := Replace(pEmail_Corpo, '#NR_PRONTUARIO', TO_CHAR(vNR_PRONTUARIO));
   pEmail_Corpo := Replace(pEmail_Corpo, '#NR_ATENDIMENTO', TO_CHAR(pATD_ATE_ID));
   pEmail_Corpo := Replace(pEmail_Corpo, '#COD_CONVENIO', vCOD_CONVENIO);
   pEmail_Corpo := Replace(pEmail_Corpo, '#NOME_CONVENIO', RETIRAR_ACENTO(vNOME_CONVENIO));
   pEmail_Corpo := Replace(pEmail_Corpo, '#COD_PLANO', vCOD_PLANO);
   pEmail_Corpo := Replace(pEmail_Corpo, '#NOME_PLANO', RETIRAR_ACENTO(vNOME_PLANO));
   pEmail_Corpo := Replace(pEmail_Corpo, '#NOME_PROF', RETIRAR_ACENTO(vNOME_PROF));
   pEmail_Corpo := Replace(pEmail_Corpo, '#NOME_PAC', RETIRAR_ACENTO(vNOME_PAC));
   pEmail_Corpo := Replace(pEmail_Corpo, '#DT_NASC', TO_CHAR(vDT_NASC, 'DD/MM/YYYY'));
   pEmail_Corpo := Replace(pEmail_Corpo, '#TP_SEXO', vTP_SEXO);

   PRC_ENVIA_EMAIL('sgs@anacosta.com.br',
                   'arquivo@anacosta.com.br',
                   NULL,
                   'SOLICITACAO DE PRONTUARIO',
                   pEmail_Corpo);

end PRC_CAD_EMAIL_SOL_PRONTUARIO;
