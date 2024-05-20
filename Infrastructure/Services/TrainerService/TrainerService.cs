using AutoMapper;
using Domain.Responses;
using Domain.DTOs.TrainerDto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Domain.Filters;
using System.Data.Common;

namespace Infrastructure.Services.TrainerService;

public class TrainerService : ITrainerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TrainerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> CreateTrainerAsync(CreateTrainerDto Trainer)
    {
        try
        {
            var existingTrainer = await _context.Trainers.FirstOrDefaultAsync(x => x.Name == Trainer.Name);
            if (existingTrainer != null)
                return new Response<string>(HttpStatusCode.BadRequest, "Trainer already exists");
            var mapped = _mapper.Map<Trainer>(Trainer);

            await _context.Trainers.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new Trainer");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteTrainerAsync(int id)
    {
        try
        {
            var Trainers = await _context.Trainers.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (Trainers == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Trainers not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetTrainerDto>> GetTrainerByIdAsync(int id)
    {
        try
        {
            var Trainers = await _context.Trainers.FirstOrDefaultAsync(x => x.Id == id);
            if (Trainers == null)
                return new Response<GetTrainerDto>(HttpStatusCode.BadRequest, "Trainer not found");
            var mapped = _mapper.Map<GetTrainerDto>(Trainers);
            return new Response<GetTrainerDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetTrainerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PagedResponse<List<GetTrainerDto>>> GetTrainersAsync(TrainerFilter filter)
    {
        try
        {
            var Trainers = _context.Trainers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                Trainers = Trainers.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            if (!string.IsNullOrEmpty(filter.Email.ToString()))
                Trainers = Trainers.Where(x => x.Email.ToString().ToLower().Contains(filter.Email.ToString().ToLower()));

            var response = await Trainers
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var totalRecord = Trainers.Count();

            var mapped = _mapper.Map<List<GetTrainerDto>>(response);
            return new PagedResponse<List<GetTrainerDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);

        }
        catch (DbException dbEx)
        {
            return new PagedResponse<List<GetTrainerDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<GetTrainerDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }



    public async Task<Response<string>> UpdateTrainerAsync(UpdateTrainerDto Trainer)
    {
        try
        {
            var mapped = _mapper.Map<Trainer>(Trainer);
            _context.Trainers.Update(mapped);
            var update = await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "Trainers not found");
            return new Response<string>("Trainers updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
