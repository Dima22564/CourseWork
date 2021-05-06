using ERP.Data.Abstractions;
using ERP.Data.Repositories;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using ERP.Services.Services;
using ERP.Services.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Currency>, GenericRepository<Currency>>();
            
            // Services
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<ICounterpartyService, CounterpartyService>();
            services.AddTransient<IBankAccountsService, BankAccountService>();
            services.AddTransient<IPartnerService, IPartnerService>();
            
            // Repositories
            services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddTransient<IGenericRepository<AgreementWithCustomer>, GenericRepository<AgreementWithCustomer>>();
            services.AddTransient<IGenericRepository<AlcoholicLicense>, GenericRepository<AlcoholicLicense>>();
            services.AddTransient<IGenericRepository<Bank>, GenericRepository<Bank>>();
            services.AddTransient<IGenericRepository<BankAccount>, GenericRepository<BankAccount>>();
            services.AddTransient<IGenericRepository<BusinessProposal>, GenericRepository<BusinessProposal>>();
            services.AddTransient<IGenericRepository<BusinessProposalProduct>, GenericRepository<BusinessProposalProduct>>();
            services.AddTransient<IGenericRepository<ClientOrder>, GenericRepository<ClientOrder>>();
            services.AddTransient<IGenericRepository<Company>, GenericRepository<Company>>();
            services.AddTransient<IGenericRepository<ContactPerson>, GenericRepository<ContactPerson>>();
            services.AddTransient<IGenericRepository<Counterparty>, GenericRepository<Counterparty>>();
            services.AddTransient<IGenericRepository<Country>, GenericRepository<Country>>();
            services.AddTransient<IGenericRepository<Currency>, GenericRepository<Currency>>();
            services.AddTransient<IGenericRepository<Partner>, GenericRepository<Partner>>();
            services.AddTransient<IGenericRepository<Position>, GenericRepository<Position>>();
            services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddTransient<IGenericRepository<ProductKind>, GenericRepository<ProductKind>>();
            services.AddTransient<IGenericRepository<StorageUnit>, GenericRepository<StorageUnit>>();
            services.AddTransient<IGenericRepository<Person>, GenericRepository<Person>>();

            services.AddTransient<ICounterpartyRepository, CounterpartyRepository>();
        }
    }
}