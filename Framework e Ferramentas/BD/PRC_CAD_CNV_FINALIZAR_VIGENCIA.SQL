create or replace procedure PRC_CAD_CNV_FINALIZAR_VIGENCIA
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pCAD_CNV_DT_FIM_VIGENCIA IN TB_CAD_CNV_CONVENIO.CAD_CNV_DT_FIM_VIGENCIA%type default NULL,
     pCAD_CNV_FL_STATUS IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CNU_CONVENIO_UNIDADE.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CNV_FINALIZAR_VIGENCIA
  *
  *    Data Criacao:   20/08/2009   Por: Alexandre M. Muniz
  *    Funcao: Finaliza a vigência de todas as unidades de um convênio
  *
  *******************************************************************/
  
  vDS_MOTIVO_FIM_VIG varchar2(50);
  vQtdCaracteres binary_integer;

  begin         
        --Busca todos os planos de um convênio que ainda estão ativos
        FOR vREC_PLANOS IN (SELECT PLA.CAD_PLA_ID_PLANO
                              FROM TB_CAD_PLA_PLANO PLA
                             WHERE ((UPPER(PLA.CAD_PLA_FL_SITUACAO_PLANO) = 'A') OR PLA.CAD_PLA_DT_FIM_VIGENCIA IS NULL)
                               AND PLA.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
        LOOP
             
            raise_application_error(-20000, 'Existem planos ativos, favor desativá-los primeiro. ');   
        
        END LOOP;
        
        vQtdCaracteres := 50;
  
        FOR vREC_USUARIO IN (SELECT U.SEG_USU_DS_NOME                               
                               FROM TB_SEG_USU_USUARIO U 
                              WHERE U.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) 
        LOOP            
            vDS_MOTIVO_FIM_VIG := 'Usuário ' || vREC_USUARIO.SEG_USU_DS_NOME;
            
            IF LENGTH(vDS_MOTIVO_FIM_VIG) > vQtdCaracteres THEN 
               vDS_MOTIVO_FIM_VIG := SUBSTR(vDS_MOTIVO_FIM_VIG, 0, vQtdCaracteres);
            END IF;         
        END LOOP;
        
        IF vDS_MOTIVO_FIM_VIG IS NULL THEN 
           vDS_MOTIVO_FIM_VIG := '[USUÁRIO NÃO ENCONTRADO]';
        END IF;
        
        IF pCAD_CNV_DT_FIM_VIGENCIA IS NULL THEN 
           vDS_MOTIVO_FIM_VIG := NULL;
        END IF;
        
        --Unidades de Atendimento
        prc_ass_cnu_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_DT_FIM_VIGENCIA,
                                       pSEG_USU_ID_USUARIO,
                                       vDS_MOTIVO_FIM_VIG);                                       
        --Locais de Atendimento
        prc_ass_cul_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_DT_FIM_VIGENCIA,
                                       pSEG_USU_ID_USUARIO,
                                       vDS_MOTIVO_FIM_VIG);        
        --Tipos de Atendimento
        prc_ass_cta_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_DT_FIM_VIGENCIA,
                                       pSEG_USU_ID_USUARIO,
                                       vDS_MOTIVO_FIM_VIG);        
        --Tipos de Acomodação
        prc_ass_cut_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_DT_FIM_VIGENCIA,
                                       pSEG_USU_ID_USUARIO,
                                       vDS_MOTIVO_FIM_VIG);        
        --Impostos
        prc_ass_cui_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_DT_FIM_VIGENCIA,
                                       pSEG_USU_ID_USUARIO,
                                       vDS_MOTIVO_FIM_VIG);                
        --Procedimentos                               
        prc_ass_ccp_finalizar_vigencia(pCAD_CNV_ID_CONVENIO,
                                       pCAD_CNV_FL_STATUS,
                                       pSEG_USU_ID_USUARIO);        
        

  end PRC_CAD_CNV_FINALIZAR_VIGENCIA;
