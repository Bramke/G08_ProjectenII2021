using System.Linq;
using G08_Project2021.Models.Domein;
using G08_Project2021.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace G08_Project2021.Controllers
{
    [Authorize]
    public class StatistiekController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public StatistiekController(ITicketRepository ticketRepository, IContractRepository contractRepository, IGebruikerRepository gebruikerRepository)
        {
            _ticketRepository = ticketRepository;
            _contractRepository = contractRepository;
            _gebruikerRepository = gebruikerRepository;
        }
        public IActionResult Index()
        {

            ViewData["kl"] = _ticketRepository.GetAll().Count().ToString();
            ViewData["tk"] = _gebruikerRepository.GetAll().Count().ToString();
            ViewData["cl"] = _contractRepository.GetAll().Count().ToString();

            ViewData["open"] = _ticketRepository.GetAll()
                .Where(e => e.Status != Status.GEANNULEERD || e.Status != Status.AFGEHANDELD).ToList().Count().ToString();
            ViewData["closed"] = _ticketRepository.GetAll()
                .Where(e => e.Status == Status.GEANNULEERD || e.Status == Status.AFGEHANDELD).ToList().Count().ToString();
            ViewData["total"] = _ticketRepository.GetAll()
                .Where(e => e.Status == Status.WACHTENINFOKLANT || e.Status == Status.INBEHANDELING).ToList().Count().ToString();
            
            return View();
        }
        
        
    }
}