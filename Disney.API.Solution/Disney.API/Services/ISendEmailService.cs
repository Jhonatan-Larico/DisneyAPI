using Disney.API.Dtos;

namespace Disney.API.Services
{
    public interface ISendEmailService
    {
        void SendEmail(EmailDto request);

    }
}
