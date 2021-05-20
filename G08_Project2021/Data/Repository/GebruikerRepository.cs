using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Repository
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DbSet<Gebruiker> _gebruikers;
        private readonly ApplicationDbContext _dbContext;

        public GebruikerRepository(ApplicationDbContext context)
        {
            _gebruikers = context.Gebruikers;
            _dbContext = context;
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetByGebruikersnaamKlant(string Gebruikersnaam)
        {
            return _gebruikers.Where(g => g.Rol == Rol.KLANT).SingleOrDefault(g => g.Gebruikersnaam == Gebruikersnaam);

        }

        public Gebruiker GetById(int id)
        {
            return _gebruikers.SingleOrDefault(g => g.Id == id);
        }
        public Gebruiker GetByGebruikersnaamTechnieker(string Gebruikersnaam)
        {
            return _gebruikers.Where(g => g.Rol == Rol.TECHNIEKER).SingleOrDefault(g => g.Gebruikersnaam == Gebruikersnaam);
        }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
