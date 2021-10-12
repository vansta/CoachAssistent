using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers
{
    public interface IGroupManager
    {
        Task<int> Create(CreateGroupViewModel createGroupViewModel);
        Task<int> DeleteGroup(Guid groupId);
        IList<GroupViewModel> Get(Guid? clubId);
    }

    public class GroupManager : IGroupManager
    {
        readonly CoachAssistentDbContext dbContext;
        readonly IMapper mapper;
        public GroupManager(CoachAssistentDbContext context, IMapper _mapper)
        {
            dbContext = context;
            mapper = _mapper;
        }

        public IList<GroupViewModel> Get(Guid? clubId)
        {
            return dbContext.Groups
                .Where(g => !clubId.HasValue || g.ClubId.Equals(clubId.Value))
                .Select(g => mapper.Map<GroupViewModel>(g)).ToList();
        }

        public async Task<int> Create(CreateGroupViewModel createGroupViewModel)
        {
            await dbContext.Groups.AddAsync(mapper.Map<Group>(createGroupViewModel));
            return await dbContext.SaveChangesAsync();
        }

        public Task<int> DeleteGroup(Guid groupId)
        {
            dbContext.Groups.Remove(dbContext.Groups.Find(groupId));
            return dbContext.SaveChangesAsync();
        }
    }
}
