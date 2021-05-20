using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using G08_Project2021.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace G08_Project2021.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        private readonly IContractTypeRepository _contractTypeRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        
        public ContractController(IContractRepository contractRepository, IGebruikerRepository gebruikerRepository, IContractTypeRepository contractTypeRepository)
        {
            _contractRepository = contractRepository;
            _gebruikerRepository = gebruikerRepository;
            _contractTypeRepository = contractTypeRepository;
            
        }
        public IActionResult Index()
        {
            string gebruikersnaam = User.Identity.Name;
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaamKlant(gebruikersnaam);
            IEnumerable<Contract> contracten = _contractRepository.GetByGebruiker(gebruiker);
            ViewData["Actief"] = contracten.Where(c => c.ContractStatus == ContractStatus.IN_BEHANDELING || c.ContractStatus == ContractStatus.LOPEND).Count();
            ViewData["Ended"] = contracten.Where(c => c.ContractStatus == ContractStatus.BEËINDIGD).Count();
            return View(contracten);
        }
        public IActionResult Detail(int id)
        {
            Contract contract = _contractRepository.GetById(id);

            return View(new ContractViewModel(contract));
        }
        public IActionResult KiesContractType()
        {
            List<ContractType> contractTypes = _contractTypeRepository.GetAll().ToList();
            return View(contractTypes);
        }
        public IActionResult Create(int id)
        {
            string gebruikersnaam = User.Identity.Name;
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaamKlant(gebruikersnaam);
            ContractType ct = _contractTypeRepository.GetById(id);
            IEnumerable<Contract> contracten = _contractRepository.GetByGebruiker(gebruiker);
            foreach(Contract c in contracten)
            {
                if (c.ContractType == ct)
                {
                    if (c.ContractStatus == ContractStatus.LOPEND || c.ContractStatus == ContractStatus.IN_BEHANDELING)
                    {
                        TempData["error"] = "U hebt reeds een lopend contract van dit type, kies een ander contracttype.";
                        return RedirectToAction(nameof(KiesContractType));
                    }
                }
            }
            string StartDatum = DateTime.Today.ToString("dd/MM/yyyy");
            string EindDatum = DateTime.Today.AddYears(ct.MinLooptijdContract).ToString("dd/MM/yyyy");
            string[] Details = { ct.Naam, StartDatum, EindDatum, ct.MaxDagen.ToString(), ct.MinLooptijdContract.ToString(), ct.ContractPrijs.ToString(), ct.Id.ToString() };
            ViewBag.Details = Details;
            return View(new ContractViewModel());
        }


        [HttpPost]
        public IActionResult Create(int id, string naam)
        {
            string gebruikersnaam = User.Identity.Name;
            Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaamKlant(gebruikersnaam);
            ContractType ct = _contractTypeRepository.GetById(id);
            IEnumerable<Contract> contracten = _contractRepository.GetByGebruiker(gebruiker);
            Contract contract = new Contract(ct, DateTime.Now, gebruiker);
                _contractRepository.Add(contract);
                _contractRepository.SaveChanges();
            TempData["message"] = $"{contract.ContractTypeNaam} contract succesvol aangemaakt!";
                return RedirectToAction(nameof(Index));
            }
        }
    }

