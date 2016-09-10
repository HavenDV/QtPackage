/****************************************************************************
**
** Copyright (C) 2012 Digia Plc and/or its subsidiary(-ies).
** Contact: http://www.qt-project.org/legal
**
** This file is part of the Qt VS Add-in.
**
** $QT_BEGIN_LICENSE:LGPL$
** Commercial License Usage
** Licensees holding valid commercial Qt licenses may use this file in
** accordance with the commercial license agreement provided with the
** Software or, alternatively, in accordance with the terms contained in
** a written agreement between you and Digia.  For licensing terms and
** conditions see http://qt.digia.com/licensing.  For further information
** use the contact form at http://qt.digia.com/contact-us.
**
** GNU Lesser General Public License Usage
** Alternatively, this file may be used under the terms of the GNU Lesser
** General Public License version 2.1 as published by the Free Software
** Foundation and appearing in the file LICENSE.LGPL included in the
** packaging of this file.  Please review the following information to
** ensure the GNU Lesser General Public License version 2.1 requirements
** will be met: http://www.gnu.org/licenses/old-licenses/lgpl-2.1.html.
**
** In addition, as a special exception, Digia gives you certain additional
** rights.  These rights are described in the Digia Qt LGPL Exception
** version 1.1, included in the file LGPL_EXCEPTION.txt in this package.
**
** GNU General Public License Usage
** Alternatively, this file may be used under the terms of the GNU
** General Public License version 3.0 as published by the Free Software
** Foundation and appearing in the file LICENSE.GPL included in the
** packaging of this file.  Please review the following information to
** ensure the GNU General Public License version 3.0 requirements will be
** met: http://www.gnu.org/copyleft/gpl.html.
**
**
** $QT_END_LICENSE$
**
****************************************************************************/

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using EnvDTE;


using Digia.Qt5ProjectLib;
using Microsoft.VisualStudio.VCProjectEngine;

namespace QtPackage
{
    public partial class FormProjectQtSettings : Form
    {
        private Project project;
        private QtProject qtProject;
        private ProjectQtSettings qtSettings = null;

        private struct ModuleMapItem
        {
            public CheckBox checkbox;
            public QtModule moduleId;
            public bool initialValue;

            public ModuleMapItem(CheckBox cb, QtModule mid)
            {
                checkbox = cb;
                moduleId = mid;
                initialValue = false;
            }
        }

        private List<ModuleMapItem> moduleMap = new List<ModuleMapItem>();

