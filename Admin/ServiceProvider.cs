using Admin.lib.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.lib.Modules
{
    public class ServiceProvider
    {
        List<Provider> Providers = new List<Provider>();

        public void AddProvider()
        {
            Provider prov = new Provider();

            Console.WriteLine("Emter Company Name");
            prov.NameCompany = Console.ReadLine();

            Console.WriteLine("Enter Logo");
            prov.LigoURL = Console.ReadLine();

            prov.Procent = Double.Parse(Console.ReadLine());


            Console.WriteLine("Enter LIst prefix");
            bool exit = true;
            int pre = 0;
            do
            {
                exit = Int32.TryParse(Console.ReadLine(), out pre);
                if (exit)
                {
                    prov.Prefix.Add(pre);
                }
            }
            while (!exit);
            
        }

    }
}
