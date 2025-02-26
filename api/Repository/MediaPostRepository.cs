using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MediaPost;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MediaPostRepository : IMediaPostRepository
    {
        private readonly ApplicationDBContext _context;
        public MediaPostRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<MediaPost> CreateAsync(MediaPost mediaPost)
        {
            await _context.MediaPosts.AddAsync(mediaPost);
            await _context.SaveChangesAsync();
            return mediaPost;
        }

        public async Task<MediaPost?> DeleteAsync(int id)
        {
            var postModel = await _context.MediaPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (postModel == null)
            {
                throw new Exception("Post not found");
            }

            _context.Remove(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<List<MediaPost>> GetAllAsync()
        {
            return await _context.MediaPosts.ToListAsync();
        }

        public async Task<MediaPost?> GetByIdAsync(int id)
        {
            return await _context.MediaPosts.FindAsync(id);
        }

        public async Task<MediaPost?> PatchAsync(int id, PatchMediaPostDto mediaPostDto)
        {
            var post = await _context.MediaPosts.FindAsync(id);
            if (post == null)
            {
                return null;
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

            return post;
        }

        public async Task<MediaPost?> UpdateAsync(int id, UpdateMediaPostDto mediaPostDto)
        {
            var post = await _context.MediaPosts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            
            post.Title = mediaPostDto.Title;
            post.Description = mediaPostDto.Description;
            post.Author = mediaPostDto.Author;
            post.DatePosted = mediaPostDto.DatePosted;
            await _context.SaveChangesAsync();

            return post;
        }
    }
}