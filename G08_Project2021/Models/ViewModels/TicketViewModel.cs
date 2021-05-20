using G08_Project2021.Models.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Type = G08_Project2021.Models.Domein.Type;

namespace G08_Project2021.Models.ViewModels
{
    public class TicketViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} may not contain more than 20 characters")]
        [Display(Prompt = "Titel")]
        public string Titel { get; set; }
        [Required]
        [Display(Prompt = "omschrijving van het ticket")]
        public string Omschrijving { get; set; }

        
        public string Technieker { get; set; }
        public Gebruiker Klant { get; set; }

        public Status Status { get; set; }
        public Type Type { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public TicketViewModel()
        {

        }
        public TicketViewModel(Ticket ticket)
        {
            Id = ticket.Id;
            Titel = ticket.Titel;
            Omschrijving = ticket.Omschrijving;
            Status = ticket.Status;
            Type = ticket.Type;
            Technieker = ticket.Technieker.Gebruikersnaam;
            AanmaakDatum = ticket.AanmaakDatum;

        }

    }
}
