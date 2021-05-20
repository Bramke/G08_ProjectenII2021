using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public interface ITicketRepository
    {
        Ticket GetById(int Id);
        IEnumerable<Ticket> GetByGebruiker(Gebruiker gebruiker);
        void Add(Ticket ticket);
        void AnnuleerTicket(Ticket ticket);

        IEnumerable<Ticket> GetByTitel(string titel);

        IEnumerable<Ticket> GetAll();


        void Delete(Ticket ticket);

        void SaveChanges();
    }
}
