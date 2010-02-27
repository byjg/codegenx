namespace CodeGenX
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dlgOpenXML = new System.Windows.Forms.OpenFileDialog();
			this.btnAddXsl = new System.Windows.Forms.Button();
			this.lstXsl = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dlgAddXsl = new System.Windows.Forms.OpenFileDialog();
			this.btnRun = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txtExtraProperties = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtSaveTo = new System.Windows.Forms.TextBox();
			this.dlgSaveTo = new System.Windows.Forms.FolderBrowserDialog();
			this.dlgOpenExtraXML = new System.Windows.Forms.OpenFileDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.dlgSaveProject = new System.Windows.Forms.SaveFileDialog();
			this.dlgOpenProject = new System.Windows.Forms.OpenFileDialog();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.lstAllTables = new System.Windows.Forms.ListBox();
			this.lblXml = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// dlgOpenXML
			// 
			this.dlgOpenXML.FileName = "openFileDialog1";
			this.dlgOpenXML.Filter = "XML|*.xml|All Files|*.*";
			this.dlgOpenXML.Title = "Open Torque XML";
			// 
			// btnAddXsl
			// 
			this.btnAddXsl.Location = new System.Drawing.Point(8, 30);
			this.btnAddXsl.Name = "btnAddXsl";
			this.btnAddXsl.Size = new System.Drawing.Size(75, 23);
			this.btnAddXsl.TabIndex = 2;
			this.btnAddXsl.Text = "Add XSL";
			this.btnAddXsl.UseVisualStyleBackColor = true;
			this.btnAddXsl.Click += new System.EventHandler(this.btnAddXsl_Click);
			// 
			// lstXsl
			// 
			this.lstXsl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstXsl.FormattingEnabled = true;
			this.lstXsl.Location = new System.Drawing.Point(8, 59);
			this.lstXsl.Name = "lstXsl";
			this.lstXsl.Size = new System.Drawing.Size(361, 108);
			this.lstXsl.TabIndex = 5;
			this.lstXsl.Click += new System.EventHandler(this.lstXsl_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.lstXsl);
			this.groupBox2.Controls.Add(this.btnAddXsl);
			this.groupBox2.Location = new System.Drawing.Point(12, 234);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(375, 173);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "XSL Template Modifier";
			// 
			// dlgAddXsl
			// 
			this.dlgAddXsl.Filter = "XSL|*.xsl|All Files|*.*";
			// 
			// btnRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.Location = new System.Drawing.Point(393, 482);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(108, 23);
			this.btnRun.TabIndex = 15;
			this.btnRun.Text = "Generate Code";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(68, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Save To:";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.txtExtraProperties);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.txtSaveTo);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(12, 413);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(375, 92);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Properties";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(294, 25);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "Browse";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtExtraProperties
			// 
			this.txtExtraProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtExtraProperties.Location = new System.Drawing.Point(125, 27);
			this.txtExtraProperties.Name = "txtExtraProperties";
			this.txtExtraProperties.ReadOnly = true;
			this.txtExtraProperties.Size = new System.Drawing.Size(163, 20);
			this.txtExtraProperties.TabIndex = 15;
			this.txtExtraProperties.Text = "< optional >";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Extra Properties File:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(294, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtSaveTo
			// 
			this.txtSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSaveTo.Location = new System.Drawing.Point(125, 56);
			this.txtSaveTo.Name = "txtSaveTo";
			this.txtSaveTo.ReadOnly = true;
			this.txtSaveTo.Size = new System.Drawing.Size(163, 20);
			this.txtSaveTo.TabIndex = 12;
			// 
			// dlgOpenExtraXML
			// 
			this.dlgOpenExtraXML.FileName = "openFileDialog1";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(393, 176);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(108, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "Load ";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(393, 205);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(108, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "Save";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// dlgSaveProject
			// 
			this.dlgSaveProject.Filter = "CodeGenX Project|*.codegenx";
			this.dlgSaveProject.Title = "Save CodeGenX Project";
			// 
			// dlgOpenProject
			// 
			this.dlgOpenProject.Filter = "CodeGenX Project|*.codegenx|All Files|*.*";
			this.dlgOpenProject.Title = "Open CodeGenX Project";
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(393, 147);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(108, 23);
			this.btnNew.TabIndex = 16;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(8, 34);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open XML";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// lstAllTables
			// 
			this.lstAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstAllTables.FormattingEnabled = true;
			this.lstAllTables.Location = new System.Drawing.Point(8, 63);
			this.lstAllTables.Name = "lstAllTables";
			this.lstAllTables.Size = new System.Drawing.Size(361, 147);
			this.lstAllTables.TabIndex = 3;
			// 
			// lblXml
			// 
			this.lblXml.AutoSize = true;
			this.lblXml.Location = new System.Drawing.Point(89, 39);
			this.lblXml.Name = "lblXml";
			this.lblXml.Size = new System.Drawing.Size(34, 13);
			this.lblXml.TabIndex = 4;
			this.lblXml.Text = "lblXml";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lblXml);
			this.groupBox1.Controls.Add(this.lstAllTables);
			this.groupBox1.Controls.Add(this.btnOpen);
			this.groupBox1.Location = new System.Drawing.Point(12, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(375, 219);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "XML Database Definition";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(393, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(108, 102);
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(401, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 18);
			this.label3.TabIndex = 18;
			this.label3.Text = "v1.1 ByJG";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 517);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(470, 500);
			this.Name = "Form1";
			this.Text = "CodeGenX - Code Generator based on XML Torque and XSL";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.OpenFileDialog dlgOpenXML;
		private System.Windows.Forms.Button btnAddXsl;
		private System.Windows.Forms.ListBox lstXsl;
        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.OpenFileDialog dlgAddXsl;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtExtraProperties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog dlgSaveTo;
        private System.Windows.Forms.OpenFileDialog dlgOpenExtraXML;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog dlgSaveProject;
        private System.Windows.Forms.OpenFileDialog dlgOpenProject;
        private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ListBox lstAllTables;
		private System.Windows.Forms.Label lblXml;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
    }
}

