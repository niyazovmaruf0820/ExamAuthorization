using AutoMapper;
using Domain.Responses;
using Domain.DTOs.UserDto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Domain.Filters;
using System.Data.Common;

namespace Infrastructure.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> CreateUserAsync(CreateUserDto User)
    {
        try
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Name == User.Name);
            if (existingUser != null)
                return new Response<string>(HttpStatusCode.BadRequest, "User already exists");
            var mapped = _mapper.Map<User>(User);

            await _context.Users.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new User");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteUserAsync(int id)
    {
        try
        {
            var Users = await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (Users == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Users not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetUserDto>> GetUserByIdAsync(int id)
    {
        try
        {
            var Users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (Users == null)
                return new Response<GetUserDto>(HttpStatusCode.BadRequest, "User not found");
            var mapped = _mapper.Map<GetUserDto>(Users);
            return new Response<GetUserDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PagedResponse<List<GetUserDto>>> GetUsersAsync(PaginationFilter filter)
    {
        try
        {
            var Users = _context.Users.AsQueryable();
            var response = await Users
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var totalRecord = Users.Count();

            var mapped = _mapper.Map<List<GetUserDto>>(response);
            return new PagedResponse<List<GetUserDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);

        }
        catch (DbException dbEx)
        {
            return new PagedResponse<List<GetUserDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<GetUserDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }



    public async Task<Response<string>> UpdateUserAsync(UpdateUserDto User)
    {
        try
        {
            var mapped = _mapper.Map<User>(User);
            _context.Users.Update(mapped);
            var update = await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "Users not found");
            return new Response<string>("Users updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
