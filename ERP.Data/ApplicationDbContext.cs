using ERP.Data.ModelBuilderExtensions;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Intermediary;
using ERP.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER4;Database=ApplicationDb2;Trusted_Connection=True;");
        }

        public virtual DbSet<Person> Users { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Counterparty> Counterparties { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<AlcoholicLicense> AlcoholicLicenses { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ClientOrder> ClientOrders { get; set; }
        public virtual DbSet<BusinessProposal> BusinessProposals { get; set; }
        public virtual DbSet<BusinessProposalProduct> BusinessProposalProducts { get; set; }
        public virtual DbSet<ClientOrderProduct> ClientOrderProducts { get; set; }
        public virtual DbSet<AgreementWithCustomer> AgreementWithCustomers { get; set; }
        public virtual DbSet<ContactPerson> ContactPeople { get; set; }
        
        public virtual DbSet<Document> Documents { get; set; }
        
        public virtual DbSet<CounterpartyPartner> CounterpartyPartners { get; set; }
        public virtual DbSet<PartnerContactPeople> PartnerContactPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK
            modelBuilder.Entity<ClientOrderProduct>().HasKey(u => new { u.ClientOrderId, u.ProductId, u.PositionNumber });
            modelBuilder.Entity<BusinessProposalProduct>().HasKey(u => new { u.BusinessProposalId, u.ProductId, u.PositionNumber });
            
            // Types
            modelBuilder.Entity<Position>()
                .Property(s => s.Name)
                .HasConversion<string>();
            
            modelBuilder.Entity<BusinessProposal>()
                .Property(s => s.Status)
                .HasConversion<string>();
            
            modelBuilder.Entity<AgreementWithCustomer>()
                .Property(s => s.Status)
                .HasConversion<string>();
            
            modelBuilder.Entity<ClientOrder>()
                .Property(s => s.CurrentState)
                .HasConversion<string>();
            
            modelBuilder.Entity<AlcoholicLicense>()
                .Property(s => s.CheckStatus)
                .HasConversion<string>();
            

            // One-to-Many // Currency has many BankAccount
            modelBuilder.Entity<BankAccount>()
                .HasOne<Currency>(c => c.Currency)
                .WithMany(d => d.BankAccounts)
                .HasForeignKey(e => e.CurrencyCode);

            // One-to-Many // Counterparty has many BankAccount
            modelBuilder.Entity<BankAccount>()
                .HasOne<Counterparty>(c => c.Company)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(c => c.CompanyTin);

            // One-to-Many // Country has many Bank
            modelBuilder.Entity<Bank>()
                .HasOne<Country>(c => c.Country)
                .WithMany(c => c.Banks)
                .HasForeignKey(c => c.CountryCode);

            // One-to-Many // Bank has many BankAccount
            modelBuilder.Entity<BankAccount>()
                .HasOne<Bank>(c => c.Bank)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(c => c.BankBic);

            // One-to-Many // Counterpatry has many AlcoholicLicense
            modelBuilder.Entity<AlcoholicLicense>()
                .HasOne<Counterparty>(c => c.Counterparty)
                .WithMany(c => c.AlcoholicLicenses)
                .HasForeignKey(c => c.CounterpartyId);
            
            // One-to-Many // Employee has one Position
            modelBuilder.Entity<Person>()
                .HasOne<Position>(c => c.Position)
                .WithMany(c => c.People)
                .HasForeignKey(c => c.PositionId);
            
            // One-to-Many // Company has many Employees
            modelBuilder.Entity<Employee>()
                .HasOne<Company>(c => c.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.CompanyId);

            // Many-to-Many // Counterpaty has many Partners
            modelBuilder.Entity<CounterpartyPartner>()
                .HasKey(c => new { c.CounterpartyId, c.PartnerId });
            modelBuilder.Entity<CounterpartyPartner>()
                .HasOne<Counterparty>(c => c.Counterparty)
                .WithMany(c => c.CounterpartyPartners)
                .HasForeignKey(c => c.CounterpartyId);
            modelBuilder.Entity<CounterpartyPartner>()
                .HasOne<Partner>(c => c.Partner)
                .WithMany(c => c.CounterpartyPartners)
                .HasForeignKey(c => c.PartnerId);
            
            // Many-to-Many // Partner has many ContactPeople
            modelBuilder.Entity<PartnerContactPeople>()
                .HasKey(c => new { c.ContactPersonId, c.PartnerId });
            modelBuilder.Entity<PartnerContactPeople>()
                .HasOne<Partner>(c => c.Partner)
                .WithMany(c => c.PartnerContactPeople)
                .HasForeignKey(c => c.PartnerId);
            modelBuilder.Entity<PartnerContactPeople>()
                .HasOne<ContactPerson>(c => c.ContactPerson)
                .WithMany(c => c.PartnerContactPeople)
                .HasForeignKey(c => c.ContactPersonId);
            
            // One-to-Many // BusinessProposal has many BusinessProposalProducts
            modelBuilder.Entity<BusinessProposalProduct>()
                .HasOne<BusinessProposal>(c => c.BusinessProposal)
                .WithMany(d => d.BusinessProposalProducts)
                .HasForeignKey(e => e.BusinessProposalId);
            
            // One-to-Many // AgreementWithCustomer has one Currency
            modelBuilder.Entity<AgreementWithCustomer>()
                .HasOne<Currency>(c => c.Currency)
                .WithMany(d => d.AgreementsWithCustomers)
                .HasForeignKey(e => e.CurrencyCode);
            
            // One-to-Many // AgreementWithCustomer has one Currency
            modelBuilder.Entity<AgreementWithCustomer>()
                .HasOne<Partner>(c => c.Partner)
                .WithMany(d => d.AgreementsWithCustomers)
                .HasForeignKey(e => e.PartnerId);
            
            // One-to-Many // ClientOrder has one Company
             modelBuilder.Entity<ClientOrder>()
                 .HasOne<Company>(c => c.Company)
                .WithMany(d => d.ClientOrders)
                 .HasForeignKey(e => e.CompanyId);
            
            // One-to-Many // ClientOrder has one BusinessProposal
            modelBuilder.Entity<ClientOrder>()
                .HasOne<BusinessProposal>(c => c.BusinessProposal)
                .WithMany(d => d.ClientOrders)
                .HasForeignKey(e => e.BusinessProposalId);
            
            // One-to-Many // ClientOrder has one BusinessProposal
            modelBuilder.Entity<ClientOrder>()
                .HasOne<AgreementWithCustomer>(c => c.AgreementWithCustomer)
                .WithMany(d => d.ClientOrders)
                .HasForeignKey(e => e.AgreementWithCustomerId);
            
            // One-to-Many // Client order has many ClientOrderProducts
            modelBuilder.Entity<ClientOrderProduct>()
                .HasOne<ClientOrder>(c => c.ClientOrder)
                .WithMany(d => d.ClientOrderProducts)
                .HasForeignKey(e => e.ClientOrderId);
            
            // One-to-Many // Employee has many Partners responsible for
            modelBuilder.Entity<Partner>()
                .HasOne<Employee>(c => c.ResponsiblePerson)
                .WithMany(d => d.ResponsibleForPartners)
                .HasForeignKey(e => e.ResponsiblePersonId);
            
            // One-to-Many // ClientOrderProduct has oneProduct
            modelBuilder.Entity<ClientOrderProduct>()
                .HasOne<Product>(c => c.Product)
                .WithMany(d => d.ClientOrderProducts)
                .HasForeignKey(e => e.ProductId);
            
            // One-to-Many // BusinessProposalProduct has oneProduct
            modelBuilder.Entity<BusinessProposalProduct>()
                .HasOne<Product>(c => c.Product)
                .WithMany(d => d.BusinessProposalProducts)
                .HasForeignKey(e => e.ProductId);
            
            // One-to-Many // BusinessProposal has one Partner
            modelBuilder.Entity<BusinessProposal>()
                .HasOne<Partner>(c => c.Partner)
                .WithMany(d => d.BusinessProposals)
                .HasForeignKey(e => e.PartnerId);
            
            // modelBuilder.Seed();
            
        }
    }
}