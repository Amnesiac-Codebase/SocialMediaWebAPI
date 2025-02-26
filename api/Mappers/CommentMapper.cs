using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDtoFromComment(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Text = commentModel.Text,
                Author = commentModel.Author,
                DatePosted = commentModel.DatePosted,
                PostId = commentModel.PostId
            };
        }

        public static Comment ToCommentFromCommentDto(CommentDto commentDto)
        {
            return new Comment
            {
                Id = commentDto.Id,
                Text = commentDto.Text,
                Author = commentDto.Author,
                DatePosted = commentDto.DatePosted,
                PostId = commentDto.PostId
            };
        }
    }
}