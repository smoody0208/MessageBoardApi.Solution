using System;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Heading { get; set; }
    public string Body { get; set;}
    public DateTime DatePosted { get; set; }
    public int BoardId { get; set; }
    public virtual Board Board { get; set; }
  }
}