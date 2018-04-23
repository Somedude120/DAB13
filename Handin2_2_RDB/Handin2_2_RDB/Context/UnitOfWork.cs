using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Main.Interface;

namespace Handin2_2_RDB.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonIndexContext _context;

        public UnitOfWork(PersonIndexContext context)
        {
            _context = context;
            Ops = new Operations();
            Operations = new CrudRepository(_context);
        }

        public IOperationsRepository Operations { get; set; }
        public IOperations Ops { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}