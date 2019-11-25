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
using System.Windows.Forms;

namespace jaw
{
    partial class MainWindow
    {
        private void CreditsWho_Click(object sender, EventArgs e)
            => MessageBox.Show("github.com/vmsh0", "Who did this?");

        private void CreditsWhy_Click(object sender, EventArgs e)
            => MessageBox.Show(
                "Please read the explanation given at gitlab.com/vmsh0/jaw.",
                "Is this ok?");

        private void Help1_Click(object sender, EventArgs e)
            => MessageBox.Show(
                "KMS activation requires a Volume License (VL) Key to be installed. This kind of key " +
                "tells Windows to interrogate a private KMS server instead of Microsoft's own " +
                "servers. In later steps, you will install a dummy instance of this server which " +
                "will always approve activation requests, regardless of licensing status.\n" +
                "\n" +
                "Step 1 helps you install the key corresponding to your Windows edition, if you " +
                "don't have it already. Please note that the step could fail for editions of Windows " +
                "released after this program. In this case, the program will prompt you for a VL key, " +
                "which you'll have to look up online (try Reddit or Microsoft's website).",
                "Step 1 - Help");

        private void Help2_Click(object sender, EventArgs e)
            => MessageBox.Show(
                "Windows will refuse to use a local server for KMS activation. This is a mild " +
                "mitigation against dummy KMS servers running on the local machine.\n" +
                "\n" +
                "Step 2 helps you install a TAP network device through which the dummy KMS server " +
                "will communicate with Windows. This will trick Windows into thinking the KMS server " +
                "is running on a different machine. The installation method used by JAW doesn't " +
                "touch any existing Tap devices installed on the system.\n" +
                "\n" +
                "The TAP network driver is part of the OpenVPN project, to which this program is not " +
                "affiliated in any way.",
                "Step 2 - Help");

        private void Help3_Click(object sender, EventArgs e)
            => MessageBox.Show(
                "vlmcsd is an Open Source dummy KMS server which approves all activation requests " +
                "(i.e. it activates Windows even without a valid license). It is an external piece " +
                "of software which I didn't make. You can find its source code at " +
                "github.com/Wind4/vlmcsd.\n" +
                "\n" +
                "Step 3 helps you install the server as a Windows service. It also creates a firewall " +
                "rule to allow it to communicate with Windows, and instructs Windows to do so.",
                "Step 3 - Help");

        private void HelpUninstallRepair_Click(object sender, EventArgs e)
            => MessageBox.Show(
                "You can use these buttons to uninstall the activator and recover from broken " +
                "installs. These may also help you clean up other activator's installs, however you " +
                "should always try to use the activators' uninstall options first.\n" +
                "\n" +
                "The Safe uninstall button will reverse the second and third install steps. This will " +
                "generally not break anything, but of course Windows will deactivate (probably not " +
                "immediately, but eventually it will).\n" +
                "\n" +
                "The Tap uninstall button will remove *all* tap0901 (OpenVPN) Tap devices from the " +
                "system. This step, of course, will break JAW, so you should always do " +
                "a Safe uninstall and re-do the second and third steps after using this button. This " +
                "will also potentially temporarily break VPN software. If this happens, you " +
                "should be able to fix it by reinstalling it. If you notice that installing JAW breaks " +
                "your VPN software, or that installing VPN software breaks JAW, you should try " +
                "uninstalling both and reinstalling them in reversed order. This issue sometimes arises " +
                "when poorly written VPN software uses the first available Tap device on a system, " +
                "instead of installing and managing its own. If that happens and you can't fix it in a " +
                "simple way, I strongly suggest that you switch to different VPN software.\n" +
                "\n" +
                "The Product key removal button will require you to do a backup first. Please note that " +
                "JAW doesn't support restoring arbitrary Product keys at the moment, but there are " +
                "plenty of free tools available online for that.",
                "Uninstall/repair");
    }
}
