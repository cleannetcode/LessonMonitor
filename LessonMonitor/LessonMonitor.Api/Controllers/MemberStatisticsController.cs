using LessonMonitor.Api.DataAccess;
using LessonMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.Api.Controllers
{
    /// <summary>
    /// Methods for interacting with member statistics
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MemberStatisticsController: ControllerBase
    {
        private readonly MembersRepository _members;

        public MemberStatisticsController()
        {
            _members = new MembersRepository();
        }

        /// <summary>
        /// Get member statistics by member id
        /// </summary>
        /// <param name="memberId">Member Id whose statistic you want get</param>
        /// <returns>MemberStatustics object</returns>
        [HttpGet]
        public ActionResult<MemberStatistics> Get(int memberId)
        {
            var member = _members.GetById(memberId);

            if (member == null)
                return NotFound("We can't find member with this id");
            
            return new MemberStatistics()
            {
                Member = member
            };
        }
    }
}
