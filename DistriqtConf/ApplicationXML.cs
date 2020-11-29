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
using System.Net;



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

                string xml = uxAneList.Text.Replace(remove, "");
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

        private void Add(string xml, string comment = "")
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList list = doc.SelectNodes("/extensions/extensionID");
            if (list.Count > 0)
            {
                foreach (XmlNode node in list)
                {
                    string lib = node.InnerXml;
                    if (!labrery.ContainsKey(lib))
                    {
                        labrery.Add(lib, comment);
                    }
                }
            }

        }

        private void AddManifest(string xml)
        {
            xml = xml.Replace("android:", "android_");

            if(xml.Contains("android.permission.READ_PHONE_STATE"))
            {
                Console.WriteLine("test");
            }

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
                Add(Properties.Resources.Adverts, "Adverts");
                AddManifest(Properties.Resources.AdvertsManifest);
            }


            if (checkBox7.Checked)
            {
                Add(Properties.Resources.FacebookSignin, "FacebookSignin");
                AddManifest(Properties.Resources.FaceBookSignINManifest);
            }

            if (checkBox1.Checked)
            {
                Add(Properties.Resources.Facebook, "Facebook");
                AddManifest(Properties.Resources.FacebookManifest );
            }

            if (checkBox2.Checked)
            {
                Add(Properties.Resources.GameService, "GameService");
                AddManifest(Properties.Resources.GameSeviceManifest);
            }

            if (checkBox3.Checked)
            {
                Add(Properties.Resources.InApp, "InApp");
                AddManifest(Properties.Resources.InAppManifest);
            }

            if(checkBox5.Checked)
            {
                Add(Properties.Resources.Application, "Application");
                //AddManifest(Properties.Resources.ApplicationManifest); // !!!!
            }

            if (checkBox6.Checked)
            {
                Add(Properties.Resources.ApplicationRater, "AppRater");
                AddManifest(Properties.Resources.ApplicationRateManifest);
            }

            if(checkBox8.Checked)
            {
                Add(Properties.Resources.NativeWebView, "NativeWebView");
                AddManifest(Properties.Resources.NativeWebViewManifest);
            }

            if(uxMultidex.Checked)
            {
                Add(Properties.Resources.Multidex, "Multidex");
            }



            AddManifest(Properties.Resources.CommonManifest);

            Dictionary<string, string> downloads = new Dictionary<string, string>();
            Dictionary<string, string> notFoundDownloads = new Dictionary<string, string>();
            string notFoundDownloadsStr = string.Empty;

            if (labrery.Keys.Count > 0)
            {
                string outText = "<extensions>" + Environment.NewLine;
                foreach (string key in labrery.Keys)
                {
                    outText += "\t<extensionID>" + key + "</extensionID>" + (uxComments.Checked ? (labrery[key] == string.Empty ? "" : "<!-- " + labrery[key] + " -->") : "") + Environment.NewLine;
                }

                outText += "</extensions>" + Environment.NewLine;

                uxAneList.Text = outText;

                string[] listAne = Properties.Resources.ANEs.Split('\n');

                foreach (string key in labrery.Keys)
                {
                    bool exists = false;
                    foreach(string url in listAne)
                    {
                        if(url.Contains(key))
                        {
                            exists = true;

                            if(!downloads.Keys.Contains(key))
                            {
                                downloads.Add(key, url);
                            }
                        }

                    }

                    if(!exists)
                    {
                        notFoundDownloads.Add(key, key);
                        notFoundDownloadsStr += key + " " + labrery[key] + Environment.NewLine;
                    }
                }
            }

            if (outDoc != null)
            {
                //MessageBox.Show(outDoc.ToString().Replace("android_", "android:"));

                XElement root = (XElement)outDoc.FirstNode;

                if (uxMultidex.Checked)
                {
                    foreach (XElement element in outDoc.Descendants("application"))
                    {
                        if (element.Attribute("android_name") == null)
                            element.Add(new XAttribute("android_name", "androidx.multidex.MultiDexApplication"));
                    }
                }

                

                /*while (true)
                {
                    XElement uses_permission = null;

                    foreach (XElement element in outDoc.Descendants("uses-permission"))
                    {
                        if(element.Parent!=outDoc.FirstNode)
                        {
                            uses_permission = element;
                            break;
                        }
                    }

                    if (uses_permission!=null)
                    {
                        uses_permission.Remove();
                        root.Add(uses_permission);
                        
                    }
                    else break;
                }*/



                if (DisriqtConfig != null)
                {
                    string text = outDoc.ToString();
                    text = text.Replace("XXXXXXXXXXXX", DisriqtConfig.GoogleService);
                    text = text.Replace("ca-app-pub-AAAAAAAAAAAAAAAA~XXXXXXXXXX", DisriqtConfig.Adverts);

                    text = text.Replace("[YOUR_FACEBOOK_APP_ID]", DisriqtConfig.YOUR_FACEBOOK_APP_ID);
                    text = text.Replace("YOUR_PACKAGE_NAME", DisriqtConfig.YOUR_PACKAGE_NAME);

                    //
                    //You will need to replace the instances of FACEBOOK_APP_ID and FACEBOOK_APP_NAME with the relevant settings from your Facebook app. (Don't include the braces).
                    //You will need to replace the instances of APPLICATION_PACKAGE with your applications java package name(generally your AIR application id prefixed with air.) eg air.com.distriqt.test.
                    //

                    text = text.Replace("FACEBOOK_APP_NAME", DisriqtConfig.FACEBOOK_APP_NAME);
                    text = text.Replace("FACEBOOK_APP_ID", DisriqtConfig.YOUR_FACEBOOK_APP_ID);
                    text = text.Replace("APPLICATION_PACKAGE", DisriqtConfig.YOUR_PACKAGE_NAME);


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

                    /*try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(text);

                        XMLHelper.XMLSort.sortXML(doc);

                        text = doc.OuterXml;

                    }
                    catch(Exception ee)
                    {

                    }*/

                    text = text.Replace("android_", "android:");

                    textBox2.Text = text;
                }
            }

            if(downloads.Keys.Count>0)
            {
                if(MessageBox.Show("Download anes?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    FolderBrowserDialog dlg = new FolderBrowserDialog();
                    if(dlg.ShowDialog()== DialogResult.OK)
                    {
                        foreach(string file in downloads.Keys)
                        {
                            Download(downloads[file], dlg.SelectedPath + "\\" + file + ".ane");
                        }
                    }
                }
            }

            tabControl1.SelectedIndex = 1;
        }

        private void Download(string uri, string outFile)
        {
            /*WebClient webClient = new WebClient();
            webClient.DownloadFile(url, outFile);*/

            //webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            //webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            //webClient.DownloadFileAsync(new Uri(url), outFile);

            using (WebClient client = new WebClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                client.DownloadFile(uri, outFile);
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
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

                disriqtConfig.GoogleService = uxGoogleServiceId.Text;
                disriqtConfig.Adverts = uxAdverts.Text;

                disriqtConfig.YOUR_FACEBOOK_APP_ID = uxYOUR_FACEBOOK_APP_ID.Text;
                disriqtConfig.YOUR_PACKAGE_NAME = uxYOUR_PACKAGE_NAME.Text;
                disriqtConfig.FACEBOOK_APP_NAME = uxFACEBOOK_APP_NAME.Text;

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
                DisriqtConfig.FACEBOOK_APP_NAME = uxFACEBOOK_APP_NAME.Text;
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
                    uxFACEBOOK_APP_NAME.Text = disriqtConfig.FACEBOOK_APP_NAME;
                }
            }
        }

        private void diffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateXmlToolStripMenuItem_Click(sender, e);


        }
    }
}
