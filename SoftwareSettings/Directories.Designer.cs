﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftwareSettings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Directories : global::System.Configuration.ApplicationSettingsBase {
        
        private static Directories defaultInstance = ((Directories)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Directories())));
        
        public static Directories Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SYSTEM_PATH_LOG {
            get {
                return ((string)(this["SYSTEM_PATH_LOG"]));
            }
            set {
                this["SYSTEM_PATH_LOG"] = value;
            }
        }
    }
}
