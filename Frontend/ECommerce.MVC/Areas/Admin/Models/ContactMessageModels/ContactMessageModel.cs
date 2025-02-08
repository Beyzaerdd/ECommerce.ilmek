namespace ECommerce.MVC.Areas.Admin.Models.ContactMessageModels
{
    public class ContactMessageModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
    }
}
