using ForumApp2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp2.Core.Contracts
{
    public interface IPostService
    {
        Task AddAsync(PostModel model);
        Task DeleteAsync(int id);
        Task EditAsync(PostModel model);
        Task<PostModel?> GeByIdAsync(int id);
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
    }
}
