using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Repository
{
    public class PogingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Poging> _pogingen;

        public PogingRepository(ApplicationDbContext context)
        {
            _context = context;
            _pogingen = _context.Pogingen;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Add(Poging poging)
        {
            _pogingen.Add(poging);
        }
    }
}
