using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;



namespace DistriqtConf
{
    public partial class ApplicationXML : Form
    {
        public ApplicationXML()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string remove = " xmlns=\"http://ns.adobe.com/air/application/32.0\"";
                string remove2 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                XmlDocument doc = new XmlDocument();

                string xml = textBox1.Text.Replace(remove, "");
                xml = xml.Replace(remove2, "");

                doc.LoadXml(xml);

                XmlNode Application = doc.SelectSingleNode("/application");

                if (Application != null)
                {
                    XmlNode node = Application.SelectSingleNode("id");

                    if (node != null)
                    {
                        Text = node.InnerXml + " " + Application.SelectSingleNode("versionNumber").InnerXml;
                    }
                }




            }
            catch(Exception ee)
            {

            }
        }

        private void Add(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList list = doc.SelectNodes("/extensions/extensionID");
            if (list.Count > 0)
            {
                foreach (XmlNode node in list)
                {
                    string lib = node.InnerXml;
                    if (!labrery.ContainsKey(lib)) labrery.Add(lib, lib);
                }
            }

        }

        private void AddManifest(string xml)
        {
            xml = xml.Replace("android:", "android_");

            if (outDoc == null)
            {
                outDoc = XDocument.Parse(xml);
            }
            else
            {
                XDocument docB = XDocument.Parse(xml);

                MergeElements(outDoc.Element("manifest"), docB.Element("manifest"));
            }
        }

        private Dictionary<string, string> labrery = new Dictionary<string, string>();

        // determine which elements we consider the same
        //
        private static bool AreEquivalent(XElement a, XElement b)
        {
            if (a.Name != b.Name) return false;
            if (!a.HasAttributes && !b.HasAttributes) return true;
            if (!a.HasAttributes || !b.HasAttributes) return false;
            if (a.Attributes().Count() != b.Attributes().Count()) return false;

            return a.Attributes().All(attA => b.Attributes(attA.Name)
                .Count(attB => attB.Value == attA.Value) != 0);
        }

        // Merge "merged" document B into "source" A
        //
        private static void MergeElements(XElement parentA, XElement parentB)
        {
            // merge per-element content from parentB into parentA
            //
            foreach (XNode childNodeB in parentB.DescendantNodes())
            {
                bool isMatchFound = false;

                if (childNodeB is XElement)
                {
                    var childB = (XElement)childNodeB;

                    // merge childB with first equivalent childA
                    // equivalent childB1, childB2,.. will be combined
                    //

                    foreach (XElement childA in parentA.Descendants())
                    {
                        if (AreEquivalent(childA, childB))
                        {
                            MergeElements(childA, childB);
                            isMatchFound = true;
                            break;
                        }
                    }
                }
                else
                {
                    isMatchFound = true;
                }


                // if there is no equivalent childA, add childB into parentA
                //
                if (!isMatchFound) parentA.Add(childNodeB);
            }
        }


        private XDocument outDoc = null;

        private void generateXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labrery = new Dictionary<string, string>();

            outDoc = null;

            if (checkBox4.Checked)
            {
                Add(Properties.Resources.Adverts);
                AddManifest(Properties.Resources.AdvertsManifest);
            }

            if (checkBox1.Checked)
            {
                Add(Properties.Resources.Facebook);
                AddManifest(Properties.Resources.FacebookManifest);
            }

            if (checkBox2.Checked)
            {
                Add(Properties.Resources.GameService);
                AddManifest(Properties.Resources.GameSeviceManifest);
            }

            if (checkBox3.Checked)
            {
                Add(Properties.Resources.InApp);
                AddManifest(Properties.Resources.InAppManifest);
            }

            if(checkBox5.Checked)
            {
                Add(Properties.Resources.Application);
                AddManifest(Properties.Resources.ApplicationManifest);
            }

            

            AddManifest(Properties.Resources.CommonManifest);

            if (labrery.Keys.Count > 0)
            {
                string outText = "<extensions>" + Environment.NewLine;
                foreach (string key in labrery.Keys)
                {
                    outText += "\t<extensionID>" + key + "</extensionID>" + Environment.NewLine;
                }

                outText += "</extensions>" + Environment.NewLine;

                textBox1.Text = outText;
            }

            if (outDoc != null)
            {
                //MessageBox.Show(outDoc.ToString().Replace("android_", "android:"));

                if (DisriqtConfig != null)
                {
                    string text = outDoc.ToString().Replace("android_", "android:");
                    text = text.Replace("XXXXXXXXXXXX", DisriqtConfig.GoogleService);
                    text = text.Replace("ca-app-pub-AAAAAAAAAAAAAAAA~XXXXXXXXXX", DisriqtConfig.Adverts);

                    text = text.Replace("[YOUR_FACEBOOK_APP_ID]", DisriqtConfig.YOUR_FACEBOOK_APP_ID);
                    text = text.Replace("YOUR_PACKAGE_NAME", DisriqtConfig.YOUR_PACKAGE_NAME);

                    int firstApplication = text.IndexOf("<application");
                    int lastApplication = text.LastIndexOf("</application>");

                    if (firstApplication>0 && lastApplication>0)
                    {
                        bool flag = true;

                        while(flag)
                        {
                            flag = false;

                            //firstApplication = text.IndexOf("<application");
                            lastApplication = text.LastIndexOf("</application>");

                            int indexStartApplication = text.IndexOf("<application", firstApplication + 1);
                            if(indexStartApplication>firstApplication)
                            {
                                int indexOfCloseStartApp = text.IndexOf(">", indexStartApplication);

                                if (indexOfCloseStartApp > indexStartApplication)
                                {
                                    text = text.Remove(indexStartApplication, indexOfCloseStartApp-indexStartApplication + 1);
                                    flag = true;
                                }
                            }

                            int indexEndApplication = text.IndexOf("</application>", firstApplication + 1);

                            if(indexEndApplication< lastApplication)
                            {
                                flag = true;

                                text = text.Remove(indexEndApplication, 14);
                            }

                        }
                    }

                    textBox2.Text = text;
                }
            }

            tabControl1.SelectedIndex = 1;
        }

        private DisriqtConfig DisriqtConfig
        {
            get;set;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog() { Filter = "config files (*.config)|*.config|All files (*.*)|*.*", RestoreDirectory = true };

            DisriqtConfig disriqtConfig = new DisriqtConfig() { Adverts = uxAdverts.Text, GoogleService = uxGoogleServiceId.Text };

            if(dlg.ShowDialog()== DialogResult.OK)
            {
                disriqtConfig.FileName = dlg.FileName;

                DisriqtConfig.GoogleService = uxGoogleServiceId.Text;
                DisriqtConfig.Adverts = uxAdverts.Text;

                DisriqtConfig.YOUR_FACEBOOK_APP_ID = uxYOUR_FACEBOOK_APP_ID.Text;
                DisriqtConfig.YOUR_PACKAGE_NAME = uxYOUR_PACKAGE_NAME.Text;

                disriqtConfig.Save();

                DisriqtConfig = disriqtConfig;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DisriqtConfig.FileName != string.Empty)
            {
                DisriqtConfig.GoogleService = uxGoogleServiceId.Text;
                DisriqtConfig.Adverts = uxAdverts.Text;

                DisriqtConfig.YOUR_FACEBOOK_APP_ID = uxYOUR_FACEBOOK_APP_ID.Text;
                DisriqtConfig.YOUR_PACKAGE_NAME = uxYOUR_PACKAGE_NAME.Text;
                DisriqtConfig.Save();
            }
            else saveAsToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() { Filter = "config files (*.config)|*.config|All files (*.*)|*.*", RestoreDirectory = true };
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                DisriqtConfig disriqtConfig = new DisriqtConfig();

                if (disriqtConfig.Load(dlg.FileName))
                {
                    DisriqtConfig = disriqtConfig;

                    uxAdverts.Text = DisriqtConfig.Adverts;
                    uxGoogleServiceId.Text = DisriqtConfig.GoogleService;
                    uxYOUR_FACEBOOK_APP_ID.Text = DisriqtConfig.YOUR_FACEBOOK_APP_ID;
                    uxYOUR_PACKAGE_NAME.Text = DisriqtConfig.YOUR_PACKAGE_NAME;
                }
            }
        }
    }
}
