CREATE OR REPLACE FUNCTION SGS."FNC_FAT_LIBERA_AUTO" (pCAD_SET_ID in tb_cad_set_setor.cad_set_id%type,

                                                pATD_ATE_TP_PACIENTE in tb_atd_ate_atendimento.atd_ate_tp_paciente%type,

                                                pCAD_CNV_ID_CONVENIO in tb_cad_cnv_convenio.cad_cnv_id_convenio%type,

                                                pTIS_TAT_CD_TPATENDIMENTO in tb_tis_tat_tp_atendimento.tis_tat_cd_tpatendimento%type,

                                                pCAD_PRO_ID_PROF_EXEC in tb_atd_ate_atendimento.cad_pro_id_prof_exec%type DEFAULT NULL)

/*

  Marcus Relva - 20/02/2013

  Marcus Relva - 10/01/2019

*/

return NUMBER is Result NUMBER;

begin



-- tipo A continua do mesmo jeito

-- tipo U para 281 liberar s© tipoAtend <> 4



if(pATD_ATE_TP_PACIENTE in ('A','U')) then

     if(pATD_ATE_TP_PACIENTE = 'A' and pCAD_CNV_ID_CONVENIO not in (281, 283, 1014, 1022, 512, 1021, 2762, 3162)) then

        Result := 0;

     elsif(pATD_ATE_TP_PACIENTE = 'U' and (pCAD_CNV_ID_CONVENIO not in (281, 283, 1014, 1022, 512, 1021, 2762, 3162,331)

     or (pCAD_CNV_ID_CONVENIO in (281) and pTIS_TAT_CD_TPATENDIMENTO not in ('4','5'))

     or (pCAD_CNV_ID_CONVENIO in (331) and pTIS_TAT_CD_TPATENDIMENTO not in ('4')))) then

        Result := 0;

   else

    if((pTIS_TAT_CD_TPATENDIMENTO <> '4' AND pCAD_SET_ID in (57, 1952, 44,85,86,87,114,113,332,672,634,1972,159)) or (pCAD_PRO_ID_PROF_EXEC in (5381) and pTIS_TAT_CD_TPATENDIMENTO = '4' )) then

       Result := 0;

    else

      Result := 1;

    end if;

   end if;

else

Result := 1;

end if;



return(Result);



end FNC_FAT_LIBERA_AUTO;