﻿#pragma checksum "..\..\..\..\gameCrud\EditGameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D24288E422E58B46832F72F49B6C0C35DB6DD6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfAppTestDb.gameCrud;


namespace WpfAppTestDb.gameCrud {
    
    
    /// <summary>
    /// EditGameWindow
    /// </summary>
    public partial class EditGameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxDesc;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtGrdGenre;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSelectedPub;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSelectedDev;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddGenre;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelGenre;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPub;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelPub;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddDev;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelDev;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtGrdPlat;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPlatform;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelPlatform;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\gameCrud\EditGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfAppTestDb;V1.0.0.0;component/gamecrud/editgamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtBoxDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dtGrdGenre = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.tbSelectedPub = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbSelectedDev = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btnAddGenre = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnAddGenre.Click += new System.Windows.RoutedEventHandler(this.btnAddGenre_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDelGenre = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnDelGenre.Click += new System.Windows.RoutedEventHandler(this.btnDelGenre_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAddPub = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnAddPub.Click += new System.Windows.RoutedEventHandler(this.btnAddPub_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDelPub = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnDelPub.Click += new System.Windows.RoutedEventHandler(this.btnDelPub_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAddDev = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnAddDev.Click += new System.Windows.RoutedEventHandler(this.btnAddDev_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnDelDev = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnDelDev.Click += new System.Windows.RoutedEventHandler(this.btnDelDev_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dtGrdPlat = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.btnAddPlatform = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnAddPlatform.Click += new System.Windows.RoutedEventHandler(this.btnAddPlatform_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnDelPlatform = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnDelPlatform.Click += new System.Windows.RoutedEventHandler(this.btnDelPlatform_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnOk.Click += new System.Windows.RoutedEventHandler(this.btnOk_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\gameCrud\EditGameWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

