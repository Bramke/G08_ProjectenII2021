using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace G08_Project2021.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Ticket> _tickets;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
            _tickets = _context.Tickets;
        }

        public void Add(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void AnnuleerTicket(Ticket ticket)
        {
            _tickets.SingleOrDefault(t => t.Id == ticket.Id).Status = Status.GEANNULEERD;
        }

        public IEnumerable<Ticket> GetByTitel(string titel)
        {
            return _context.Tickets.Where(t=>t.Titel.Contains(titel));
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets.ToList();
        }

        public Ticket GetById(int Id)
        {
            return _context.Tickets.Include(x => x.Technieker).SingleOrDefault(t => t.Id == Id);
        }


        public IEnumerable<Ticket> GetByGebruiker(Gebruiker gebruiker)
        {
            return _context.Tickets.Where(t => t.Klant == gebruiker);
        }

        public void Delete(Ticket ticket)
        {
            _context.Remove(ticket);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       
    }
}
