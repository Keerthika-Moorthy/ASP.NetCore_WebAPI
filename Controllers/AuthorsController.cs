﻿using System;
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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController:ControllerBase
    {
        private readonly IBookRepository<Author, AuthorDto> _dataRepository;

        public AuthorsController(IBookRepository<Author, AuthorDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _dataRepository.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _dataRepository.GetDto(id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            if (author is null)
            {
                return BadRequest("Author is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(author);
            return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("Author is null.");
            }

            var authorToUpdate = _dataRepository.Get(id);
            if (authorToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(authorToUpdate, author);
            return NoContent();
        }
    }
}
