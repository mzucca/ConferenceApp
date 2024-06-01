﻿namespace ReHub.Utilities.Services
{
    /// <summary>
    /// Service to send emails
    /// </summary>
    public interface IMailSender
    {
        bool SendMessage(string message, string to, string subject);
    }
}