namespace APIStuff.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlerContext _bowlerContext;
        public EFBowlerRepository(BowlerContext temp)
        {
            _bowlerContext = temp;
        }

        public IEnumerable<Bowlers> Bowlers => _bowlerContext.Bowlers;
    }
}
