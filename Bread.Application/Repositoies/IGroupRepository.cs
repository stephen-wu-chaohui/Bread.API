using Bread.Domain.Dto;
using Bread.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Application.Repositoies
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetHostedGroups(string userId);
        Task<IEnumerable<Group>> GetParticipatedGroups(string userId);
        Task<IEnumerable<Group>> GetPublicGroups();

        Task<IEnumerable<ApplicationUser>> GetGroupMembers(int groupId);

        Task<Group> GetGroupById(int groupId);
        Task<Group> CreateGroup(string userId, GroupInfo info);

        Task UpdateGroupInfo(int groupId, GroupInfo info);
        Task CloseGroup(int groupId);
        Task JoinGroup(string userId, int groupId);
        Task LeaveGroup(string userId, int groupId);
    }
}
