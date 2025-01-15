using System;

public class ContactMessage
{
    public int MessageID { get; set; }       // Unique identifier for each message
    public string Name { get; set; }         // Name of the sender
    public string Email { get; set; }        // Email address of the sender
    public string Subject { get; set; }      // Subject of the message (optional)
    public string Message { get; set; }      // The content of the message
    public DateTime SubmittedAt { get; set; } // Timestamp when the message was submitted

    // Constructor to initialize a new contact message
    public ContactMessage(string name, string email, string subject, string message)
    {
        Name = name;
        Email = email;
        Subject = subject;
        Message = message;
        SubmittedAt = DateTime.Now;  // Set the timestamp to the current time
    }

    // Default constructor for ORM (e.g., Entity Framework) purposes
    public ContactMessage() { }
}
