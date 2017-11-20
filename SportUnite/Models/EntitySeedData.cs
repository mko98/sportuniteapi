using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SportUnite.DAL;
using SportUnite.Domain.Models;


namespace SportUnite.WEBUI.Models
{
    public static class EntitySeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppEventEntityDbContext context = app.ApplicationServices.GetRequiredService<AppEventEntityDbContext>();

            SportComplex sportComplex = new SportComplex() { Name = "De jager", Address = "Hoofdweg", City = "Nieuwendijk", HouseNumber = "43", PostalCode = "4269LF" };
            SportHall sportHall = new SportHall() { Name = "Hal 1", MinPerson = 2, MaxPerson = 6 };
            Invoice invoice = new Invoice() { Name = "Factuur 1" };
            Sport sport = new Sport() { Name = "Voetbal", Description = "11 tegen 11" };
            SportEvent sportEvent = new SportEvent() { Name = "Voetbaltoernooi in De Jager", Sport = sport, SportHall = sportHall, Price = 25 };
            SportAttribute sportAttribute = new SportAttribute() { Name = "Voetbal doel", Description = "Een doel om in te scoren", NotUsable = false };
            SportSportAttribute sportSportAttribute = new SportSportAttribute() { Sport = sport, SportAttribute = sportAttribute };

            sportHall.SportComplex = sportComplex;
            invoice.SportComplex = sportComplex;

            if (!context.SportComplex.Any())
            {
                context.SportComplex.Add(sportComplex);

            }

            if (!context.SportHall.Any())
            {
                context.SportHall.Add(sportHall);

            }

            if (!context.Invoice.Any())
            {
                context.Invoice.Add(invoice);

            }

            if (!context.Sport.Any())
            {
                context.Sport.Add(sport);
            }

            if (!context.SportEvent.Any())
            {
                context.SportEvent.Add(sportEvent);
            }

            if (!context.SportAttribute.Any())
            {
                context.SportAttribute.Add(sportAttribute);

            }

            if (!context.SportSportAttribute.Any())
            {
                context.SportSportAttribute.Add(sportSportAttribute);
                sport.SportSportAttributes.Add(sportSportAttribute);

            }
            context.SaveChanges();
        }
    }
}