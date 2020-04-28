using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Models;
using System;
using System.Threading.Tasks;
using WebApplication.Repository;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientService _clientService;

        //IClientRepository _clientRepository;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetClients")]
        public async Task<IActionResult> GetClients()
        {
            try
            {
               var clients = await _clientService.GetClientsDTO();

                if (clients == null)
                {
                    return NotFound();
                }

                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("GetClient")]
        public async Task<IActionResult> GetClient(int? clientId)
        {
            if (clientId == null)
            {
                return BadRequest();
            }

            try
            {
                var client = await _clientService.GetClientDTO(clientId);

                if (client == null)
                {
                    return NotFound();
                }

                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient([FromBody]ClientDTO model)
        {
            var clientId = await _clientService.AddClientDTO(model);
            if (clientId > 0)
            {
                return Ok(clientId);
            }
            else
            {
                return NotFound();
            }

            /*
            if (ModelState.IsValid)
            {
                try
                {
                    var clientId = await _clientService.AddClientDTO(model);
                    if (clientId > 0)
                    {
                        return Ok(clientId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
            */
        }

        [HttpPost]
        [Route("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int? clientId)
        {
            int result = 0;

            if (clientId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _clientService.DeleteClientDTO(clientId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateClient")]
        public async Task<IActionResult> UpdatePost([FromBody]ClientDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clientService.UpdateClientDTO(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
