using Microsoft.EntityFrameworkCore;

namespace HotelRoomManagement.DataAccess.Interfaces
{
    public interface IDbContext : IDisposable
    {
        /// <summary>
        ///     Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        int SaveChanges();

        /// <summary>
        ///     Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        Task<int> SaveChangesAsync();

        /// <summary>
        ///     Access to database context
        /// </summary>
        //Database Database { get; }

        DbContext Context { get; }
    }
}
