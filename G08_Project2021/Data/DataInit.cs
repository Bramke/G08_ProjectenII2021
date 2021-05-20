using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Type = G08_Project2021.Models.Domein.Type;

namespace G08_Project2021.Data
{
    public class DataInit
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public DataInit(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await Initialize(); 

            }

        }

        private async Task Initialize()
        {

            Gebruiker arthur = new Gebruiker("Degitise", "ArthurG", "Geeraert", Rol.KLANT, GebruikerStatus.ACTIEF, "Arthur", "arthur.geeraert@student.hogent.be");
            IdentityUser user = new IdentityUser { UserName = arthur.Gebruikersnaam, Email =  arthur.Email };     
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "klant"));

            Gebruiker samy = new Gebruiker("Degitise", "Samy", "Agnaou", Rol.KLANT, GebruikerStatus.ACTIEF, "Samy", "samy.agnaou@student.hogent.be");
            IdentityUser user2 = new IdentityUser { UserName = samy.Gebruikersnaam, Email = samy.Email };
            await _userManager.CreateAsync(user2, "P@ssword1");
            await _userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "klant"));

            Gebruiker bram = new Gebruiker("Degitise", "bram", "", Rol.TECHNIEKER, GebruikerStatus.ACTIEF, "bram", "bram@student.hogent.be");
            Gebruiker thibault = new Gebruiker("Degitise", "Thibault", "", Rol.TECHNIEKER, GebruikerStatus.ACTIEF, "thibault", "thibault@student.hogent.be");



            Ticket ticket1 = new Ticket("Kan niet meer aanmelden door een systeemfout", Status.AANGEMAAKT, "Aanmeld Fout", Type.NORMAAL, arthur, bram);
            Ticket ticket2 = new Ticket("Kon een factuur niet betalen", Status.AANGEMAAKT, "Betaal Fout", Type.NORMAAL, arthur, thibault);
            Ticket ticket3 = new Ticket("Probleem bij het versturen van email naar jullie emailadres", Status.AANGEMAAKT, "Email Fout", Type.NORMAAL, arthur, thibault);
            Ticket ticket4 = new Ticket("Kon een factuur niet betalen", Status.AANGEMAAKT, "Betaal Fout", Type.NORMAAL, samy, thibault);
            Ticket ticket5 = new Ticket("Kreeg een 404 error bij het betreden van jullie website", Status.AANGEMAAKT, "404 Fout", Type.NORMAAL, arthur, bram);
            Ticket ticket6 = new Ticket("Kreeg een 404 error bij het betreden van jullie website", Status.AFGEHANDELD, "404 Fout", Type.NORMAAL, arthur, bram);
            Ticket ticket7 = new Ticket("Kan niet meer aanmelden door een systeemfout", Status.AFGEHANDELD, "Aanmeld Fout", Type.BELANGRIJK, arthur, thibault);
            Ticket ticket8 = new Ticket("Probleem bij het versturen van email naar jullie emailadres", Status.AFGEHANDELD, "Email Fout", Type.NIETBELANGRIJK, arthur, thibault);


            ContractType ct = new ContractType("Platinum", AanmaakTypeManier.APPLICATIE, 3, 3, 1000.00);
            ContractType ct2 = new ContractType("Gold", AanmaakTypeManier.APPLICATIE, 5, 2, 500.00);
            ContractType ct3 = new ContractType("Silver", AanmaakTypeManier.APPLICATIE, 7, 2, 300.00);
            ContractType ct4 = new ContractType("Bronze", AanmaakTypeManier.APPLICATIE, 10, 1, 150.00);
            

            Contract contract1 = new Contract(ct, DateTime.Parse("22/07/2019"), arthur);
            Contract contract2 = new Contract(ct, DateTime.Parse("12/05/2016"), samy);
            Contract contract3 = new Contract(ct2, DateTime.Parse("12/03/2016"), arthur);
            Contract contract4 = new Contract(ct2, DateTime.Parse("12/05/2020"), samy);
            Contract contract5 = new Contract(ct3, DateTime.Parse("12/08/2021"), arthur);
            Contract contract6 = new Contract(ct2, DateTime.Parse("18/09/2020"), arthur);
            Contract contract7 = new Contract(ct, DateTime.Parse("01/05/2018"), arthur);
            Contract contract8 = new Contract(ct4, DateTime.Parse("12/04/2020"), arthur);
            contract1.BepaalStatus();
            contract2.BepaalStatus();
            contract3.BepaalStatus();
            contract4.BepaalStatus();
            contract5.BepaalStatus();
            contract6.BepaalStatus();
            contract7.BepaalStatus();
            contract8.BepaalStatus();

           /* arthur.AddTicket(ticket1);
            arthur.AddTicket(ticket2);
            arthur.AddTicket(ticket3);
            samy.AddTicket(ticket4);*/
           /* arthur.Contracten.Add(contract1);
            arthur.Contracten.Add(contract3);
            arthur.Contracten.Add(contract5);
            arthur.Contracten.Add(contract6);
            arthur.Contracten.Add(contract7);
            arthur.Contracten.Add(contract8);
            samy.Contracten.Add(contract2);
            samy.Contracten.Add(contract4);*/



            _dbContext.Gebruikers.Add(bram);
            _dbContext.Gebruikers.Add(arthur);
            _dbContext.Gebruikers.Add(samy);
            _dbContext.Gebruikers.Add(thibault);

            _dbContext.Tickets.Add(ticket1);
            _dbContext.Tickets.Add(ticket2);
            _dbContext.Tickets.Add(ticket3);
            _dbContext.Tickets.Add(ticket4);
            _dbContext.Tickets.Add(ticket5);
            _dbContext.Tickets.Add(ticket6);
            _dbContext.Tickets.Add(ticket7);
            _dbContext.Tickets.Add(ticket8);
            _dbContext.Contracten.Add(contract1);
            _dbContext.Contracten.Add(contract2);
            _dbContext.Contracten.Add(contract3);
            _dbContext.Contracten.Add(contract4);
            _dbContext.Contracten.Add(contract5);
            _dbContext.Contracten.Add(contract6);
            _dbContext.Contracten.Add(contract7);
            _dbContext.Contracten.Add(contract8);

            _dbContext.SaveChanges();
        }
    }
}
