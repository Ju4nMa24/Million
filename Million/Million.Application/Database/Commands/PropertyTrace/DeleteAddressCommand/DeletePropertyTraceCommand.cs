using Microsoft.EntityFrameworkCore;

namespace Million.Application.Database.Commands.PropertyTrace.DeleteAddressCommand
{
    /// <summary>
    /// Delete command for PropertyTrace.
    /// </summary>
    public class DeletePropertyTraceCommand(IDataBaseService db) : IDeletePropertyTraceCommand
    {
        private readonly IDataBaseService _db = db;

        /// <summary>
        /// Deletes a PropertyTrace by ID.
        /// </summary>
        public async Task<bool> Execute(Guid id)
        {
            var trace = await _db.PropertyTraces.FirstOrDefaultAsync(p => p.IdPropertyTrace == id);
            if (trace == null)
                return false;

            _db.PropertyTraces.Remove(trace);
            await _db.SaveAsync();
            return true;
        }
    }
}
