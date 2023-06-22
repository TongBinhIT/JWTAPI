using JWTAPI.Data;


namespace JWTAPI.Service
{
    public interface IModelAreaRepository
    {
        public Task<List<Area>> getAllAreaAsync();
        public Task<Area> getAreaAsync(int id);
        public Task<int> AddAreaAsync(Area model);
        public Task UpdateAreaAsync(int id, Area model);
        public Task DeleteAreaAsync(int id);
    }
}
