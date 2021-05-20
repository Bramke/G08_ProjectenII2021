using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public interface IContractRepository
    {
        Contract GetById(int Id);
        IEnumerable<Contract> GetByGebruiker(Gebruiker gebruiker);
        void SaveChanges();
        IEnumerable<Contract> GetAll();
        void Add(Contract contract);
    }
}
