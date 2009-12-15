using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CodeGenX.Classes;
using System.Xml.Xsl;
using System.Xml;

namespace CodeGenX
{
    public partial class Form1 : Form
    {
        protected TorqueXML _xmlTorque = null;
        protected ExtraPropertiesXML _xmlExtraProperties = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpenXML.FileName = "";
            if (dlgOpenXML.ShowDialog() == DialogResult.OK)
            {
                this.LoadXmlTables(dlgOpenXML.FileName);
            }
        }

        protected void LoadXmlTables(string FileName)
        {
            try
            {
                lblXml.Text = "";
                lstAllTables.Items.Clear();
                this._xmlTorque = new TorqueXML(FileName, "TorqueModel");
                lstAllTables.Sorted = true;
                lstAllTables.SelectionMode = SelectionMode.MultiExtended;
                lstAllTables.Items.AddRange(this._xmlTorque.GetAllTables());
                lblXml.Text = FileName;

                for (int i = lstAllTables.Items.Count - 1; i >= 0; i--)
                {
                    lstAllTables.SelectedItems.Add(lstAllTables.Items[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtMensagem.AppendText(ex.Message);
            }
        }

        protected void NewProject()
        {
            this._xmlExtraProperties = null;
            this._xmlTorque = null;
            lblXml.Text = "";

            lstAllTables.Items.Clear();
            lstXsl.Items.Clear();

            txtExtraProperties.Text = "< optional >";
            txtSaveTo.Text = "";
        }

        protected void LoadExtraProperties(string FileName)
        {
            try
            {
                this._xmlExtraProperties = new ExtraPropertiesXML(FileName, "ExtraPropertiesModel");
                txtExtraProperties.Text = FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtMensagem.AppendText(ex.Message);
            }
        }


        private void btnAddXsl_Click(object sender, EventArgs e)
        {
            dlgAddXsl.FileName = "";
            if (dlgAddXsl.ShowDialog() == DialogResult.OK)
            {
                lstXsl.Items.Add(dlgAddXsl.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblXml.Text = "";
            lstXsl.Items.Clear();
            lstXsl.Sorted = true;
        }

        private void lstXsl_Click(object sender, EventArgs e)
        {
            if (lstXsl.SelectedIndex >= 0)
            {
                lstXsl.Items.RemoveAt(lstXsl.SelectedIndex);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form2 form = new Form2();
            form.Show();
            form.ProcessarXSL(this, txtSaveTo.Text, lstAllTables.SelectedItems, lstXsl.Items, this._xmlTorque, this._xmlExtraProperties);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dlgSaveTo.ShowDialog() == DialogResult.OK)
            {
                txtSaveTo.Text = dlgSaveTo.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dlgOpenExtraXML.ShowDialog() == DialogResult.OK)
            {
                this.LoadExtraProperties(dlgOpenExtraXML.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dlgSaveProject.ShowDialog() == DialogResult.OK)
            {
				string baseDir = System.IO.Path.GetDirectoryName(dlgSaveProject.FileName);

                XmlDocument document = new XmlDocument();
                document.LoadXml("<codegenx />");
                XmlNode generator = document.DocumentElement;

                // Save Torque XML
                XmlNode torque = document.CreateElement("torqueXml");
                if (this._xmlTorque != null)
                {
                    XmlNode torquetxt = document.CreateTextNode(this.GetRelativePath(baseDir, this.lblXml.Text));
                    torque.AppendChild(torquetxt);
                }
                generator.AppendChild(torque);

                // Save XSL
                XmlNode xsl = document.CreateElement("xsl");
                generator.AppendChild(xsl);
                foreach (string xslTxt in lstXsl.Items)
                {
                    XmlNode xslitem = document.CreateElement("item");
                    xsl.AppendChild(xslitem);

                    XmlAttribute node = document.CreateAttribute("name");
                    node.Value = this.GetRelativePath(baseDir, xslTxt);
                    xslitem.Attributes.Append(node);
                }

                // Save Extra Properties
                XmlNode extra = document.CreateElement("extraProperties");
                if (this._xmlExtraProperties != null)
                {
                    XmlNode extratxt = document.CreateTextNode(this.GetRelativePath(baseDir, this.txtExtraProperties.Text));
                    extra.AppendChild(extratxt);
                }
                generator.AppendChild(extra);

                // Save output
                XmlNode saveTo = document.CreateElement("saveTo");
                if (this.txtSaveTo.Text != "")
                {
                    XmlNode saveToTxt = document.CreateTextNode(this.GetRelativePath(baseDir, this.txtSaveTo.Text));
                    saveTo.AppendChild(saveToTxt);
                }
                generator.AppendChild(saveTo);

                document.Save(dlgSaveProject.FileName);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewProject();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dlgOpenProject.ShowDialog() == DialogResult.OK)
            {
                this.NewProject();

                XmlDocument document = new XmlDocument();
                document.Load(dlgOpenProject.FileName);
                XmlNode generator = document.DocumentElement;

				string baseDir = System.IO.Path.GetDirectoryName(dlgOpenProject.FileName);

                // Load Torque XML
                XmlNode torque = generator.SelectSingleNode("torqueXml");
                if (torque != null)
                {
                    this.LoadXmlTables(this.GetAbsolutePath(baseDir, torque.InnerText));
                }

                // Load XSL
                XmlNodeList xslList = generator.SelectNodes("xsl/item");
                foreach (XmlNode node in xslList)
                {
                    lstXsl.Items.Add(this.GetAbsolutePath(baseDir, node.Attributes["name"].Value));
                }

                // Load Extra Properties
                XmlNode extra = generator.SelectSingleNode("extraProperties");
                if (extra != null)
                {
                    this.LoadExtraProperties(this.GetAbsolutePath(baseDir, extra.InnerText));
                }

                // Load SaveTo
                XmlNode saveTo = generator.SelectSingleNode("saveTo");
                if (saveTo != null)
                {
                    txtSaveTo.Text = this.GetAbsolutePath(baseDir, saveTo.InnerText);
                }
            }

        }

		private string GetAbsolutePath(string baseDir, string path)
		{
			if ((path[1] == ':') || (path[0] == '/'))
				return path;
			else
			{
				baseDir += "/";
				return System.IO.Path.GetFullPath(baseDir + path);
			}
		}

		private string GetRelativePath(string baseDir, string path)
		{
			baseDir = baseDir.Replace('\\', '/');
			path = path.Replace('\\', '/');

			string[] baseParts = baseDir.Split('/');
			string[] pathParts = path.Split('/');

			int i = 0;

			while ((i < baseParts.Length) && (i < pathParts.Length) && (baseParts[i] == pathParts[i]))
			{
				i++;
			}

			string result = "";
			for (int j = i; j < baseParts.Length; j++)
			{
				result += "../";
			}

			for (int j = i; j < pathParts.Length; j++)
			{
				result += pathParts[j] + (j + 1 == pathParts.Length ? "" : "/");
			}

			return result;
		}

	}
}
