namespace APIStuff.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Teams> Teams { get; }
    }
}