        public FormProjectQtSettings()
        {
            InitializeComponent();
            okButton.Text = SR.GetString("OK");
            cancelButton.Text = SR.GetString("Cancel");
            tabControl1.TabPages[0].Text = this.Text = SR.GetString("ActionDialog_Properties");
            tabControl1.TabPages[1].Text = this.Text = SR.GetString("QtModules");
            this.activeQtCLib.Text = SR.GetString("ActiveQtContainerLibrary");
            this.activeQtSLib.Text = SR.GetString("ActiveQtServerLibrary");
            this.testLib.Text = SR.GetString("TestLibrary");
            this.svgLib.Text = SR.GetString("SVGLibrary");
            this.xmlLib.Text = SR.GetString("XMLLibrary");
            this.networkLib.Text = SR.GetString("NetworkLibrary");
            this.openGLLib.Text = SR.GetString("OpenGLLibrary");
            this.sqlLib.Text = SR.GetString("SQLLibrary");
            this.guiLib.Text = SR.GetString("GUILibrary");
            this.multimediaLib.Text = SR.GetString("MultimediaLibrary");
            this.coreLib.Text = SR.GetString("CoreLibrary");
            this.Text = SR.GetString("ProjectQtSettingsButtonText");
            this.scriptLib.Text = SR.GetString("ScriptLibrary");
            this.helpLib.Text = SR.GetString("HelpLibrary");
            this.webKitLib.Text = SR.GetString("WebKitLibrary");
            this.xmlPatternsLib.Text = SR.GetString("XmlPatternsLibrary");
            this.scriptToolsLib.Text = SR.GetString("ScriptToolsLibrary");
            this.uiToolsLib.Text = SR.GetString("UiToolsLibrary");

            threeDLib.Text = SR.GetString("3DLibrary");
            locationLib.Text = SR.GetString("LocationLibrary");
            qmlLib.Text = SR.GetString("QmlLibrary");
            quickLib.Text = SR.GetString("QuickLibrary");
            bluetoothLib.Text = SR.GetString("BluetoothLibrary");
            printSupportLib.Text = SR.GetString("PrintSupportLibrary");
            declarativeLib.Text = SR.GetString("DeclarativeLibrary");
            sensorsLib.Text = SR.GetString("SensorsLibrary");
            webkitWidgetsLib.Text = SR.GetString("WebkitWidgetsLibrary");
            widgetsLib.Text = SR.GetString("WidgetsLibrary");

            concurrentLib.Text = SR.GetString("ConcurrentLibrary");
            multimediaWidgetsLib.Text = SR.GetString("MultimediaWidgetsLibrary");

            enginioLib.Text = SR.GetString("EnginioLibrary");
            nfcLib.Text = SR.GetString("NfcLibrary");
            positioningLib.Text = SR.GetString("PositioningLibrary");
            serialPortLib.Text = SR.GetString("SerialPortLibrary");
            webChannelLib.Text = SR.GetString("WebChannelLibrary");
            webSocketsLib.Text = SR.GetString("WebSocketsLibrary");
            windowsExtrasLib.Text = SR.GetString("WindowsExtrasLibrary");
            quickWidgetsLib.Text = SR.GetString("QuickWidgetsLibrary");

            //Qt5.6+
            core3DLib.Text = "3DCore";//SR.GetString("3DCoreLibrary");
            extras3DLib.Text = "3DExtras";//SR.GetString("3DExtrasLibrary");
            input3DLib.Text = "3DInput";//SR.GetString("3DInputLibrary");
            logic3DLib.Text = "3DLogic";//SR.GetString("3DLogicLibrary");
            quick3DLib.Text = "3DQuick";//SR.GetString("3DQuickLibrary");
            quickWidgetsLib.Text = "3DQuickWidgets";//SR.GetString("3DQuickWidgetsLibrary");
            quickExtras3DLib.Text = "3DQuickExtras";//SR.GetString("3DQuickExtrasLibrary");
            quickInput3DLib.Text = "3DQuickInput";//SR.GetString("3DQuickInputLibrary");
            quickRender3DLib.Text = "3DQuickRender";//SR.GetString("3DQuickRenderLibrary");
            render3DLib.Text = "3DRender";//SR.GetString("3DRenderLibrary");
            bootstrapLib.Text = "Bootstrap";//SR.GetString("BootstrapLibrary");
            chartsLib.Text = "Charts";//SR.GetString("ChartsLibrary");
            dataVisualizationLib.Text = "DataVisualization";//SR.GetString("DataVisualizationLibrary");
            dBusLib.Text = "DBus";//SR.GetString("DBusLibrary");
            packetProtocolLib.Text = "PacketProtocol";//SR.GetString("PacketProtocolLibrary");
            platformSupportLib.Text = "PlatformSupport";//SR.GetString("PlatformSupportLibrary");
            purchasingLib.Text = "Purchasing";//SR.GetString("PurchasingLibrary");
            quickTestLib.Text = "QuickTest";//SR.GetString("QuickTestLibrary");
            quickControls2Lib.Text = "QuickControls2";//SR.GetString("QuickControls2Library");
            quickParticlesLib.Text = "QuickParticles";//SR.GetString("QuickParticlesLibrary");
            quickTemplatesLib.Text = "QuickTemplates";//SR.GetString("QuickTemplatesLibrary");
            scxmlLib.Text = "Scxml";//SR.GetString("ScxmlLibrary");
            serialBusLib.Text = "SerialBus";//SR.GetString("SerialBusLibrary");
            webEngineLib.Text = "WebEngine";//SR.GetString("WebEngineLibrary");
            webEngineCoreLib.Text = "WebEngineCore";//SR.GetString("WebEngineCoreLibrary");
            webEngineWidgetsLib.Text = "WebEngineWidgets";//SR.GetString("WebEngineWidgetsLibrary");
            webViewLib.Text = "WebView";//SR.GetString("WebViewLibrary");

            // essentials
            AddMapping(threeDLib, QtModule.ThreeD);
            AddMapping(coreLib, QtModule.Core);
            AddMapping(guiLib, QtModule.Gui);
            AddMapping(locationLib, QtModule.Location);
            AddMapping(multimediaLib, QtModule.Multimedia);
            AddMapping(networkLib, QtModule.Network);
            AddMapping(qmlLib, QtModule.Qml);
            AddMapping(quickLib, QtModule.Quick);
            AddMapping(sqlLib, QtModule.Sql);
            AddMapping(testLib, QtModule.Test);
            AddMapping(webKitLib, QtModule.WebKit);

            // add-ons
            AddMapping(activeQtCLib, QtModule.ActiveQtC);
            AddMapping(activeQtSLib, QtModule.ActiveQtS);
            AddMapping(bluetoothLib, QtModule.Bluetooth);
            AddMapping(helpLib, QtModule.Help);
            AddMapping(openGLLib, QtModule.OpenGL);
            AddMapping(scriptToolsLib, QtModule.ScriptTools);
            AddMapping(uiToolsLib, QtModule.UiTools);
            AddMapping(printSupportLib, QtModule.PrintSupport);
            AddMapping(declarativeLib, QtModule.Declarative);
            AddMapping(scriptLib, QtModule.Script);
            AddMapping(sensorsLib, QtModule.Sensors);
            AddMapping(svgLib, QtModule.Svg);
            AddMapping(webkitWidgetsLib, QtModule.WebkitWidgets);
            AddMapping(widgetsLib, QtModule.Widgets);
            AddMapping(xmlLib, QtModule.Xml);
            AddMapping(xmlPatternsLib, QtModule.XmlPatterns);

            AddMapping(concurrentLib, QtModule.Concurrent);
            AddMapping(multimediaWidgetsLib, QtModule.MultimediaWidgets);

            AddMapping(enginioLib, QtModule.Enginio);
            AddMapping(nfcLib, QtModule.Nfc);
            AddMapping(positioningLib, QtModule.Positioning);
            AddMapping(serialPortLib, QtModule.SerialPort);
            AddMapping(webChannelLib, QtModule.WebChannel);
            AddMapping(webSocketsLib, QtModule.WebSockets);
            AddMapping(windowsExtrasLib, QtModule.WindowsExtras);
            AddMapping(quickWidgetsLib, QtModule.QuickWidgets);
            
            //Qt5.6+
            AddMapping(core3DLib, QtModule.Core3D);
            AddMapping(extras3DLib, QtModule.Extras3D);
            AddMapping(input3DLib, QtModule.Input3D);
            AddMapping(logic3DLib, QtModule.Logic3D);
            AddMapping(quick3DLib, QtModule.Quick3D);
            AddMapping(quickExtras3DLib, QtModule.QuickExtras3D);
            AddMapping(quickInput3DLib, QtModule.QuickInput3D);
            AddMapping(quickRender3DLib, QtModule.QuickRender3D);
            AddMapping(render3DLib, QtModule.Render3D);
            AddMapping(bootstrapLib, QtModule.Bootstrap);
            AddMapping(chartsLib, QtModule.Charts);
            AddMapping(dataVisualizationLib, QtModule.DataVisualization);
            AddMapping(dBusLib, QtModule.DBus);
            AddMapping(packetProtocolLib, QtModule.PacketProtocol);
            AddMapping(platformSupportLib, QtModule.PlatformSupport);
            AddMapping(purchasingLib, QtModule.Purchasing);
            AddMapping(quickTestLib, QtModule.QuickTest);
            AddMapping(quickControls2Lib, QtModule.QuickControls2);
            AddMapping(quickParticlesLib, QtModule.QuickParticles);
            AddMapping(quickTemplatesLib, QtModule.QuickTemplates);
            AddMapping(scxmlLib, QtModule.Scxml);
            AddMapping(serialBusLib, QtModule.SerialBus);
            AddMapping(webEngineLib, QtModule.WebEngine);
            AddMapping(webEngineCoreLib, QtModule.WebEngineCore);
            AddMapping(webEngineWidgetsLib, QtModule.WebEngineWidgets);
            AddMapping(webViewLib, QtModule.WebView);
            
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyPress += new KeyPressEventHandler(this.FormProjectQtSettings_KeyPress);
        }

