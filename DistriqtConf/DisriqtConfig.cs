﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DistriqtConf
{
    class DisriqtConfig
    {
        public string FileName
        {
            get;set;
        }
        public string Adverts
        {
            get;set;
        }

        public string GoogleService
        {
            get;set;
        }

        public string YOUR_PACKAGE_NAME
        {
            get;set;
        }

        public string YOUR_FACEBOOK_APP_ID
        {
            get;set;
        }

        public void Save()
        {
            Save(FileName);
        }
        public void Save(string fileName)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<settings version = \"1.0\"/>");

            doc.FirstChild.Attributes.Append(doc.CreateAttribute("Adverts")).Value = Adverts;
            doc.FirstChild.Attributes.Append(doc.CreateAttribute("GoogleService")).Value = GoogleService;
            doc.FirstChild.Attributes.Append(doc.CreateAttribute("YOUR_PACKAGE_NAME")).Value = YOUR_PACKAGE_NAME;
            doc.FirstChild.Attributes.Append(doc.CreateAttribute("YOUR_FACEBOOK_APP_ID")).Value = YOUR_FACEBOOK_APP_ID;

            doc.Save(fileName);

            FileName = fileName;
        }

        public DisriqtConfig()
        {
            YOUR_PACKAGE_NAME = "YOUR_PACKAGE_NAME";
            YOUR_FACEBOOK_APP_ID = "YOUR_FACEBOOK_APP_ID";
        }

        public bool Load(string Filename)
        {
            FileName = Filename;

            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);

            Adverts = doc.FirstChild.Attributes["Adverts"].Value;
            GoogleService = doc.FirstChild.Attributes["GoogleService"].Value;

            try
            {
                YOUR_PACKAGE_NAME = doc.FirstChild.Attributes["YOUR_PACKAGE_NAME"].Value;
                YOUR_FACEBOOK_APP_ID = doc.FirstChild.Attributes["YOUR_FACEBOOK_APP_ID"].Value;
            }
            catch
            {

            }

            return true;
        }
    }
}
