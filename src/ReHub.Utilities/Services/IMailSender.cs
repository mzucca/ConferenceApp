namespace ReHub.Utilities.Services
{
    /// <summary>
    /// Service to send emails
    /// </summary>
    public interface IMailSender
    {
        void SendTextMessage(string message,string to,string subject)
        {

        }
    }
}
