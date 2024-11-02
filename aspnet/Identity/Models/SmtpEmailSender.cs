using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public class SmtpEmailSender : IEmailSender
    {
        private string? _host;
        private int _port;
        private bool _enableSSL;
        private string? _username;
        private string? _password;

        public SmtpEmailSender(string? host, int port, bool enableSSL, string? username, string? password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // 'from' adresini belirle
            var fromAddress = string.IsNullOrEmpty(_username) ? "varsayılan_email@domain.com" : _username;

            // SMTP istemcisini oluştur
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username ?? "", _password ?? ""),
                EnableSsl = _enableSSL
            };

            // MailMessage nesnesini oluştur
            var mailMessage = new MailMessage(fromAddress, email, subject, message) { IsBodyHtml = true };

            try
            {
                // E-postayı gönder
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                // Loglama veya uygun bir hata mesajı
                Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
            }
        }
    }
}
