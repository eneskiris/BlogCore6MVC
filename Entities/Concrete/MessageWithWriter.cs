using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class MessageWithWriter
{
    [Key]
    public int MessageId { get; set; }

    public int? SenderId { get; set; }
    public int? ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public Writer SenderUser { get; set; }
    public Writer ReceiverUser { get; set; }
}