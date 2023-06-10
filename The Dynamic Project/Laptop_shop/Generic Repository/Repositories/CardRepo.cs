using Laptop_shop.Models.Data;
using Laptop_shop.Generic_Repository.interfaces;
using Laptop_shop.Database;
using Laptop_shop.Models.Data;
namespace Laptop_shop.Generic_Repository.Repositories
{
    public class CardRepo : Generic_Repository<Card> , ICardRepo 
    {
        public CardRepo(ApplicationContext context):base(context)
        {
            
        }
        public void AddProductToCard(Product product , int CardId) 
        {
            Card card = GetById(CardId);
            card.Products.Add(product);
            Update(card);
        }
        public void addCard(Card card)
        {
            Insert(card);
        }
        public void DeleteCard(int id)
        {
            Delete(id);
        }
    }
}