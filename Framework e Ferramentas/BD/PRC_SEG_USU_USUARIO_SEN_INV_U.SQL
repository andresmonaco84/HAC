create or replace procedure PRC_SEG_USU_USUARIO_SEN_INV_U
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,
     pSucessoLogin_Ok char
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_SEN_INV_U
  *
  *    Data Criacao: 	05/03/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por:
  *
  *    Funcao: Realiza a controle de Logins invalidos e bloqueia o usuario
  *            caso o login falhe 3 vezes consecutivas.
  *
  *    Data Alteracao: 30/12/2008  Por: Davi Silvestre M. dos Reis
  *    Alteracao: nao bloquear o usario quando este errar a senha por 3 vezes
  *
  *******************************************************************/
  qtdLoginInvalido integer;
  begin

    --Se o login foi com sucesso, entao deve zerar o contador
    IF (pSucessoLogin_Ok = 'S') THEN
      UPDATE TB_SEG_USU_USUARIO
      SET    SEG_USU_QT_LOGIN_INVALIDO = 0,
             SEG_USU_DT_LOGIN_INVALIDO = NULL,
             SEG_USU_ID_ATUALIZADO_POR = pSEG_USU_ID_USUARIO
      WHERE  SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;
    ELSE

      --Recupera a qtd de logins invalidos
      SELECT NVL(SEG_USU_QT_LOGIN_INVALIDO,0) INTO qtdLoginInvalido
      FROM   TB_SEG_USU_USUARIO
      WHERE  SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;

      --Incrementa o contador de logins invalidos
      UPDATE TB_SEG_USU_USUARIO
      SET    SEG_USU_QT_LOGIN_INVALIDO = qtdLoginInvalido + 1,
             SEG_USU_DT_LOGIN_INVALIDO = SYSDATE,
             SEG_USU_ID_ATUALIZADO_POR = pSEG_USU_ID_USUARIO
      WHERE  SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;

      /*
      --Bloqueia usuario se o login falhar 3 vezes
      IF (qtdLoginInvalido = 2) THEN
        UPDATE TB_SEG_USU_USUARIO
        SET    SEG_USU_FL_STATUS = 'B', --BLOQUEADO
               SEG_USU_QT_LOGIN_INVALIDO = 0,
               SEG_USU_ID_ATUALIZADO_POR = pSEG_USU_ID_USUARIO
        WHERE  SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;
      END IF;
      */

    END IF;

  end PRC_SEG_USU_USUARIO_SEN_INV_U;
/
