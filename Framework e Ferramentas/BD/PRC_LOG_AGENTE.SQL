CREATE OR REPLACE PROCEDURE PRC_LOG_AGENTE
IS
/* Marcus Relva - LOG AGENTE - 18/01/2012 */
v_header         varchar2(20000) := '<font face="calibri">';
v_mensagem       varchar2(20000) := '<font face="courier">';
v_mensagem_outro varchar2(20000) := '';
v_grupo          varchar2(100)  := 'InterfacesMonitoramento@anacosta.com.br';
v_consultas      varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_laboratorio    varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_lote           varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_imagem         varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_diarias        varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_beneficiarios  varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_escalas        varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_historico      varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_pacs           varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_elegibilidade  varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_visitas        varchar2(100)  := '<FONT COLOR="RED">VERIFICAR</FONT>';
v_mailhost       VARCHAR2(64) := '172.16.1.18';
v_con utl_smtp.connection;
BEGIN
  BEGIN
    FOR itens IN (
    /*Consultas*/
    select 'CONSULTAS' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > sysdate - (12/24)
    and   l.seg_usu_id_usuario in (8642)
    and   l.cad_log_ate_atd = 0
    union
    /*Visitas*/
    select 'VISITAS' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)
    and   l.seg_usu_id_usuario in (8447)
    and   l.cad_log_ate_atd = -5
    union
    /*Diarias*/
    select 'DIARIAS' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)
    and   l.seg_usu_id_usuario in (8447)
    and   l.cad_log_ate_atd = 0
    union
    /*Imagem*/
    select 'IMAGEM' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > sysdate - (12/24)
    and   l.seg_usu_id_usuario in (8087)
    and   l.cad_log_ate_atd = 0
    union
    /*Laboratorio*/
    select 'LABORATORIO' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)
    and   l.seg_usu_id_usuario in (8086)
    and   l.cad_log_ate_atd = 0
    union
    /*GeracaoLote*/
    select 'GERACAOLOTE' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)-1
    and   l.seg_usu_id_usuario in (8642)
    and   l.cad_log_ate_atd = 1
    union
    /*Beneficiarios*/
    select 'AGENDAWEB - CARGA BENEFICIARIOS' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)
    and   l.seg_usu_id_usuario in (26046)
    and   l.cad_log_class = 'AtualizaBeneficiarioAgendaWEB'
    and   l.cad_log_msg_erro not like '%ERRO%'
    union
    /*Escalas AgendaWeb*/
    select 'AGENDAWEB - ATUALIZA ESCALA' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate) - 1
    and   l.seg_usu_id_usuario in (26046)
    and   l.cad_log_class = 'Atualiza Escalas'
    union
    /*HistoricoInternacao AgendaWeb*/
    select 'AGENDAWEB - ATUALIZA HISTORICO INTERNACAO' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate) - 1
    and   l.seg_usu_id_usuario in (26046)
    and   l.cad_log_class like 'Atualiza%Internados'
    union
    /*PACS*/
    select 'PACS' as interface, ''
      from (select count(1) as qt
              from sgs.tb_ass_xlp_xml_laudo_pacs xml
             where xml.xlp_data_atualizado > trunc(sysdate) - 2) s1
     where qt > 0
     union
     /*Elegibilidade*/
    select 'ELEGIBILIDADE' as interface, l.cad_log_msg_erro from tb_cad_log_erro_processo l
    where l.cad_log_data_processo > trunc(sysdate)
    and   l.cad_log_origem  = 'AgenteService'
    and   l.cad_log_class =  'Elegibilidade'
    and   l.cad_log_metodo = 'Elegibilidade'
    and   l.cad_log_msg_erro like  'Elegibilidade executada com sucesso%'
    and   l.seg_usu_id_usuario in (26046)
    and   l.cad_log_ate_atd = 1
    union
    /*Outros*/
    select 'OUTROS' AS interface,
           ll.cad_log_origem || ' - ' || ll.cad_log_class || ' - ' ||
           ll.cad_log_metodo || ' - ' || ll.cad_log_ate_atd || ' - ' ||
           ll.cad_log_msg_erro
      from tb_cad_log_erro_processo ll
     where ll.cad_log_data_processo > trunc(sysdate) - 1
       and ll.cad_log_class <> 'Credenciamento'
       and ll.cad_log_class <> 'FrmMovimentacaoComanda'
       and ll.cad_log_origem <> 'AlterarCodigoProcedimento'
       and ll.cad_log_msg_erro not in
           ('Sem registros na tabela ControleLancamentoConvenio',
            'Atendimento sem profissional.',
            'Conta recalculada com sucesso.')
       and ll.cad_log_ate_atd not in (0, 1)
       and ll.cad_log_ate_atd > 0
       and ll.cad_log_msg_erro not like '%ENVIADA para a auditoria por%'
       and ll.cad_log_msg_erro not like '%como retorno (RETORNO =%'
       and ll.cad_log_msg_erro not like '%existem itens para recalcular.%'
       and ll.cad_log_msg_erro not like '%: O exame de laboratorio %'
       and ll.cad_log_msg_erro not like '%existe consulta lan%ada para esse atend%'
       and ll.cad_log_msg_erro not like '%foi possivel obter o paciente/atendimento%'
       and ll.cad_log_msg_erro not like '%NF SGS e Movimento RM excluido%'
       and ll.cad_log_msg_erro not like '%foi encontrada diaria automatica em vigencia%'
       and ll.cad_log_msg_erro not like '%ERRO AO CANCELAR MOVIMENTOS%'
       and ll.cad_log_msg_erro not like '%O atendimento % um retorno%'
       and ll.cad_log_msg_erro not like '%N%o foi poss%vel enviar, j% existe uma NF lan%ada%'
       and ll.cad_log_msg_erro not like '%NF SGS e Movimento RM excluðdo%'
       and ll.cad_log_msg_erro not like '%AlterarCodigoProcedimento%'
       and ll.cad_log_msg_erro not like '%CID Principal alterado de Atendimento%'
       and ll.cad_log_msg_erro not like '%NENHUM ITEM ENCONTRADO%'
       and ll.cad_log_msg_erro not like '% foi encontrada di%ria autom%tica em vig%ncia para este conv%nio.%'
       and ll.cad_log_msg_erro not like '% foi encontrado cadastro de di%ria (cortesia) em %'
       and ll.cad_log_msg_erro not like '%marcada como AUDITADA por%'
       and ll.cad_log_msg_erro not like '%Data de emiss%o de nota fiscal alterada%'
       and ll.cad_log_msg_erro not like '%C%digo de procedimento alterad%'
       and ll.cad_log_msg_erro not like '%existe para o atendimento%'
       and ll.cad_log_msg_erro not like '%foi poss%vel obter o paciente/atendimento%'
       and ll.cad_log_msg_erro not like '%Produto n%o dispon%vel para rec%lculo%'
       and ll.cad_log_msg_erro not like '%Atendimento n%o est%˜ ativo%'
       and ll.cad_log_msg_erro not like '%Tipo de comanda sem setor de associa%'
       and ll.cad_log_msg_erro not like '%o foi encontrado cadastro de diferen%'
       and ll.cad_log_msg_erro not like '%Erro ao reemitir a conta pela auditoria%'
       and ll.cad_log_msg_erro not like '%O exame de laboratorio%ja existe para o atendimento.%'
       and ll.cad_log_msg_erro not like '%Codigo de procedimento alterado de %'
    order by 2
    )
    LOOP
    if(itens.interface = 'CONSULTAS') then
        v_consultas := 'OK';
    end if;
    if(itens.interface = 'IMAGEM') then
        v_imagem := 'OK';
    end if;
    if(itens.interface = 'LABORATORIO') then
        v_laboratorio := 'OK';
    end if;
    if(itens.interface = 'GERACAOLOTE') then
        v_lote := 'OK';
    end if;
    if(itens.interface = 'PACS') then
        v_pacs := 'OK';
    end if;
    if(itens.interface = 'DIARIAS') then
        v_diarias := 'OK';
    end if;
    if(itens.interface = 'AGENDAWEB - CARGA BENEFICIARIOS') then
        v_beneficiarios := 'OK';
    end if;
    if(itens.interface = 'AGENDAWEB - ATUALIZA ESCALA') then
        v_escalas := 'OK';
    end if;
    if(itens.interface = 'AGENDAWEB - ATUALIZA HISTORICO INTERNACAO') then
        v_historico := 'OK';
    end if;
    if(itens.interface = 'VISITAS') then
        v_visitas := 'OK';
    end if;
    if(itens.interface = 'ELEGIBILIDADE') then
        v_elegibilidade := 'OK';
    end if;
    if(itens.interface <> 'OUTROS') then
    v_mensagem := v_mensagem || itens.interface || ' - ' || itens.cad_log_msg_erro || '<BR/>';
    else
    v_mensagem_outro := v_mensagem_outro || itens.interface || ' - <FONT COLOR="RED">' || itens.cad_log_msg_erro || '</FONT><BR/>';
    end if;
    END LOOP;
  EXCEPTION WHEN others THEN
    v_mensagem_outro := '';
    v_mensagem := '<p/><STRONG><FONT COLOR="RED">VERIFICAR LOG DE ERROS</FONT></STRONG>';
  END;
  
  
