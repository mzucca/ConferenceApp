namespace ReHub.Utilities.Models
{
    public partial class MailTemplate
    {
        public string Template {  get; set; }
        public object Context {  get; set; }
        public string Subject {  get; set; }
        public string To {  get; set; }
        public string Body {  get; set; }
    }
}
