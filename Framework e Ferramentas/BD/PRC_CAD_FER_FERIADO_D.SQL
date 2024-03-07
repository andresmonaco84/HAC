  --PRC_CAD_FER_FERIADO_D
  create or replace procedure PRC_CAD_FER_FERIADO_D 
  (
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FER_FERIADO_D
  * 
  *    Data Criacao: 	26/06/2007   Por: Guilherme Holdack
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Deleção de registro na tabela TB_CAD_FER_FERIADO
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_FER_FERIADO
    WHERE  
        CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO;	   
  end PRC_CAD_FER_FERIADO_D;
/
