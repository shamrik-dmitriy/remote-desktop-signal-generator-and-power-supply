﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    public sealed partial class Software : global::System.Configuration.ApplicationSettingsBase {
        
        private static Software defaultInstance = ((Software)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Software())));
        
        public static Software Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int LOG_LEVEL {
            get {
                return ((int)(this["LOG_LEVEL"]));
            }
            set {
                this["LOG_LEVEL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DEFAULT_SYSTEM_PATH_LOG {
            get {
                return ((string)(this["DEFAULT_SYSTEM_PATH_LOG"]));
            }
            set {
                this["DEFAULT_SYSTEM_PATH_LOG"] = value;
            }
        }
    }
}
