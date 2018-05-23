using Admin.lib.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Admin.lib.Modules
{
    public class ServiceProvider
    {
        List<Provider> Providers = new List<Provider>();

        List<int> ProvidersPrefix = new List<int>(); 

        public void AddProvider()
        {
            Provider prov = new Provider();

            Console.WriteLine("Emter Company Name");
            prov.NameCompany = Console.ReadLine();

            Console.WriteLine("Enter Logo");
            prov.LigoURL = Console.ReadLine();

            prov.Procent = Double.Parse(Console.ReadLine());


            Console.WriteLine("Enter LIst prefix" + "For exit press ENTER twis");
            bool exit = true;
            int pre = 0;
            do
            {
                exit = Int32.TryParse(Console.ReadLine(), out pre);
                if (exit && IsExistPrefix(pre))
                {
                    prov.Prefix.Add(pre);
                }
            }
            while (exit);
            
            if (IsExistProvider(prov))
            {
                Providers.Add(prov);
                ProvidersPrefix.AddRange(prov.Prefix);
            }

        }

        private bool IsExistProvider(Provider pro)
        {
            if (Providers.Where(w => w.NameCompany == pro.NameCompany).Count() > 0)
            {
                Console.WriteLine("Takoy provider uzhe est");
                return false;
            }
            return true;
        }

        private bool IsExistPrefix(int pref)
        {
            if (ProvidersPrefix.Where(w => w == pref).Count() > 0)
            {
                Console.WriteLine("Takoy prefix est");
                return false;
            }
            return true;

        }

        private void AddProvidetToXML(Provider pro)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement elem = doc.CreateElement("Provider");

            XmlElement LogoURL = doc.CreateElement("LogoURL");
            LogoURL.InnerText = pro.LigoURL;

            XmlElement NameCompay = doc.CreateElement("NameCompany");
            NameCompay.InnerText = pro.NameCompany;

            XmlElement Procent = doc.CreateElement("Procent");
            Procent.InnerText = pro.Procent.ToString();

            XmlElement Prefixs = doc.CreateElement("Prefixs");
            foreach (var item in pro.Prefix)
            {
                XmlElement Prefix = doc.CreateElement("Prefix");
                Prefix.InnerText = item.ToString();
                Prefixs.AppendChild(Prefix);
            }

            elem.AppendChild(LogoURL);
            elem.AppendChild(NameCompay);
            elem.AppendChild(Procent);
            elem.AppendChild(Prefixs);

            doc.AppendChild(elem);

            doc.Save("Providers.xml");
        }
    }
}
