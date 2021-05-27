using System;
using ERP.Domain.Core.Models;
using ERP.Domain.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data.ModelBuilderExtensions
{
    public static class SeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Name = "RUB", NumericCode = 245, CharacterCode = "RUB", ExchangeRate = (float) 66.15},
                new Currency { Name = "USD", NumericCode = 127, CharacterCode = "USD", ExchangeRate = (float) 30.15},
                new Currency { Name = "SUM", NumericCode = 782, CharacterCode = "SUM", ExchangeRate = (float) 75.15}
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Code = 475, Name = "Россия", FullName = "Российская Федерация", Code2 = "RF", Code3 = "RFE"},
                new Country { Code = 741, Name = "Казахстан", FullName = "Казахстан", Code2 = "KZ", Code3 = "RZH"},
                new Country { Code = 123, Name = "Китай", FullName = "Китайская народная республика", Code2 = "КА", Code3 = "АВМ"}
                );
            
            modelBuilder.Entity<Bank>().HasData(
                new Bank { CountryCode = 475, Bic = 123456789, Tin = "457896321", Name = "ПАО «Сбербанк России»", City = "Москва", CorrAccount = "2412565265511", Address = "Москва, улица Вавилова, дом 19 "},
                new Bank { CountryCode = 475, Bic = 254896315, Tin = "138755865", Name = "ПАО «Банк ВТБ»", City = "Москва", CorrAccount = "65317869285655", Address = "Санкт-Петербург, ул. Большая Морская, д. 29 "}
            );

            modelBuilder.Entity<Counterparty>().HasData(
                new Counterparty
                {
                    Name = new CompanyName("VEON (Vimpelcom) ", "VEON"), 
                    Address = new CompanyAddress("445047, Самарская обл, г Тольятти, ш Южное, 37, кв 116", "445047, Самарская обл, г Тольятти, ш Южное, 37, кв 116"),
                    Contacts = new CompanyContacts("+78569512345", "test@mail.ru"),
                    Tin = 4578936413, Crtr = "462863215313", CreatedAt = DateTime.Now
                },
                new Counterparty{ 
                    Name = new CompanyName("Металлоинвест", "Металлоинвест"), 
                    Address = new CompanyAddress("445047, Самарская обл, г Тольятти, ш Южное, 37, кв 116", "445047, Самарская обл, г Тольятти, ш Южное, 37, кв 116"),
                    Contacts = new CompanyContacts("+74521235478", "test22@mail.ru"),
                    Tin = 8945161862, Crtr = "958915261631", CreatedAt = DateTime.Now.AddDays(6) 
                }
                );
            
            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount { CompanyTin = 4578936413, AccountNumber = 123456789, Name = "Счет для операционных сделок", AccountOpened = "opened at", CurrencyCode = 245, BankBic = 123456789 },
                new BankAccount { CompanyTin = 4578936413, AccountNumber = 456792166, Name = "Счет для заказов по понедельникам", AccountOpened = "opened at", CurrencyCode = 245, BankBic = 123456789}
                );
        }
    }
}