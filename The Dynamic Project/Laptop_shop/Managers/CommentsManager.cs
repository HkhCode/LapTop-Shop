using Laptop_shop.Generic_Repository;
using Laptop_shop.Models.Data;

namespace Laptop_shop.Managers
{
    public class CommentsManager
    {
        private readonly Generic_Repository<Comment> CommentRepo = new Generic_Repository<Comment>();
        private readonly Generic_Repository<Product> ProductRepo = new Generic_Repository<Product>();

        public List<Comment> GetRealtedComments(int ProductId)
        {
            Product p;
            p = ProductRepo.GetById(ProductId);
            List<Comment> comments;
            comments = p.Comments.ToList();
            return comments;
        }
        public void AddComment(Comment comment)
        {
            CommentRepo.Insert(comment);
        }
    }
}
