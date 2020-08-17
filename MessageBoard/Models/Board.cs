using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Board
  {
    public Board()
    {
      this.Messages = new HashSet<Message>(); 
    }
    public int BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
  }
}