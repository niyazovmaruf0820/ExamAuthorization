using AutoMapper;
using Domain.Responses;
using Domain.DTOs.ClassSchduleDto;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Domain.Entities;
using Domain.Filters;
using System.Data.Common;

namespace Infrastructure.Services.ClassSchduleService;

public class ClassSchduleService : IClassSchduleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ClassSchduleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> CreateClassSchduleAsync(CreateClassSchduleDto ClassSchdule)
    {
        try
        {
            var mapped = _mapper.Map<ClassSchedule>(ClassSchdule);

            await _context.ClassSchedules.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new ClassSchdule");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteClassSchduleAsync(int id)
    {
        try
        {
            var ClassSchdules = await _context.ClassSchedules.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (ClassSchdules == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "ClassSchdules not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetClassSchduleDto>> GetClassSchduleByIdAsync(int id)
    {
        try
        {
            var ClassSchdules = await _context.ClassSchedules.FirstOrDefaultAsync(x => x.Id == id);
            if (ClassSchdules == null)
                return new Response<GetClassSchduleDto>(HttpStatusCode.BadRequest, "ClassSchdule not found");
            var mapped = _mapper.Map<GetClassSchduleDto>(ClassSchdules);
            return new Response<GetClassSchduleDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetClassSchduleDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PagedResponse<List<GetClassSchduleDto>>> GetClassSchdulesAsync(PaginationFilter filter)
    {
        try
        {
            var ClassSchdules = _context.ClassSchedules.AsQueryable();


            var response = await ClassSchdules
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var totalRecord = ClassSchdules.Count();

            var mapped = _mapper.Map<List<GetClassSchduleDto>>(response);
            return new PagedResponse<List<GetClassSchduleDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);

        }
        catch (DbException dbEx)
        {
            return new PagedResponse<List<GetClassSchduleDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<GetClassSchduleDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }



    public async Task<Response<string>> UpdateClassSchduleAsync(UpdateClassSchduleDto ClassSchdule)
    {
        try
        {
            var mapped = _mapper.Map<ClassSchedule>(ClassSchdule);
            _context.ClassSchedules.Update(mapped);
            var update = await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "ClassSchdules not found");
            return new Response<string>("ClassSchdules updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
