create or replace procedure PRC_AGS_AGG_AGE_GERACAO_SADT
  (
     pAGS_ESM_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_ESM_ID%type,
     pSEG_USU_ID_USUARIO IN TB_AGS_AGG_AGE_GERADA_SADT.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGG_AGE_GERADA_SADT_I
  *
  *    Data Criacao:   26/03/2008   Por: Cristiane Gomes da Silva
  *    Data Alteracao:  27/01/2009  Por: Cristiane Gomes da Silva
  *
  *    Funcao: Inclui agenda gerada para a escala SADT na tabela
  *            TB_AGS_AGG_AGE_GERADA_SADT
  *
  *    Alteracao: 1) Inclusao de Exception para tratamento de erro
  *	              2) comentei --AND    ESM.AGS_ESM_FL_STATUS = 'P'
  *               3) Ajuste dos horarios gerados
  *               4) Ajuste para nao calcular ou considerar o intervalo 
  *               em 60 minutos
  *               5) Ajuste contemplar tambem o intervalo de 90 minutos
  *
  *******************************************************************/

    lIdtRetorno       integer;
    v_contador        integer;
    v_dtgerada        date;
    v_hrgerada        number(4);
    v_datainiesc      date;
    v_datafimesc      date;
    v_qtdiasint       number;
    v_qtsemcriacao    number;
    v_idtunidade      number;
    v_qtagepermhora   number;
    v_qtdatagerada    number;
    v_isferiado       boolean;
    v_idtfalta        number;
    v_intervalo       number;
    v_hrinicial       number(4);
    v_hrfinal         number(4);
    v_hradic          number(4);
    v_minadic         number(4);
    v_temp            number(4);
    v_error_code      number;
    v_error_message   varchar2(900);
