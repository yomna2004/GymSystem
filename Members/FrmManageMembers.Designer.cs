namespace GymSystem.Members
{
    partial class FrmManageMembers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageMembers));
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddTrainerbtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.deactivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reactivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(534, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(431, 60);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Manage Members";
            // 
            // dgvMembers
            // 
            this.dgvMembers.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMembers.Location = new System.Drawing.Point(27, 196);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(1459, 462);
            this.dgvMembers.TabIndex = 105;
            this.dgvMembers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMembers_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonInfoToolStripMenuItem,
            this.editInfoToolStripMenuItem,
            this.deactivateToolStripMenuItem,
            this.reactivateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showPersonInfoToolStripMenuItem.Text = "Show Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // editInfoToolStripMenuItem
            // 
            this.editInfoToolStripMenuItem.Name = "editInfoToolStripMenuItem";
            this.editInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editInfoToolStripMenuItem.Text = "Edit Info";
            this.editInfoToolStripMenuItem.Click += new System.EventHandler(this.editInfoToolStripMenuItem_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(442, 135);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(73, 21);
            this.cbIsActive.TabIndex = 104;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1362, 674);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRecordsCount.Image = ((System.Drawing.Image)(resources.GetObject("lblRecordsCount.Image")));
            this.lblRecordsCount.Location = new System.Drawing.Point(141, 689);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(17, 13);
            this.lblRecordsCount.TabIndex = 102;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(29, 684);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 101;
            this.label2.Text = "# Records:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Member Code",
            "Phone",
            "Full Name",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(131, 136);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 21);
            this.cbFilterBy.TabIndex = 100;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(361, 136);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 20);
            this.txtFilterValue.TabIndex = 99;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(29, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "Filter By:";
            // 
            // AddTrainerbtn
            // 
            this.AddTrainerbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddTrainerbtn.BackgroundImage")));
            this.AddTrainerbtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.AddTrainerbtn.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.AddTrainerbtn.Image = ((System.Drawing.Image)(resources.GetObject("AddTrainerbtn.Image")));
            this.AddTrainerbtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.AddTrainerbtn.ImageRotate = 0F;
            this.AddTrainerbtn.Location = new System.Drawing.Point(1412, 108);
            this.AddTrainerbtn.Name = "AddTrainerbtn";
            this.AddTrainerbtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.AddTrainerbtn.Size = new System.Drawing.Size(74, 65);
            this.AddTrainerbtn.TabIndex = 97;
            this.AddTrainerbtn.Click += new System.EventHandler(this.AddMemberbtn_Click);
            // 
            // deactivateToolStripMenuItem
            // 
            this.deactivateToolStripMenuItem.Name = "deactivateToolStripMenuItem";
            this.deactivateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deactivateToolStripMenuItem.Text = "Deactivate";
            this.deactivateToolStripMenuItem.Click += new System.EventHandler(this.deactivateToolStripMenuItem_Click);
            // 
            // reactivateToolStripMenuItem
            // 
            this.reactivateToolStripMenuItem.Name = "reactivateToolStripMenuItem";
            this.reactivateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reactivateToolStripMenuItem.Text = "Reactivate";
            this.reactivateToolStripMenuItem.Click += new System.EventHandler(this.reactivateToolStripMenuItem_Click);
            // 
            // FrmManageMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.ClientSize = new System.Drawing.Size(1510, 733);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTrainerbtn);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmManageMembers";
            this.Text = "FrmManageMembers";
            this.Load += new System.EventHandler(this.FrmManageMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton AddTrainerbtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reactivateToolStripMenuItem;
    }
}