using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Repository
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ContractType> _contractTypes;

        public ContractTypeRepository(ApplicationDbContext context)
        {
            _context = context;
            _contractTypes = _context.ContractTypes;

        }
        public void Add(ContractType contractType)
        {
            _contractTypes.Add(contractType);
            
        }
        public IEnumerable<ContractType> GetAll()
        {
            return _contractTypes.ToList();
        }
        public ContractType GetById(int id)
        {
            return _contractTypes.SingleOrDefault(c => c.Id == id);
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
