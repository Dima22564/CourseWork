using Bogus;
using ERP.Domain.Core.Models;

namespace ERP.Test.FakeData
{
    public class EmployeeFakeData : Fake
    {
        public EmployeeFakeData(int seed) : base(seed)
        {
        }
    }
}