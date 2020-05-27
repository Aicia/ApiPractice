using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiAppPractice.Data;
using ApiAppPractice.Data.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAppPractice.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAppRepository _repository;
        public AccountController(IAppRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult Get()
        {
            var results = _repository.GetAllAcc();
            if ( results != null)
            {
                return Ok(results);
            }
            else
            {
                return NoContent();
            }
            
        }

        // GET api/Account/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Account acc = _repository.GetAccById(id);
            if (acc != null)
            {
                return Ok(acc);
            } 
            else 
            {
                return NotFound(id);
            } 
        }

        // POST api/Account
        [HttpPost]
        public IActionResult Post([FromBody]Account acc)
        {
            try
            {
                _repository.AddEntity(acc);
                _repository.SaveAll();
                return Ok(acc);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/Account/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _repository.DeleteAcc(id);
                _repository.SaveAll();
                return Ok(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
            
        }
    }
}
