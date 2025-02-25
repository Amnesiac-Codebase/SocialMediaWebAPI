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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateMediaPostDto mediaPostDto)
        {
            var post = _context.MediaPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            post.Title = mediaPostDto.Title;
            post.Description = mediaPostDto.Description;
            post.Author = mediaPostDto.Author;
            post.DatePosted = mediaPostDto.DatePosted;
            _context.SaveChanges();
            return Ok(post.ToMediaPostDto());
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] PatchMediaPostDto mediaPostDto)
        {
            var post = _context.MediaPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            if (mediaPostDto.Title != null)
            {
                post.Title = mediaPostDto.Title;
            }
            if (mediaPostDto.Description != null)
            {
                post.Description = mediaPostDto.Description;
            }
            if (mediaPostDto.Author != null)
            {
                post.Author = mediaPostDto.Author;
            }
            if (mediaPostDto.DatePosted != null)
            {
                post.DatePosted = mediaPostDto.DatePosted;
            }
            _context.SaveChanges();
            return Ok(post.ToMediaPostDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var post = _context.MediaPosts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            _context.MediaPosts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}