using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using G08_Project2021.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Type = G08_Project2021.Models.Domein.Type;
namespace G08_Project2021.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IGebruikerRepository _gebruikerRepository;


        public TicketController(ITicketRepository ticketRepository, IGebruikerRepository gebruikerRepository)
        {
            _ticketRepository = ticketRepository;
            _gebruikerRepository = gebruikerRepository;
        }


        public IActionResult Index(string search)
        {
            ViewData["CurrentFilter"] = search;
            string gebruikersnaam = User.Identity.Name;
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaamKlant(gebruikersnaam);
            IEnumerable<Ticket> tickets = null;
            if (!string.IsNullOrEmpty(search))
            {
                 tickets = _ticketRepository.GetByTitel(search).ToList();
            }else
             tickets = _ticketRepository.GetByGebruiker(gebruiker).ToList();
            ViewData["Alle"] = tickets.Count();
            ViewData["Ended"] = tickets.Where(t => t.Status == Status.AFGEHANDELD).Count();
            ViewData["belangrijk"] = tickets.Where(t => t.Type == Type.BELANGRIJK).Count();
            ViewData["nietBelangrijk"] = tickets.Where(t => t.Type == Type.NIETBELANGRIJK).Count();
            ViewData["normaal"] = tickets.Where(t => t.Type == Type.NORMAAL).Count();
            return View(tickets);
        }
        public IActionResult Edit(int id)
        {
            Ticket ticket = _ticketRepository.GetById(id);
            if (ticket == null)
                return NotFound();
            ViewData["Techniekers"] = GetTechniekersAsSelectedList();

            return View(new TicketViewModel(ticket));
        }

        [HttpPost]
        public IActionResult Edit(TicketViewModel ticketViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = null;
                try
                {
                    ticket = _ticketRepository.GetById(id);
                    MapTicketViewModelToTicket(ticketViewModel, ticket);
                    _ticketRepository.SaveChanges();
                    TempData["message"] = $"{ticket.Titel} is succesvol upgedate.";
                }
                catch
                {
                    TempData["error"] = $"{ticket?.Titel} is niet upgedate...";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Techniekers"] = GetTechniekersAsSelectedList();
            return View(nameof(Edit), ticketViewModel);
        }

        public IActionResult Create()
        {
            ViewData["Techniekers"] = GetTechniekersAsSelectedList();
            return View(nameof(Edit), new TicketViewModel());
        }

        [HttpPost]
        public IActionResult Create(TicketViewModel ticketViewModel)
        {

            if (ModelState.IsValid)
            {
                string gebruikersnaam = User.Identity.Name;
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaamKlant(gebruikersnaam);
                try
                {
                    Gebruiker technieker = _gebruikerRepository.GetByGebruikersnaamTechnieker(ticketViewModel.Technieker);
                    
                    Ticket ticket = new Ticket(ticketViewModel.Titel, ticketViewModel.Omschrijving, gebruiker);
                    MapTicketViewModelToTicket(ticketViewModel, ticket);
                    _ticketRepository.Add(ticket);
                    _ticketRepository.SaveChanges();
                    TempData["message"] = $" {ticket.Titel} is aangemaakt.";
                }
                catch
               {
                    TempData["error"] = "Er is iets misgelopen bij het aanmaken van een ticket";
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Techniekers"] = GetTechniekersAsSelectedList();
            return View(nameof(Edit));
        }

        public IActionResult Details(int id)
        {
            Ticket ticket = _ticketRepository.GetById(id);
            if (ticket == null)
                return NotFound();
            return View(new TicketViewModel(ticket));

        }

        public IActionResult Delete(int id)
        {
            Ticket ticket = _ticketRepository.GetById(id);
            if (ticket == null)
                return NotFound();

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmd(int id)
        {
            Ticket ticket = null;
            try
            {
                ticket = _ticketRepository.GetById(id);
                _ticketRepository.Delete(ticket);
                _ticketRepository.SaveChanges();
                TempData["message"] = $"Ticket is verwijderd {ticket.Titel}.";
            }
            catch
            {
                TempData["error"] = $"{ticket?.Titel} is niet verwijderd…";
            }
            return RedirectToAction(nameof(Index));
        }


        public SelectList GetTechniekersAsSelectedList()
        {
            //return new SelectList(_gebruikerRepository.GetAll().Where(g => g.Rol == Rol.TECHNIEKER).OrderBy(g => g.Naam), nameof(Gebruiker.Id), nameof(Gebruiker.Naam));
            //throw new NotImplementedException();
            // TODO:Opvullen an Id en Naam, Zie WEB .
             return new SelectList(_gebruikerRepository.GetAll().Where(g => g.Rol == Rol.TECHNIEKER),nameof(Gebruiker.Id),nameof(Gebruiker.Gebruikersnaam));
        }
        private void MapTicketViewModelToTicket(TicketViewModel ticketViewModel, Ticket ticket)
        {
            ticket.Titel = ticketViewModel.Titel;
            ticket.Omschrijving = ticketViewModel.Omschrijving;
            ticket.Status = ticketViewModel.Status;
            ticket.Type = ticketViewModel.Type;
            ticket.Klant = ticketViewModel.Klant;
            // ticket.Technieker = _gebruikerRepository.GetByGebruikersnaamTechnieker(ticketViewModel.Technieker);

        }

    }
}