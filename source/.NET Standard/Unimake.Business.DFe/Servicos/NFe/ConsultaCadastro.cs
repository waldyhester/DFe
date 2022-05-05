﻿#if INTEROP
using System;
using System.Runtime.InteropServices;
#endif
using System;
using Unimake.Business.DFe.Servicos.Interop;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;

namespace Unimake.Business.DFe.Servicos.NFe
{
    /// <summary>
    /// Enviar o XML de consulta cadastro do contribuinte para o webservice
    /// </summary>
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Servicos.NFe.ConsultaCadastro")]
    [ComVisible(true)]
#endif
    public class ConsultaCadastro : ServicoBase, IInteropService<ConsCadBase>
    {
        #region Protected Methods

        /// <summary>
        /// Definir o valor de algumas das propriedades do objeto "Configuracoes"
        /// </summary>
        protected override void DefinirConfiguracao()
        {
            var xml = new ConsCad();
            xml = xml.LerXML<ConsCad>(ConteudoXML);

            if (!Configuracoes.Definida)
            {
                Configuracoes.Servico = Servico.NFeConsultaCadastro;
                Configuracoes.CodigoUF = (int)xml.InfCons.UF;
                Configuracoes.Modelo = ModeloDFe.NFe;
                Configuracoes.SchemaVersao = xml.Versao;
                Configuracoes.TipoAmbiente = TipoAmbiente.Producao;
                Configuracoes.TipoEmissao = TipoEmissao.Normal;

                base.DefinirConfiguracao();
            }
        }

        #endregion Protected Methods

        #region Public Properties

        /// <summary>
        /// Conteúdo retornado pelo webservice depois do envio do XML
        /// </summary>
        public RetConsCad Result
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(RetornoWSString))
                {
                    return XMLUtility.Deserializar<RetConsCad>(RetornoWSXML);
                }

                return new RetConsCad
                {
                    InfCons = new InfConsRetorno
                    {
                        CStat = 0,
                        XMotivo = "Ocorreu uma falha ao tentar criar o objeto a partir do XML retornado da SEFAZ."
                    }
                };
            }
        }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="consCad">Objeto contendo o XML a ser enviado</param>
        /// <param name="configuracao">Configurações para conexão e envio do XML para o web-service</param>
        public ConsultaCadastro(ConsCadBase consCad, Configuracao configuracao) : this()
        {
            if (configuracao is null)
            {
                throw new ArgumentNullException(nameof(configuracao));
            }

            Inicializar(consCad?.GerarXML() ?? throw new ArgumentNullException(nameof(consCad)), configuracao);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public ConsultaCadastro() : base() { }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Executa o serviço: Assina o XML, valida e envia para o web-service
        /// </summary>
#if INTEROP
        [ComVisible(false)]
#endif
        public override void Executar()
        {
            base.Executar();

            //Mato Grosso do Sul está retornando o XML da consulta cadastro fora do padrão, vou ter que intervir neste ponto para fazer a correção
            if (Configuracoes.CodigoUF == (int)UFBrasil.MT)
            {
                if (RetornoWSXML.GetElementsByTagName("retConsCad")[0] != null)
                {
                    RetornoWSString = RetornoWSXML.GetElementsByTagName("retConsCad")[0].OuterXml;
                    RetornoWSXML.LoadXml(RetornoWSString);
                }
            }
        }

#if INTEROP

        /// <summary>
        /// Executa o serviço: Assina o XML, valida e envia para o webservice
        /// </summary>
        /// <param name="consCad">Objeto contendo o XML a ser enviado</param>
        /// <param name="configuracao">Configurações a serem utilizadas na conexão e envio do XML para o webservice</param>
        [ComVisible(true)]
        public void Executar(ConsCadBase consCad, Configuracao configuracao)
        {
            if (configuracao is null)
            {
                throw new ArgumentNullException(nameof(configuracao));
            }

            Inicializar(consCad?.GerarXML() ?? throw new ArgumentNullException(nameof(consCad)), configuracao);
            Executar();
        }

#endif

        /// <summary>
        /// Grava o XML de Distribuição em uma pasta definida - (Para este serviço não tem XML de distribuição).
        /// </summary>
        /// <param name="pasta">Pasta onde é para ser gravado do XML</param>
        /// <param name="nomeArquivo">Nome para o arquivo XML</param>
        /// <param name="conteudoXML">Conteúdo do XML</param>
        public override void GravarXmlDistribuicao(string pasta, string nomeArquivo, string conteudoXML) => throw new System.Exception("Não existe XML de distribuição para consulta cadastro do contribuinte.");

        #endregion Public Methods
    }
}