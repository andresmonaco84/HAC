create or replace procedure PRC_CAD_CVM_CNV_VLR_MOEDA_S
(
     pCAD_CVM_ID IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_CVM_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_TIH_TP_INDICE_HOSP%type DEFAULT NULL,     
     pCAD_CVM_DT_INICIO_VIGENCIA IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_CVM_DT_INICIO_VIGENCIA%type DEFAULT NULL,     
     pCAD_PLA_ID_PLANO IN TB_CAD_CVM_CONV_VLR_MOEDAHOS.CAD_PLA_ID_PLANO%type DEFAULT NULL,     
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_CVM_CNV_VLR_MOEDA_S
* 
*    Data Criacao: 	10/12/2009  Por: pedro
*    Data Alteracao: 19/10/2010   Por: André S. Monaco
*         Alteracao: Adição do campo CAD_TAP_TP_ATRIBUTO
*
*    Funcao: Seleciona valor de índice
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       CAD_CVM_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_TIH_TP_INDICE_HOSP,
       CAD_CVM_VL_MOEDA_HOSPITALAR,
       CAD_CVM_DT_INICIO_VIGENCIA,
       CAD_CVM_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       CAD_CVM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_TAP_TP_ATRIBUTO
FROM TB_CAD_CVM_CONV_VLR_MOEDAHOS
WHERE       
        (pCAD_CVM_ID is null OR CAD_CVM_ID = pCAD_CVM_ID) AND 
        (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO) AND 
        (pCAD_TIH_TP_INDICE_HOSP is null OR CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP) AND         
        (pCAD_CVM_DT_INICIO_VIGENCIA is null OR trunc(CAD_CVM_DT_INICIO_VIGENCIA) = pCAD_CVM_DT_INICIO_VIGENCIA) AND         
        (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)     
        ;          
io_cursor := v_cursor;
end PRC_CAD_CVM_CNV_VLR_MOEDA_S;
