namespace GymSystem.Members
{
    partial class FrmAddMember
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMemberID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SubscriptionPlanCB = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TrainerCB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SportCB = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblClassesCount = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSubscriptionPrice = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new GymSystem.People.controls.ctrlPersonCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(282, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(431, 60);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Add New Member";
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMemberID.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblMemberID.Location = new System.Drawing.Point(168, 49);
            this.lblMemberID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberID.Name = "lblMemberID";
            this.lblMemberID.Size = new System.Drawing.Size(38, 20);
            this.lblMemberID.TabIndex = 120;
            this.lblMemberID.Text = "N/A";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label22.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label22.Location = new System.Drawing.Point(31, 49);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 20);
            this.label22.TabIndex = 119;
            this.label22.Text = "Member ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label2.Location = new System.Drawing.Point(31, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 121;
            this.label2.Text = "Member Code :";
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.AutoSize = true;
            this.lblMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMemberCode.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblMemberCode.Location = new System.Drawing.Point(169, 88);
            this.lblMemberCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(38, 20);
            this.lblMemberCode.TabIndex = 122;
            this.lblMemberCode.Text = "N/A";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SubscriptionPlanCB
            // 
            this.SubscriptionPlanCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubscriptionPlanCB.FormattingEnabled = true;
            this.SubscriptionPlanCB.Location = new System.Drawing.Point(780, 555);
            this.SubscriptionPlanCB.Name = "SubscriptionPlanCB";
            this.SubscriptionPlanCB.Size = new System.Drawing.Size(167, 27);
            this.SubscriptionPlanCB.TabIndex = 132;
            this.SubscriptionPlanCB.SelectedValueChanged += new System.EventHandler(this.SubscriptionPlanCB_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label15.Location = new System.Drawing.Point(605, 558);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 20);
            this.label15.TabIndex = 131;
            this.label15.Text = "Subscription Plan:";
            // 
            // TrainerCB
            // 
            this.TrainerCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrainerCB.FormattingEnabled = true;
            this.TrainerCB.Location = new System.Drawing.Point(417, 555);
            this.TrainerCB.Name = "TrainerCB";
            this.TrainerCB.Size = new System.Drawing.Size(167, 27);
            this.TrainerCB.TabIndex = 130;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label17.Location = new System.Drawing.Point(330, 558);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 20);
            this.label17.TabIndex = 129;
            this.label17.Text = "Trainer:";
            // 
            // SportCB
            // 
            this.SportCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SportCB.FormattingEnabled = true;
            this.SportCB.Location = new System.Drawing.Point(145, 555);
            this.SportCB.Name = "SportCB";
            this.SportCB.Size = new System.Drawing.Size(167, 27);
            this.SportCB.TabIndex = 134;
            this.SportCB.SelectedValueChanged += new System.EventHandler(this.SportCB_SelectedValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label19.Location = new System.Drawing.Point(8, 562);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 20);
            this.label19.TabIndex = 133;
            this.label19.Text = "Sport / Activity:";
            // 
            // lblClassesCount
            // 
            this.lblClassesCount.AutoSize = true;
            this.lblClassesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClassesCount.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblClassesCount.Location = new System.Drawing.Point(185, 603);
            this.lblClassesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassesCount.Name = "lblClassesCount";
            this.lblClassesCount.Size = new System.Drawing.Size(29, 20);
            this.lblClassesCount.TabIndex = 138;
            this.lblClassesCount.Text = "??";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label21.Location = new System.Drawing.Point(13, 603);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 20);
            this.label21.TabIndex = 137;
            this.label21.Text = "Classes Count :";
            // 
            // lblSubscriptionPrice
            // 
            this.lblSubscriptionPrice.AutoSize = true;
            this.lblSubscriptionPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscriptionPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSubscriptionPrice.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblSubscriptionPrice.Location = new System.Drawing.Point(185, 636);
            this.lblSubscriptionPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubscriptionPrice.Name = "lblSubscriptionPrice";
            this.lblSubscriptionPrice.Size = new System.Drawing.Size(29, 20);
            this.lblSubscriptionPrice.TabIndex = 136;
            this.lblSubscriptionPrice.Text = "??";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label24.Location = new System.Drawing.Point(13, 636);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(164, 20);
            this.label24.TabIndex = 135;
            this.label24.Text = "Subscription Price :";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(670, 656);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 140;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(804, 656);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.MidnightBlue;
            this.ctrlPersonCardWithFilter1.FilterEnable = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(88, 123);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(831, 392);
            this.ctrlPersonCardWithFilter1.TabIndex = 141;
            // 
            // FrmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.ClientSize = new System.Drawing.Size(1007, 718);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblClassesCount);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblSubscriptionPrice);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.SportCB);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.SubscriptionPlanCB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TrainerCB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblMemberCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMemberID);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmAddMember";
            this.Text = "FrmAddUpdateMember";
            this.Load += new System.EventHandler(this.FrmAddUpdateMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private People.controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblClassesCount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblSubscriptionPrice;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox SportCB;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox SubscriptionPlanCB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox TrainerCB;
        private System.Windows.Forms.Label label17;
    }
}