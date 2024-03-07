SELECT DISTINCT  
 DECODE(TIN.TIS_TIN_DS_INTERNACAO,'CIRURGICA', 'CIRURGICA','CLINICA') TIPO_INT,
ATD.Atd_Ate_Fl_Suspeita_Covid19 SUSP_COVID19,
  PAC.CAD_PAC_NR_PRONTUARIO PRONTUARIO,
   DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') SIT_PAC,
    ATD.ATD_ATE_ID ATD,
    TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) DT_INT,
    TRUNC(ATD.ATD_ATE_HR_ATENDIMENTO) HR_INT,
    SETORENT.CAD_SET_DS_SETOR SETOR_ADM,
    PES.CAD_PES_NM_PESSOA PACIENTE,
    PES.CAD_PES_DT_NASCIMENTO DT_NASC,
    FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM),
    PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE, 
    PES.CAD_PES_TP_SEXO SEXO,
    fnc_cad_pes_municipio_s(PAC.CAD_PES_ID_PESSOA,1) MUNICIPIO,
    PRF.AUX_PRF_DS_DESCRICAO PROFISSAO,
    CNV.Cad_Cnv_Nm_Fantasia CONVENIO, 
    SETOR.CAD_SET_DS_SETOR SETOR_ENT, 
    IML_QLE.ATD_IML_DT_ENTRADA DT_ENT_LEITO, 
    IML_QLE.ATD_IML_HR_ENTRADA HR_ENT_LEITO,    
    INA.ATD_INA_DT_ALTA_ADM DT_ALTA, 
    INA.ATD_INA_HR_ALTA_ADM HR_ALTA,
MSI.TIS_MSI_DS_MOTIVOSAIDAINT   MOTIVO_SAIDA ,   
FNC_INT_ULTIMO_CID(ATD.ATD_ATE_ID) CID10,         
 MPM.ATD_MPM_DS_MEDICAMENTO MEDICAMENTO, 
      REEXA.DATA,      
       REEXA.CODMNE,
       REEXA.DESCRICAO,
       REEXA.RESULTADO
  FROM          TB_ATD_ATE_ATENDIMENTO    ATD
  JOIN          TB_ASS_PAT_PACIEATEND     PAT  ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC  ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(pat.atd_ate_id)
  JOIN          TB_CAD_PES_PESSOA         PES  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_PME_PRESCRICAO_MEDICA PME ON PME.ATD_ATE_ID = ATD.ATD_ATE_ID 
  AND  PME.ATD_PME_FL_STATUS = 'A' AND 
  (TRUNC(PME.ATD_PME_DT_ULT_ATUALIZ) = TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO)   OR     (TRUNC(PME.ATD_PME_DT_ULT_ATUALIZ) + 1 = TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) + 1))    
  LEFT  JOIN      TB_ATD_MPM_MED_PRESC_MED MPM ON MPM.ATD_PME_ID  = PME.ATD_PME_ID    
  AND MPM.ATD_MPM_DS_MEDICAMENTO IS NOT NULL
  LEFT JOIN tb_cad_mtmd_mat_med mtmd  ON MTMD.CAD_MTMD_ID = MPM.CAD_MTMD_ID
AND  mtmd.cad_mtmd_grupo_id = 1
and mtmd.cad_mtmd_subgrupo_id in( 14, 981,913)
  LEFT JOIN TB_AUX_PRF_PROFISSAO PRF ON PRF.AUX_PRF_CD_CODIGO = PES.AUX_PRF_CD_CODIGO
  LEFT JOIN (
  select 
      a.codateamb,
       a.datexa DATA,      
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       paciente_atendimento_amb  e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.codateamb
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19D', 'COV19L', 'COV19F', 'COV19P') 
   and b.codsitldo = 'R'
UNION
select   
a.codateamb,
a.datexa DATA,    
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       tb_internado              e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.nr_seqinter
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19D', 'COV19L', 'COV19F', 'COV19P')  
   and b.codsitldo = 'R'
UNION
select  a.codateamb,
a.datexa DATA,      
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       paciente_atendimento_amb  e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.codateamb
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19D')
   and f.sequencia(+) = 3   
   and b.codsitldo <> 'R'
UNION
select  
a.codateamb,
a.datexa DATA,           
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       tb_internado              e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.nr_seqinter
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19D')
   and f.sequencia(+) = 3  
   and b.codsitldo <> 'R'
UNION
select  
a.codateamb,
a.datexa DATA,          
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       paciente_atendimento_amb  e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.codateamb
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19L')
   and f.sequencia(+) = 4  
   and b.codsitldo <> 'R'
UNION
select 
a.codateamb,
  a.datexa DATA,      
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       tb_internado              e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.nr_seqinter
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19L')
   and f.sequencia(+) = 4  
   and b.codsitldo <> 'R'
UNION
select  
a.codateamb,
a.datexa DATA,         
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       paciente_atendimento_amb  e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.codateamb
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19F')
   and f.sequencia(+) = 3  
   and b.codsitldo <> 'R'
UNION
select 
 a.codateamb,
  a.datexa DATA,      
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
      tb_internado              e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.nr_seqinter
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19F')
   and f.sequencia(+) = 3   
   and b.codsitldo <> 'R'
UNION
select 
a.codateamb,
a.datexa DATA,      
       c.codmne CODMNE,
      c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       paciente_atendimento_amb  e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.codateamb
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19P')
   and f.sequencia(+) = 3   
   and b.codsitldo <> 'R'
UNION
select   
a.codateamb,
a.datexa DATA,     
     
       c.codmne CODMNE,
       c.desexa DESCRICAO,
       decode(g.txt_padrao, null, f.resultado, g.txt_padrao) RESULTADO, f.sequencia
  from sadt_paciente             a,
       sadt_exames_paciente      b,
       sadt_exame                c,
       sadt_procedencia          d,
       tb_internado              e,
       sadt_resultado_exame      f,
       sadt_texto_padrao         g
where a.codunisad = b.codunisad
   and a.codunihos = b.codunihos
   and a.codexa = b.codexa
   and b.codunisad = c.codunisad
   and b.codmne = c.codmne
   and a.cd_proced = d.cd_proced
   and a.codateamb = e.nr_seqinter
   and b.codunisad = f.codunisad(+)
   and b.codunihos = f.codunihos(+)
   and b.codexa = f.codexa(+)
   and b.codmne = f.codmne(+)
   and f.codunisad = g.codunisad(+)
   and f.resultado = g.cd_padrao(+)
   and a.codunisad = 'L'
   and (a.cancelado <> 'S' or a.cancelado is null)
   and b.codmne in ('COV19P')
   and f.sequencia(+) = 3   
   and b.codsitldo <> 'R'  
  ) REEXA
  ON REEXA.CODATEAMB = ATD.ATD_ATE_ID
