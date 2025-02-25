using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MediaPost;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaPostController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MediaPostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.MediaPosts.Select(p => p.ToMediaPostDto()).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _context.MediaPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.ToMediaPostDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMediaPostDto mediaPostDto)
        {
            var mediaPost = mediaPostDto.ToMediaPostFromCreateDTO();
            _context.MediaPosts.Add(mediaPost);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = mediaPost.Id }, mediaPost.ToMediaPostDto());
        }
    }
}