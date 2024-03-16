namespace APIStuff.Data
{
    public class EFTeamRepository : ITeamRepository
    {
        private BowlerContext _teamContext;
        public EFTeamRepository(BowlerContext temp) 
        {
            _teamContext = temp;
        }

        public IEnumerable<Teams> Teams => _teamContext.Teams;
    }
}
