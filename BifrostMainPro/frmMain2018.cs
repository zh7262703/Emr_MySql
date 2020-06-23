using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using System.Globalization;

namespace BifrostMainPro
{
    public partial class frmMain2018 : DevComponents.DotNetBar.RibbonForm
    {
        public frmMain2018()
        {
            InitializeComponent();
        }

        private void frmMain2018_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\DevComponents\Ribbon");
            if (key != null)
            {
                try
                {
                    string layout = key.GetValue("RibbonPadCSLayout", "").ToString();
                    if (layout != "" && layout != null)
                        ribbonControl1.QatLayout = layout;
                }
                finally
                {
                    key.Close();
                }
            }

            ArrayList items = ribbonControl1.RibbonStrip.GetItems("", typeof(SystemCaptionItem));
            SystemCaptionItem sysFormButtons = (SystemCaptionItem)items[items.Count - 1];
            BaseItem parentCont = sysFormButtons.Parent;
            ButtonItem buttonNotify = new ButtonItem("buttonNotify");
            buttonNotify.Symbol = "\uf0f3";
            buttonNotify.ItemAlignment = eItemAlignment.Far;
            buttonNotify.SymbolSize = 12f;         
            parentCont.SubItems.Insert(parentCont.SubItems.IndexOf(sysFormButtons), buttonNotify);
        }

        #region Automatic Color Scheme creation based on the selected color table
        private bool m_ColorSelected = false;
        private eStyle m_BaseStyle = eStyle.Office2010Silver;
        private void buttonStyleCustom_ExpandChange(object sender, System.EventArgs e)
        {
           if (buttonStyleCustom.Expanded)
            {
                // Remember the starting color scheme to apply if no color is selected during live-preview
                m_ColorSelected = false;
                m_BaseStyle = StyleManager.Style;
            }
            else
            {
                if (!m_ColorSelected)
                {
                    if (StyleManager.IsMetro(StyleManager.Style))
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.Default;
                    else
                        StyleManager.ChangeStyle(m_BaseStyle, Color.Empty);
                 }
            }
        }

        private void buttonStyleCustom_ColorPreview(object sender, DevComponents.DotNetBar.ColorPreviewEventArgs e)
        {
            if (StyleManager.IsMetro(StyleManager.Style))
            {
                Color baseColor = e.Color;
                StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, baseColor);
            }
            else
                StyleManager.ColorTint = e.Color;
        }

        private void buttonStyleCustom_SelectedColorChanged(object sender, System.EventArgs e)
        {
            m_ColorSelected = true; // Indicate that color was selected for buttonStyleCustom_ExpandChange method
            buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor;
        }


        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                // Using StyleManager change the style and color tinting
                if (StyleManager.IsMetro(style))
                {
                    // More customization is needed for Metro
                    // Capitalize App Button and tab
                    buttonFile.Text = buttonFile.Text.ToUpper();
                    foreach (BaseItem item in RibbonControl.Items)
                    {
                        // Ribbon Control may contain items other than tabs so that needs to be taken in account
                        RibbonTabItem tab = item as RibbonTabItem;
                        if (tab != null)
                            tab.Text = tab.Text.ToUpper();
                    }

                    buttonFile.BackstageTabEnabled = true; // Use Backstage for Metro

                    ribbonControl1.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (style == eStyle.Metro)
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;

                    // Adjust size of switch button to match Metro styling
                    switchButtonItem1.SwitchWidth = 16;
                    switchButtonItem1.ButtonWidth = 48;
                    switchButtonItem1.ButtonHeight = 19;

                    // Adjust tab strip style
                    tabStrip1.Style = eTabStripStyle.Metro;

                    StyleManager.Style = style; // BOOM
                }
                else
                {
                    // If previous style was Metro we need to update other properties as well
                    if (StyleManager.IsMetro(StyleManager.Style))
                    {
                        ribbonControl1.RibbonStripFont = null;
                        // Fix capitalization App Button and tab
                        //buttonFile.Text = ToTitleCase(buttonFile.Text);
                        foreach (BaseItem item in RibbonControl.Items)
                        {
                            // Ribbon Control may contain items other than tabs so that needs to be taken in account
                            RibbonTabItem tab = item as RibbonTabItem;
                            //if (tab != null)
                            //    tab.Text = ToTitleCase(tab.Text);
                        }
                        // Adjust size of switch button to match Office styling
                        switchButtonItem1.SwitchWidth = 28;
                        switchButtonItem1.ButtonWidth = 62;
                        switchButtonItem1.ButtonHeight = 20;
                    }
                    // Adjust tab strip style
                    tabStrip1.Style = eTabStripStyle.Office2007Document;
                    StyleManager.ChangeStyle(style, Color.Empty);
                    if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                        buttonFile.BackstageTabEnabled = false;
                    else
                        buttonFile.BackstageTabEnabled = true;
                }
            }
            else if (source.CommandParameter is Color)
            {
                if (StyleManager.IsMetro(StyleManager.Style))
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                else
                    StyleManager.ColorTint = (Color)source.CommandParameter;
            }
        }

        private void RibbonStateCommand_Executed(object sender, EventArgs e)
        {
            ribbonControl1.Expanded = RibbonStateCommand.Checked;
            RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }
        #endregion
    }
}
