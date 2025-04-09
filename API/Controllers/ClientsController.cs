using System.Net;
using System.Numerics;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //NOTE connection string for API is stored in appsettings.json 
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return context.Clients.OrderByDescending(c=>c.Id).ToList();
        }
        
        [HttpGet("{id}")] //get client by ID
        public IActionResult GetClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost] // insert client using model clientdto
        public IActionResult CreateClient(ClientsDto clientDto) 
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Email == clientDto.Email);// verify if email is already existing
            if (otherClient != null) {
                ModelState.AddModelError("Email", "The Email is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);// return  bad request if client email is already existing
            }

            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Phone = clientDto.Phone,
                Address = clientDto.Address,
                Status = clientDto.Status,
                CreatedAt = DateTime.Now,
            };

            context.Clients.Add(client);
            context.SaveChanges();


            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientsDto clientDto)// Function for modifying client data using edit button 
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Id != id && c.Email  == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone ?? "";
            client.Address = clientDto.Address ?? "";
            client.Status = clientDto.Status;

            context.SaveChanges();


            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id) //function for Deleting Client name
        {
            var client = context.Clients.Find(id);
            if (client == null) {
            return NotFound();
            }

            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok(client);
        }

    }
}
