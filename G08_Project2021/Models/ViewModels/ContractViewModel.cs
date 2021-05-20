using System;
using G08_Project2021.Models.Domein;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Type = G08_Project2021.Models.Domein.Type;

namespace G08_Project2021.Models.ViewModels
{
    public class ContractViewModel
    {
        public string Id { get; set; }
        public string ContractStatus { get; set; }
        public string EindDatum { get; set; }
        public string StartDatum { get; set; }
        public string ContractTypeNaam { get; set; }
        public string ContractTypeStatus { get; set; }
        public string AanmaakWijze { get; set; }
        public string MaxDagen { get; set; }
        public string MinLooptijdContract { get; set; }
        public string Prijs { get; set; }

        
        public ContractViewModel()
        {

        }
        public ContractViewModel(Contract contract)
        {
            Id = contract.Id.ToString();
            StartDatum = contract.StartDatum.ToString("dd/MM/yyyy");
            EindDatum = contract.EindDatum.ToString("dd/MM/yyyy");
            ContractTypeNaam = contract.ContractType.Naam;
            ContractStatus = contract.ContractStatus.ToString();
            ContractTypeStatus = contract.ContractType.Status.ToString();
            AanmaakWijze = contract.ContractType.AanmaakTypeManier.ToString();
            MaxDagen = contract.ContractType.MaxDagen.ToString();
            MinLooptijdContract = contract.ContractType.MinLooptijdContract.ToString();
            Prijs = contract.ContractType.ContractPrijs.ToString();
        }

    }
}