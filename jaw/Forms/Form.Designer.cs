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

namespace jaw
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.step1 = new System.Windows.Forms.GroupBox();
            this.installKey = new System.Windows.Forms.Button();
            this.backupKey = new System.Windows.Forms.Button();
            this.step1action = new System.Windows.Forms.Label();
            this.step1output = new System.Windows.Forms.Label();
            this.step1info = new System.Windows.Forms.Label();
            this.help1 = new System.Windows.Forms.Button();
            this.step2 = new System.Windows.Forms.GroupBox();
            this.installTap = new System.Windows.Forms.Button();
            this.step2action = new System.Windows.Forms.Label();
            this.step2output = new System.Windows.Forms.Label();
            this.step2info = new System.Windows.Forms.Label();
            this.help2 = new System.Windows.Forms.Button();
            this.step3 = new System.Windows.Forms.GroupBox();
            this.installSrv = new System.Windows.Forms.Button();
            this.step3action = new System.Windows.Forms.Label();
            this.step3output = new System.Windows.Forms.Label();
            this.step3info = new System.Windows.Forms.Label();
            this.help3 = new System.Windows.Forms.Button();
            this.creditsWho = new System.Windows.Forms.Button();
            this.creditsWhy = new System.Windows.Forms.Button();
            this.stateUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.stepUninstallRepair = new System.Windows.Forms.GroupBox();
            this.deleteProductKey = new System.Windows.Forms.Button();
            this.deleteTaps = new System.Windows.Forms.Button();
            this.safeUninstall = new System.Windows.Forms.Button();
            this.labelUninstallRepair = new System.Windows.Forms.Label();
            this.helpUninstallRepair = new System.Windows.Forms.Button();
            this.step1.SuspendLayout();
            this.step2.SuspendLayout();
            this.step3.SuspendLayout();
            this.stepUninstallRepair.SuspendLayout();
            this.SuspendLayout();
            // 
            // step1
            // 
            this.step1.Controls.Add(this.installKey);
            this.step1.Controls.Add(this.backupKey);
            this.step1.Controls.Add(this.step1action);
            this.step1.Controls.Add(this.step1output);
            this.step1.Controls.Add(this.step1info);
            this.step1.Enabled = false;
            this.step1.Location = new System.Drawing.Point(12, 12);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(475, 150);
            this.step1.TabIndex = 0;
            this.step1.TabStop = false;
            this.step1.Text = "Step 1 - Product key";
            // 
            // installKey
            // 
            this.installKey.Location = new System.Drawing.Point(236, 97);
            this.installKey.Name = "installKey";
            this.installKey.Size = new System.Drawing.Size(233, 47);
            this.installKey.TabIndex = 4;
            this.installKey.Text = "Install VL key";
            this.installKey.UseVisualStyleBackColor = true;
            this.installKey.Click += new System.EventHandler(this.InstallKey_Click);
            // 
            // backupKey
            // 
            this.backupKey.Location = new System.Drawing.Point(10, 97);
            this.backupKey.Name = "backupKey";
            this.backupKey.Size = new System.Drawing.Size(220, 47);
            this.backupKey.TabIndex = 3;
            this.backupKey.Text = "Backup current key";
            this.backupKey.UseVisualStyleBackColor = true;
            this.backupKey.Click += new System.EventHandler(this.BackupKey_Click);
            // 
            // step1action
            // 
            this.step1action.AutoSize = true;
            this.step1action.Location = new System.Drawing.Point(10, 76);
            this.step1action.Name = "step1action";
            this.step1action.Size = new System.Drawing.Size(123, 17);
            this.step1action.TabIndex = 3;
            this.step1action.Text = "Action: (detecting)";
            // 
            // step1output
            // 
            this.step1output.AutoSize = true;
            this.step1output.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step1output.Location = new System.Drawing.Point(32, 43);
            this.step1output.Name = "step1output";
            this.step1output.Size = new System.Drawing.Size(115, 17);
            this.step1output.TabIndex = 2;
            this.step1output.Text = "... detecting ...";
            // 
            // step1info
            // 
            this.step1info.AutoSize = true;
            this.step1info.Location = new System.Drawing.Point(7, 22);
            this.step1info.Name = "step1info";
            this.step1info.Size = new System.Drawing.Size(114, 17);
            this.step1info.TabIndex = 1;
            this.step1info.Text = "You are running:";
            // 
            // help1
            // 
            this.help1.Location = new System.Drawing.Point(460, 12);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(23, 23);
            this.help1.TabIndex = 2;
            this.help1.Text = "?";
            this.help1.UseVisualStyleBackColor = true;
            this.help1.Click += new System.EventHandler(this.Help1_Click);
            // 
            // step2
            // 
            this.step2.Controls.Add(this.installTap);
            this.step2.Controls.Add(this.step2action);
            this.step2.Controls.Add(this.step2output);
            this.step2.Controls.Add(this.step2info);
            this.step2.Enabled = false;
            this.step2.Location = new System.Drawing.Point(12, 171);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(475, 150);
            this.step2.TabIndex = 6;
            this.step2.TabStop = false;
            this.step2.Text = "Step 2 - Tap device";
            // 
            // installTap
            // 
            this.installTap.Location = new System.Drawing.Point(10, 97);
            this.installTap.Name = "installTap";
            this.installTap.Size = new System.Drawing.Size(459, 47);
            this.installTap.TabIndex = 5;
            this.installTap.Text = "Install Tap device";
            this.installTap.UseVisualStyleBackColor = true;
            this.installTap.Click += new System.EventHandler(this.InstallTap_Click);
            // 
            // step2action
            // 
            this.step2action.AutoSize = true;
            this.step2action.Location = new System.Drawing.Point(10, 76);
            this.step2action.Name = "step2action";
            this.step2action.Size = new System.Drawing.Size(123, 17);
            this.step2action.TabIndex = 3;
            this.step2action.Text = "Action: (detecting)";
            // 
            // step2output
            // 
            this.step2output.AutoSize = true;
            this.step2output.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step2output.Location = new System.Drawing.Point(32, 43);
            this.step2output.Name = "step2output";
            this.step2output.Size = new System.Drawing.Size(115, 17);
            this.step2output.TabIndex = 2;
            this.step2output.Text = "... detecting ...";
            // 
            // step2info
            // 
            this.step2info.AutoSize = true;
            this.step2info.Location = new System.Drawing.Point(7, 22);
            this.step2info.Name = "step2info";
            this.step2info.Size = new System.Drawing.Size(195, 17);
            this.step2info.TabIndex = 1;
            this.step2info.Text = "Tap device installation status:";
            // 
            // help2
            // 
            this.help2.Location = new System.Drawing.Point(460, 171);
            this.help2.Name = "help2";
            this.help2.Size = new System.Drawing.Size(23, 23);
            this.help2.TabIndex = 0;
            this.help2.Text = "?";
            this.help2.UseVisualStyleBackColor = true;
            this.help2.Click += new System.EventHandler(this.Help2_Click);
            // 
            // step3
            // 
            this.step3.Controls.Add(this.installSrv);
            this.step3.Controls.Add(this.step3action);
            this.step3.Controls.Add(this.step3output);
            this.step3.Controls.Add(this.step3info);
            this.step3.Enabled = false;
            this.step3.Location = new System.Drawing.Point(12, 330);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(475, 150);
            this.step3.TabIndex = 7;
            this.step3.TabStop = false;
            this.step3.Text = "Step 3 - KMS emulator";
            // 
            // installSrv
            // 
            this.installSrv.Location = new System.Drawing.Point(10, 97);
            this.installSrv.Name = "installSrv";
            this.installSrv.Size = new System.Drawing.Size(459, 47);
            this.installSrv.TabIndex = 7;
            this.installSrv.Text = "Register service, add firewall rule and Activate";
            this.installSrv.UseVisualStyleBackColor = true;
            this.installSrv.Click += new System.EventHandler(this.InstallSrv_Click);
            // 
            // step3action
            // 
            this.step3action.AutoSize = true;
            this.step3action.Location = new System.Drawing.Point(10, 76);
            this.step3action.Name = "step3action";
            this.step3action.Size = new System.Drawing.Size(123, 17);
            this.step3action.TabIndex = 3;
            this.step3action.Text = "Action: (detecting)";
            // 
            // step3output
            // 
            this.step3output.AutoSize = true;
            this.step3output.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.step3output.Location = new System.Drawing.Point(32, 43);
            this.step3output.Name = "step3output";
            this.step3output.Size = new System.Drawing.Size(115, 17);
            this.step3output.TabIndex = 2;
            this.step3output.Text = "... detecting ...";
            // 
            // step3info
            // 
            this.step3info.AutoSize = true;
            this.step3info.Location = new System.Drawing.Point(7, 22);
            this.step3info.Name = "step3info";
            this.step3info.Size = new System.Drawing.Size(101, 17);
            this.step3info.TabIndex = 1;
            this.step3info.Text = "Service status:";
            // 
            // help3
            // 
            this.help3.Location = new System.Drawing.Point(460, 330);
            this.help3.Name = "help3";
            this.help3.Size = new System.Drawing.Size(23, 23);
            this.help3.TabIndex = 6;
            this.help3.Text = "?";
            this.help3.UseVisualStyleBackColor = true;
            this.help3.Click += new System.EventHandler(this.Help3_Click);
            // 
            // creditsWho
            // 
            this.creditsWho.Location = new System.Drawing.Point(13, 492);
            this.creditsWho.Name = "creditsWho";
            this.creditsWho.Size = new System.Drawing.Size(229, 39);
            this.creditsWho.TabIndex = 0;
            this.creditsWho.Text = "Who did this?";
            this.creditsWho.UseVisualStyleBackColor = true;
            this.creditsWho.Click += new System.EventHandler(this.CreditsWho_Click);
            // 
            // creditsWhy
            // 
            this.creditsWhy.Location = new System.Drawing.Point(248, 492);
            this.creditsWhy.Name = "creditsWhy";
            this.creditsWhy.Size = new System.Drawing.Size(239, 39);
            this.creditsWhy.TabIndex = 1;
            this.creditsWhy.Text = "Is this okay?";
            this.creditsWhy.UseVisualStyleBackColor = true;
            this.creditsWhy.Click += new System.EventHandler(this.CreditsWhy_Click);
            // 
            // stateUpdateTimer
            // 
            this.stateUpdateTimer.Enabled = true;
            this.stateUpdateTimer.Interval = 1500;
            this.stateUpdateTimer.Tick += new System.EventHandler(this.StateUpdateTimer_Tick);
            // 
            // stepUninstallRepair
            // 
            this.stepUninstallRepair.Controls.Add(this.deleteProductKey);
            this.stepUninstallRepair.Controls.Add(this.deleteTaps);
            this.stepUninstallRepair.Controls.Add(this.safeUninstall);
            this.stepUninstallRepair.Controls.Add(this.labelUninstallRepair);
            this.stepUninstallRepair.Location = new System.Drawing.Point(12, 551);
            this.stepUninstallRepair.Name = "stepUninstallRepair";
            this.stepUninstallRepair.Size = new System.Drawing.Size(475, 150);
            this.stepUninstallRepair.TabIndex = 8;
            this.stepUninstallRepair.TabStop = false;
            this.stepUninstallRepair.Text = "Uninstall/repair";
            // 
            // deleteProductKey
            // 
            this.deleteProductKey.Location = new System.Drawing.Point(236, 95);
            this.deleteProductKey.Name = "deleteProductKey";
            this.deleteProductKey.Size = new System.Drawing.Size(233, 47);
            this.deleteProductKey.TabIndex = 10;
            this.deleteProductKey.Text = "Advanced: remove the currently installed Product key(s)";
            this.deleteProductKey.UseVisualStyleBackColor = true;
            this.deleteProductKey.Click += new System.EventHandler(this.DeleteProductKey_Click);
            // 
            // deleteTaps
            // 
            this.deleteTaps.Location = new System.Drawing.Point(10, 95);
            this.deleteTaps.Name = "deleteTaps";
            this.deleteTaps.Size = new System.Drawing.Size(220, 47);
            this.deleteTaps.TabIndex = 9;
            this.deleteTaps.Text = "Advanced: delete *all* Tap devices on the system";
            this.deleteTaps.UseVisualStyleBackColor = true;
            this.deleteTaps.Click += new System.EventHandler(this.DeleteTaps_Click);
            // 
            // safeUninstall
            // 
            this.safeUninstall.Location = new System.Drawing.Point(10, 42);
            this.safeUninstall.Name = "safeUninstall";
            this.safeUninstall.Size = new System.Drawing.Size(459, 47);
            this.safeUninstall.TabIndex = 7;
            this.safeUninstall.Text = "Safe uninstall (note: doesn\'t remove Product key)";
            this.safeUninstall.UseVisualStyleBackColor = true;
            this.safeUninstall.Click += new System.EventHandler(this.SafeUninstall_Click);
            // 
            // labelUninstallRepair
            // 
            this.labelUninstallRepair.AutoSize = true;
            this.labelUninstallRepair.Location = new System.Drawing.Point(7, 22);
            this.labelUninstallRepair.Name = "labelUninstallRepair";
            this.labelUninstallRepair.Size = new System.Drawing.Size(369, 17);
            this.labelUninstallRepair.TabIndex = 1;
            this.labelUninstallRepair.Text = "Use the advanced options carefully; they may break stuff!";
            // 
            // helpUninstallRepair
            // 
            this.helpUninstallRepair.Location = new System.Drawing.Point(460, 551);
            this.helpUninstallRepair.Name = "helpUninstallRepair";
            this.helpUninstallRepair.Size = new System.Drawing.Size(23, 23);
            this.helpUninstallRepair.TabIndex = 9;
            this.helpUninstallRepair.Text = "?";
            this.helpUninstallRepair.UseVisualStyleBackColor = true;
            this.helpUninstallRepair.Click += new System.EventHandler(this.HelpUninstallRepair_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 713);
            this.Controls.Add(this.helpUninstallRepair);
            this.Controls.Add(this.stepUninstallRepair);
            this.Controls.Add(this.creditsWhy);
            this.Controls.Add(this.creditsWho);
            this.Controls.Add(this.help3);
            this.Controls.Add(this.step3);
            this.Controls.Add(this.help2);
            this.Controls.Add(this.step2);
            this.Controls.Add(this.help1);
            this.Controls.Add(this.step1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Just Activate Windows!";
            this.step1.ResumeLayout(false);
            this.step1.PerformLayout();
            this.step2.ResumeLayout(false);
            this.step2.PerformLayout();
            this.step3.ResumeLayout(false);
            this.step3.PerformLayout();
            this.stepUninstallRepair.ResumeLayout(false);
            this.stepUninstallRepair.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox step1;
        private System.Windows.Forms.Button installKey;
        private System.Windows.Forms.Button backupKey;
        private System.Windows.Forms.Label step1action;
        private System.Windows.Forms.Label step1output;
        private System.Windows.Forms.Label step1info;
        private System.Windows.Forms.Button help1;
        private System.Windows.Forms.GroupBox step2;
        private System.Windows.Forms.Button installTap;
        private System.Windows.Forms.Label step2action;
        private System.Windows.Forms.Label step2output;
        private System.Windows.Forms.Label step2info;
        private System.Windows.Forms.Button help2;
        private System.Windows.Forms.GroupBox step3;
        private System.Windows.Forms.Button installSrv;
        private System.Windows.Forms.Label step3action;
        private System.Windows.Forms.Label step3output;
        private System.Windows.Forms.Label step3info;
        private System.Windows.Forms.Button help3;
        private System.Windows.Forms.Button creditsWho;
        private System.Windows.Forms.Button creditsWhy;
        private System.Windows.Forms.Timer stateUpdateTimer;
        private System.Windows.Forms.GroupBox stepUninstallRepair;
        private System.Windows.Forms.Button deleteProductKey;
        private System.Windows.Forms.Button deleteTaps;
        private System.Windows.Forms.Button safeUninstall;
        private System.Windows.Forms.Label labelUninstallRepair;
        private System.Windows.Forms.Button helpUninstallRepair;
    }
}

