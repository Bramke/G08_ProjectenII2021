using System;

namespace G08_Project2021.Models.Domein
{
    public class ContractType
    {
        #region Properties
        public int Id { get; set; }
        public String Naam { get; set; }
        public ContractTypeStatus Status { get; set; }
        public AanmaakTypeManier AanmaakTypeManier { get; set; }
        public int MaxDagen { get; set; }
        public int MinLooptijdContract { get; set; }
        public double ContractPrijs { get; set; }
        #endregion

        public ContractType(string Naam, AanmaakTypeManier AanmaakTypeManier, int MaxDagen, int MinLooptijdContract, double ContractPrijs)
        {
            this.Naam = Naam;
            this.Status = ContractTypeStatus.ACTIEF;
            this.AanmaakTypeManier = AanmaakTypeManier;
            this.MaxDagen = MaxDagen;
            this.MinLooptijdContract = MinLooptijdContract;
            this.ContractPrijs = ContractPrijs;
        }
    }
    public enum ContractTypeStatus
    {
        ACTIEF = 0,
        NIETACTIEF = 1
    }
    public enum AanmaakTypeManier
    {
        EMAIL = 0,
        TELEFONISCH = 1,
        APPLICATIE = 2
    }
}
