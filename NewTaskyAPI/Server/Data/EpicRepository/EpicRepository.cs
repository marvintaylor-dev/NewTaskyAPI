using AutoMapper;
using Microsoft.EntityFrameworkCore;
//using NewTaskyAPI.Client.Services.TaskService;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs.Incoming.Epic;
using NewTaskyAPI.Shared.DTOs.Outgoing.Epic;

namespace NewTaskyAPI.Server.Data.EpicRepository
{
    public class EpicRepository : GenericRepository<Epic>, IEpicRepository
    {

        private readonly AppDbContext _context;

        public EpicRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Epic>> GetAllEpics()
        {
            var result = await _context.Epics.Include(x => x.UserStoriesInEpic).ToListAsync() ?? throw new Exception("Could not get Epics.");

            if (result == null)
            {
                throw new Exception("No Epics were found.");
            }
            else
            {
                return result;
            }
        }

        public async Task<Epic> GetEpicById(int? id)
        {
            if (id is null)
            {
                throw new Exception("No Epics were found.");
            }
            else
            {
                var result = await _context.Epics.Include(x => x.UserStoriesInEpic).FirstOrDefaultAsync(x => x.EpicId == id) ?? throw new Exception("Could not get Epics.");
                return result;
            }
        }

        public async Task<Epic> UpdateEpic(Epic Epic)
        {
            Epic result = _context.Epics.Include(x => x.UserStoriesInEpic).FirstOrDefault(s => s.EpicId == Epic.EpicId) ?? throw new Exception($"Could not find id");
            // _mapper.Map(Epic, result);

            //result.EpicId = Epic.EpicId;
            if (Epic != null)
            {
                result.EpicName = Epic.EpicName;
                result.EpicBudget = Epic.EpicBudget;
                result.EpicCategory = Epic.EpicCategory;
                result.EpicColor = Epic.EpicColor;
                result.UserStoriesInEpic = Epic.UserStoriesInEpic;
            }

            await _context.SaveChangesAsync();
            return result;
        }
    }
}
