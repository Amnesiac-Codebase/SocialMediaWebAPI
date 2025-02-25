using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.MediaPost;
using api.Models;

namespace api.Mappers
{
    public static class MediaPostMappers
    {
        public static MediaPostDto ToMediaPostDto(this MediaPost mediaPost)
        {
            return new MediaPostDto
            {
                Id = mediaPost.Id,
                Title = mediaPost.Title,
                Description = mediaPost.Description,
                Author = mediaPost.Author,
                DatePosted = mediaPost.DatePosted
            };
        }

        public static MediaPost ToMediaPostFromCreateDTO(this CreateMediaPostDto mediaPostDto)
        {
            return new MediaPost
            {
                Title = mediaPostDto.Title,
                Description = mediaPostDto.Description,
                Author = mediaPostDto.Author,
                DatePosted = mediaPostDto.DatePosted
            };
        }
    }
}