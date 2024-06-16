//using ReHub.DbDataModel.Models;
//using System.Text.Json.Serialization;

//namespace ReHub.BackendAPI.Models
//{
//    public class NotificationOut
//    {
//        public NotificationOut() { }
//        public NotificationOut(NotificationRecipient recipient) 
//        {
//            Id = recipient.Id;
//            UserSeen = recipient.UserSeen;
//            Sender = new UserOut(recipient.User);
//            CreatedAt = recipient.CreatedAt;
//            Message = recipient.Notification.Message;
//            //notification.
//            // TODO why userSeen is global ???UserSeen = notification.us
//        }
//        [JsonPropertyName("id")]
//        public int Id { get; set; }
//        [JsonPropertyName ("user_seen")]
//        public bool UserSeen {  get; set; }
//        [JsonPropertyName ("sender")]
//        public UserOut Sender { get; set; }
//        [JsonPropertyName("created_at")]
//        public DateTime CreatedAt { get; set; }
//        [JsonPropertyName("message")]
//        public string Message { get; set; }

//    }
//}
