create or replace procedure PRC_LEG_ATUALIZA_ENDERECO
(
  pCAD_END_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%TYPE default NULL,
  pCAD_TEL_TELEFONE IN TB_CAD_TEL_TELEFONE.CAD_TEL_ID_TELEFONE%TYPE default NULL,
  pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_ATU_ENDERECO   
  *    Data Criacao:  16/12/2008   Por: SILMARA
  *    Funcao: ATUALIZAR ENDERECO
  *
  *******************************************************************/
    v_contador                   number;
    v_contador1                  number;
    v_contador2                  number;
    v_contador3                  number;
    v_contador4                  number;
    v_id_paciente                number;
    v_id_telefone                number;
    v_id_endereco                number;
    v_cip                        varchar2(20);
    v_cidade                     varchar2(15);
    v_uf                         char(2);   
    v_cep                        char(9);
    v_complemento                varchar2(60);
    v_tipo_logr                  varchar2(30);   
    v_logradouro                 varchar2(60);   
    v_bairro                     varchar2(60);
    v_ddd                        number(4);
    v_nr_telefone                number(8); 
    v_nr_prontuario              number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;

  begin
  
   v_cep:=null;
   v_cip:=null; 
   v_nr_telefone:=null; 
   v_nr_prontuario:=null;  
   v_contador :=null; 
   v_contador1 :=null;  
   v_contador2 :=null; 
   v_contador3 :=null; 
   v_contador4 :=null; 
   v_complemento :=null; 
   v_logradouro  :=null; 
   v_bairro :=null; 
   v_ddd :=null; 
   v_cidade :=null; 
   v_uf :=null; 
   v_tipo_logr :=null;   
   
    SELECT    COUNT(*)
    INTO      v_contador 
    FROM      TB_CAD_PAC_PACIENTE PAC             
    WHERE     
    PAC.CAD_PAC_ID_PACIENTE=pCAD_PAC_ID_PACIENTE    
    AND PAC.CAD_PAC_CD_CODCIP IS NOT NULL;
   
    IF v_contador=0 
         THEN
          raise ex_atendimentoinexistente;
   ELSE 
        select distinct(pac.cad_pac_cd_codcip)
        into v_cip 
         from 
         tb_cad_pac_paciente pac 
         where pac.cad_pac_id_paciente=pCAD_PAC_ID_PACIENTE; 
    END IF;        
         SELECT COUNT(*) 
         INTO v_contador3
          from 
       tb_cad_pac_paciente pac 
       where pac.cad_pac_id_paciente=pCAD_PAC_ID_PACIENTE
        and (pac.cad_pac_nr_prontuario is not null or pac.cad_pac_nr_prontuario <> 7);
      IF v_contador3 <> 0 THEN  
         select distinct(pac.cad_pac_nr_prontuario)
         into v_nr_prontuario
        from 
       tb_cad_pac_paciente pac 
       where pac.cad_pac_id_paciente=pCAD_PAC_ID_PACIENTE
        and (pac.cad_pac_nr_prontuario is not null or pac.cad_pac_nr_prontuario <> 7); 
        END IF;
  
 
  IF pCAD_END_ENDERECO is not null then
     SELECT DISTINCT
     SUBSTR(ENDER.CAD_END_CD_CEP,0,5)||'-'||
     SUBSTR(ENDER.CAD_END_CD_CEP,6,8),
     SUBSTR(ENDER.CAD_END_DS_NUMERO,0,7)||'/'||
     SUBSTR(ENDER.CAD_END_DS_COMPLEMENTO,0,7),
     ENDER.CAD_END_NM_BAIRRO,
     ENDER.CAD_END_SG_UF,
     SUBSTR(TLG.TIS_TLG_DS_TPLOGRADOURO,0,30),
     SUBSTR(MUN.AUX_MUN_NM_MUNICIPIO,0,15),
     SUBSTR(ENDER.CAD_END_NM_LOGRADOURO,0,60)
     into
     v_cep,
     v_complemento,
     v_bairro,
     v_uf,
     v_tipo_logr,
     v_cidade,
     v_logradouro   
     FROM TB_CAD_END_ENDERECO ENDER,  
    TB_AUX_MUN_MUNICIPIO MUN,
    TB_TIS_TLG_TP_LOGRADOURO TLG
    WHERE     
      ENDER.CAD_END_ID_ENDERECO=pCAD_END_ENDERECO  
    AND ENDER.CAD_END_SG_UF=MUN.AUX_MUN_SG_UF
    AND ENDER.AUX_MUN_CD_IBGE=MUN.AUX_MUN_CD_IBGE
    AND ENDER.TIS_TLG_CD_TPLOGRADOURO=TLG.TIS_TLG_CD_TPLOGRADOURO;  
    END IF; 
    
   IF trim(v_cep)='-' then
        v_cep:=null;
    END IF;    
    
    
    IF  pCAD_TEL_TELEFONE is not null then    
    SELECT DISTINCT TO_NUMBER(SUBSTR(TEL.CAD_TEL_NR_NUM_TEL,2,2)),
    TO_NUMBER(SUBSTR(TEL.CAD_TEL_NR_NUM_TEL,5,5)||SUBSTR(TEL.CAD_TEL_NR_NUM_TEL,11,4))
    INTO
    v_ddd,
    v_nr_telefone
    FROM  TB_CAD_TEL_TELEFONE TEL  
    WHERE TEL.CAD_TEL_ID_TELEFONE=pCAD_TEL_TELEFONE;     
    
    END IF;   
     
    select count(*) into
    v_contador1
    from HOSPITAL.PACIENTE_CEP_COMP
    where TRIM(cip)=TRIM(v_cip);
    
    IF v_contador1 = 0 AND v_cep is not  null THEN
       INSERT INTO HOSPITAL.PACIENTE_CEP_COMP
       ( CEP, COMP, CIP, NR_DDD, NR_TELEFONE,CODPAC)
         VALUES
       (v_cep,
        v_complemento,
        v_cip,
        v_ddd,
        v_nr_telefone,
        v_nr_prontuario);
      END IF;    
    IF v_contador1 <> 0 AND v_cep is not null and pCAD_END_ENDERECO is not null then
         update HOSPITAL.paciente_cep_comp
         set cep=v_cep,
         comp=v_complemento
       --  nr_ddd=v_ddd,
       --  nr_telefone=v_nr_telefone
         where TRIM(cip)=TRIM(v_cip);        
     END IF;  
      IF v_contador1 <> 0 AND pCAD_TEL_TELEFONE  is not null then
         update HOSPITAL.paciente_cep_comp
         set
         nr_ddd=v_ddd,
         nr_telefone=v_nr_telefone
         where TRIM(cip)=TRIM(v_cip);        
     END IF; 
     
     select count(*) into 
     v_contador2 from HOSPITAL.paciente_logradouro 
     where TRIM(cip)=TRIM(v_cip);
       
    IF v_contador2 = 0 and v_cep is null and (pCAD_END_ENDERECO is not null or pCAD_TEL_TELEFONE is not null) then
        INSERT INTO HOSPITAL.PACIENTE_LOGRADOURO 
       (cip, tipo_logr, nm_logr, nm_bairro, nm_cidade, cep, uf, comp, nr_ddd, nr_telefone, 
        nr_ddd1, nr_telefone1,
        codpac) 
        VALUES
        (v_cip,
         v_tipo_logr,
         v_logradouro,
         v_bairro,
         v_cidade,
         null,
         v_uf,
         v_complemento,
         v_ddd,
         v_nr_telefone,
         null,
         null,
         v_nr_prontuario);
     END IF;    
     
     IF v_contador2 <>  0  and pCAD_END_ENDERECO is not null  then   
       
     Update  	HOSPITAL.PACIENTE_LOGRADOURO   
     set COMP = v_complemento, 
	 --  NR_DDD = v_ddd,
   --  NR_TELEFONE = v_nr_telefone, 
	   NM_CIDADE = v_cidade,
	   NM_BAIRRO= v_bairro,
   	 UF = v_uf,
  	 NM_LOGR = v_logradouro,
     TIPO_LOGR	= v_tipo_logr  
    where 	TRIM(cip) = TRIM(v_cip);
    END IF;   
    
      IF v_contador2 <>  0 and pCAD_TEL_TELEFONE is not null  then   
       
     Update  	HOSPITAL.PACIENTE_LOGRADOURO   
     set 	NR_DDD = v_ddd,
     NR_TELEFONE = v_nr_telefone	  
     where 	TRIM(cip) = TRIM(v_cip);
     END IF;   
    
    IF v_contador2 <>  0  and pCAD_TEL_TELEFONE IS NULL  then      
       SELECT nr_ddd, nr_telefone 
       into    v_ddd, v_nr_telefone
       from  
     HOSPITAL.PACIENTE_LOGRADOURO       
     where 	TRIM(cip) = TRIM(v_cip);
     END IF; 
     
    select count(*) into 
     v_contador4 from HOSPITAL.paciente_logradouro 
     where TRIM(cip)=TRIM(v_cip);
     
     IF v_nr_telefone is not null AND v_contador2 <>  0 and v_contador4 <> 0 and pCAD_TEL_TELEFONE IS NULL  then 
      UPDATE  HOSPITAL.paciente_cep_comp
         set
         nr_ddd=v_ddd,
         nr_telefone=v_nr_telefone
        where TRIM(cip)=TRIM(v_cip)
         AND NR_TELEFONE IS NULL 
         AND CEP IS NOT NULL;
     END IF;     
    EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Endereço Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
     
    end PRC_LEG_ATUALIZA_ENDERECO;
/
