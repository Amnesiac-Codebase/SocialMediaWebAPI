using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MediaPost;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var posts = await _context.MediaPosts.ToListAsync();
            return Ok(posts.Select(p => p.ToMediaPostDto()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _context.MediaPosts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.ToMediaPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMediaPostDto mediaPostDto)
        {
            var mediaPost = mediaPostDto.ToMediaPostFromCreateDTO();
            await _context.MediaPosts.AddAsync(mediaPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = mediaPost.Id }, mediaPost.ToMediaPostDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateMediaPostDto mediaPostDto)
        {
            var post = await _context.MediaPosts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            post.Title = mediaPostDto.Title;
            post.Description = mediaPostDto.Description;
            post.Author = mediaPostDto.Author;
            post.DatePosted = mediaPostDto.DatePosted;
            await _context.SaveChangesAsync();
            return Ok(post.ToMediaPostDto());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] PatchMediaPostDto mediaPostDto)
        {
            var post = await _context.MediaPosts.FindAsync(id);
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
            await _context.SaveChangesAsync();
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