LEFT JOIN  (  SELECT QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                       IML.ATD_ATE_ID, IML.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                       IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA, IML.ATD_IML_DT_SAIDA, IML.ATD_IML_ID,
                       IML.TIS_TAC_CD_TIPO_ACOMOD_AUT
                  FROM TB_ATD_IML_INT_MOV_LEITO IML 
             LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                  JOIN TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 WHERE   (ATD2.CAD_UNI_ID_UNIDADE = 244)
                  AND    (ATD2.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29)
                  AND     FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MIN(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) 
                                         FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                          WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A' 
                                         ) )  IML_QLE_ENT
  ON            IML_QLE_ENT.ATD_ATE_ID = ATD.ATD_ATE_ID
LEFT JOIN  (  SELECT QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                       IML.ATD_ATE_ID, IML.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                       IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA, IML.ATD_IML_DT_SAIDA, IML.ATD_IML_ID,
                       IML.TIS_TAC_CD_TIPO_ACOMOD_AUT
                  FROM TB_ATD_IML_INT_MOV_LEITO IML
             LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                  JOIN TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 WHERE   (ATD2.CAD_UNI_ID_UNIDADE = 244)
                  AND    (ATD2.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29)
                  AND     FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) 
                                         FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                          WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A' 
                                         ) )  IML_QLE
  ON            IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
LEFT JOIN          TB_TIS_TAC_TIPO_ACOMODACAO   TAC  ON            TAC.TIS_TAC_CD_TIPO_ACOMODACAO = IML_QLE.TIS_TAC_CD_TIPO_ACOMODACAO
LEFT JOIN          TB_TIS_TAC_TIPO_ACOMODACAO   TAC_AUT ON        TAC_AUT.TIS_TAC_CD_TIPO_ACOMODACAO = IML_QLE.TIS_TAC_CD_TIPO_ACOMOD_AUT
LEFT JOIN          TB_CAD_SET_SETOR            SETOR ON            SETOR.CAD_SET_ID          = IML_QLE.CAD_SET_ID
LEFT JOIN          TB_CAD_SET_SETOR            SETORENT ON            SETORENT.CAD_SET_ID          = IML_QLE_ENT.CAD_SET_ID
 JOIN          TB_ATD_AIC_ATE_INT_COMPL     AIC  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA          INA  ON            INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_TIS_MSI_MOTIVO_SAIDA_INT  MSI ON             MSI.TIS_MSI_CD_MOTIVOSAIDAINT = INA.TIS_MSI_CD_MOTIVOSAIDAINT
  JOIN          TB_TIS_CBO_CBOS             CBOS  ON            CBOS.TIS_CBO_CD_CBOS      = ATD.TIS_CBO_CD_CBOS
  JOIN          TB_CAD_UNI_UNIDADE           UNI  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO  ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
  LEFT JOIN     TB_TIS_TIN_TP_INTERNACAO    TIN  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN     TB_TIS_TRI_TP_REGINTERNACAO TRI  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO

  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = AIC.CAD_PRD_ID   
   WHERE
       ( ATD.CAD_UNI_ID_UNIDADE = 244)  
   AND ( ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29)   
   AND (ATD.ATD_ATE_FL_STATUS = 'A')
  AND ATD.ATD_ATE_DT_ATENDIMENTO >= '01-JAN-2020'  
   AND ATD.ATD_ATE_DT_ATENDIMENTO <= TRUNC(SYSDATE)  
   AND ATD.ATD_ATE_TP_PACIENTE = 'I' 
   AND (AIC.ATD_AIC_TP_SITUACAO_PAC = 'I'    OR (AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND  (TRUNC(INA.ATD_INA_DT_ALTA_CLINICA) IN(TRUNC(SYSDATE) - 1, TRUNC(SYSDATE))) ))
AND SETOR.CAD_CSE_ID <> 8
ORDER BY 6,10,24,27