        private void AddMapping(CheckBox checkbox, QtModule moduleId)
        {
            moduleMap.Add(new ModuleMapItem(checkbox, moduleId));
        }

        public void SetProject(Project pro)
        {
            project = pro;
            qtProject = QtProject.Create(project);
            InitModules();
            qtSettings = new ProjectQtSettings(project);
            OptionsPropertyGrid.SelectedObject = qtSettings;
        }

        private void FormProjectQtSettings_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            qtSettings.SaveSettings();
            saveModules();
            this.okButton.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static string NormalizePath(string path)
        {
            return System.IO.Path.GetFullPath(path)
                       .TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar)
                       .ToLowerInvariant();
        }

        public static bool comparePath(string path1, string path2)
        {
            return NormalizePath(path1) == NormalizePath(path2);
        }

        public static string libraryPathToName(string path)
        {
            return System.IO.Path.GetFileNameWithoutExtension(path).Replace("Qt5", "");
        }

        private void InitModules()
        {
            var versionManager = QtVersionManager.The();
            var qtVersion = qtProject.GetQtVersion();
            var installPath = versionManager.GetInstallPath(qtVersion);

            var modulesList = getQtLibs(qtProject.GetQtVersion());
            //var projectModules = new List<string>();
            for (int i = 0; i < moduleMap.Count; ++i)
            {
                var item = moduleMap[i];
                item.initialValue = qtProject.HasModule(item.moduleId);
                item.checkbox.Checked = item.initialValue;
                moduleMap[i] = item;

                // Disable if module not installed
                var info = QtModules.Instance.ModuleInformation(item.moduleId);
                var libraryPrefix = info.LibraryPrefix;
                if (libraryPrefix.StartsWith("Qt"))
                {
                    libraryPrefix = "Qt5" + libraryPrefix.Substring(2);
                }
                var fullPath = installPath + "\\lib\\" + libraryPrefix + ".lib";
                var isExists = System.IO.File.Exists(fullPath);
                item.checkbox.Enabled = isExists;
                //foreach (var module in modulesList)
                //{
                //    if (comparePath(fullPath, module) && item.initialValue && isExists)
                //    {
                //        projectModules.Add(module);
                //    }
                //}
                // Don't disable item if qtVersion not available
                if ( !isExists && qtVersion != null )
                {
                    item.checkbox.Checked = false;
                }
            }

            var projectLibs = getUsedLibs(qtProject.Project);
            modulesListBox.Items.Clear();
            foreach (var item in modulesList)
            {
                var libName = System.IO.Path.GetFileName(item);
                modulesListBox.Items.Add(libraryPathToName(item), projectLibs.Contains(libName));
            }
        }

