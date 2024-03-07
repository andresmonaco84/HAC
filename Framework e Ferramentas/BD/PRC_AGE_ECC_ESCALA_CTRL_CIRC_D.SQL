  --PRC_AGE_ECC_ESCALA_CTRL_CIRC_D
  create or replace procedure PRC_AGE_ECC_ESCALA_CTRL_CIRC_D 
  (
     pAGE_ECC_ID IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ECC_ESCALA_CTRL_CIRC_D
  * 
  *    Data Criacao: 	02/07/2007           Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Deleção de registros na tabela TB_AGE_ECC_ESCALA_CTRL_CIRC
  *
  *******************************************************************/    
  nCount integer;
  begin
  nCount:=0;
      SELECT COUNT(*) 
    INTO   nCount
    FROM   TB_ASS_CIE_CIRCULAR_ESCALA
    WHERE   AGE_ECC_ID = pAGE_ECC_ID;
           
    IF nCount > 0 then
       raise_application_error (-20000, 'Não é possível deletar essa circular. Existe uma associação com Escala Médica.');
    END IF;
    DELETE TB_AGE_ECC_ESCALA_CTRL_CIRC
    WHERE  
        AGE_ECC_ID = pAGE_ECC_ID;	  
 
  end PRC_AGE_ECC_ESCALA_CTRL_CIRC_D;
/
