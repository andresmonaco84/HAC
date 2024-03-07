declare   
  setorId integer;
  uniId integer;
  localId integer;
  matId integer;
  filialId integer;
begin
  for padraoAntigo in 
  (SELECT CD_SETOR, CODMNEMAT, QTD_REQ FROM MTM_PEDIDO_DEFAULT)
  loop
  
      begin
           SELECT MATMED.CAD_MTMD_ID, MATMED.CAD_MTMD_FILIAL_ID INTO matId, filialId FROM tb_cad_mtmd_mat_med MATMED
           WHERE MATMED.Cad_Mtmd_Codmne = padraoAntigo.Codmnemat;
      exception
               when no_data_found then                                
                    dbms_output.put_line('ERRO - Tabela MTM_PEDIDO_DEFAULT, Codmnemat = ' || padraoAntigo.Codmnemat || ' não encontrado em tb_cad_mtmd_mat_med');
      end; 

      if (padraoAntigo.Cd_Setor = 'ACPC') then
         setorId := 21;
         uniId := 248;
         localId := 27;
      elsif (padraoAntigo.Cd_Setor = 'AECO') then
         setorId := 28;
         uniId := 248;
         localId := 27;
      elsif (padraoAntigo.Cd_Setor = 'ANPA') then
         setorId := 38;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = 'BERC') then
         setorId := 46;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = 'CATA') then
         setorId := 50;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = 'CATC') then
         setorId := 51;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = 'CD05') then
         setorId := 55;
         uniId := 248;
         localId := 27;        
      elsif (padraoAntigo.Cd_Setor = 'CD06') then
         setorId := 56;
         uniId := 248;
         localId := 27;        
      elsif (padraoAntigo.Cd_Setor = 'CD07') then
         setorId := 57;
         uniId := 248;
         localId := 27;                 
      elsif (padraoAntigo.Cd_Setor = 'CECI') then
         setorId := 61;
         uniId := 244;
         localId := 29;        
      elsif (padraoAntigo.Cd_Setor = 'COLP') then
         setorId := 67;
         uniId := 248;
         localId := 27;        
      elsif (padraoAntigo.Cd_Setor = 'CURA') then
         setorId := 73;
         uniId := 248;
         localId := 27;        
      elsif (padraoAntigo.Cd_Setor = 'GUAR') then
         setorId := 112;
         uniId := 245;
         localId := 27; 
      elsif (padraoAntigo.Cd_Setor = 'HEMO') then
         setorId := 114;
         uniId := 248;
         localId := 27;
      elsif (padraoAntigo.Cd_Setor = 'HMPS') then
         setorId := 115;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = 'HOMA') then
         setorId := 116;
         uniId := 248;
         localId := 27;             
      elsif (padraoAntigo.Cd_Setor = 'INFE') then
         setorId := 118;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'LITO') then
         setorId := 132;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'MATA') then
         setorId := 140;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'MATC') then
         setorId := 141;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'OFTA') then
         setorId := 146;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'PABX') then
         setorId := 247;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'PEDA') then
         setorId := 148;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'PEDC') then
         setorId := 149;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'QUIM') then
         setorId := 159;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'RADI') then
         setorId := 166;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'SERV') then
         setorId := 177;
         uniId := 246;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'TOMO') then
         setorId := 194;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'ULTR') then
         setorId := 199;
         uniId := 248;
         localId := 27;  
      elsif (padraoAntigo.Cd_Setor = 'UTIC') then
         setorId := 200;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'UTIG') then
         setorId := 201;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = 'ZELA') then
         setorId := 209;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = '1A') then
         setorId := 5;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = '2A') then
         setorId := 8;
         uniId := 244;
         localId := 29; 
      elsif (padraoAntigo.Cd_Setor = '2B') then
         setorId := 12;
         uniId := 244;
         localId := 29;  
      elsif (padraoAntigo.Cd_Setor = '3B') then
         setorId := 14;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = '6C') then
         setorId := 17;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = '7C') then
         setorId := 18;
         uniId := 244;
         localId := 29;
      elsif (padraoAntigo.Cd_Setor = '8C') then
         setorId := 19;
         uniId := 244;
         localId := 29;       
      elsif (padraoAntigo.Cd_Setor = '9C') then
         setorId := 20;
         uniId := 244;
         localId := 29;         
      end if;       
      
      filialId := DECODE(SUBSTR(padraoAntigo.CODLOC,1,1),5,2,1);
      if ( filialId is null ) then
		filialId := 3;
      end if;
      
      
      begin
           PRC_MTMD_PEDIDO_PADRAO_I(matId, localId, uniId, setorId, filialId, padraoAntigo.Qtd_Req, 1, 3, null);
           commit;
      exception
           when others then                                                    
                dbms_output.put_line('ERRO INSERÇÃO - Codmnemat = ' || padraoAntigo.Codmnemat || ' para CAD_MTMD_ID = ' || matId);
                rollback;
      end; 

  end loop;  
end;







 



 
 