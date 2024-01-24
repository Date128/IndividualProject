using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace индив.проект.уч.практ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class CustomersController : ControllerBase
        {
            public CustomersContext Context { get; }

            public CustomersController(CustomersContext context)
            {
                Context = context;
            }

            [HttpGet]
            public IActionResult GetAll() // Получение всех записей
            {
                List<User> user = Context.Users.ToList();
                return Ok(user);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id) // Получение одной записи
            {
                User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Not Found");
                }
                return Ok(user);
            }

            [HttpPost]
            public IActionResult Add(User user) // Создание одной записи
            {
                Context.Users.Add(user);
                Context.SaveChanges();
                return Ok(user);
            }

            [HttpPut]
            public IActionResult Update(User user) // Изменение существующей записи
            {
                Context.Users.Update(user);
                Context.SaveChanges();
                return Ok(user);
            }

            [HttpDelete]
            public IActionResult Delete(int id) // Удаление существующей записи
            {
                User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Not Found");
                }
                Context.Users.Remove(user);
                Context.SaveChanges();
                return Ok(user);
            }
        }
    
}
