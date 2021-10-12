using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers
{
    public interface IClubManager
    {
        Task<int> Create(CreateClubViewModel createViewModel);
        Task<int> Delete(Guid id);
        IList<ClubViewModel> Get(string name);
    }

    public class ClubManager : IClubManager
    {
        readonly CoachAssistentDbContext dbContext;
        readonly IMapper mapper;

        public ClubManager(CoachAssistentDbContext context, IMapper _mapper, IConfiguration configuration)
        {
            dbContext = context;
            mapper = _mapper;
        }

        public IList<ClubViewModel> Get(string name)
        {
            return dbContext.Clubs
                .Where(g => string.IsNullOrEmpty(name) || g.Name.Contains(name))
                .Select(g => mapper.Map<ClubViewModel>(g)).ToList();
        }

        public async Task<int> Create(CreateClubViewModel createViewModel)
        {
            if (dbContext.Clubs.Any(c => c.Name.Equals(createViewModel.Name)))
            {
                throw new Exception($"A club already exists by the name of {createViewModel.Name}");
            }
            await dbContext.Clubs.AddAsync(mapper.Map<Club>(createViewModel));
            return await dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(Guid id)
        {
            dbContext.Clubs.Remove(dbContext.Clubs.Find(id));
            return dbContext.SaveChangesAsync();
        }
    }
}
