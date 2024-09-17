* ---------------------------------------------------------------------------------
* eSocial - Consultar lote assincrono
* ---------------------------------------------------------------------------------
#IfNdef __XHARBOUR__
   #xcommand TRY => BEGIN SEQUENCE WITH {| oErr | Break( oErr ) }
   #xcommand CATCH [<!oErr!>] => RECOVER [USING <oErr>] <-oErr->
#endif
 
Function eSocialConsultaLoteAssincrono()
   Local oExceptionInterop, oErro
   Local oConfiguracao
   Local oConsultarLoteEventos
   Local oConsultaLoteAssincrono
   Local nStatusResposta, nHandle, cArquivo
   Local oEvento, nrRecibo, Hash, i, x

 * Criar o objeto de configuração mínima
   oConfiguracao = CreateObject("Unimake.Business.DFe.Servicos.Configuracao")
   oConfiguracao:TipoDFe = 12 //12=eSocial
   oConfiguracao:TipoEmissao = 1 //1=Normal
   oConfiguracao:CertificadoArquivo = "C:\Users\Wandrey\Downloads\Telegram Desktop\CERT_DIG_AGAPE_MEDICINA_DO_TRABALHO_LTDA_15527739000123_1702988563264876200.pfx"
   oConfiguracao:CertificadoSenha = "1234"
   oConfiguracao:Servico = 70 //Servico.ESocialConsultaEvts
   oConfiguracao:TipoAmbiente = 1 //TipoAmbiente.Producao

 * Criar objeto para pegar exceção do lado do CSHARP
   oExceptionInterop = CreateObject("Unimake.Exceptions.ThrowHelper")   
   
 * Criar o XML de ConsultaLoteEventos
   oConsultarLoteEventos = CreateObject("Unimake.Business.DFe.Xml.ESocial.ConsultarLoteEventos")
   oConsultarLoteEventos:Versao = "1.0.0"
   
   oConsultaLoteEventos = CreateObject("Unimake.Business.DFe.Xml.ESocial.ConsultaLoteEventos")
   oConsultaLoteEventos:ProtocoloEnvio = "1.1.202408.0000000010502861381"
  
   oConsultarLoteEventos:ConsultaLoteEventos = oConsultaLoteEventos   
  
   Try        
    * Enviar a consulta e pegar o retorno
	  oConsultaLoteAssincrono := CreateObject("Unimake.Business.DFe.Servicos.ESocial.ConsultaLoteAssincrono")
      oConsultaLoteAssincrono:Executar(oConsultarLoteEventos, oConfiguracao)

    * Gravar o XML retornado no HD
	  cArquivo := "d:\testenfe\" + oConsultaLoteEventos:ProtocoloEnvio + "-eSocial-ret.xml"
      nHandle := fCreate(cArquivo)
 	  FWrite(nHandle, oConsultaLoteAssincrono:RetornoWSString)
	  FClose(nHandle)

    * Demonstrar na tela o XML retornado	  
	  ? oConsultaLoteAssincrono:RetornoWSString
	  ?
	  ?
	  Wait
	  
	  nStatusResposta := oConsultaLoteAssincrono:Result:RetornoProcessamentoLoteEventos:Status:CdResposta
      ? "StatusRespostaLote: " + Trim(Str(nStatusResposta,3))	  	  	  	  
	  
	  If nStatusResposta == 201		 
	   * Tem que passar para a consulta o XML do lote de eventos enviados para que ela tenha os eventos para montar o XML de distribuição de cada um deles.
	     if File("C:\projetos\github\Unimake.DFe\source\Unimake.DFe.Test\ESocial\Resources\eSocial_envioLoteEventos.xml")
            oESocialEnvioLoteEventos = CreateObject("Unimake.Business.DFe.Xml.ESocial.ESocialEnvioLoteEventos")
   	        oESocialEnvioLoteEventos = oESocialEnvioLoteEventos:LoadFromFile("C:\projetos\github\Unimake.DFe\source\Unimake.DFe.Test\ESocial\Resources\eSocial_envioLoteEventos.xml")  		 
	        oConsultaLoteAssincrono:ESocialEnvioLoteEventos = oESocialEnvioLoteEventos
	     Endif		

	     For i = 1 To oConsultaLoteAssincrono:Result:RetornoProcessamentoLoteEventos:RetornoEventos:GetEventoCount()
		    oEvento = oConsultaLoteAssincrono:Result:RetornoProcessamentoLoteEventos:RetornoEventos:GetEvento(i-1)
			
			? "ID Evento:", oEvento:ID
			
			If oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta == 201 //Sucesso
			   nrRecibo := oEvento:RetornoEvento:eSocial:RetornoEvento:Recibo:NRRecibo
			   Hash := oEvento:RetornoEvento:eSocial:RetornoEvento:Recibo:Hash
			   
			   ? "Recibo autorizacao:", nrRecibo
			   ? "Hash assinatura evento:", Hash
			   ?
			   ?
			   ?

   			   oConsultaLoteAssincrono:GravarXmlDistribuicao("D:\testenfe\esocial\Enviado\Autorizados", "ID1230985630000002024090317432200001")
			   
			   Wait
			Else
   			   For x = 1 To oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:Ocorrencias:GetOcorrenciaCount()
			       oOcorrencia = oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:Ocorrencias:GetOcorrencia(x-1)
				   
				   ? "<tipo>", oOcorrencia:Tipo
				   ? "<codigo>", oOcorrencia:codigo
				   ? "<descricao>", oOcorrencia:descricao
				   ? "<localizacao>", oOcorrencia:localizacao
				   ?
				   ?
				   ?
    			   Wait
			   Next x
			Endif						
		 Next i		 
		 Cls
		 
      Else //Aconteceu algum erro no Retorno
		 hb_MemoWrit("d:\testenfe\" + oConsultaLoteEventos:ProtocoloEnvio + "-eSocial-erro-ret.xml", oConsultaLoteAssincrono:RetornoWSString)

         DO CASE
			CASE oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta == 101
				 ? "Aguarde alguns minutos e tente novamente!"
				 
			CASE oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta == 301
				 ? "Erro no servidor do eSocial. Aguarde alguns minutos e envie novamente!"
				 
			CASE oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta >= 401 .AND. oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta <= 411
				 ? "Codigo: " + hb_Ntos(oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta)
				 ? "Descricao: " + oEvento:RetornoEvento:eSocial:RetornoEvento:processamento:descResposta
				 
			CASE oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta >= 501 .AND. oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta <= 505
				 ? "Codigo: " + hb_Ntos(oEvento:RetornoEvento:eSocial:RetornoEvento:Processamento:CdResposta)
				 ? "Descricao: " + oEvento:RetornoEvento:eSocial:RetornoEvento:processamento:descResposta
				 
			OTHERWISE
				 ? "Erro nao catalogado!!"				 
         ENDCASE
	  
		 Wait
		 Cls
	  Endif	  
   
   Catch oErro
      //Demonstrar exceções geradas no proprio Harbour, se existir.
	  ? "ERRO"
	  ? "===="
	  ? "Falha ao tentar enviar o XML"
      ? oErro:Description
      ? oErro:Operation
	  
      //Demonstrar a exceção do CSHARP
	  ?
      ? "Excecao do CSHARP - Message: ", oExceptionInterop:GetMessage()
      ? "Excecao do CSHARP - Codigo: ", oExceptionInterop:GetErrorCode()
      ?     
	  
	  Wait
	  cls   
   End
Return 