using DisneyAPI.Dtos;

namespace DisneyAPI.Services
{
    public interface ISendEmailService
    {
        void SendEmail(EmailDto request);

    }
}
