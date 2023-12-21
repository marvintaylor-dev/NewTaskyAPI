using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs;

namespace NewTaskyAPI.Server.Data.StatusRepository
{
    public interface IStatusRepository
    {
        Task<List<StatusDTO>> GetAllStatuses();
        Task<StatusDTO> AddStatus(StatusDTO status);
        Task<StatusDTO> GetStatusById(int id);
        Task<StatusDTO> GetStatusIdByName(string name);

        Task<StatusDTO> UpdateStatus(StatusDTO status);
        Task<StatusDTO> DeleteStatus(int id);



    }
}
