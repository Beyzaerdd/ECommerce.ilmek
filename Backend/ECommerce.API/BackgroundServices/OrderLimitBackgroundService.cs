
using ECommerce.Business.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.API.BackgroundServices
{
    public class OrderLimitBackgroundService : BackgroundService
    {
        private readonly TimeSpan interval = TimeSpan.FromDays(7);
        private Timer _timer;


        private readonly IUserAccountManagerService userAccountManagerService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderLimitBackgroundService(IUserAccountManagerService userAccountManagerService, UserManager<ApplicationUser> userManager)
        {
            this.userAccountManagerService = userAccountManagerService;
            this.userManager = userManager;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(async state => await ExecuteSellerUpdate(), null, TimeSpan.Zero, interval);
            return Task.CompletedTask;
        }

        private async Task ExecuteSellerUpdate()
        {
            var sellers = await userAccountManagerService.GetAllSellersAsync();

           
            if (sellers.Data == null || !sellers.Data.Any())
            {
                return; 
            }

            foreach (var seller in sellers.Data)
            {
                var user = await userManager.FindByIdAsync(seller.Id) as Seller;

             
                if (user == null)
                {
                    continue;
                }

                user.WeeklyOrderLimit = Math.Min(user.WeeklyOrderLimit, 20);
                await userManager.UpdateAsync(user);
            }
        
    }
    }
}
