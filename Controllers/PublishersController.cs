using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWeb.Models;
using BookStoreWeb.Repository;
using BookStoreWeb.DataManager;
using BookStoreWeb.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersController:ControllerBase
    {
        private readonly IBookRepository<Publisher, PublisherDto> _dataRepository;

        public PublishersController(IBookRepository<Publisher, PublisherDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _dataRepository.Get(id);
            if (publisher == null)
            {
                return NotFound("The Publisher record couldn't be found.");
            }

            _dataRepository.Delete(publisher);
            return NoContent();
        }
    }
}
