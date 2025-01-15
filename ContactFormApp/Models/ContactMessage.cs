// Models/ContactMessage.cs

namespace ContactFormApp.Models

{
    public class ContactMessage
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }

        public ContactMessage() { }

        public ContactMessage(string name, string email, string subject, string message)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Message = message;
            SubmittedAt = DateTime.Now;
        }
    }
}