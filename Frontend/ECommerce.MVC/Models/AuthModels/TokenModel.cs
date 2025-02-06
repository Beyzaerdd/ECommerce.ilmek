namespace ECommerce.MVC.Models.AuthModels
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
