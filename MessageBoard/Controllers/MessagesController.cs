using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get(DateTime date)
    {
      var query = _db.Messages.AsQueryable();
      
      if (date != null)
      {
        query = query.Where(entry => entry.DatePosted == date);
      }

      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Message message)
    {
      _db.Messages.Add(message);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Message> Get(int id)
    {
      return _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Message message)
    {
      message.MessageId = id;
      _db.Entry(message).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var messageToDelete = _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
      _db.Messages.Remove(messageToDelete);
      _db.SaveChanges();
    }
  }
}