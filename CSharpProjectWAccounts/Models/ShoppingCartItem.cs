namespace CSharpProjectWAccounts.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId { get; set; }
        public virtual Items Item { get; set; }
    }
}