        private List<string> getQtLibs(string qtVersion)
        {
            if (qtVersion == null)
            {
                throw new ArgumentNullException("qtVersion");
            }

            List<string> modulesNames = new List<string>();
            try
            {
                var versionManager = QtVersionManager.The();
                var installPath = versionManager.GetInstallPath(qtVersion);
                var libPath = installPath + @"\lib\";
                var libs = System.IO.Directory.GetFiles(libPath, "*.lib");//*Qt5
                var listLibs = new List<string>(libs);
                foreach ( var item in libs)
                {
                    //Exclude Debug version libs
                    if (item.Contains( "d.lib" ) && 
                        listLibs.Contains( item.Replace("d.lib",".lib") ) )
                    {
                        continue;
                    }

                    modulesNames.Add(item);
                }
            }
            catch ( Exception exception )
            {
                MessageBox.Show("Init Modules Exception: " + exception.Message);
            }
            return modulesNames;
        }

        private List<string> getUsedLibs(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("project");
            }

            List<string> libs = new List<string>();

            VCProject vcPro = project.Object as VCProject;
            foreach (VCConfiguration config in (IVCCollection)vcPro.Configurations)
            {
                var compiler = CompilerToolWrapper.Create(config);
                var linker = ((IVCCollection)config.Tools).Item("VCLinkerTool") as VCLinkerTool;
                
                if (linker != null)
                {
                    var linkerWrapper = new LinkerToolWrapper(linker);
                    var additionalDeps = linkerWrapper.AdditionalDependencies;
                    libs.AddRange(additionalDeps);
                }
            }

            return libs;
        }

        private void saveModules()
        {
            qtProject = QtProject.Create(project);
            for (int i = 0; i < moduleMap.Count; ++i)
            {
                var item = moduleMap[i];
                bool isModuleChecked = item.checkbox.Checked;
                if (isModuleChecked != item.initialValue)
                {
                    if (isModuleChecked)
                        qtProject.AddModule(item.moduleId);
                    else
                        qtProject.RemoveModule(item.moduleId);
                }
            }
        }

    }
}
