﻿#pragma checksum "..\..\OptionsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "56CCE76FB5D76F9255DEDCA45C8C8BBE389D8C72DB7C0AEC745E6C1579BCC565"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WDocAuto;


namespace WDocAuto {
    
    
    /// <summary>
    /// OptionsWindow
    /// </summary>
    public partial class OptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 219 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IncludeInNameBox;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IncludeFDateBox;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleSizeBox;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CloseOnCreateBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WDocAuto;component/optionswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OptionsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.IncludeInNameBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 219 "..\..\OptionsWindow.xaml"
            this.IncludeInNameBox.Click += new System.Windows.RoutedEventHandler(this.InNameClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 223 "..\..\OptionsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IncludeFDateBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 229 "..\..\OptionsWindow.xaml"
            this.IncludeFDateBox.Click += new System.Windows.RoutedEventHandler(this.IncludeFDateClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleSizeBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 241 "..\..\OptionsWindow.xaml"
            this.TitleSizeBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TitleSizeTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CloseOnCreateBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 246 "..\..\OptionsWindow.xaml"
            this.CloseOnCreateBox.Click += new System.Windows.RoutedEventHandler(this.CloseOnCreateBoxClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

