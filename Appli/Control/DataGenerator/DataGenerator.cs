using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;

namespace WildCircus
{
    public static class DataGenerator
    {
        public static void Init()
        {
            using (var context = new WildCircusContext())
            {
                if(context.Exists())
                {
                    return;
                }

                context.Database.EnsureCreated();

                CreateShow();
                CreateArtist();
                CreateCategories();
            }
        }

        private static void CreateShow()
        {
            Show show1 = new Show()
            {
                Name = "Show 1 Name",
                Description = "Show 1 Description",
                StartDate = DateTime.Parse("01/01/2020"),
                EndDate = DateTime.Parse("31/05/2020"),
                Duration = 2,
                State = "Reservation open",
                Picture = "Show1.jpg"
            };
            show1.GeneratePerformance();

            Show show2 = new Show()
            {
                Name = "Show 2 Name",
                Description = "Show 2 Description",
                StartDate = DateTime.Parse("01/06/2020"),
                EndDate = DateTime.Parse("31/12/2020"),
                Duration = 2,
                State = "Reservation open",
                Picture = "Show2.jpg"
            };
            show2.GeneratePerformance();

            using(var context = new WildCircusContext())
            {
                context.Shows.Add(show1);
                context.Shows.Add(show2);
                context.SaveChanges();
            }

        }

        private static void CreateArtist()
        {
            var context = new WildCircusContext();

            string nom = "Le clown sympa";
            string description = "Quibus ita sceleste patratis Paulus cruore perfusus reversusque ad principis castra multos coopertos paene catenis adduxit in squalorem deiectos atque maestitiam, quorum adventu intendebantur eculei uncosque parabat carnifex et tormenta. et ex is proscripti sunt plures actique in exilium alii, non nullos gladii consumpsere poenales. nec enim quisquam facile meminit sub Constantio, ubi susurro tenus haec movebantur, quemquam absolutum.";
            Artist currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Clown.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Clown.jpg";
            context.Artists.Add(currentArtist);

            nom = "L'atout charme";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Charme.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Charme.jpg";
            context.Artists.Add(currentArtist);

            nom = "Le super magicien";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Doctor-Strange.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Doctor-Strange.jpg";
            context.Artists.Add(currentArtist);

            nom = "Nos petits chanteurs";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Expandable.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Expandable.jpg";
            context.Artists.Add(currentArtist);

            nom = "Le nain trop fort";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Gimli.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Gimli.jpg";
            context.Artists.Add(currentArtist);

            nom = "Le mec à l'haleine qui déchire";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Godzilla.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Godzilla.jpg";
            context.Artists.Add(currentArtist);

            nom = "Une vrai licorne";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Licorne.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Licorne.jpg";
            context.Artists.Add(currentArtist);

            nom = "Le chauve";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Marcheur-blanc.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Marcheur-blanc.jpg";
            context.Artists.Add(currentArtist);

            nom = "Un mec bizarre";
            currentArtist = ArtistFactory.Create(nom, description);
            currentArtist.PicturesURIBig = "/View/Images/Big/Witcher.jpg";
            currentArtist.PicturesURISmall = "/View/Images/Small/Witcher.jpg";
            context.Artists.Add(currentArtist);
            context.SaveChanges();
        }

        private static void CreateCategories()
        {
            Category catVip = new Category()
            {
                Name = "VIP",
                Price = 50
            };

            Category catNormal = new Category()
            {
                Name = "Normal",
                Price = 30
            };

            Category ecoVip = new Category()
            {
                Name = "Eco",
                Price = 15
            };

            using (var context = new WildCircusContext())
            {
                context.Categories.Add(catVip);
                context.Categories.Add(catNormal);
                context.Categories.Add(ecoVip);
                context.SaveChanges();
            }

        }


    }
}
