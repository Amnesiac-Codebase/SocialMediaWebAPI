using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MediaPost;
using api.Interfaces;
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
        private readonly IMediaPostRepository _mediaPostRepository;
        public MediaPostController(IMediaPostRepository mediaPostRepository)
        {
            _mediaPostRepository = mediaPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _mediaPostRepository.GetAllAsync();
            return Ok(posts.Select(p => p.ToMediaPostDto()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _mediaPostRepository.GetByIdAsync(id);
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
            await _mediaPostRepository.CreateAsync(mediaPost);
            
            return CreatedAtAction(nameof(GetById), new { id = mediaPost.Id }, mediaPost.ToMediaPostDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMediaPostDto mediaPostDto)
        {
            var mediaPost = await _mediaPostRepository.UpdateAsync(id, mediaPostDto);

            if(mediaPost == null)
            {
                return NotFound();
            }

            return Ok(mediaPost.ToMediaPostDto());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PatchMediaPostDto mediaPostDto)
        {
            var mediaPost = await _mediaPostRepository.PatchAsync(id, mediaPostDto);
            if(mediaPost == null)
            {
                return NotFound();
            }

            return Ok(mediaPost.ToMediaPostDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var post = await _mediaPostRepository.DeleteAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}