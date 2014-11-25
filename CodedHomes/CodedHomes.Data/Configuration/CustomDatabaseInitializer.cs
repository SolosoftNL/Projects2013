using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializer : 
        DropCreateDatabaseIfModelChanges<DataContext>
        //CreateDatabaseIfNotExists<DataContext>
     {
        protected override void Seed(DataContext context)
        {
            string[] descriptions = new string[10]{
            "Vriendelijke buurt met aardige buren.",
            "Een werkelijk schitterend huis.",
            "Vrijstaand in een groene omgeving.",
            "Energiezuinig met een groote tuin",
            "Veel opslagruimte en grote badkamers",
            "Goed onderhouden door vorige bewoners",
            "Inclusief zwembad en basketbal veld.",
            "De tuin heeft wat onderhoud nodig maar het huis is in optimale staat!",
            "Bevat een extra grote werkkamer voor invulling van diverse hobby's!",
            "Dicht in de buurt van scholen en winkelcentra."           
            };

            int count = 10;

            while (count--!=0)
            {
                Home home = new Home();
                home.StreetAdress =  string.Format("Straat 12{0}", count);
                home.City = "Schoorl";
                home.ZipCode = "1234ss";
                home.Bedrooms = ((count % 2 == 1)) ? 4 : 3;
                home.Bathrooms = (home.Bedrooms - 2);
                home.SquareFeet = 100 + count;
                home.Price = 300000 + (count * 1000);
                home.ImageName = string.Format("home-{0}.png", ((count % 2 == 1) ? 0 : 1));
                home.Description = descriptions[count];
                context.Homes.Add(home);
            }

            base.Seed(context);
        }
    }
}
