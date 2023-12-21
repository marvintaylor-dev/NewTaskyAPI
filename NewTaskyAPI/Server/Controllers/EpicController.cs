using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using NewTaskyAPI.Client.Services.TaskService;
using NewTaskyAPI.Server.Data.EpicRepository;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs.Incoming.Epic;
using NewTaskyAPI.Shared.DTOs.Incoming.Tasks;
using NewTaskyAPI.Shared.DTOs.Outgoing.Epic;

namespace NewTaskyAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicController : ControllerBase
    {

        private readonly IEpicRepository _repository;
        private readonly ITaskRepository _taskRepo;
        private readonly IMapper _mapper;

        public EpicController(IEpicRepository repo, IMapper mapper, ITaskRepository taskRepo)
        {
            _repository = repo;
            _mapper = mapper;
            _taskRepo = taskRepo;
        }


        [HttpGet]
        public async Task<ActionResult<List<GetEpicDTO>>> GetEpics()
        {
            try
            {
                List<Epic> epics = await _repository.GetAllEpics();
                var listOfEpicDTOs = _mapper.Map<List<GetEpicDTO>>(epics);

                return Ok(listOfEpicDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database. {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEpicDTO>> GetEpic(int id)
        {
            try
            {
                var epic = await _repository.GetEpicById(id);
                var result = _mapper.Map<GetEpicDTO>(epic);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops! Could not get this epic from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Epic>> CreateEpic(CreateEpicDTO createEpicDTO)
        {
            try
            {
                if (createEpicDTO is null)
                {
                    return BadRequest("Your epic did not contain essential information.");
                }
                var epic = _mapper.Map<Epic>(createEpicDTO);
                var result = await _repository.AddAsync(epic);

                return CreatedAtAction("GetEpics", new { id = result.EpicId }, epic);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops! Something went wrong while creating the epic. Please try again later.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetEpicDTO>> UpdateEpic(UpdateEpicDTO updateEpicDto)
        {
            try
            {
                if (updateEpicDto == null)
                {
                    return NotFound($"Epic was empty or missing key information.");
                }
    
                Epic updatedEpic = _mapper.Map<Epic>(updateEpicDto);

                List<NoteModel> userStories = new();
                foreach(var task in updateEpicDto.UserStoriesInEpic)
                {
                   NoteModel newTask = await _taskRepo.GetTaskById(task.TaskId);
                    if (newTask == null)
                    {
                        return NotFound("There was an error in adding or removing tasks to your epic. Changes not saved.");
                    }
                   userStories.Add(newTask);
                }

                updatedEpic.UserStoriesInEpic = userStories;
                Epic submittedEpic = await _repository.UpdateEpic(updatedEpic);
                var result = _mapper.Map<GetEpicDTO>(submittedEpic);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Epic>> DeleteEpic(int id)
        {
            try
            {
                var FindDeletedEpic = await _repository.GetAsync(id);
                if (FindDeletedEpic == null)
                {
                    return NotFound("Could not find the item to be deleted.");
                }
                var deletedEpic = await _repository.DeleteAsync(id);

                return Ok(deletedEpic);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }
        }
    }
}
