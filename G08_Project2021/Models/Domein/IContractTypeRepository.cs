using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public interface IContractTypeRepository
    {
        void Add(ContractType contractType);
        IEnumerable<ContractType> GetAll();
        ContractType GetById(int id);
        void SaveChanges();
    }
}
