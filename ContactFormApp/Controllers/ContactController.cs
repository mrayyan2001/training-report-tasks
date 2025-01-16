using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ContactFormApp.Models;
using System.Data;

public class ContactController : Controller
{
    private string _connectionString = "Server=MRAYYAN;Database=contact_db;Trusted_Connection=True;TrustServerCertificate=True;";



    // Action to display the contact form
    public IActionResult Index()
    {
        return View(new ContactMessage());  // Pass an empty model to the view
    }

    public IActionResult SendMessages()
    {
        return View(new ContactMessage()); // Ensure there is a corresponding SendMessages.cshtml view
    }

    // Action to handle form submission
    [HttpPost]
    public IActionResult SubmitForm(ContactMessage model)
    {
        if (ModelState.IsValid)
        {
            // Save the data to the database
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO ContactMessages (Name, Email, Subject, Message) VALUES (@Name, @Email, @Subject, @Message)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Subject", model.Subject ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Message", model.Message);

                    try
                    {
                        command.ExecuteNonQuery();  // Execute the query to insert the data
                    }
                    catch (Exception ex)
                    {
                        // Handle the error (optional)
                        ModelState.AddModelError("", "There was an error saving your message. Please try again.");
                        return View("SendMessages", model);
                    }
                }
            }

            // Redirect to the form again or show a success message
            return RedirectToAction("SendMessages");
        }

        // If the form is invalid, return the form with validation errors
        return View("SendMessages", model);
    }

    // Action to display all messages
    public IActionResult ViewMessages()
    {
        List<ContactMessage> messages = new List<ContactMessage>();

        // Get all messages from the database using ADO.NET
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT MessageID, Name, Email, Subject, Message, SubmittedAt FROM ContactMessages";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var message = new ContactMessage
                        {
                            MessageID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Subject = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Message = reader.GetString(4),
                            SubmittedAt = reader.GetDateTime(5)
                        };
                        messages.Add(message);
                    }
                }
            }
        }

        // Pass messages to the view
        return View(messages);
    }
}
