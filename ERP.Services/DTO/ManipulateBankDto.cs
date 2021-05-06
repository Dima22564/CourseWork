namespace ERP.Services.DTO
{
    public class ManipulateBankDto
    {
        public int Bic { get; }
        public string Tin { get; }
        public string Name { get; }
        public string City { get; }
        public string CorrAccount { get; }
        public string Address { get; }

        public int CountryCode { get; }

        public ManipulateBankDto(int bic, string tin, string name, string city, string corrAccount, string address, int countryCode)
        {
            Bic = bic;
            Tin = tin;
            Name = name;
            City = city;
            CorrAccount = corrAccount;
            Address = address;
            CountryCode = countryCode;
        }
    }
}