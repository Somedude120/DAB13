using System;

namespace Handin2_2_RDB.Main.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}