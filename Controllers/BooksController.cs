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
    [Route("api/books")]
    [ApiController]
    public class BooksController:ControllerBase
    {
       
       
            private readonly IBookRepository<Book, BookDto> _dataRepository;

            public BooksController(IBookRepository<Book, BookDto> dataRepository)
            {
                _dataRepository = dataRepository;
            }
           

            // GET: api/Books/5
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var book = _dataRepository.Get(id);
                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                return Ok(book);
            }
        }
    }

