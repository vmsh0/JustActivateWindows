/*
 * Copyright 2019 Riccardo Paolo Bestetti
 * 
 * This file is part of Just Activate Windows.
 *
 * Just Activate Windows is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 *
 * Just Activate Windows is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
 * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
 * Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Foobar.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jaw
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            // actual actions to activate windows
            BundleSetup.Setup();

            // Designer stuff
            InitializeComponent();
        }

        private void BackupKey_Click(object sender, EventArgs e)
        {
            string productKey = LicensingHelper.GetProductKey();
            if (productKey == null)
            {
                MessageBox.Show(
                    "No Product key is currently installed. No backup is necessary.",
                    "No Product key installed"
                    );
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.RestoreDirectory = true;
            dialog.Title = "Backup current Product key";
            dialog.FileName = "product-key.txt";
            dialog.CheckPathExists = true;
            dialog.OverwritePrompt = true;
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(
                    dialog.FileName, 
                    "Product key backup file created by jaw - " +
                    DateTime.Now.ToString(CultureInfo.CurrentCulture) + Environment.NewLine +
                    productKey + Environment.NewLine,
                    Encoding.UTF8
                    );
            }
        }

        private async void InstallKey_Click(object sender, EventArgs e)
        {
            Enabled = false;

            MessageBox.Show(
                "JAW will now uninstall all product keys and install the correct one. This should " +
                "take a few seconds, but on particularly slow systems it could take a few minutes.",
                "Software Licensing Service"
                );

            string sku = LicensingHelper.GetWindowsSKU();
            string key = SkuToProductKey.Get(sku);

            if (key == null)
            {
                using (InputBox keyInput = new InputBox())
                {
                    keyInput.ShowDialog();
                    if (keyInput.InputValid)
                    {
                        key = keyInput.Input;
                        SkuToProductKey.SetOverrideKey(key);
                    }
                    else
                    {
                        MessageBox.Show(
                            "The Product key you've inserted is not valid.",
                            "Product key invalid."
                            );
                        Enabled = true;
                        return;
                    }
                }
            }

            LicensingHelper.SetProductKey(key);

            await UpdateGui();
            Enabled = true;
        }

        private async void InstallTap_Click(object sender, EventArgs e)
        {
            Enabled = false;

            MessageBox.Show(
                "JAW will now install the Tap device. If this is the first time you install a Tap " +
                "device, you will be prompted by Windows to install a device driver. Of course, you " +
                "must approve the installation in order for the Step to succeed.",
                "Tap device driver");

            if (!NicHelper.InstallAndRenameTap0901Device())
            {
                MessageBox.Show(
                    "Failed to install the Tap device. Please try to manually remove any existing " +
                    "unused Tap devices before retrying.",
                    "Tap device error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Enabled = true;
                return;
            }

            await UpdateGui();
            Enabled = true;
        }

        private async void InstallSrv_Click(object sender, EventArgs e)
        {
            Enabled = false;

            MessageBox.Show(
                "JAW will now start vlmcsd and configure the Software Licensing Service. This should " +
                "take a few seconds, but on particularly slow systems it could take a few minutes.",
                "Software Licensing Service"
                );

            // service
            IPAddress ipa = ServiceHelper.RegisterAndStartVlmcsd();
            if (ipa == null)
            {
                MessageBox.Show(
                    "Failed to start the service.",
                    "Service setup error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Enabled = true;
                return;
            }

            // activate
            if (!LicensingHelper.KmsActivate(ipa))
            {
                MessageBox.Show(
                    "Failed to activate Windows.",
                    "Licensing Service error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Enabled = true;
                return;
            }

            await UpdateGui();
            Enabled = true;
        }

        // update GUI on startup asynchronously
        private async void StateUpdateTimer_Tick(object sender, EventArgs e)
        {
            stateUpdateTimer.Enabled = false;
            await UpdateGui();
        }

        private bool previousStepEnabled;

        // update GUI asynchronously
        private async Task UpdateGui()
        {
            previousStepEnabled = false;

            if (!(await Step1Update() && await Step2Update() && await Step3Update()))
            {
                step1.Enabled = false;
                step2.Enabled = false;
                step3.Enabled = false;
            }
        }

        // gets Windows edition and current product key, updates GUI with available actions
        private async Task<bool> Step1Update()
        {
            // windows edition
            string s = await Task.Run(
                () => {
                    return LicensingHelper.GetWindowsSKU();
                });

            // current product key
            string oldkey = await Task.Run(
                () => {
                    return LicensingHelper.GetProductKey();
                });

            step1output.Text = s;

            // update gui
            if (s != null)
            {
                string key = SkuToProductKey.Get(s);
                if ((key != null && !key.Equals(oldkey)) || key == null)
                {
                    step1action.Text = "Action: backup current key and install VL key.";
                    previousStepEnabled |= step1.Enabled = true;
                }
                else
                {
                    step1action.Text = "No action necessary: VL key is installed.";
                    step1.Enabled = false;
                }
            }

            return true;
        }

        // checks whether the tap device already exists and updates gui
        private async Task<bool> Step2Update()
        {
            // checks whether the tap device already exist
            bool adapterInstalled = await Task.Run(
                () => {
                    return NicHelper.JawDevInstalled();
                });

            // update gui
            if (adapterInstalled)
            {
                step2.Enabled = false;
                step2output.Text = "Tap device installed.";
                step2action.Text = "No action necessary: device is installed.";
            }
            else
            {
                previousStepEnabled |= step2.Enabled = !previousStepEnabled;
                step2output.Text = "Tap device not installed.";
                step2action.Text = "Action: install Tap device.";
            }

            return true;
        }

        private async Task<bool> Step3Update()
        {
            // checks whether the service is already registered
            bool serviceRegistered = await Task.Run(
                () => {
                    return ServiceHelper.VlmcsdRegistered();
                });

            if (serviceRegistered)
            {
                step3.Enabled = false;
                step3output.Text = "Service registered.";
                step3action.Text = "No action necessary: service is registered.";
            }
            else
            {
                step3.Enabled = !previousStepEnabled;
                step3output.Text = "Service not registered.";
                step3action.Text = "Action: register service, add firewall rule and Activate.";
            }

            return true;
        }

        private async void SafeUninstall_Click(object sender, EventArgs e)
        {
            Enabled = false;

            NicHelper.DeleteTap0901JawDev();
            ServiceHelper.DeleteVlmcsd();

            await UpdateGui();
            Enabled = true;
        }

        private async void DeleteTaps_Click(object sender, EventArgs e)
        {
            Enabled = false;

            NicHelper.GetAllTap0901Devices().ForEach(d => d.Remove());

            await UpdateGui();
            Enabled = true;
        }

        private async void DeleteProductKey_Click(object sender, EventArgs e)
        {
            Enabled = false;

            LicensingHelper.ClearProductKeys();

            await UpdateGui();
            Enabled = true;
        }
    }
}
