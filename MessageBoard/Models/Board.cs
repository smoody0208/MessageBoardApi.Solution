using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Board
  {
    public Board()
    {
      this.Posts = new HashSet<Post>(); 
    }
    public int BoardId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
  }
}