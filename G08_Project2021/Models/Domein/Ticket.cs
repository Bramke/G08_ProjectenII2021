using System;

namespace G08_Project2021.Models.Domein
{
    public class Ticket
    {
        /*private string _titel;
        private string _omschrijving;*/
        #region Properties
        public int Id { get; set; }
        public DateTime AanmaakDatum { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        /*public string Omschrijving
        {
            get { return _omschrijving; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("titel mag niet leeg zijn"); }
                if (value.Length > 50)
                {
                    throw new ArgumentException("titel mag niet langer dan 50 characters zijn");

                }; _omschrijving = value;
            }
        }*/
        public int StatusAlsInt { get; set; }
        public Status Status { get; set; }
        /*public string Titel
        {
            get { return _titel; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("titel mag niet leeg zijn"); }
                if (value.Length > 20)
                { throw new ArgumentException("titel mag niet langer dan 20 characters zijn");
                    
                }; _titel = value;
            }
        }*/
        public Type Type { get; set; }
        //   private Gebruiker _technieker;
        public Gebruiker Klant { get; set; }
        public Gebruiker Technieker { get; set; }
        #endregion


        public Ticket(string Omschrijving, Status Status, String Titel, Type type, Gebruiker Klant,Gebruiker Technieker)
        {
            AanmaakDatum = DateTime.Now;
            this.Status = Status;
            this.Omschrijving = Omschrijving;
            StatusAlsInt = StatusAlsInt;
            this.Titel = Titel;
            Type = type;
            this.Klant = Klant;
            this.Technieker = Technieker;
            if (Klant.Rol == Rol.KLANT) { this.Klant = Klant; }
            if (Technieker.Rol == Rol.TECHNIEKER) { this.Technieker = Technieker; }

        }

        public Ticket(string Titel, string Omschrijving, Gebruiker Klant)
        {
            AanmaakDatum = DateTime.Now;
            Status = Status.AANGEMAAKT;
            this.Omschrijving = Omschrijving;
            this.Titel = Titel;
            Type = Type.NORMAAL;
            this.Klant = Klant;
            this.Technieker = null;
        }


        protected Ticket() { }
    }
    public enum Status
    {
        AANGEMAAKT = 0,
        INBEHANDELING = 1,
        AFGEHANDELD = 2,
        GEANNULEERD = 3,
        WACHTENINFOKLANT = 4,
        INFOKLANTONTVANGEN = 5,
        DEVELOPMENT = 6,
    }
    public enum Type
    {
        BELANGRIJK = 0,
        NIETBELANGRIJK = 1,
        NORMAAL = 2
    }
}