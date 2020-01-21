using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INTEGRetroScreenSaver
{
    public partial class Configure : Form
    {
        private UserPreferences settings;

        public Configure()
        {
            InitializeComponent();

            settings = new UserPreferences();
            settings.GetRegistrySettings();

            foreach (Troll troll in settings.trolls)
            {
                listTrolls.Items.Add(troll.Name);
            }

            txtSteps.Text = settings.nSteps.ToString();
            txtMoveInterval.Text = settings.nMoveInterval.ToString();

            gbTrolls.Name = "Trolls (" + settings.nTrolls.ToString() + ")";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INTEG v1.2 21/05/2012 - Written by Luke Walker <luke@blackduck.nu> to emulate the INTEG screensaver written by SDT.  All trademarks of INTEG belong to SDT, not to me ;)");
        }

        private void LoadRegSettings()
        {
            txtMoveInterval.Text = settings.nMoveInterval.ToString();
            txtSteps.Text = settings.nSteps.ToString();
        }

        private void LoadDefaultSettings()
        {
            settings.ClearRegistrySettings();
            settings.SetDefaults();
            settings.SetRegistrySettings();

            LoadRegSettings();
        }

        private void btnSavePreferences_Click(object sender, EventArgs e)
        {
            settings.SetRegistrySettings();
            this.Close();
        }

        private void listTrolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Since we don't have a GetTrollByName function, we'll just do it the hard way for now
            foreach (Troll troll in settings.trolls)
            {
                try
                {
                    if (listTrolls.SelectedItem.ToString() == troll.Name)
                    {
                        txtTrollName.Text = troll.Name;
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private void btnChangeTrollName_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < settings.nTrolls; i++)
            {
                if (settings.trolls[i].Name == listTrolls.SelectedItem.ToString())
                {
                    listTrolls.Items.Remove(settings.trolls[i].Name);
                    listTrolls.Items.Add(txtTrollName.Text);
                    settings.trolls[i].Name = txtTrollName.Text;

                    listTrolls.Refresh();
                    break;
                }
            }
        }

        private void btnNewTroll_Click(object sender, EventArgs e)
        {
            listTrolls.Items.Add("New Troll");
            settings.ResizeTrolls(settings.nTrolls + 1);

            settings.trolls[settings.nTrolls - 1] = new Troll("New Troll",
                -1, -1,
                Troll.MoveDir.Up,
                settings.nSteps,
                System.Drawing.Color.Red,
                System.Drawing.Color.White,
                System.Drawing.Color.Blue);

            gbTrolls.Name = "Trolls (" + settings.nTrolls.ToString() + ")";
        }

        private void btnDeleteTroll_Click(object sender, EventArgs e)
        {
            if (listTrolls.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a troll first");
            }
            else
            {
                for (int i = 0; i < settings.nTrolls; i++)
                {
                    if (settings.trolls[i].Name == listTrolls.SelectedItem.ToString())
                    {
                        settings.RemoveTroll(listTrolls.SelectedItem.ToString());
                        listTrolls.Items.Remove(listTrolls.SelectedItem);
                        txtTrollName.Text = "";
                    }
                }
            }
        }

        private Color pickColour(Color currentColor)
        {
            ColorDialog MyColorDialog = new ColorDialog();
            MyColorDialog.AllowFullOpen = false;
            MyColorDialog.AnyColor = true;
            MyColorDialog.Color = currentColor;

            if (MyColorDialog.ShowDialog() == DialogResult.OK)
            {
                return MyColorDialog.Color;
            } else {
                return currentColor;
            }
        }

        private void btnColour1_Click(object sender, EventArgs e)
        {
            foreach (Troll troll in settings.trolls)
            {
                if (listTrolls.SelectedItem.ToString() == troll.Name)
                {
                    troll.first = pickColour(troll.first);
                }
            }
        }

        private void btnColour2_Click(object sender, EventArgs e)
        {
            foreach (Troll troll in settings.trolls)
            {
                if (listTrolls.SelectedItem.ToString() == troll.Name)
                {
                    troll.second = pickColour(troll.second);
                }
            }
        }

        private void btnColour3_Click(object sender, EventArgs e)
        {
            foreach (Troll troll in settings.trolls)
            {
                if (listTrolls.SelectedItem.ToString() == troll.Name)
                {
                    troll.third = pickColour(troll.third);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Form preview = new ScreenSaverForm(System.Windows.Forms.Screen.PrimaryScreen);
            preview.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDefaultSettings();
        }
    }
}
