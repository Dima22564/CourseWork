namespace ERP.Services.DTO
{
    public class ManipulateCountryDto
    {
        public int Code { get; }
        public string Name { get; }
        public string FullName { get; }
        public string Code2 { get; }
        public string Code3 { get; }

        public ManipulateCountryDto(int code, string name, string fullName, string code2, string code3)
        {
            Code = code;
            Name = name;
            FullName = fullName;
            Code2 = code2;
            Code3 = code3;
        }
    }
}