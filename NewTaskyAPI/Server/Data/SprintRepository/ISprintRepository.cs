using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs;

namespace NewTaskyAPI.Server.Data.SprintRepository
{
    public interface ISprintRepository
    {
        Task<List<SprintModel>> GetSprints();
        Task<SprintModel> GetSprintById(int id);
        Task<SprintModel> AddSprint(SprintModel newSprint);
        Task<SprintModel> DeleteSprintById(int id);
        Task<SprintModel> UpdateSprint(SprintModel updateSprint);
        Task<SprintModel> LinkSprint(SprintTaskDTO sprintUpdate);

        Task<SprintTaskDTO> DeleteSprintTaskRelationship(int taskId, int sprintId);
    }
}
