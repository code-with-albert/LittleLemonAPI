using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync(QueryObject query);
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> CreateAsync(Comment CommentModel);
        Task<Comment?> UpdateAsync(int id);
        Task<Comment?> RemoveAsync(int id);
        Task<Comment?> DeleteAsync(int id);
    }
}