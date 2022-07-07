using LessonMonitor.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LessonMonitor.Api.Data;

namespace LessonMonitor.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> Index()
        {
            return UsersStaticList.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> Details(int id)
        {
            return UsersStaticList.Get(id);
        }

        [HttpPost]
        public ActionResult Create(UserCreate model)
        {
            UsersStaticList.Add(model);

            return Ok();
        }
        [HttpPatch]
        public ActionResult Edit(User model)
        {
            UsersStaticList.Update(model);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            UsersStaticList.Delete(id);

            return Ok();
        }
    }
}
