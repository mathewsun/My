﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Этот исходный код был создан с помощью xsd, версия=4.6.81.0.
// 
namespace EfDatabaseInvoice {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("ReportSheme", Namespace="", IsNullable=false)]
    public partial class Report {
        
        private ParamRequest paramRequestField;
        
        private Main mainField;
        
        private Body[] bodyField;
        
        /// <remarks/>
        public ParamRequest ParamRequest {
            get {
                return this.paramRequestField;
            }
            set {
                this.paramRequestField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Main Main {
            get {
                return this.mainField;
            }
            set {
                this.mainField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Body", IsNullable=true)]
        public Body[] Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ParamRequest {
        
        private int idSelectField;
        
        private int idOutField;
        
        private int idUsersField;
        
        public ParamRequest() {
            this.idSelectField = 0;
            this.idOutField = 0;
            this.idUsersField = 0;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int IdSelect {
            get {
                return this.idSelectField;
            }
            set {
                this.idSelectField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int IdOut {
            get {
                return this.idOutField;
            }
            set {
                this.idOutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int IdUsers {
            get {
                return this.idUsersField;
            }
            set {
                this.idUsersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Main {
        
        private Formed formedField;
        
        private Received receivedField;
        
        private Organization organizationField;
        
        /// <remarks/>
        public Formed Formed {
            get {
                return this.formedField;
            }
            set {
                this.formedField = value;
            }
        }
        
        /// <remarks/>
        public Received Received {
            get {
                return this.receivedField;
            }
            set {
                this.receivedField = value;
            }
        }
        
        /// <remarks/>
        public Organization Organization {
            get {
                return this.organizationField;
            }
            set {
                this.organizationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Formed {
        
        private string userNameField;
        
        private string smallNameField;
        
        private string nameOtdelField;
        
        private string namePositionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SmallName {
            get {
                return this.smallNameField;
            }
            set {
                this.smallNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameOtdel {
            get {
                return this.nameOtdelField;
            }
            set {
                this.nameOtdelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NamePosition {
            get {
                return this.namePositionField;
            }
            set {
                this.namePositionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Received {
        
        private string userNameField;
        
        private string smallNameField;
        
        private string nameOtdelField;
        
        private string chiefNameField;
        
        private string chiefSmallNameField;
        
        private string chiefPositionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SmallName {
            get {
                return this.smallNameField;
            }
            set {
                this.smallNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameOtdel {
            get {
                return this.nameOtdelField;
            }
            set {
                this.nameOtdelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ChiefName {
            get {
                return this.chiefNameField;
            }
            set {
                this.chiefNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ChiefSmallName {
            get {
                return this.chiefSmallNameField;
            }
            set {
                this.chiefSmallNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ChiefPosition {
            get {
                return this.chiefPositionField;
            }
            set {
                this.chiefPositionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Organization {
        
        private string nameOrganizationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameOrganization {
            get {
                return this.nameOrganizationField;
            }
            set {
                this.nameOrganizationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Body {
        
        private string nameField;
        
        private string nameCategoryField;
        
        private string modelField;
        
        private string categoryField;
        
        private string serNumField;
        
        private string serviceNumField;
        
        private string inventarNumSysBlokField;
        
        private string numberKabinetField;
        
        private string nameComputerField;
        
        private string ipAdressField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameCategory {
            get {
                return this.nameCategoryField;
            }
            set {
                this.nameCategoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SerNum {
            get {
                return this.serNumField;
            }
            set {
                this.serNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ServiceNum {
            get {
                return this.serviceNumField;
            }
            set {
                this.serviceNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InventarNumSysBlok {
            get {
                return this.inventarNumSysBlokField;
            }
            set {
                this.inventarNumSysBlokField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumberKabinet {
            get {
                return this.numberKabinetField;
            }
            set {
                this.numberKabinetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameComputer {
            get {
                return this.nameComputerField;
            }
            set {
                this.nameComputerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IpAdress {
            get {
                return this.ipAdressField;
            }
            set {
                this.ipAdressField = value;
            }
        }
    }
}