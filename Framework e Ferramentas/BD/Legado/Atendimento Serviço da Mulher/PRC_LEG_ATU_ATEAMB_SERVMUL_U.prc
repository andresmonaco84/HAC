create or replace procedure PRC_LEG_ATU_ATEAMB_SERVMUL_U
(
 pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_ATEAMB_SERVMUL_U
  *
  *    Data Criacao:  22/02/2008   Por: SILMARA
  *
  *
  *    Funcao: alterar as informac?es na tabela paciente_atendimento_amb
  *            indicadores do servico da mulher
  *
  *******************************************************************/

    v_in_vulvoscopia                char(1);
    v_in_cauterizacao               char(1);
    v_in_biopsia_colo_utero      char(1);
    v_in_biopsia_vulva           char(1);
    v_in_tocardiograma           char(1);
    v_in_colposcopia             char(1);
    v_in_biopsia_vagina          char(1);
    v_contador                   number;
    v_error_code                 number;   
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;
   

  begin   
 

   SELECT    COUNT(*)
   INTO      v_contador
   FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
             TB_ATD_ATE_ATENDIMENTO ATD
    WHERE    ATD.ATD_ATE_ID = pATD_ATE_ID
    AND      PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND      ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND      PRD.CAD_PRD_CD_CODIGO in ('45010021','41301102') AND PAP.ASS_PAP_QT_REALIZ=2;
 --   IN ('45010021','45050015','45040010','45020027','45010072','45030022');
 
  

    IF v_contador != 0 THEN
     SELECT    'S' , 'S'
    INTO      v_in_vulvoscopia, v_in_colposcopia
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
              TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45010021','41301102') AND PAP.ASS_PAP_QT_REALIZ=2;
    end if;


      SELECT    COUNT(*)
      INTO      v_contador
      FROM   TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
             TB_ATD_ATE_ATENDIMENTO ATD
    WHERE    ATD.ATD_ATE_ID = pATD_ATE_ID
    AND      PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND      ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45010021','41301102') AND PAP.ASS_PAP_QT_REALIZ=1;

      IF v_contador != 0 THEN
       SELECT    'S'
    INTO      v_in_colposcopia
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
              TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45010021','41301102') AND PAP.ASS_PAP_QT_REALIZ=1;
    end if;

    SELECT    count(*)
    INTO    v_contador
   FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
              TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45050015','31303021');

   IF v_contador != 0 THEN
   SELECT    'S'
   INTO     v_in_biopsia_colo_utero
   FROM    TB_ASS_PAP_PAC_ATEN_PROC PAP,
           TB_CAD_PRD_PRODUTO PRD,
           TB_ATD_ATE_ATENDIMENTO ATD
    WHERE  ATD.ATD_ATE_ID = pATD_ATE_ID
    AND    PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND    ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND    PRD.CAD_PRD_CD_CODIGO in ('45050015','31303021');
    END IF;

    SELECT    COUNT(*)
    INTO     v_contador
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
   WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
   AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
   AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
   AND       PRD.CAD_PRD_CD_CODIGO in ( '45040010','31302017');

    IF v_contador != 0 THEN
    SELECT    'S'
    INTO     v_in_biopsia_vagina
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
   WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
   AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
   AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
   AND       PRD.CAD_PRD_CD_CODIGO in ( '45040010','31302017');
   END IF;

    SELECT    count(*)
    INTO
        v_contador
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
            TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45020027','31303196');

    IF v_contador != 0 THEN
    SELECT    'S'
    INTO      v_in_cauterizacao
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
            TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45020027','31303196');
    END IF;

    SELECT    COUNT(*)
    INTO     v_contador
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
              TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45010072','20202016');

     IF v_contador != 0 THEN
    SELECT    'S'
    INTO     v_in_tocardiograma
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
              TB_CAD_PRD_PRODUTO PRD,
              TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45010072','20202016');
    END IF;

    SELECT    COUNT(*)
   INTO       v_contador
   FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
             TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45030022','31301029');

    IF v_contador != 0 THEN
     SELECT    'S'
     INTO       v_in_biopsia_vulva
     FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP,
             TB_CAD_PRD_PRODUTO PRD,
             TB_ATD_ATE_ATENDIMENTO ATD
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
    AND       PAP.CAD_PRD_ID=PRD.CAD_PRD_ID
    AND       ATD.ATD_ATE_ID=PAP.ATD_ATE_ID
    AND       PRD.CAD_PRD_CD_CODIGO in ('45030022','31301029');
    END IF; 
    UPDATE  HOSPITAL.PACIENTE_ATENDIMENTO_AMB
    SET
    IN_VULVOSCOPIA=v_in_vulvoscopia,
    IN_CAUTERIZACAO= v_in_cauterizacao,
    IN_BIOPSIA_COLO_UTERO= v_in_biopsia_colo_utero,
    IN_BIOPSIA_VULVA = v_in_biopsia_vulva,
    IN_TOCARDIOGRAMA = v_in_tocardiograma,
    IN_COLPOSCOPIA = v_in_colposcopia,
    IN_BIOPSIA_VAGINA = v_in_biopsia_vagina,
    DT_EXAME=SYSDATE
    where codateamb= pATD_ATE_ID;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Atendimento Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_ATEAMB_SERVMUL_U;