begin

    SELECT COUNT(*)
    INTO   v_contador
    FROM   TB_AGS_ESM_ESCALA_SADT ESM
    WHERE  ESM.AGS_ESM_ID = pAGS_ESM_ID
    AND    ESM.AGS_ESM_FL_AGENDAGERADA_OK = 'N';

    IF v_contador > 0 THEN
       SELECT ESM.AGS_ESM_DT_INI_ESCALA, ESM.AGS_ESM_QT_DIAS_INTERVALO,
              ESM.AGS_ESM_QT_SEMANAS_CRIACAO, ESM.CAD_UNI_ID_UNIDADE,
              ESM.AGS_ESM_QT_AGE_PERM_HORA, ESM.AGS_ESM_HR_INI_ESCALA,
              ESM.AGS_ESM_HR_FIM_ESCALA, ESM.AGS_ESM_DT_FIM_ESCALA
       INTO   v_datainiesc, v_qtdiasint,
              v_qtsemcriacao,v_idtunidade,
              v_qtagepermhora, v_hrinicial,
              v_hrfinal, v_datafimesc
       FROM   TB_AGS_ESM_ESCALA_SADT ESM
       WHERE  ESM.AGS_ESM_ID = pAGS_ESM_ID;

       v_qtdatagerada := 0;
       v_isferiado := TRUE;
       v_dtgerada := v_datainiesc;
       v_intervalo :=  v_qtagepermhora;
       v_hradic := 0;
       v_temp:= 0;
       
       LOOP

         WHILE v_isferiado = TRUE LOOP
           SELECT COUNT(*)
           INTO   v_contador
           FROM   TB_CAD_FER_FERIADO FER
           WHERE  FER.CAD_FER_DT_FERIADO = v_dtgerada
           AND    ((FER.CAD_UNI_ID_UNIDADE = v_idtunidade
           AND    FER.CAD_FER_TP_FERIADO != 'F')
           OR     (FER.CAD_FER_TP_FERIADO = 'F'));

           IF v_contador = 0 THEN
              v_isferiado := FALSE;
           ELSE
              v_dtgerada := v_dtgerada + v_qtdiasint;
           END IF;
         END LOOP;

         EXIT WHEN ((v_qtdatagerada >= v_qtsemcriacao) OR (v_dtgerada > v_datafimesc AND v_datafimesc is not null));

         v_idtfalta := null;

         SELECT COUNT(*)
         INTO   v_contador
         FROM   TB_AGS_ESF_ESCALA_FALTA_SADT ESF
         WHERE  ESF.AGS_ESM_ID = pAGS_ESM_ID
         AND v_dtgerada BETWEEN ESF.AGS_ESF_DT_INI_FALTA AND ESF.AGS_ESF_DT_FIM_FALTA;

         IF v_contador > 0 THEN
           SELECT ESF.AGS_ESF_ID
           INTO   v_idtfalta
           FROM   TB_AGS_ESF_ESCALA_FALTA_SADT ESF
           WHERE  ESF.AGS_ESM_ID = pAGS_ESM_ID
           AND v_dtgerada BETWEEN ESF.AGS_ESF_DT_INI_FALTA AND ESF.AGS_ESF_DT_FIM_FALTA;
         END IF;

         v_hrgerada :=  v_hrinicial;

         LOOP
            EXIT WHEN v_hrgerada >= v_hrfinal;

            SELECT SEQ_AGS_AGG_01.NextVal INTO lIdtRetorno FROM DUAL;

            INSERT INTO TB_AGS_AGG_AGE_GERADA_SADT
            (
               AGS_AGG_ID,
               AGS_ESM_ID,
               AGS_ESF_ID,
               AGS_AGG_DT_AGENDA_GERADA,
               AGS_AGG_HR_AGENDA_GERADA,
               AGS_AGG_TP_HORARIO,
               AGS_AGG_FL_STATUS_HORARIO,
               AGS_AGG_DT_ULTIMA_ATUALIZACAO,
               SEG_USU_ID_USUARIO,
               ASS_EHR_ID
            )
            VALUES
            (
               lIdtRetorno,
               pAGS_ESM_ID,
               v_idtfalta,
               v_dtgerada,
               v_hrgerada,
               'N',
               'L',
               TRUNC(SYSDATE),
               pSEG_USU_ID_USUARIO,
               NULL
            );

              IF v_intervalo >= 60 THEN
                 v_hradic := trunc(v_intervalo / 60);
                 v_minadic := ((v_intervalo / 60) - trunc(v_hradic)) * 60;
                 v_temp := SUBSTR(LPAD(TO_CHAR(v_hrgerada), 4, 0), 3, 2) + v_minadic;
                 IF v_temp >= 60 THEN
                   IF v_temp = 60 THEN
                     v_hradic := v_hradic + (trunc(v_temp) / 60);  
                     v_minadic := MOD((v_temp),60);
                   ELSE 
                     WHILE v_temp >= 60 LOOP
                       v_hradic := v_hradic + (trunc(v_temp) / 60);  
                       v_temp := MOD((v_temp),60);
                     END LOOP;
                     v_minadic := v_temp;
                   END IF;
                   v_hrgerada := TO_NUMBER(SUBSTR(LPAD(TO_CHAR(v_hrgerada),4,0), 0, 2) + v_hradic || LPAD(TO_CHAR(v_minadic), 2, 0));
                 ELSE
                   v_hrgerada := TO_NUMBER(SUBSTR(LPAD(TO_CHAR(v_hrgerada),4,0), 0, 2) + v_hradic || SUBSTR(LPAD(TO_CHAR(v_hrgerada), 4, 0), 3, 2) + v_minadic);
                 END IF;
              ELSE
                 IF SUBSTR(LPAD(TO_CHAR(v_hrgerada + v_intervalo), 4, 0), 3, 2) >= 60 THEN
                    v_hrgerada := TO_NUMBER(SUBSTR(LPAD(TO_CHAR(v_hrgerada),4,0), 0, 2) + 1 || SUBSTR(LPAD(TO_CHAR(v_hrgerada + v_intervalo), 4, 0), 3, 2) - 60);
                 ELSE
                    v_temp := SUBSTR(LPAD(TO_CHAR(v_hrgerada), 4, 0), 3, 2) + v_intervalo;
                    IF v_temp >= 60 THEN
                      WHILE v_temp >= 60 LOOP
                        v_hrgerada := TO_NUMBER(SUBSTR(LPAD(TO_CHAR(v_hrgerada),4,0), 0, 2)+ trunc(v_temp / 60)|| SUBSTR(LPAD(TO_CHAR(v_hrgerada), 4, 0), 3, 2));
                        v_temp := MOD((v_temp),60);
                      END LOOP;
                      v_hrgerada := TO_NUMBER(SUBSTR(LPAD(TO_CHAR(v_hrgerada),4,0), 0, 2) || LPAD(TO_CHAR(v_temp), 2, 0)); 
                    ELSE
                      v_hrgerada := v_hrgerada + v_intervalo;
                    END IF;
                END IF;
              END IF;

         END LOOP;
         v_qtdatagerada := v_qtdatagerada + 1;
         v_dtgerada := v_dtgerada + v_qtdiasint;
         v_isferiado := true;
       END LOOP;
       UPDATE TB_AGS_ESM_ESCALA_SADT ESM
       SET    ESM.AGS_ESM_FL_STATUS = 'A',
              ESM.AGS_ESM_FL_AGENDAGERADA_OK = 'S'
       WHERE  ESM.AGS_ESM_ID = pAGS_ESM_ID;
    END IF;
    EXCEPTION
    WHEN OTHERS THEN
     v_error_code := SQLCODE;
     v_error_message := SQLERRM;
     raise_application_error(v_error_code, v_error_message);
  end  PRC_AGS_AGG_AGE_GERACAO_SADT;
