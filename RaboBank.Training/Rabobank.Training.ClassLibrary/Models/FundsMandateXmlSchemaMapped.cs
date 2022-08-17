namespace Rabobank.Training.ClassLibrary.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://amt.rnss.rabobank.nl/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://amt.rnss.rabobank.nl/", IsNullable = false)]
    public partial class FundsOfMandatesData
    {
        private List<FundsOfMandatesDataFundOfMandates>? fundsOfMandatesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FundOfMandates", IsNullable = false)]
        public List<FundsOfMandatesDataFundOfMandates> FundsOfMandates
        {
            get
            {
                return fundsOfMandatesField;
            }
            set
            {
                this.fundsOfMandatesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://amt.rnss.rabobank.nl/")]
    public class FundsOfMandatesDataFundOfMandates
    {
        private string? instrumentCodeField;

        private string? instrumentNameField;

        private decimal liquidityAllocationField;

        private List<FundsOfMandatesDataFundOfMandatesMandate>? mandatesField;

        /// <remarks/>
        public string InstrumentCode
        {
            get
            {
                return this.instrumentCodeField;
            }
            set
            {
                this.instrumentCodeField = value;
            }
        }

        /// <remarks/>
        public string InstrumentName
        {
            get
            {
                return this.instrumentNameField;
            }
            set
            {
                this.instrumentNameField = value;
            }
        }

        /// <remarks/>
        public decimal LiquidityAllocation
        {
            get
            {
                return this.liquidityAllocationField;
            }
            set
            {
                this.liquidityAllocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Mandate", IsNullable = false)]
        public List<FundsOfMandatesDataFundOfMandatesMandate> Mandates
        {
            get
            {
                return this.mandatesField;
            }
            set
            {
                this.mandatesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://amt.rnss.rabobank.nl/")]
    public partial class FundsOfMandatesDataFundOfMandatesMandate
    {
        private string? mandateIdField;

        private string? mandateNameField;

        private decimal allocationField;

        /// <remarks/>
        public string MandateId
        {
            get
            {
                return this.mandateIdField;
            }
            set
            {
                this.mandateIdField = value;
            }
        }

        /// <remarks/>
        public string MandateName
        {
            get
            {
                return this.mandateNameField;
            }
            set
            {
                this.mandateNameField = value;
            }
        }

        /// <remarks/>
        public decimal Allocation
        {
            get
            {
                return this.allocationField;
            }
            set
            {
                this.allocationField = value;
            }
        }
    }
}