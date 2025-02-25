using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.MediaPost;

namespace api.Interfaces
{
    public interface IMediaPostRepository
    {
        Task<List<MediaPost>> GetAllAsync();
        Task<MediaPost?> GetByIdAsync(int id);
        Task<MediaPost> CreateAsync(MediaPost mediaPost);
        Task<MediaPost?> UpdateAsync(int id, UpdateMediaPostDto mediaPostDto);
        Task<MediaPost?> PatchAsync(int id, PatchMediaPostDto mediaPostDto);
        Task<MediaPost?> DeleteAsync(int id);
    }
}