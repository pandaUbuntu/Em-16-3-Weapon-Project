namespace WindowsFormsApp3
{
    partial class Form1
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
            this.labelWeaponName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.labelCurrentAmmo = new System.Windows.Forms.Label();
            this.labelMaxAmmoCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShoot = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.listBoxMagazine = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWeaponName
            // 
            this.labelWeaponName.AutoSize = true;
            this.labelWeaponName.Location = new System.Drawing.Point(12, 19);
            this.labelWeaponName.Name = "labelWeaponName";
            this.labelWeaponName.Size = new System.Drawing.Size(76, 26);
            this.labelWeaponName.TabIndex = 0;
            this.labelWeaponName.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(165, 30);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(197, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(165, 30);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(368, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(165, 30);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // labelCurrentAmmo
            // 
            this.labelCurrentAmmo.AutoSize = true;
            this.labelCurrentAmmo.Location = new System.Drawing.Point(622, 19);
            this.labelCurrentAmmo.Name = "labelCurrentAmmo";
            this.labelCurrentAmmo.Size = new System.Drawing.Size(38, 26);
            this.labelCurrentAmmo.TabIndex = 2;
            this.labelCurrentAmmo.Text = "30";
            // 
            // labelMaxAmmoCount
            // 
            this.labelMaxAmmoCount.AutoSize = true;
            this.labelMaxAmmoCount.Location = new System.Drawing.Point(688, 19);
            this.labelMaxAmmoCount.Name = "labelMaxAmmoCount";
            this.labelMaxAmmoCount.Size = new System.Drawing.Size(38, 26);
            this.labelMaxAmmoCount.TabIndex = 3;
            this.labelMaxAmmoCount.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // buttonShoot
            // 
            this.buttonShoot.Location = new System.Drawing.Point(17, 176);
            this.buttonShoot.Name = "buttonShoot";
            this.buttonShoot.Size = new System.Drawing.Size(134, 45);
            this.buttonShoot.TabIndex = 5;
            this.buttonShoot.Text = "Постріл";
            this.buttonShoot.UseVisualStyleBackColor = true;
            this.buttonShoot.Click += new System.EventHandler(this.buttonShoot_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(594, 176);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(178, 45);
            this.buttonReload.TabIndex = 6;
            this.buttonReload.Text = "Перезарядка";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // listBoxMagazine
            // 
            this.listBoxMagazine.FormattingEnabled = true;
            this.listBoxMagazine.ItemHeight = 25;
            this.listBoxMagazine.Location = new System.Drawing.Point(393, 237);
            this.listBoxMagazine.Name = "listBoxMagazine";
            this.listBoxMagazine.Size = new System.Drawing.Size(379, 254);
            this.listBoxMagazine.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.listBoxMagazine);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonShoot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMaxAmmoCount);
            this.Controls.Add(this.labelCurrentAmmo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelWeaponName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWeaponName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelCurrentAmmo;
        private System.Windows.Forms.Label labelMaxAmmoCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShoot;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.ListBox listBoxMagazine;
    }
}

