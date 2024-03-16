using APIStuff.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIStuff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        private ITeamRepository _teamRepository;
        public BowlerController(IBowlerRepository temp, ITeamRepository tempTeam)
        {
            _bowlerRepository = temp;
            _teamRepository = tempTeam;
        }
        [HttpGet]
        public IEnumerable<BowlerWithTeamViewModel> Get()
        {
            var bowlerData = _bowlerRepository.Bowlers.ToArray();
            var result = new List<BowlerWithTeamViewModel>();

            foreach (var bowler in bowlerData)
            {
                var team = _teamRepository.Teams.FirstOrDefault(t => t.TeamID == bowler.TeamID);

                if (team != null && (team.TeamName == "Sharks" || team.TeamName == "Marlins"))
                {
                    result.Add(new BowlerWithTeamViewModel
                    {
                        BowlerID = bowler.BowlerID,
                        BowlerLastName = bowler.BowlerLastName,
                        BowlerFirstName = bowler.BowlerFirstName,
                        BowlerMiddleInit = bowler.BowlerMiddleInit,
                        BowlerAddress = bowler.BowlerAddress,
                        BowlerCity = bowler.BowlerCity,
                        BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                        BowlerState = bowler.BowlerState,
                        BowlerZip = bowler.BowlerZip,
                        TeamID = team?.TeamID,
                        TeamName = team?.TeamName
                    });
                }
            }

            return result;
        }

        public class BowlerWithTeamViewModel
        {
            public int BowlerID { get; set; }
            public string? BowlerLastName { get; set; }
            public string? BowlerFirstName { get; set; }
            public string? BowlerMiddleInit { get; set; }
            public string? BowlerAddress { get; set; }
            public string? BowlerCity { get; set; }
            public string? BowlerState { get; set; }
            public string? BowlerZip { get; set; }
            public string? BowlerPhoneNumber { get; set; }
            public int? TeamID { get; set; }
            public string? TeamName { get; set; }
        }
    }
}
