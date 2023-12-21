using NewTaskyAPI.Server.Data.GenericRepository;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs.Incoming.Epic;

namespace NewTaskyAPI.Server.Data.EpicRepository
{
    public interface IEpicRepository : IGenericRepository<Epic>
    {
        Task<Epic> UpdateEpic(Epic epic);
        Task<Epic> GetEpicById(int? id);
        Task<List<Epic>> GetAllEpics();

    }
}
