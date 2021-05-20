using G08_Project2021.Models.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models.Domein
{
    public class Contract
    {
        public int Id { get; set; }

        public ContractStatus ContractStatus { get; set; }
        public DateTime EindDatum { get; set; }
        public int AantalLopendeContracten { get; set; }
        public DateTime StartDatum { get; set; }
        public ContractType ContractType { get; set; }
        public string ContractTypeNaam { get; set; }
        public Gebruiker Gebruiker { get; set; }
       
        public Contract(ContractType ContractType, DateTime StartDatum, Gebruiker gebruiker)
        {
            this.ContractStatus = ContractStatus.IN_BEHANDELING;
            this.ContractType = ContractType;
            this.ContractTypeNaam = ContractType.Naam;
            this.EindDatum = StartDatum.AddYears(ContractType.MinLooptijdContract);
            this.StartDatum = StartDatum;
            this.Gebruiker = gebruiker;
        }
        protected Contract() { }
        
        public string EnumToImg()
        {
            string img = "";
            switch (ContractStatus)
            {
                case ContractStatus.IN_BEHANDELING: 
                    img = "/img/clock.png";
                    break;
                case ContractStatus.LOPEND:
                    img = "/img/checkmark.png";
                    break;
                case ContractStatus.BEËINDIGD:
                    img = "";
                    break;
            }
            return img;
        }
        public void BepaalStatus()
        {
            if(EindDatum < DateTime.Today)
            {
                ContractStatus = ContractStatus.BEËINDIGD;
            }
        }
    
    }


    public enum ContractStatus
    {
        IN_BEHANDELING = 0,
        LOPEND = 1,
        BEËINDIGD = 2
    }
    
}
