using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Notification
{
    [Key]
    public int NotificationId { get; set; }
    public string Type { get; set; }
    public string TypeSymbol { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}