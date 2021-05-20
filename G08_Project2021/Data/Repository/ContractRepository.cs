using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Contract> _contracten;

        public ContractRepository(ApplicationDbContext context)
        {
            _context = context;
            _contracten = _context.Contracten;
        }

        public Contract GetById(int Id)
        {
            return _context.Contracten.Include(c => c.ContractType).SingleOrDefault(t => t.Id == Id);
        }
        public IEnumerable<Contract> GetAll()
        {
            return _contracten.ToList();
        }
        public void Add(Contract contract)
        {
            _contracten.Add(contract);
        }

        public IEnumerable<Contract> GetByGebruiker(Gebruiker gebruiker)
        {
            return _context.Contracten.Where(t => t.Gebruiker == gebruiker);
        }

        public void Delete(Contract contract)
        {
            _context.Remove(contract);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
