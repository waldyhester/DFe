﻿#pragma warning disable CS1591
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Utility;
#if INTEROP
using System.Runtime.InteropServices;
#endif

namespace Unimake.Business.DFe.Xml.ESocial
{
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.ESocial2206")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Evento Alteração de Contrato de Trabalho/Relação Estatutária.
    /// </summary>
    [Serializable()]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtAltContratual/v_S_01_02_00", IsNullable = false)]
    public class ESocial2206 : XMLBase
    {
        /// <summary>
        /// Evento Alteração de Contrato de Trabalho
        /// </summary>
        [XmlElement("evtAltContratual")]
        public EvtAltContratual EvtAltContratual { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.EvtAltContratual")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Evento Alteração de Contrato de Trabalho
    /// </summary>
    public class EvtAltContratual
    {
        /// <summary>
        /// ID
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Informações de identificação do evento.
        /// </summary>
        [XmlElement("ideEvento")]
        public IdeEventoESocial2206 IdeEvento { get; set; }

        /// <summary>
        /// Informações de identificação do empregador.
        /// </summary>
        [XmlElement("ideEmpregador")]
        public IdeEmpregador IdeEmpregador { get; set; }

        /// <summary>
        /// Informações de identificação do trabalhador e do vínculo.
        /// </summary>
        [XmlElement("ideVinculo")]
        public IdeVinculo IdeVinculo { get; set; }

        /// <summary>
        /// Alteração de dados contratuais
        /// </summary>
        [XmlElement("altContratual")]
        public AltContratual AltContratual { get; set; }
    }

    #region IdeEvento

#if INTEROP
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeEventoESocial2206")]
        [ComVisible(true)]
#endif
    /// <summary>
    /// Informações de identificação do evento.
    /// </summary>
    public class IdeEventoESocial2206
    {
        /// <summary>
        /// Informe [1] para arquivo original ou [2] para arquivo de
        /// retificação.
        /// Valores válidos:
        /// 1 - Original
        /// 2 - Retificação
        /// </summary>
        [XmlElement("indRetif")]
        public IndicativoRetificacao IndRetif { get; set; }

        /// <summary>
        /// Preencher com o número do recibo do arquivo a ser
        /// retificado.
        /// Validação: O preenchimento é obrigatório se indRetif = [2].
        /// Deve ser um recibo de entrega válido, correspondente ao
        /// arquivo que está sendo retificado.
        /// </summary>
        [XmlElement("nrRecibo")]
        public string NrRecibo { get; set; }

        /// <summary>
        /// Identificação do ambiente.
        /// </summary>
        [XmlElement("tpAmb")]
        public TipoAmbiente TpAmb { get; set; } // Enum: 1-Produção, 2-Produção restrita

        /// <summary>
        /// Processo de emissão do evento.
        /// Valores válidos:
        /// 1 - Aplicativo do empregador
        /// 2 - Aplicativo governamental - Simplificado Pessoa Física
        /// 3 - Aplicativo governamental - Web Geral
        /// 4 - Aplicativo governamental - Simplificado Pessoa Jurídica
        /// 22 - Aplicativo governamental para dispositivos móveis - Empregador Doméstico
        /// </summary>
        [XmlElement("procEmi")]
        public ProcessoEmissao ProcEmi { get; set; } // Enum: 1-Aplicativo do empregador, 2-Aplicativo governamental - Simplificado Pessoa Física, 3-Aplicativo governamental - Web Geral, 4-Aplicativo governamental - Simplificado Pessoa Jurídica, 22-Aplicativo governamental para dispositivos móveis - Empregador Doméstico

        /// <summary>
        /// Versão do processo de emissão do evento. Informar a versão do aplicativo emissor do evento.
        /// </summary>
        [XmlElement("verProc")]
        public string VerProc { get; set; }

        #region         ShouldSerialize
        public bool ShouldSerializeNrRecibo() => !string.IsNullOrEmpty(NrRecibo);
        #endregion ShouldSerialize
    }

    #endregion IdeEvento

    #region IdeVinculo

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeVinculo")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações de identificação do trabalhador e do vínculo.
    /// </summary>
    public class IdeVinculo
    {
        /// <summary>
        /// Preencher com o número do CPF do trabalhador.
        /// </summary>
        [XmlElement("cpfTrab")]
        public string CpfTrab { get; set; }

        /// <summary>
        /// Matrícula atribuída ao trabalhador pela empresa ou, no caso de servidor público, a matrícula constante no Sistema de Administração de Recursos Humanos do órgão.
        /// </summary>
        [XmlElement("matricula")]
        public string Matricula { get; set; }
    }

    #endregion IdeVinculo

    #region altContratual

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.AltContratual")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Alteração de dados contratuais
    /// </summary>
    public class AltContratual
    {
        [XmlIgnore]
#if INTEROP
        public DateTime DtAlteracao {get; set; }
#else
        /// <summary>
        /// Preencher com a data da alteração das informações.
        ///Validação: Não pode ser posterior a 180 (cento e oitenta) dias da data atual.
        /// </summary>
        public DateTimeOffset DtAlteracao { get; set; }
#endif

        /// <summary>
        /// Preencher com a data da alteração das informações.
        ///Validação: Não pode ser posterior a 180 (cento e oitenta) dias da data atual.
        /// </summary>
        [XmlElement("dtAlteracao")]
        public string DtAlteracaoField
        {
            get => DtAlteracao.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtAlteracao = DateTime.Parse(value);
#else
            set => DtAlteracao = DateTimeOffset.Parse(value);
#endif
        }

        [XmlIgnore]
#if INTEROP
        public DateTime DtEf {get; set; }
#else
        /// <summary>
        /// Data dos efeitos remuneratórios da alteração contratual.
        /// Se a alteração foi fruto de lei, acordo coletivo, convenção
        /// coletiva ou sentença normativa, informar a data a partir da
        /// qual a alteração produz efeitos remuneratórios.
        /// Validação: Deve ser uma data válida, igual ou posterior à
        /// data de admissão.
        /// </summary>
        public DateTimeOffset DtEf { get; set; }
#endif

        /// <summary>
        /// Data dos efeitos remuneratórios da alteração contratual.
        /// Se a alteração foi fruto de lei, acordo coletivo, convenção
        /// coletiva ou sentença normativa, informar a data a partir da
        /// qual a alteração produz efeitos remuneratórios.
        /// Validação: Deve ser uma data válida, igual ou posterior à
        /// data de admissão.
        /// </summary>
        [XmlElement("dtEf")]
        public string DtEfField
        {
            get => DtEf.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtEf = DateTime.Parse(value);
#else
            set => DtEf = DateTimeOffset.Parse(value);
#endif
        }

        /// <summary>
        /// Descrição da alteração ou do instrumento que a gerou.
        /// </summary>
        [XmlElement("dscAlt")]
        public string DscAlt { get; set; }

        /// <summary>
        /// Grupo de informações do vínculo trabalhista.
        /// </summary>
        [XmlElement("vinculo")]
        public Vinculo Vinculo { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeDscAlt() => !string.IsNullOrEmpty(DscAlt);
        #endregion ShouldSerialize
    }

    #region Vinculo

    /// <summary>
    /// Grupo de informações do vínculo trabalhista.
    /// </summary>
    public class Vinculo
    {
        /// <summary>
        /// Tipo de regime previdenciário (ou Sistema de Proteção
        /// Social dos Militares das Forças Armadas).
        /// </summary>
        [XmlElement("tpRegPrev")]
        public TpRegPrev TpRegPrev { get; set; }

        /// <summary>
        /// Informações do regime trabalhista 
        /// </summary>
        [XmlElement("infoRegimeTrab")]
        public InfoRegimeTrab InfoRegimeTrab { get; set; }

        /// <summary>
        /// Informações do contrato de trabalho.
        /// </summary>
        [XmlElement("infoContrato")]
        public InfoContrato InfoContrato { get; set; }
    }

    #region InfoRegimeTrab

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoRegimeTrab")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações do regime trabalhista 
    /// </summary>
    public class InfoRegimeTrab
    {
        /// <summary>
        /// Informações de trabalhador celetista
        /// </summary>
        [XmlElement("infoCeletista")]
        public InfoCeletista InfoCeletista { get; set; }

        /// <summary>
        /// Informações de trabalhador estatutário.
        /// </summary>
        [XmlElement("infoEstatutario")]
        public InfoEstatutario InfoEstatutario { get; set; }
    }

    #region InfoCeletista

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoCeletista")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações de trabalhador celetista
    /// </summary>
    public class InfoCeletista
    {
        /// <summary>
        /// Regime de jornada do empregado.
        /// Valores válidos:
        /// 1 - Submetido a horário de trabalho(Capítulo II do Título II da CLT)
        /// 2 - Atividade externa especificada no inciso I do art. 62 da CLT
        /// 3 - Função especificada no inciso II do art. 62 da CLT
        /// 4 - Teletrabalho, previsto no inciso III do art. 62 da CLT
        /// </summary>
        [XmlElement("tpRegJor")]
        public TpRegJor TpRegJor { get; set; }

        /// <summary>
        /// Natureza da atividade.
        /// </summary>
        [XmlElement("natAtividade")]
        public NatAtividade NatAtividade { get; set; }

        /// <summary>
        /// Mês relativo à data base da categoria profissional do trabalhador.
        /// </summary>
        [XmlElement("dtBase")]
        public int DtBase { get; set; }

        /// <summary>
        /// Preencher com o CNPJ do sindicato representativo da
        /// categoria(preponderante ou diferenciada).
        /// Validação: Deve ser um CNPJ válido, com 14 (catorze) algarismos.
        /// </summary>
        [XmlElement("cnpjSindCategProf")]
        public string CnpjSindCategProf { get; set; }

        /// <summary>
        /// Dados sobre trabalho temporário. Preenchimento
        /// obrigatório no caso de prorrogação de contrato de trabalhador temporário.
        /// </summary>
        [XmlElement("trabTemporario")]
        public TrabTemporario TrabTemporario { get; set; }

        /// <summary>
        /// - Informações relacionadas ao aprendiz.
        /// </summary>
        [XmlElement("aprend")]
        public Aprend Aprend { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeDtBase() => DtBase > 0;
        #endregion ShouldSerialize
    }

    #region TrabTemporario
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.TrabTemporario")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Dados sobre trabalho temporário. Preenchimento
    /// obrigatório no caso de prorrogação de contrato de trabalhador temporário.
    /// </summary>
    public class TrabTemporario
    {
        /// <summary>
        /// Descrever a justificativa para a prorrogação do contrato de trabalho temporário.
        /// </summary>
        [XmlElement("justProrr")]
        public string JustProrr { get; set; }
    }
    #endregion TrabTemporario

    #region Aprendiz
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.Aprend")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// - Informações relacionadas ao aprendiz.
    /// </summary>
    public class Aprend
    {
        /// <summary>
        /// Indicativo de modalidade de contratação de aprendiz.
        /// Valores válidos:
        /// 1 - Contratação direta: contratação do aprendiz efetivada
        /// pelo estabelecimento cumpridor da cota de aprendizagem
        /// 2 - Contratação indireta: contratação do aprendiz
        /// efetivada por entidades sem fins lucrativos ou por
        /// entidades de prática desportiva a serviço do
        /// estabelecimento cumpridor da cota
        /// </summary>
        [XmlElement("indAprend")]
        public IndAprend IndAprend { get; set; }

        /// <summary>
        /// Informar o número de inscrição no CNPJ da entidade
        /// qualificadora, no caso de contratação direta.
        /// Validação: Preenchimento obrigatório e exclusivo se
        /// indAprend = [1].
        /// Deve ser um CNPJ válido, com 14 (catorze) algarismos.
        /// </summary>
        [XmlElement("cnpjEntQual")]
        public string CnpjEntQual { get; set; }

        /// <summary>
        /// Preencher com o código correspondente ao tipo de
        /// inscrição do estabelecimento para o qual a contratação de
        /// aprendiz foi efetivada, no caso de contratação indireta,
        /// conforme Tabela 05.
        /// Valores válidos:
        /// 1 - CNPJ
        /// 2 - CPF
        /// Validação: Preenchimento obrigatório e exclusivo se
        /// indAprend = [2].
        /// </summary>
        [XmlElement("tpInsc")]
#if INTEROP
        public TpInsc TpInsc { get; set; } = (TpInsc)(-1);
#else
        public TpInsc? TpInsc { get; set; }
#endif

        /// <summary>
        /// Informar o número de inscrição do estabelecimento para
        /// o qual a contratação de aprendiz foi efetivada, no caso de
        /// contratação indireta, de acordo com o tipo de inscrição
        /// indicado no campo aprend/tpInsc.
        /// Validação: Preenchimento obrigatório e exclusivo se
        /// indAprend = [2].
        /// Deve ser um identificador válido e:
        /// a) Se aprend/tpInsc = [1], deve ser informado com 14
        /// (catorze) algarismos.Se o empregador for pessoa jurídica,
        /// a raiz do CNPJ informado deve ser diferente de
        /// ideEmpregador/nrInsc.
        /// b) Se aprend/tpInsc = [2], deve ser diferente do CPF do
        /// empregado.Se o empregador for pessoa física, também
        /// deve ser diferente do CPF do empregador.
        /// </summary>
        [XmlElement("nrInsc")]
        public string NrInsc { get; set; }

        /// <summary>
        /// Informar o número de inscrição no CNPJ do
        /// estabelecimento onde estão sendo realizadas as
        /// atividades práticas, quando ocorrer uma das seguintes
        /// situações:
        /// a) Modalidade alternativa de cumprimento de cota de
        /// aprendizagem(neste caso, informar o CNPJ da entidade
        /// concedente da parte prática);
        /// b) Realização das atividades práticas na empresa
        /// contratante do serviço terceirizado;
        /// c) Centralização das atividades práticas em
        /// estabelecimento da própria empresa, diverso do
        /// estabelecimento responsável pelo cumprimento da cota.
        /// Validação: Deve ser um CNPJ válido, com 14 (catorze) algarismos.
        /// </summary>
        [XmlElement("cnpjPrat")]
        public string CnpjPrat { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeCnpjEntQual() => !string.IsNullOrEmpty(CnpjEntQual);
#if INTEROP
        public bool ShouldSerializeTpInscField() => TpInsc != (TpInsc)(-1);
#else
        public bool ShouldSerializeTpInsc() => TpInsc.IsNullOrEmpty();
#endif
        public bool ShouldSerializeNrInsc() => !string.IsNullOrEmpty(NrInsc);

        public bool ShouldSerializeCnpjPrat() => !string.IsNullOrEmpty(CnpjPrat);
        #endregion ShouldSerialize

    }
    #endregion Aprendiz

    #endregion InfoCeletista

    #region InfoEstatutario

    /// <summary>
    /// Informações de trabalhador estatutário.
    /// </summary>
    public class InfoEstatutario
    {
        /// <summary>
        /// Tipo de plano de segregação da massa.
        /// Valores válidos:
        /// 0 - Sem segregação da massa
        /// 1 - Fundo em capitalização
        /// 2 - Fundo em repartição
        /// 3 - Mantido pelo Tesouro
        /// </summary>
        [XmlElement("tpPlanRP")]
        public TpPlanRP TpPlanRP { get; set; }

        /// <summary>
        /// Informar se o servidor está sujeito ao teto do RGPS pela
        /// instituição do regime de previdência complementar.
        /// Valores válidos:
        /// S - Sim
        /// N - Não
        /// </summary>
        [XmlElement("indTetoRGPS")]
        public SimNaoLetra IndTetoRGPS { get; set; }

        /// <summary>
        /// Indicar se o servidor recebe abono permanência.
        /// Valores válidos:
        /// S - Sim
        /// N - Não
        /// </summary>
        [XmlElement("indAbonoPerm")]
        public SimNaoLetra IndAbonoPerm { get; set; }
    }
    #endregion InfoEstatutario

    #endregion InfoRegimeTrab

    #region InfoContrato
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoContrato")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações do contrato de trabalho.
    /// </summary>
    public class InfoContrato
    {
        /// <summary>
        /// Informar o nome do cargo.
        /// Validação: O preenchimento é obrigatório, exceto se for
        /// relativo a servidor nomeado em cargo em comissão(no
        /// evento S-2200, tpRegTrab = [2] e tpProv = [2]).
        /// </summary>
        [XmlElement("nmCargo")]
        public string NmCargo { get; set; }

        /// <summary>
        /// Informar a Classificação Brasileira de Ocupações - CBO
        /// relativa ao cargo.
        /// Validação: Informação obrigatória e exclusiva se nmCargo
        /// for preenchido.Se informado, deve ser um código válido e
        /// existente na tabela de CBO, com 6 (seis) posições.
        /// </summary>
        [XmlElement("CBOCargo")]
        public string CBOCargo { get; set; }

        /// <summary>
        /// Informar o nome da função de confiança/cargo em comissão.
        /// Validação: Preenchimento obrigatório se for relativo a
        /// servidor nomeado em cargo em comissão(no evento S2200, tpRegTrab = [2] e tpProv = [2]).
        /// </summary>
        [XmlElement("nmFuncao")]
        public string NmFuncao { get; set; }

        /// <summary>
        /// Informar o nome da função de confiança/cargo em comissão.
        /// Validação: Preenchimento obrigatório se for relativo a
        /// servidor nomeado em cargo em comissão(no evento S2200, tpRegTrab = [2] e tpProv = [2]).
        /// </summary>
        [XmlElement("CBOFuncao")]
        public string CBOFuncao { get; set; }

        /// <summary>
        /// Informar se o cargo, emprego ou função pública é acumulável.
        /// Valores válidos:
        /// S - Sim
        /// N - Não
        /// Validação: Preenchimento obrigatório se a natureza
        /// jurídica do declarante for igual a 1XX-X, 201-1 ou 203-8.
        /// </summary>
        [XmlElement("acumCargo")]
#if INTEROP
        public SimNaoLetra AcumCargo { get; set; } = (SimNaoLetra)(-1);
#else
        public SimNaoLetra? AcumCargo { get; set; }
#endif
        /// <summary>
        /// Preencher com o código da categoria do trabalhador.
        /// </summary>
        [XmlElement("codCateg")]
        public CodCateg CodCateg { get; set; }

        /// <summary>
        /// Informações da remuneração e periodicidade de pagamento.
        /// </summary>
        [XmlElement("remuneracao")]
        public Remuneracao Remuneracao { get; set; }

        /// <summary>
        /// Duração do contrato de trabalho.
        /// </summary>
        [XmlElement("duracao")]
        public Duracao Duracao { get; set; }


        /// <summary>
        /// Informações do local de trabalho.
        /// </summary>
        [XmlElement("localTrabalho")]
        public LocalTrabalho LocalTrabalho { get; set; }

        /// <summary>
        /// Informações do horário contratual do trabalhador.
        /// </summary>
        [XmlElement("horContratual")]
        public HorContratual HorContratual { get; set; }

        /// <summary>
        /// Informações do alvará judicial em caso de contratação de
        /// menores de 14 anos, em qualquer categoria, e de maiores
        /// de 14 e menores de 16, em categoria diferente de "Aprendiz".
        /// </summary>
        [XmlElement("alvaraJudicial")]
        public AlvaraJudicial AlvaraJudicial { get; set; }

        /// <summary>
        /// Observações do contrato de trabalho.
        /// </summary>
        [XmlElement("observacoes")]
        public List<Observacoes> Observacoes { get; set; }
#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddObservacoes(Observacoes item)
        {
            if (Observacoes == null)
            {
                Observacoes = new List<Observacoes>();
            }

            Observacoes.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista Observacoes (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da Observacoes</returns>
        public Observacoes GetObservacoes(int index)
        {
            if ((Observacoes?.Count ?? 0) == 0)
            {
                return default;
            };

            return Observacoes[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista Observacoes
        /// </summary>
        public int GetObservacoesCount => (Observacoes != null ? Observacoes.Count : 0);
#endif
        /// <summary>
        /// Treinamentos, capacitações, exercícios simulados,
        /// autorizações ou outras anotações que devam ser anotadas
        /// no registro de empregados e/ou na CTPS, por
        /// determinação de Norma Regulamentadora - NR.
        /// </summary>
        [XmlElement("treiCap")]
        public List<TreiCap> TreiCap { get; set; }
#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddTreiCap(TreiCap item)
        {
            if (TreiCap == null)
            {
                TreiCap = new List<TreiCap>();
            }

            TreiCap.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista TreiCap (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da TreiCap</returns>
        public TreiCap GetTreiCap(int index)
        {
            if ((TreiCap?.Count ?? 0) == 0)
            {
                return default;
            };

            return TreiCap[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista TreiCap
        /// </summary>
        public int GetTreiCapCount => (TreiCap != null ? TreiCap.Count : 0);
#endif
        #region ShouldSerialize
        public bool ShouldSerializeNmCargo() => !string.IsNullOrEmpty(NmCargo);
        public bool ShouldSerializeCBOCargo() => !string.IsNullOrEmpty(CBOCargo);
        public bool ShouldSerializeNmFuncao() => !string.IsNullOrEmpty(NmFuncao);
        public bool ShouldSerializeCBOFuncao() => !string.IsNullOrEmpty(CBOFuncao);
#if INTEROP
                public bool ShouldSerializeAcumCargoField() => AcumCargo != (SimNaoLetra)(-1);
#else
        public bool ShouldSerializeAcumCargo() => AcumCargo.IsNullOrEmpty();
#endif

        #endregion ShouldSerialize
    }

    #region Remuneracao

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.Remuneracao")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações da remuneração e periodicidade de pagamento.
    /// </summary>
    public class Remuneracao
    {
        /// <summary>
        /// Salário base do trabalhador, correspondente à parte fixa
        /// da remuneração.
        /// Validação: Se undSalFixo for igual a [7], preencher com 0 (zero).
        /// </summary>
        [XmlIgnore]
        public double VrSalFx { get; set; }


        /// <summary>
        /// Salário base do trabalhador, correspondente à parte fixa
        /// da remuneração.
        /// Validação: Se undSalFixo for igual a [7], preencher com 0 (zero).
        /// </summary>
        [XmlElement("vrSalFx")]
        public string VrSalFxField
        {
            get => VrSalFx.ToString("F2", CultureInfo.InvariantCulture);
            set => VrSalFx = Converter.ToDouble(value);

        }

        /// <summary>
        /// Unidade de pagamento da parte fixa da remuneração.
        /// </summary>
        [XmlElement("undSalFixo")]
        public UndSalFixo UnidadeSalarioFixo { get; set; }

        /// <summary>
        /// Descrição do salário por tarefa ou variável e como este é
        /// calculado.Ex.: Comissões pagas no percentual de 10%
        /// sobre as vendas.
        /// Validação: Preenchimento obrigatório se undSalFixo for igual a[6, 7].
        /// </summary>
        [XmlElement("dscSalVar")]
        public string DscSalVar { get; set; }
        #region ShouldSerialize
        public bool ShouldSerializeDscSalVar() => !string.IsNullOrEmpty(DscSalVar);
        #endregion ShouldSerialize
    }
    #endregion Remuneracao

    #region Duracao

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.Duracao")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Duração do contrato de trabalho.
    /// </summary>
    public class Duracao
    {
        /// <summary>
        /// Tipo de contrato de trabalho.
        /// Valores válidos:
        /// 1 - Prazo indeterminado
        /// 2 - Prazo determinado, definido em dias
        /// 3 - Prazo determinado, vinculado à ocorrência de um fato
        /// Validação: Se codCateg = [103] e dtAlteracao >= [2024-
        /// 04-22], deve ser informado[2].
        /// </summary>
        [XmlElement("tpContr")]
        public TipoDeContratoDeTrabalho TipoDeContratoDeTrabalho { get; set; }

        [XmlIgnore]
#if INTEROP
        public DateTime DtTerm {get; set; }
#else
        /// <summary>
        /// Data do término do contrato por prazo determinado.
        /// Validação: O preenchimento é obrigatório se tpContr =
        /// [2].Não informar se tpContr = [1]. Se preenchido, deve ser
        /// igual ou posterior à data de admissão(no caso de
        /// transferência ou mudança de CPF, igual ou posterior a
        /// sucessaoVinc/dtTransf, transfDom/dtTransf ou dtAltCPF do
        /// evento S-2200, conforme o caso).
        /// Retornar alerta caso a data informada seja anterior a
        /// dtAlteracao.
        /// </summary>
        public DateTimeOffset DtTerm { get; set; }
#endif

        /// <summary>
        /// Data do término do contrato por prazo determinado.
        /// Validação: O preenchimento é obrigatório se tpContr =
        /// [2].Não informar se tpContr = [1]. Se preenchido, deve ser
        /// igual ou posterior à data de admissão(no caso de
        /// transferência ou mudança de CPF, igual ou posterior a
        /// sucessaoVinc/dtTransf, transfDom/dtTransf ou dtAltCPF do
        /// evento S-2200, conforme o caso).
        /// Retornar alerta caso a data informada seja anterior a
        /// dtAlteracao.
        /// </summary>
        [XmlElement("dtTerm")]
        public string DtTermField
        {
            get => DtTerm.ToString("yyyy-MM-dd");
#if INTEROP
            set => DtTerm = DateTime.Parse(value);
#else
            set => DtTerm = DateTimeOffset.Parse(value);
#endif
        }

        /// <summary>
        /// Indicação do objeto determinante da contratação por
        /// prazo determinado(obra, serviço, safra, etc.).
        /// Validação: O preenchimento é obrigatório e exclusivo se
        /// tpContr = [3].
        /// </summary>
        [XmlElement("objDet")]
        public string ObjDet { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeDtTermField() => !string.IsNullOrEmpty(DtTermField);
        public bool ShouldSerializeObjDet() => TipoDeContratoDeTrabalho == TipoDeContratoDeTrabalho.PrazoDeterminadoOcorrencia;

        #endregion ShouldSerialize
    }
    #endregion Duracao

    #region LocalTrabalho

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.LocalTrabalho")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações do local de trabalho.
    /// </summary>
    public class LocalTrabalho
    {
        /// <summary>
        ///  Estabelecimento (CNPJ, CNO, CAEPF) onde o trabalhador
        /// (exceto doméstico) exercerá suas atividades.Caso o
        /// trabalhador exerça suas atividades em instalações de
        /// terceiros, este campo deve ser preenchido com o
        /// estabelecimento do próprio empregador ao qual o
        /// trabalhador esteja vinculado.
        /// </summary>
        [XmlElement("localTrabGeral")]
        public LocalTrabGeral LocalTrabGeral { get; set; }

        /// <summary>
        /// Grupo preenchido exclusivamente em caso de trabalhador
        /// doméstico e trabalhador temporário, indicando o
        /// endereço onde o trabalhador exerce suas atividades.
        /// </summary>
        [XmlElement("localTempDom")]
        public LocalTempDom LocalTempDom { get; set; }
    }

    #region LocalTrabGeral

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.LocalTrabGeral")]
    [ComVisible(true)]
#endif
    /// <summary>
    ///  Estabelecimento (CNPJ, CNO, CAEPF) onde o trabalhador
    /// (exceto doméstico) exercerá suas atividades.Caso o
    /// trabalhador exerça suas atividades em instalações de
    /// terceiros, este campo deve ser preenchido com o
    /// estabelecimento do próprio empregador ao qual o
    /// trabalhador esteja vinculado.
    /// </summary>
    public class LocalTrabGeral
    {
        /// <summary>
        /// Preencher com o código correspondente ao tipo de inscrição, conforme Tabela 05.
        /// </summary>
        [XmlElement("tpInsc")]
        public TpInsc TpInsc { get; set; }

        /// <summary>
        /// Informar o número de inscrição do contribuinte de acordo
        /// com o tipo de inscrição indicado no campo
        /// localTrabGeral/tpInsc.
        /// Validação: Deve ser um número de inscrição válido e
        /// existente na Tabela de Estabelecimentos(S-1005), bem
        /// como compatível com localTrabGeral/tpInsc
        /// </summary>
        [XmlElement("nrInsc")]
        public string NrInsc { get; set; }

        /// <summary>
        /// Descrição complementar do local de trabalho.
        /// </summary>
        [XmlElement("descComp")]
        public string DescComp { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeDescComp() => !string.IsNullOrEmpty(DescComp);
        #endregion ShouldSerialize
    }

    #endregion LocalTrabGeral

    #region LocalTempDom

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.LocalTempDom")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Grupo preenchido exclusivamente em caso de trabalhador
    /// doméstico e trabalhador temporário, indicando o
    /// endereço onde o trabalhador exerce suas atividades.
    /// </summary>
    public class LocalTempDom
    {
        /// <summary>
        /// Tipo de logradouro.
        /// Validação: Se informado, deve ser um código válido e
        /// existente na Tabela 20.
        /// </summary>
        [XmlElement("tpLograd")]
        public string TpLograd { get; set; }

        /// <summary>
        /// Descrição do logradouro.
        /// </summary>
        [XmlElement("dscLograd")]
        public string DscLograd { get; set; }

        /// <summary>
        /// Número do logradouro.
        /// Se não houver número a ser informado, preencher com "S/N".
        /// </summary>
        [XmlElement("nrLograd")]
        public string NrLograd { get; set; }

        /// <summary>
        /// Complemento do logradouro
        /// </summary>
        [XmlElement("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// Nome do bairro/distrito.
        /// </summary>
        [XmlElement("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// Código de Endereçamento Postal - CEP.
        /// Validação: Deve ser preenchido apenas com números,
        /// com 8 (oito) posições.
        /// </summary>]
        [XmlElement("cep")]
        public string Cep { get; set; }

        /// <summary>
        /// Preencher com o código do município, conforme tabela
        /// do IBGE.
        /// Validação: Deve ser um código válido e existente na
        /// tabela do IBGE.
        /// </summary>
        [XmlElement("codMunic")]
        public string CodMunicipio { get; set; }

        /// <summary>
        /// Preencher com a sigla da Unidade da Federação - UF.
        /// Valores válidos: AC, AL, AP, AM, BA, CE, DF, ES, GO, MA,
        /// MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
        /// /summary>
        [XmlElement("uf")]
        public UFBrasil Uf { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeTpLograd() => !string.IsNullOrEmpty(TpLograd);
        public bool ShouldSerializeComplemento() => !string.IsNullOrEmpty(Complemento);
        public bool ShouldSerializeBairro() => !string.IsNullOrEmpty(Bairro);


        #endregion ShouldSerialize
    }
    #endregion LocalTempDom

    #endregion LocalTrabalho

    #region HorContratual

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.HorContratual")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações do horário contratual do trabalhador.
    /// </summary>
    public class HorContratual
    {
        /// <summary>
        /// Quantidade média de horas relativas à jornada semanal do trabalhador.
        /// Validação: Deve ser preenchida se codCateg for diferente
        /// de[111]. Se informada, deve ser maior que 0 (zero).
        /// </summary>
        [XmlElement("qtdHrsSem")]
        public string QtdHrsSem { get; set; }

        /// <summary>
        /// Tipo de jornada
        /// Valores válidos:
        /// 2 - Jornada 12 x 36 (12 horas de trabalho seguidas de 36
        /// horas ininterruptas de descanso)
        /// 3 - Jornada com horário diário fixo e folga variável
        /// 4 - Jornada com horário diário fixo e folga fixa(no
        /// domingo)
        /// 5 - Jornada com horário diário fixo e folga fixa(exceto no
        /// domingo)
        /// 6 - Jornada com horário diário fixo e folga fixa(em outro
        /// dia da semana), com folga adicional periódica no
        /// domingo
        /// 7 - Turno ininterrupto de revezamento
        /// 9 - Demais tipos de jornada
        /// </summary>
        [XmlElement("tpJornada")]
        public TpJornada TpJornada { get; set; }

        /// <summary>
        /// Preencher com o código relativo ao tipo de contrato em
        /// tempo parcial.
        /// Valores válidos:
        /// 0 - Não é contrato em tempo parcial
        /// 1 - Limitado a 25 horas semanais
        /// 2 - Limitado a 30 horas semanais
        /// 3 - Limitado a 26 horas semanais
        /// Validação: O código [1] só é válido se codCateg = [104].
        /// Os códigos [2, 3] não são válidos se codCateg = [104].
        /// </summary>
        [XmlElement("tmpParc")]
        public TmpParc TmpParc { get; set; }

        /// <summary>
        ///  Indicar se a jornada semanal possui horário noturno (no
        /// todo ou em parte).
        /// Valores válidos:
        /// S - Sim
        /// N - Não
        /// Validação: Informação obrigatória se codCateg for
        /// diferente de[111].
        /// </summary>
        [XmlElement("horNoturno")]
#if INTEROP
        public SimNaoLetra HorNoturno { get; set; } = (SimNaoLetra)(-1);
#else
        public SimNaoLetra? HorNoturno { get; set; }
#endif
        /// <summary>
        /// Descrição da jornada semanal contratual, contendo os
        /// dias da semana e os respectivos horários contratuais
        /// (entrada, saída e intervalos).
        /// </summary>
        [XmlElement("dscJorn")]
        public string DscJorn { get; set; }

        #region ShouldSerialize
        public bool ShouldSerializeQtdHrsSem() => !string.IsNullOrEmpty(QtdHrsSem);
#if INTEROP
        public bool ShouldSerializeHorNoturnoField() => HorNoturno != (SimNaoLetra)(-1);
#else
        public bool ShouldSerializeHorNoturno() => HorNoturno.IsNullOrEmpty();
#endif

        #endregion ShouldSerialize
    }

    #endregion HorContratual

    #region AlvaraJudicial

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.AlvaraJudicial")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informações do alvará judicial em caso de contratação de
    /// menores de 14 anos, em qualquer categoria, e de maiores
    /// de 14 e menores de 16, em categoria diferente de "Aprendiz".
    /// </summary>
    public class AlvaraJudicial
    {
        /// <summary>
        /// Preencher com o número do processo judicial.
        /// Validação: Deve ser um número de processo judicial  válido.
        /// </summary>
        [XmlElement("nrProcJud")]
        public string NrProcJud { get; set; }

    }
    #endregion AlvaraJudicial

    #region Observações
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.Observacoes")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Observações do contrato de trabalho.
    /// </summary>
    public class Observacoes
    {
        /// <summary>
        /// Observação relacionada ao contrato de trabalho
        /// </summary>
        [XmlElement("observacao")]
        public string Observacao { get; set; }
    }
    #endregion Observações

    #region TreiCap
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.TreiCap")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Treinamentos, capacitações, exercícios simulados,
    /// autorizações ou outras anotações que devam ser anotadas
    /// no registro de empregados e/ou na CTPS, por
    /// determinação de Norma Regulamentadora - NR.
    /// </summary>
    public class TreiCap
    {
        /// <summary>
        /// Informar o código do treinamento, capacitação, exercício
        /// simulado ou outra anotação, conforme Tabela 28.
        /// Validação: Deve ser um código válido e existente na Tabela 28.
        /// </summary>
        [XmlElement("codTreiCap")]
        public CodTreiCap CodTreiCap { get; set; }
    }
    #endregion TreiCap

    #endregion InfoContrato

    #endregion Vinculo

    #endregion altContratual
}