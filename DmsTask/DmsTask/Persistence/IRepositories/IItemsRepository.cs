using DmsTask.Models;

namespace DmsTask.Persistence.IRepositories
{
    public interface IItemsRepository
    {
        public Task<IEnumerable<Items>> Getitems();
        public Task<Items> GetItem(int id);
        public Task<int> AddItem(Items item);
        public Task<int> DeleteItem(int id);
    }
}
