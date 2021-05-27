using AutoMapper;
using ERP.Domain.Core.Models;
using ERP.Domain.Core.Types;
using ERP.Services.DTO.Adding;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.DTO.Types;

namespace ERP.WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Currency, CurrencyToReturn>();
            CreateMap<CreateCurrencyDto, Currency>();

            CreateMap<Country, CountryToReturn>();
            CreateMap<CreateCountryDto, Country>();
            
            CreateMap<Bank, BankToReturn>();
            CreateMap<CreateBankDto, Bank>();
            
            CreateMap<Counterparty, CounterpartyToReturn>()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.Contacts, src => src.MapFrom(s => s.Contacts))
                .ForMember(dest => dest.Address, src => src.MapFrom(s => s.Address));
            CreateMap<CreateCounterpartyDto, Counterparty>();
            
            CreateMap<CompanyName, CompanyNameToReturn>();
            CreateMap<CompanyContacts, CompanyContactsToReturn>();
            CreateMap<CompanyAddress, CompanyAddressToReturn>();
            
            CreateMap<BankAccount, BankAccountToReturn>()
                .ForMember(dest => dest.Bank, src => src.MapFrom(s => s.Bank))
                .ForMember(dest => dest.Company, src => src.MapFrom(s => s.Company))
                .ForMember(dest => dest.Currency, src => src.MapFrom(s => s.Currency));
            CreateMap<BankAccountCreateDto, BankAccount>();
            
            CreateMap<Partner, PartnerToReturnDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.Contacts, src => src.MapFrom(s => s.Contacts))
                .ForMember(dest => dest.Address, src => src.MapFrom(s => s.Address));
            CreateMap<PartnerCreateDto, Partner>();
            
            CreateMap<BusinessProposal, BusinessProposalToReturnDto>()
                .ForMember(dest => dest.Company, src => src.MapFrom(s => s.Partner))
                .ForMember(dest => dest.Status, src => src.MapFrom(s => s.Status.ToString()));
            CreateMap<BusinessProposalCreateDto, BusinessProposal>();
            
            CreateMap<Position, PositionToReturnDto>();
            CreateMap<PositionCreateDto, Position>();
            
            CreateMap<Product, ProductToReturnDto>();
            CreateMap<ProductCreateDto, Product>();
            
            CreateMap<AddBusinessProposalProduct, BusinessProposalProduct>();
            
            CreateMap<AgreementWithCustomer, AgreementToReturnDto>()
                .ForMember(dest => dest.Company, src => src.MapFrom(s => s.Partner))
                .ForMember(dest => dest.Status, src => src.MapFrom(s => s.Status.ToString()));
            CreateMap<AgreementCreateDto, AgreementWithCustomer>();

        }
    }
}