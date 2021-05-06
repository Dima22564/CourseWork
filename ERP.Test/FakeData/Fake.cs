namespace ERP.Test.FakeData
{
    public abstract class Fake
    {
        public readonly int _seed;

        protected Fake(int seed)
        {
            _seed = seed;
        }
    }
}