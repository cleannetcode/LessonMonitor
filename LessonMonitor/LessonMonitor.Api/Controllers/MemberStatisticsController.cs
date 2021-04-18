using LessonMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Controllers
{
    /// <summary>
    /// Methods for interacting with member statistics
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MemberStatisticsController: ControllerBase
    {
        private readonly List<Member> _context;

        public MemberStatisticsController()
        {
            _context = new List<Member>();
        }

        /// <summary>
        /// Get member statistics by member id
        /// </summary>
        /// <param name="memberId">Member Id whose statistic you want get</param>
        /// <returns>MemberStatustics object</returns>
        [HttpGet]
        public ActionResult<MemberStatistics> Get(int memberId)
        {
            var member = _context.FirstOrDefault(x => x.Id.Equals(memberId));

            if (member == null)
                return NotFound("We can't find member with this id");

            return new MemberStatistics()
            {
                Member = member
            };
        }
    }
}