v_header := v_header || '<TABLE BORDER=0 STYLE="FONT-FAMILY:calibri;"><TR><TD><B>CONSULTAS:</B> </TD><TD>' || v_consultas || '</TD></TR>';
v_header := v_header || '<TR><TD><B>IMAGEM:</B></TD><TD>' || v_imagem ||  '</TD></TR>';
v_header := v_header || '<TR><TD><B>LABORATORIO:</B></TD><TD> ' || v_laboratorio  || '</TD></TR>';
v_header := v_header || '<TR><TD><B>GERACAO LOTE:</B></TD><TD> ' || v_lote || '</TD></TR>';
v_header := v_header || '<TR><TD><B>DIARIAS:</B></TD><TD> ' || v_diarias || '</TD></TR>';
v_header := v_header || '<TR><TD><B>PACS:</B></TD><TD> ' || v_pacs || '</TD></TR>';
v_header := v_header || '<TR><TD><B>AGENDAWEB BENEFICIARIOS:</B></TD><TD> ' || v_beneficiarios || '</TD></TR>';
v_header := v_header || '<TR><TD><B>AGENDAWEB ESCALA:</B></TD><TD> ' || v_escalas || '</TD></TR>';
v_header := v_header || '<TR><TD><B>AGENDAWEB HISTORICO:</B></TD><TD> ' || v_historico || '</TD></TR>';
v_header := v_header || '<TR><TD><B>ELEGIBILIDADE:</B></TD><TD> ' || v_elegibilidade || '</TD></TR></TABLE>';
v_header := v_header || '<P/>' || '<B>LOG DETALHADO:</B> ' || '<BR/><FONT SIZE=1>';



prc_envia_email_n('', v_grupo, 'Monitoramento das Interfaces', '', to_clob(v_header || v_mensagem || v_mensagem_outro), null);
commit;

END PRC_LOG_AGENTE;
