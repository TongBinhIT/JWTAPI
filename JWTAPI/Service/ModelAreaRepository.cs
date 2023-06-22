using AutoMapper;
using JWTAPI.Data;
using JWTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAPI.Service
{
    public class ModelAreaRepository : IModelAreaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ModelAreaRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddAreaAsync(Area model)
        {
            var newArea = _mapper.Map<ModelArea>(model);
            _context.ModelArea!.Add(newArea);
            await _context.SaveChangesAsync();

            return newArea.IdArea;
        }

        public async Task DeleteAreaAsync(int id)
        {
            var deleteArea = _context.ModelArea!.SingleOrDefault(a => a.IdArea == id);
            if (deleteArea != null)
            {
                _context.ModelArea!.Remove(deleteArea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Area>> getAllAreaAsync()
        {
            var areas = await _context.ModelArea!.ToListAsync();
            return _mapper.Map<List<Area>>(areas);
        }

        public async Task<Area> getAreaAsync(int id)
        {
            var area = await _context.ModelArea!.FindAsync(id);
            return _mapper.Map<Area>(area);
        }

        public async Task UpdateAreaAsync(int id, Area model)
        {
            if (id == model.IdArea)
            {
                var updateArea = _mapper.Map<ModelArea>(model);
                _context.ModelArea!.Update(updateArea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
