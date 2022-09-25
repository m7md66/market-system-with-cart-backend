using DmsTask.Models;
using DmsTask.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DmsTask.Persistence.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly DmsContext _context;
        public ItemsRepository(DmsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Items>> Getitems()
        {

            return await _context.Items.ToListAsync();
        }

        public async Task<Items> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            return item;
        }

        public async Task<int> AddItem(Items item)
        {
            _context.Items.Add(item);
            var result = await _context.SaveChangesAsync();
            if (result == 1) { return 1; }
            else { return 0; }
        }

        public async Task<int> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            _context.Items.Remove(item);
            var result = await _context.SaveChangesAsync();
            if (result == 1) { return 1; }
            else
            {
                return 0;
            }

        }

    }
}
