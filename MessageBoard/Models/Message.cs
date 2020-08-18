using System;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(50)]
    public string Heading { get; set; }
    [Required]
    public string Body { get; set;}
    public DateTime DatePosted { get; set; }
    public int BoardId { get; set; }
    public virtual Board Board { get; set; }
    public int Id { get; set; }
  }
}