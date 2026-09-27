namespace GymSystem.People
{
    partial class frmTrainersAttendence
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
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpecializationsCb = new System.Windows.Forms.ComboBox();
            this.Namelbl = new System.Windows.Forms.Label();
            this.NamesCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Location = new System.Drawing.Point(2, 221);
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.Size = new System.Drawing.Size(1503, 488);
            this.dgvTrainers.TabIndex = 97;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRecordsCount.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.lblRecordsCount.Location = new System.Drawing.Point(124, 745);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(17, 13);
            this.lblRecordsCount.TabIndex = 99;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label2.Location = new System.Drawing.Point(12, 740);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 98;
            this.label2.Text = "# Records:";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(554, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(468, 60);
            this.lblTitle.TabIndex = 100;
            this.lblTitle.Text = "Trainer Attendence";
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchBy.FormattingEnabled = true;
            this.cbSearchBy.Items.AddRange(new object[] {
            "None",
            "Trainer ID",
            "Full Name",
            "Specialization"});
            this.cbSearchBy.Location = new System.Drawing.Point(117, 181);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.Size = new System.Drawing.Size(210, 21);
            this.cbSearchBy.TabIndex = 103;
            this.cbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cbSearchBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.label1.Location = new System.Drawing.Point(15, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 101;
            this.label1.Text = "Search By:";
            // 
            // btnCheckin
            // 
            this.btnCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckin.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckin.ForeColor = System.Drawing.Color.Green;
            this.btnCheckin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckin.Location = new System.Drawing.Point(1360, 157);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(130, 58);
            this.btnCheckin.TabIndex = 104;
            this.btnCheckin.Text = "Check In";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Location = new System.Drawing.Point(347, 181);
            this.txtSearchValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(256, 20);
            this.txtSearchValue.TabIndex = 102;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkOutToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 48);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.checkOutToolStripMenuItem.Text = "CheckOut";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // SpecializationsCb
            // 
            this.SpecializationsCb.FormattingEnabled = true;
            this.SpecializationsCb.Location = new System.Drawing.Point(347, 181);
            this.SpecializationsCb.Name = "SpecializationsCb";
            this.SpecializationsCb.Size = new System.Drawing.Size(169, 21);
            this.SpecializationsCb.TabIndex = 107;
            this.SpecializationsCb.SelectedIndexChanged += new System.EventHandler(this.SpecializationsCb_SelectedIndexChanged);
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Namelbl.Image = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.Namelbl.Location = new System.Drawing.Point(650, 179);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(60, 20);
            this.Namelbl.TabIndex = 108;
            this.Namelbl.Text = "Name:";
            // 
            // NamesCB
            // 
            this.NamesCB.ContextMenuStrip = this.contextMenuStrip1;
            this.NamesCB.FormattingEnabled = true;
            this.NamesCB.Location = new System.Drawing.Point(727, 180);
            this.NamesCB.Name = "NamesCB";
            this.NamesCB.Size = new System.Drawing.Size(192, 21);
            this.NamesCB.TabIndex = 109;
            // 
            // frmTrainersAttendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GymSystem.Properties.Resources.Wallpaper_color_blue_background_minimalism_navy_blue;
            this.ClientSize = new System.Drawing.Size(1517, 769);
            this.Controls.Add(this.NamesCB);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.SpecializationsCb);
            this.Controls.Add(this.btnCheckin);
            this.Controls.Add(this.cbSearchBy);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTrainers);
            this.Name = "frmTrainersAttendence";
            this.Text = "frmStaffAttendence";
            this.Load += new System.EventHandler(this.frmTrainersAttendence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.ComboBox cbSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox SpecializationsCb;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.ComboBox NamesCB;
    }
}