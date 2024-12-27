using Microsoft.AspNetCore.Identity.UI.Services;

namespace CarRentalPortal.Models
{
    //Bu sayfayı identity uygulamaları yaptıktan sonra register kısmında email sender hatası aldığımdan yaptım. Burayı bu şekilde yapmasam hatadan ötürü register çalışmıyordu.//
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Email gönderme işlemleri burada yapılıyor. Bir email onaylama servisi satın alırsam buradan aktif edeceğim.//
            return Task.CompletedTask;
        }
    }
}
