using System;

namespace G08_Project2021.Models.Domein
{
    public class Poging
    {
        #region Properties
        public int Id { get; set; }
        public Boolean AanmeldingGelukt { get; set; }
        public DateTime DateTime { get; set; }
        #endregion
        public Poging(Boolean AanmeldingGelukt)
        {
            this.AanmeldingGelukt = AanmeldingGelukt;
            this.DateTime = DateTime.Today;
        }
    }

}
