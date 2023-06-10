using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class CommentRepo : Generic_Repository<Comment> , ICommentRepo
    {
        public CommentRepo(ApplicationContext context):base(context)
        {
            
        }
        public List<Comment> GetRelatedComments(int ProductId)
        {
            return Find(x=> x.ProductId == ProductId).ToList();
        }
        public void AddComment(Comment comment)
        { 
            Insert(comment);
        }
    }
}