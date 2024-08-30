﻿#pragma warning disable CS1591
using System;
using System.Xml.Serialization;
#if INTEROP
using System.Runtime.InteropServices;
#endif

namespace Unimake.Business.DFe.Xml.ESocial
{
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.ESocial3500")]
    [ComVisible(true)]
#endif

    /// <summary>
    /// Evento Informações do Empregador. eSocial - 3500
    /// </summary>
    [Serializable()]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtExcProcTrab/v_S_01_02_00", IsNullable = false)]
    public class ESocial3500 : XMLBase
    {
        /// <summary>
        /// Evento Exclusão
        /// </summary>
        [XmlElement("evtExcProcTrab")]
        public EvtExcProcTrab EvtExcProcTrab { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.EvtExcProcTrab")]
    [ComVisible(true)]
#endif
    public class EvtExcProcTrab
    {
        /// <summary>
        /// Informações de identificação do evento
        /// </summary>
        [XmlElement("ideEvento")]
        public IdeEvento IdeEvento { get; set; }

        /// <summary>
        /// Informações de identificação doempregador
        /// </summary>
        [XmlElement("ideEmpregador")]
        public IdeEmpregador IdeEmpregador { get; set; }


        /// <summary>
        /// Informação do evento que será excluído
        /// </summary>
        [XmlElement("infoExclusao")]
        public InfoExclusaoESocial3500 InfoExclusao { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.InfoExclusaoESocial3500")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Informação do evento que será excluído
    /// </summary>
    public class InfoExclusaoESocial3500
    {
        /// <summary>
        /// Preencher com o tipo de evento (S-2500 ou S-2501).
        /// Validação:
        /// Deve ser igual a[S - 2500, S - 2501].
        /// </summary>
        [XmlElement("tpEvento")]
        public string TpEvento { get; set; }

        /// <summary>
        /// Preencher com o número do recibo do evento que seráexcluído.
        /// Validação:
        /// O recibo deve ser relativo ao mesmo tipo deevento indicado em
        /// tpEvento
        /// </summary>
        [XmlElement("nrRecEvt")]
        public string NrRecEvt { get; set; }

        /// <summary>
        /// Identificação do processo, do trabalhador e do período aque se refere o evento que será excluído.
        /// </summary>
        [XmlElement("ideProcTrab")]
        public IdeProcTrab IdeProcTrab { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.ESocial.IdeProcTrab")]
    [ComVisible(true)]
#endif
    /// <summary>
    /// Identificação do processo, do trabalhador e do período aque se refere o evento que será excluído.
    /// </summary>
    public class IdeProcTrab
    {
        /// <summary>
        /// Número do processo trabalhista, da ata ou número deidentificação da conciliação.
        /// Validação:
        /// Deve ser o mesmo número do processoinformado no evento objeto da exclusão.
        /// </summary>
        [XmlElement("nrProcTrab")]
        public string NrProcTrab { get; set; }

        /// <summary>
        /// Preencher com o número do CPF do trabalhador.
        /// Validação:
        /// Preenchimento obrigatório e exclusivo se
        /// tpEvento
        /// = [S - 2500].Deve ser o mesmo CPF informadono evento S-2500 objeto da exclusão.
        /// </summary>
        [XmlElement("cpfTrab")]
        public string CpfTrab { get; set; }


        [XmlIgnore]
#if INTEROP
        public DateTime PerApurPgto { get; set; }
#else
        public DateTimeOffset PerApurPgto { get; set; }
#endif

        /// <summary>
        /// Mês/ano em que é devida a obrigação de pagar a parcelaprevista no acordo/sentença.
        /// Validação:
        /// Preenchimento obrigatório e exclusivo se
        /// tpEvento
        /// = [S - 2501].Deve ser o mesmo períodoinformado no evento S-2501 objeto da exclusão.
        /// </summary>
        [XmlElement("perApurPgto")]
        public string PerApurPgtoField
        {
            get => PerApurPgto.ToString("yyyy-MM");
#if INTEROP
            set => PerApurPgto = DateTime.Parse(value);
#else
            set => PerApurPgto = DateTimeOffset.Parse(value);
#endif
        }
        #region ShouldSerialize

        public bool ShouldSerializeCpfTrabField() => !string.IsNullOrEmpty(CpfTrab);
        #endregion ShouldSerialize

    }

}