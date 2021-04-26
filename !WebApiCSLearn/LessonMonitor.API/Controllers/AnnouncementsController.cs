using LessonMonitor.API.Interfaces;
using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly List<Announcement> _announcements;
        public AnnouncementsController()
        {
            DateTime date = new DateTime();
            _announcements = new List<Announcement>()
            {
                new Announcement(date.AddDays(3),"AspNet start","aspnet",true),
                new Announcement(date.AddDays(13),"Mssql database from beginner to professional","mssql",true),
                new Announcement(date.AddDays(13),"Attributes will always haunt you ","Attributes",true),
                new Announcement(date.AddDays(23),"AspNet Map","aspnet"),
                new Announcement(date.AddDays(33),"never use Reflection if u can do without it!","Reflection",true),
                new Announcement(date.AddDays(43),"how to connect Reflection","Reflection")
            };
        }

        /// <summary>
        /// Get announcements data by header
        /// </summary>
        /// <param name="header">gives information about all announcements which have the same header</param>
        /// <returns>IEnumerable<IAnnouncement></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Announcement>> Get(string header)
        {
            var announcements = 
                _announcements.Where(x => x.Header.ToLower().Equals(header.ToLower()));
            if (announcements.Count().Equals(0))
                return NotFound();
            return Ok(announcements);
        }
    }
}
