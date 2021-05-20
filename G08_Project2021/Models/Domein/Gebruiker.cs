using G08_Project2021.Models.Domein;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Models
{
    public class Gebruiker 
    {
        #region Properties
        public int Id { get; set; }
        public string Bedrijf { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Naam { get; set; }
        public Rol Rol { get; set; }
        public GebruikerStatus Status { get; set; }
        public string Voornaam { get; set; }
        // public string Wachtwoord { get; set; }
        //public ICollection<Contract> Contracten { get; set; }
       

        
        
        //public string Adres { get; set; }
        //public string TelNr { get; set; }
        public string Email { get; set; }
        //public int AantalJaren { get; set; }

        //public List<Poging> Pogingen { get; set; }
        #endregion
            

        public Gebruiker(string Bedrijf, string Gebruikersnaam, string Naam, Rol rol, GebruikerStatus status , string voornaam, string  email /*string Wachtwoord,*/ /*List<Contract> Contracten, string Adres, string TelNr, string Email, int AantalJaren)*/)
        {
            this.Bedrijf = Bedrijf;
            this.Gebruikersnaam = Gebruikersnaam;
            this.Rol = rol;
            this.Status = status;
            this.Naam = Naam;
            this.Voornaam = voornaam;
            
            //this.Contracten = new List<Contract>();
            
            //   this.Wachtwoord = Wachtwoord;
            
            //this.Adres = Adres;
            //this.TelNr = TelNr;
            this.Email = email;
            //this.AantalJaren = AantalJaren;
            //this.Pogingen = new List<Poging>();
        }
        protected Gebruiker() { }


    }

    public enum Rol
    {
        TECHNIEKER = 0,
        SUPPORTMANAGER = 1,
        ADMINISTRATOR = 2,
        KLANT = 3
    }

    public enum GebruikerStatus
    {
        ACTIEF = 0,
        GEBLOKKEERD = 1
    }

    
}
