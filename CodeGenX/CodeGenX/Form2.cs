using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeGenX.Classes;
using System.Xml.Xsl;
using System.Text.RegularExpressions;

namespace CodeGenX
{
    public partial class Form2 : Form
    {
        protected Form _parentForm;
		protected string _saveTo;
		protected List<string> _tableList;
		protected List<string> _xslList;
		protected TorqueXML _xmlTorque;
		protected ExtraPropertiesXML _extraProperty;
		protected int _maxElements;

		protected bool _stop = false;

        public Form2()
        {
            InitializeComponent();
        }


        public void ProcessarXSL(Form parentForm, string saveTo, ListBox.SelectedObjectCollection tableList, ListBox.ObjectCollection xslList, TorqueXML xmlTorque, ExtraPropertiesXML extraProperty )
        {
			this._parentForm = parentForm;
			this._saveTo = saveTo;
			this._tableList = new List<string>();
			foreach (string item in tableList)
			{
				this._tableList.Add(item);
			}
			this._xslList = new List<string>();
			foreach (string item in xslList)
			{
				this._xslList.Add(item);
			}
			this._xmlTorque = xmlTorque;
			this._extraProperty = extraProperty;
			this._maxElements = this._xslList.Count * this._tableList.Count;

			System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ProcessarThread));
			thread.Start();
		}

		#region Thread Safe functions

		protected void threadSafeMessage(string message)
		{
			this.Invoke(new MethodInvoker(delegate
			{
				if (String.IsNullOrEmpty(message))
				{
					txtMensagem.Clear();
				}
				else
				{
					txtMensagem.Text = message;
				}
			}));
		}

		protected void threadSafeAppendMessage(string message)
		{
			this.Invoke(new MethodInvoker(delegate
			{
				txtMensagem.AppendText(message);
			}));
		}

		protected void threadSafeStartProgress()
		{
			this.Invoke(new MethodInvoker(delegate
			{
				progressBar1.Minimum = 0;
				progressBar1.Maximum = this._maxElements;
				progressBar1.Value = 0;
			}));
		}

		protected void threadSafeUpdateProgress()
		{
			this.Invoke(new MethodInvoker(delegate
			{
				progressBar1.Value++;
			}));
		}

		#endregion

		protected void ProcessarThread()
		{
			try
			{
				if (this._saveTo != "")
				{
					this.threadSafeMessage(null);

					this.threadSafeStartProgress();

					System.IO.Directory.CreateDirectory(this._saveTo);
					this._saveTo += Platform.Slash();

					if (this._xslList.Count == 0)
					{
						this.threadSafeMessage("None XSL are load.");
					}
					else if (this._tableList.Count == 0)
					{
						this.threadSafeMessage("You must select 1 table at least, in order to get working.");
					}
					else
					{
						foreach (string xslfile in this._xslList)
						{
							foreach (string table in this._tableList)
							{
								// Updating Messages
								this.threadSafeAppendMessage("Doing: '" + table + "' and '" + xslfile + "'\r\n");

								#region Define Properties
								// Define Class name
								string[] fileparts = table.Split('_');
								string className = "";
								foreach (string fp in fileparts)
								{
									className += fp[0].ToString().ToUpper() + fp.Substring(1).ToLower();
								}

								// Define Save To Directory
								string newFolder = (this._extraProperty != null ? this._extraProperty.GetSaveTo(table) : "");

								// Get The File Name
								string filename = (this._extraProperty != null ? this._extraProperty.GetFileName(table) : "");
								if (String.IsNullOrEmpty(filename))
								{
									filename = System.IO.Path.GetFileNameWithoutExtension(xslfile) + "." + className + ".source";
								}
								else
								{
									filename = this.ReplaceMacros(filename, className, table, xslfile);
								}
								#endregion

								#region Reading Arguments
								// Reading Arguments
								XsltArgumentList xslArg = new XsltArgumentList();
								xslArg.AddParam("tablename", "", table);
								if (this._extraProperty != null)
								{
									Dictionary<string, string> extraPropValues = this._extraProperty.GetPropertyValues(table);
									foreach (KeyValuePair<string, string> prop in extraPropValues)
									{
										string propValue = this.ReplaceMacros(prop.Value, className, table, xslfile);
										xslArg.AddParam(prop.Key, "", propValue);
										newFolder = newFolder.Replace("%" + prop.Key, propValue);
										filename = filename.Replace("%" + prop.Key, propValue);
									}
								}
								#endregion

								// Create Destination Directory
								if (!String.IsNullOrEmpty(newFolder))
								{
									newFolder = this.ReplaceMacros(newFolder, className, table, xslfile);
									newFolder = Platform.FixPath(newFolder);
									System.IO.Directory.CreateDirectory(this._saveTo + newFolder);
									newFolder += Platform.Slash();
								}

								// Transform
								string result = this._xmlTorque.Transform(xslfile, xslArg);

								// Defines the Full File Name
								string fullFilename = this._saveTo + newFolder + filename;

								// Try detect if have changes
								if (System.IO.File.Exists(fullFilename))
								{
									string basePatternPrefix = @"\{@@@\[(?<delimiter>%%)\r?\n";
									string basePatternSuffix = @"\s*(\k<delimiter>)\]\}@@@";
									string prefix = @"[\w\d/\-]+";

									string oldContent = System.IO.File.ReadAllText(fullFilename);

									// There are some special chars when you do substitutions. We have to scape it.
									// http://msdn.microsoft.com/en-us/library/ewy2t5e0(v=vs.110).aspx
									Regex fixSpecialChar = new Regex(@"\$([\{0-9`'\+_])");
									oldContent = fixSpecialChar.Replace(oldContent, @"$$$$$1");

									Regex regexOld = new Regex("(?<all>" + basePatternPrefix.Replace("%%", prefix) + @"(?<text>[\w\d\s.""\r\n':;\{\}\[\]\(\)\+\-\*!@#$%^&<>,\?~`_|\\\/=]*)" + basePatternSuffix + ")");
									MatchCollection mcOld = regexOld.Matches(oldContent);

									foreach (Match match in mcOld)
									{
										Regex regexNew = new Regex("(?<all>" + basePatternPrefix.Replace("%%", match.Groups["delimiter"].Value) + basePatternSuffix + ")");
										result = regexNew.Replace(result, match.Groups["all"].Value);
									}
								}

								// Save File
								System.IO.File.WriteAllText(fullFilename, result);
								this.threadSafeUpdateProgress();

								if (this._stop) break;
							}

							if (this._stop) break;
						}
					}
				}
				else
				{
					this.threadSafeMessage("No output directory was specified.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.Close();
				this._parentForm.Enabled = true;
			}

			if (this._stop)
			{
				this.threadSafeAppendMessage("\r\n***** CANCELLED BY USER *****\r\n");
			}

			this.Invoke(new MethodInvoker(delegate
			{
				this.button1.Tag = "1";
				this.button1.Text = "Close Window";
			}));
		}
		
		private void button1_Click(object sender, EventArgs e)
        {
			if (this.button1.Tag.ToString() == "1")
			{
				this.Close();
			}
			else
			{
				this._stop = true;
			}
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._parentForm.Enabled = true;
        }

		private string ReplaceMacros (string Str, string className, string table, string xslfile)
		{
			return Str.Replace("%classname", className)
						.Replace("%tablename", table)
						.Replace("%TableName", Regex.Replace(table.Replace('_', ' '), @"\b(\w)", m => m.Value.ToUpper()).Replace(" ", ""))
						.Replace("%Table_Name", Regex.Replace(table.Replace('_', ' '), @"\b(\w)", m => m.Value.ToUpper()).Replace(" ", "_"))
						.Replace("%xsl", System.IO.Path.GetFileNameWithoutExtension(xslfile));
		}

    }
}
