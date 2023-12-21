using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTaskyAPI.Server.Data;
using NewTaskyAPI.Server.Data.ProductGoalsRepository;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs.Incoming.ProductGoal;
using NewTaskyAPI.Shared.DTOs.Outgoing.ProductGoal;

namespace NewTaskyAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGoalsController : ControllerBase
    {
        private readonly IProductGoalsRepository _repo;
        private readonly IMapper _mapper;

        public ProductGoalsController(IProductGoalsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/ProductGoals
        [HttpGet]
        public async Task<ActionResult<List<GetProductGoalDto>>> GetProductGoals()
        {

            var goalList = await _repo.GetAllAsync();
            var result = _mapper.Map<List<GetProductGoalDto>>(goalList);
            return Ok(result);
        }

        // GET: api/ProductGoals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductGoalDto>> GetProductGoalById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var productGoal = await _repo.GetAsync(id);

            if (productGoal == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetProductGoalDto>(productGoal);

            return Ok(result);
        }

        // PUT: api/ProductGoals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<GetProductGoalDto>> UpdateProductGoal(int id, UpdateProductGoalsDto updateProductGoalsDto)
        {
            if (id != updateProductGoalsDto.ProductGoalId)
            {
                return BadRequest();
            }

            //_repo.Entry(productGoal).State = EntityState.Modified;
            var goal = await _repo.GetAsync(updateProductGoalsDto.ProductGoalId);
            if (goal == null)
            {
                return NotFound("Could not find and update this goal.");
            }

            try
            {
                var mappedDtoToGoal = _mapper.Map(updateProductGoalsDto, goal);
                var updatedGoal = await _repo.UpdateAsync(mappedDtoToGoal);
                var result = _mapper.Map<GetProductGoalDto>(updatedGoal);
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _repo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/ProductGoals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetProductGoalDto>> PostProductGoal(CreateProductGoalDto productGoalDto)
        {
            if (productGoalDto == null)
            {
                return BadRequest("Please enter necessary information to save");
            }
            var productGoal = _mapper.Map<ProductGoal>(productGoalDto);
            var savedGoal = await _repo.AddAsync(productGoal);
            var result = _mapper.Map<GetProductGoalDto>(savedGoal);

            return CreatedAtAction("GetProductGoalById", new { id = productGoal.ProductGoalId }, result);
        }

        // DELETE: api/ProductGoals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetProductGoalDto>> DeleteProductGoal(int id)
        {
            if (id == 0 || id < 0)
            {
                return NotFound();
            }
            var productGoal = await _repo.GetAsync(id);
            if (productGoal == null)
            {
                return NotFound();
            }
            await _repo.DeleteAsync(productGoal.ProductGoalId);
            var result = _mapper.Map<GetProductGoalDto>(productGoal);

            return result;
        }


    }
}
