CREATE OR REPLACE PROCEDURE "PRC_ENVIA_EMAIL_N" (
    pemail_origem   IN nvarchar2,
    pemail_destino  IN nvarchar2,
    pemail_assunto  IN nvarchar2,
    pemail_msgbody  IN nvarchar2 default null,
    pemail_msgbodyclob IN clob default null,
    pemail_replyto IN nvarchar2 default null)

   IS


  EmailServer     varchar2(30) := '172.16.1.18';
  Port number  := 25;
  conn UTL_SMTP.CONNECTION;
  crlf VARCHAR2( 2 ):= CHR( 13 ) || CHR( 10 );
  mesg VARCHAR2(8000);
  mesg_body varchar2(8000):=  pemail_msgbody;

BEGIN


/*

        conn:= utl_smtp.open_connection( EmailServer, Port );

        utl_smtp.helo( conn, EmailServer );
        utl_smtp.mail( conn, pemail_origem);

    for itens in (select * from table(fnc_split(pemail_destino)))
     loop
      utl_smtp.rcpt( conn, itens.column_value);
     end loop;

        mesg:=
         'From:'||pemail_origem|| crlf ||
         'Subject:'||pemail_assunto|| crlf ||
         'To: '||pemail_destino|| crlf || '' || crlf ||mesg_body||'';

        utl_smtp.data(conn, 'MIME-Version: 1.0' ||CHR(13)|| CHR(10)||'Content-type: text/html' || CHR(13)||CHR(10)||mesg);
        utl_smtp.quit( conn );
        
        */

        INSERT INTO TB_SGS_EML_ENVIA_EMAIL EE
(SGS_EML_ID,
SGS_EML_TEXTO,
SGS_EML_DESTINO,
SGS_EML_STATUS,
SGS_EML_ASSUNTO,
SGS_EML_DT_ULTIMA_ATUALIZACAO,
SGS_EML_REPLYTO)
values
(seq_sgs_eml_01.nextval,
nvl(pemail_msgbodyclob, pemail_msgbody),
pemail_destino,
'N',
pemail_assunto,
sysdate,
pemail_replyto);
commit;

end;

