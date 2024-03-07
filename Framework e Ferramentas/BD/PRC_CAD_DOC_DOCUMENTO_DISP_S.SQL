create or replace procedure PRC_CAD_DOC_DOCUMENTO_DISP_S
  (   
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO in TB_ASS_CDL_CONV_DOC_LOCATEND.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,  
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DOC_DOCUMENTO_DISP_S
  * 
  *    Data Criacao: 	11/06/2007   Por: Silmara
  *    Data Alteracao: 12/06/2007  Por: Silmara
  *    alteracao: trazer somente documentos ativos
  *    Funcao: Seleciona os Documentos disponíveis
  *    
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
	     A.CAD_DOC_ID_DOCUMENTO,
       A.CAD_DOC_SG_DOCUMENTO,
       A.CAD_DOC_DS_DOCUMENTO,
       A.CAD_DOC_DS_OBSERVACAO,
       A.CAD_DOC_FL_ATIVO_OK,
       A.CAD_DOC_DT_ULTIMA_ATUALIZACAO,
       A.SEG_USU_ID_USUARIO
    FROM TB_CAD_DOC_DOCUMENTO A 
         WHERE
    NOT EXISTS (SELECT 1
                FROM   TB_ASS_CDL_CONV_DOC_LOCATEND                             
                WHERE   CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                AND     CAD_CNV_ID_CONVENIO  = pCAD_CNV_ID_CONVENIO
                AND CAD_DOC_ID_DOCUMENTO=A.CAD_DOC_ID_DOCUMENTO)
    AND A.CAD_DOC_FL_ATIVO_OK = 'S';            
    io_cursor := v_cursor;
    end PRC_CAD_DOC_DOCUMENTO_DISP_S;
/
