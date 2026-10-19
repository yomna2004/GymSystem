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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblClassesCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSubscriptionPrice = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SubscriptionPlanCB = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TrainerCB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLastName = new GymSystem.CustomTextBox();
            this.txtSecondName = new GymSystem.CustomTextBox();
            this.txtPhone = new GymSystem.CustomTextBox();
            this.txtAddress = new GymSystem.CustomTextBox();
            this.txtEmail = new GymSystem.CustomTextBox();
            this.txtNationalNo = new GymSystem.CustomTextBox();
            this.txtThirdName = new GymSystem.CustomTextBox();
            this.txtFirstName = new GymSystem.CustomTextBox();
            this.SportCB = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NationalNolbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMemberID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(272, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(431, 60);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Add New Member";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.groupBox1.Controls.Add(this.lblClassesCount);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblSubscriptionPrice);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.SubscriptionPlanCB);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.TrainerCB);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtSecondName);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtNationalNo);
            this.groupBox1.Controls.Add(this.txtThirdName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.SportCB);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.llRemoveImage);
            this.groupBox1.Controls.Add(this.rbFemale);
            this.groupBox1.Controls.Add(this.rbMale);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.llSetImage);
            this.groupBox1.Controls.Add(this.dtpDateOfBirth);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NationalNolbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pbPersonImage);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(21, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 448);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            // 
            // lblClassesCount
            // 
            this.lblClassesCount.AutoSize = true;
            this.lblClassesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClassesCount.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblClassesCount.Location = new System.Drawing.Point(191, 375);
            this.lblClassesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClassesCount.Name = "lblClassesCount";
            this.lblClassesCount.Size = new System.Drawing.Size(38, 20);
            this.lblClassesCount.TabIndex = 132;
            this.lblClassesCount.Text = "N/A";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label18.Location = new System.Drawing.Point(19, 375);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 20);
            this.label18.TabIndex = 131;
            this.label18.Text = "Classes Count :";
            // 
            // lblSubscriptionPrice
            // 
            this.lblSubscriptionPrice.AutoSize = true;
            this.lblSubscriptionPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscriptionPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSubscriptionPrice.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblSubscriptionPrice.Location = new System.Drawing.Point(191, 408);
            this.lblSubscriptionPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubscriptionPrice.Name = "lblSubscriptionPrice";
            this.lblSubscriptionPrice.Size = new System.Drawing.Size(38, 20);
            this.lblSubscriptionPrice.TabIndex = 130;
            this.lblSubscriptionPrice.Text = "N/A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label16.Location = new System.Drawing.Point(19, 408);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 20);
            this.label16.TabIndex = 129;
            this.label16.Text = "Subscription Price :";
            // 
            // SubscriptionPlanCB
            // 
            this.SubscriptionPlanCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubscriptionPlanCB.FormattingEnabled = true;
            this.SubscriptionPlanCB.Location = new System.Drawing.Point(537, 210);
            this.SubscriptionPlanCB.Name = "SubscriptionPlanCB";
            this.SubscriptionPlanCB.Size = new System.Drawing.Size(167, 27);
            this.SubscriptionPlanCB.TabIndex = 128;
            this.SubscriptionPlanCB.SelectedValueChanged += new System.EventHandler(this.SubscriptionPlanCB_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label14.Location = new System.Drawing.Point(347, 210);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 20);
            this.label14.TabIndex = 127;
            this.label14.Text = "Subscription Plan:";
            // 
            // TrainerCB
            // 
            this.TrainerCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrainerCB.FormattingEnabled = true;
            this.TrainerCB.Location = new System.Drawing.Point(158, 210);
            this.TrainerCB.Name = "TrainerCB";
            this.TrainerCB.Size = new System.Drawing.Size(167, 27);
            this.TrainerCB.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label13.Location = new System.Drawing.Point(19, 210);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 20);
            this.label13.TabIndex = 125;
            this.label13.Text = "Trainer:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtLastName.IsRequired = true;
            this.txtLastName.Location = new System.Drawing.Point(733, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(167, 27);
            this.txtLastName.TabIndex = 124;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            // 
            // txtSecondName
            // 
            this.txtSecondName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondName.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtSecondName.IsRequired = false;
            this.txtSecondName.Location = new System.Drawing.Point(351, 50);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(167, 27);
            this.txtSecondName.TabIndex = 123;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.inputType = GymSystem.CustomTextBox.InputTypeEnum.NumberInput;
            this.txtPhone.IsRequired = true;
            this.txtPhone.Location = new System.Drawing.Point(537, 131);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(167, 27);
            this.txtPhone.TabIndex = 122;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtAddress.IsRequired = false;
            this.txtAddress.Location = new System.Drawing.Point(158, 252);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(546, 98);
            this.txtAddress.TabIndex = 121;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtEmail.IsRequired = false;
            this.txtEmail.Location = new System.Drawing.Point(158, 166);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 27);
            this.txtEmail.TabIndex = 120;
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationalNo.inputType = GymSystem.CustomTextBox.InputTypeEnum.NumberInput;
            this.txtNationalNo.IsRequired = true;
            this.txtNationalNo.Location = new System.Drawing.Point(158, 97);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(167, 27);
            this.txtNationalNo.TabIndex = 119;
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // txtThirdName
            // 
            this.txtThirdName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdName.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtThirdName.IsRequired = false;
            this.txtThirdName.Location = new System.Drawing.Point(540, 50);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(167, 27);
            this.txtThirdName.TabIndex = 117;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.inputType = GymSystem.CustomTextBox.InputTypeEnum.TextInput;
            this.txtFirstName.IsRequired = true;
            this.txtFirstName.Location = new System.Drawing.Point(158, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(167, 27);
            this.txtFirstName.TabIndex = 115;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            // 
            // SportCB
            // 
            this.SportCB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SportCB.FormattingEnabled = true;
            this.SportCB.Location = new System.Drawing.Point(537, 169);
            this.SportCB.Name = "SportCB";
            this.SportCB.Size = new System.Drawing.Size(167, 27);
            this.SportCB.TabIndex = 114;
            this.SportCB.SelectedValueChanged += new System.EventHandler(this.SportCB_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label11.Location = new System.Drawing.Point(362, 169);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 20);
            this.label11.TabIndex = 113;
            this.label11.Text = "Sport / Activity:";
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRemoveImage.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.llRemoveImage.LinkColor = System.Drawing.Color.Red;
            this.llRemoveImage.Location = new System.Drawing.Point(772, 314);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(66, 19);
            this.llRemoveImage.TabIndex = 112;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbFemale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(251, 132);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(77, 23);
            this.rbFemale.TabIndex = 8;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = false;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(158, 132);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(59, 23);
            this.rbMale.TabIndex = 7;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label5.Location = new System.Drawing.Point(19, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 106;
            this.label5.Text = "Gender:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label10.Location = new System.Drawing.Point(787, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 20);
            this.label10.TabIndex = 103;
            this.label10.Text = "Last";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label9.Location = new System.Drawing.Point(596, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 102;
            this.label9.Text = "Third";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label8.Location = new System.Drawing.Point(396, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 101;
            this.label8.Text = "Second";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label7.Location = new System.Drawing.Point(220, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "First";
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.llSetImage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetImage.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.llSetImage.LinkColor = System.Drawing.Color.Red;
            this.llSetImage.Location = new System.Drawing.Point(772, 283);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(81, 19);
            this.llSetImage.TabIndex = 13;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.CustomFormat = "dd/M/yyyy";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(537, 95);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(167, 20);
            this.dtpDateOfBirth.TabIndex = 6;
            this.dtpDateOfBirth.Value = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(445, 358);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label12.Location = new System.Drawing.Point(19, 252);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label6.Location = new System.Drawing.Point(19, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 91;
            this.label6.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label4.Location = new System.Drawing.Point(423, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 90;
            this.label4.Text = "Phone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label3.Location = new System.Drawing.Point(368, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 89;
            this.label3.Text = "Date Of Birth:";
            // 
            // NationalNolbl
            // 
            this.NationalNolbl.AutoSize = true;
            this.NationalNolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NationalNolbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NationalNolbl.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.NationalNolbl.Location = new System.Drawing.Point(19, 95);
            this.NationalNolbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NationalNolbl.Name = "NationalNolbl";
            this.NationalNolbl.Size = new System.Drawing.Size(107, 20);
            this.NationalNolbl.TabIndex = 88;
            this.NationalNolbl.Text = "National No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "Name:";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Image = global::GymSystem.Properties.Resources.Male_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(733, 97);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(167, 161);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonImage.TabIndex = 85;
            this.pbPersonImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(579, 358);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMemberID.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblMemberID.Location = new System.Drawing.Point(154, 96);
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
            this.label22.Location = new System.Drawing.Point(17, 96);
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
            this.label2.Location = new System.Drawing.Point(17, 135);
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
            this.lblMemberCode.Location = new System.Drawing.Point(155, 135);
            this.lblMemberCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(38, 20);
            this.lblMemberCode.TabIndex = 122;
            this.lblMemberCode.Text = "N/A";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.ClientSize = new System.Drawing.Size(1007, 636);
            this.Controls.Add(this.lblMemberCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMemberID);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmAddMember";
            this.Text = "FrmAddUpdateMember";
            this.Load += new System.EventHandler(this.FrmAddUpdateMember_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomTextBox txtLastName;
        private CustomTextBox txtSecondName;
        private CustomTextBox txtPhone;
        private CustomTextBox txtAddress;
        private CustomTextBox txtEmail;
        private CustomTextBox txtNationalNo;
        private CustomTextBox txtThirdName;
        private CustomTextBox txtFirstName;
        private System.Windows.Forms.ComboBox SportCB;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NationalNolbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox TrainerCB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox SubscriptionPlanCB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSubscriptionPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblClassesCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}