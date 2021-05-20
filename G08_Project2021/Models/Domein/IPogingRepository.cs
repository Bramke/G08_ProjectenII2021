using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public interface IPogingRepository
    {
        void Add(Poging poging);
        void SaveChanges();
    }
}
