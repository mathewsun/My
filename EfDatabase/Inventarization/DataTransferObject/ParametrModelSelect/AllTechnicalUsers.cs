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
namespace EfDatabaseParametrsModel {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class AllTechnicalUsersAndOtdel {
        
        private Users[] usersField;
        
        private Otdel[] otdelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Users")]
        public Users[] Users {
            get {
                return this.usersField;
            }
            set {
                this.usersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Otdel")]
        public Otdel[] Otdel {
            get {
                return this.otdelField;
            }
            set {
                this.otdelField = value;
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
    public partial class Users {
        
        private Monitors[] monitorsField;
        
        private Mfu[] mfuField;
        
        private Printer[] printerField;
        
        private ScanerAndCamer[] scanerAndCamerField;
        
        private SysBlock[] sysBlockField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Monitors")]
        public Monitors[] Monitors {
            get {
                return this.monitorsField;
            }
            set {
                this.monitorsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Mfu")]
        public Mfu[] Mfu {
            get {
                return this.mfuField;
            }
            set {
                this.mfuField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Printer")]
        public Printer[] Printer {
            get {
                return this.printerField;
            }
            set {
                this.printerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScanerAndCamer")]
        public ScanerAndCamer[] ScanerAndCamer {
            get {
                return this.scanerAndCamerField;
            }
            set {
                this.scanerAndCamerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SysBlock")]
        public SysBlock[] SysBlock {
            get {
                return this.sysBlockField;
            }
            set {
                this.sysBlockField = value;
            }
        }
        
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Monitors {
        
        private Kabinet kabinetField;
        
        private NameMonitor nameMonitorField;
        
        private string serNumField;
        
        private string inventarNumMonitorField;
        
        /// <remarks/>
        public Kabinet Kabinet {
            get {
                return this.kabinetField;
            }
            set {
                this.kabinetField = value;
            }
        }
        
        /// <remarks/>
        public NameMonitor NameMonitor {
            get {
                return this.nameMonitorField;
            }
            set {
                this.nameMonitorField = value;
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
        public string InventarNumMonitor {
            get {
                return this.inventarNumMonitorField;
            }
            set {
                this.inventarNumMonitorField = value;
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
    public partial class Kabinet {
        
        private string numberKabinetField;
        
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class NameMonitor {
        
        private string nameField;
        
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Mfu {
        
        private Kabinet kabinetField;
        
        private FullProizvoditel fullProizvoditelField;
        
        private FullModel fullModelField;
        
        private string zavNumberField;
        
        private string serviceNumberField;
        
        /// <remarks/>
        public Kabinet Kabinet {
            get {
                return this.kabinetField;
            }
            set {
                this.kabinetField = value;
            }
        }
        
        /// <remarks/>
        public FullProizvoditel FullProizvoditel {
            get {
                return this.fullProizvoditelField;
            }
            set {
                this.fullProizvoditelField = value;
            }
        }
        
        /// <remarks/>
        public FullModel FullModel {
            get {
                return this.fullModelField;
            }
            set {
                this.fullModelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ZavNumber {
            get {
                return this.zavNumberField;
            }
            set {
                this.zavNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ServiceNumber {
            get {
                return this.serviceNumberField;
            }
            set {
                this.serviceNumberField = value;
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
    public partial class FullProizvoditel {
        
        private string nameProizvoditelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameProizvoditel {
            get {
                return this.nameProizvoditelField;
            }
            set {
                this.nameProizvoditelField = value;
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
    public partial class FullModel {
        
        private string nameModelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameModel {
            get {
                return this.nameModelField;
            }
            set {
                this.nameModelField = value;
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
    public partial class Printer {
        
        private Kabinet kabinetField;
        
        private FullProizvoditel fullProizvoditelField;
        
        private FullModel fullModelField;
        
        private string zavNumberField;
        
        private string serviceNumberField;
        
        /// <remarks/>
        public Kabinet Kabinet {
            get {
                return this.kabinetField;
            }
            set {
                this.kabinetField = value;
            }
        }
        
        /// <remarks/>
        public FullProizvoditel FullProizvoditel {
            get {
                return this.fullProizvoditelField;
            }
            set {
                this.fullProizvoditelField = value;
            }
        }
        
        /// <remarks/>
        public FullModel FullModel {
            get {
                return this.fullModelField;
            }
            set {
                this.fullModelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ZavNumber {
            get {
                return this.zavNumberField;
            }
            set {
                this.zavNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ServiceNumber {
            get {
                return this.serviceNumberField;
            }
            set {
                this.serviceNumberField = value;
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
    public partial class ScanerAndCamer {
        
        private Kabinet kabinetField;
        
        private FullProizvoditel fullProizvoditelField;
        
        private FullModel fullModelField;
        
        private string zavNumberField;
        
        private string serviceNumberField;
        
        private string inventarNumberField;
        
        /// <remarks/>
        public Kabinet Kabinet {
            get {
                return this.kabinetField;
            }
            set {
                this.kabinetField = value;
            }
        }
        
        /// <remarks/>
        public FullProizvoditel FullProizvoditel {
            get {
                return this.fullProizvoditelField;
            }
            set {
                this.fullProizvoditelField = value;
            }
        }
        
        /// <remarks/>
        public FullModel FullModel {
            get {
                return this.fullModelField;
            }
            set {
                this.fullModelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ZavNumber {
            get {
                return this.zavNumberField;
            }
            set {
                this.zavNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ServiceNumber {
            get {
                return this.serviceNumberField;
            }
            set {
                this.serviceNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InventarNumber {
            get {
                return this.inventarNumberField;
            }
            set {
                this.inventarNumberField = value;
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
    public partial class SysBlock {
        
        private Kabinet kabinetField;
        
        private NameSysBlock nameSysBlockField;
        
        private string serviceNumField;
        
        private string serNumField;
        
        private string inventarNumSysBlokField;
        
        private string nameComputerField;
        
        private string ipAdressField;
        
        /// <remarks/>
        public Kabinet Kabinet {
            get {
                return this.kabinetField;
            }
            set {
                this.kabinetField = value;
            }
        }
        
        /// <remarks/>
        public NameSysBlock NameSysBlock {
            get {
                return this.nameSysBlockField;
            }
            set {
                this.nameSysBlockField = value;
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class NameSysBlock {
        
        private string nameComputerField;
        
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Otdel {
        
        private Users[] usersField;
        
        private string nameOtdelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Users")]
        public Users[] Users {
            get {
                return this.usersField;
            }
            set {
                this.usersField = value;
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
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class CopySave {
        
        private string nameCopySaveField;
        
        private string serNumField;
        
        private string inventarNumField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NameCopySave {
            get {
                return this.nameCopySaveField;
            }
            set {
                this.nameCopySaveField = value;
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
        public string InventarNum {
            get {
                return this.inventarNumField;
            }
            set {
                this.inventarNumField = value;
            }
        }
    }
}