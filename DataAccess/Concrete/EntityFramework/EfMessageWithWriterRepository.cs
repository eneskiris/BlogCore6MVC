using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfMessageWithWriterRepository : GenericRepository<MessageWithWriter>, IMessageWithWriterDal
{
    public List<MessageWithWriter> GetListWithMessageByWriter(int id)
    {
        using (var _context = new BlogDemoContext())
        {
            return _context.MessageWithWriters.Include(x => x.SenderUser).Where(x=>x.ReceiverId == id).ToList();
        }
    }
}