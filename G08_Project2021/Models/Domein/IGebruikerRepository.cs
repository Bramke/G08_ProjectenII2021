using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByGebruikersnaamKlant(string Gebruikersnaam);
        Gebruiker GetByGebruikersnaamTechnieker(string Gebruikersnaam);

        Gebruiker GetById(int id);
        IEnumerable<Gebruiker> GetAll();
        void SaveChanges();
    }
}
