using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MessageBoard.Controllers
{
  [Authorize(Roles = Role.User)]
  [Route("api/[controller]")]
  [ApiController]
  public class BoardsController : ControllerBase
  {
    private MessageBoardContext _db;

    public BoardsController(MessageBoardContext db)
    {
      _db = db;
    }

    [Authorize(Roles = Role.User)]
    [HttpGet]
    public ActionResult<IEnumerable<Board>> Get(string name)
    {
      var query = _db.Boards.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      return query.ToList();
    }

    [Authorize(Roles = Role.User)]
    [HttpPost]
    public void Post([FromBody] Board board)
    {
      // Message associatedMessage = _db.Messages.FirstOrDefault(message => message.MessageId == messageId);
      // board.Messages.Add(associatedMessage);
      // _db.Boards.Add(board);
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.User)]
    [HttpGet("{id}")]
    public ActionResult<Board> Get(int id)
    {
      Board newBoard = _db.Boards.FirstOrDefault(entry => entry.BoardId == id);
      newBoard.Messages = _db.Messages.Where(messages => messages.BoardId == id).ToList();
      return newBoard;
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var boardToDelete = _db.Boards.FirstOrDefault(entry => entry.BoardId == id);
      _db.Boards.Remove(boardToDelete);
      _db.SaveChanges();
    }
  }
}