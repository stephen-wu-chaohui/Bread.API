using AutoMapper;
using Bread.Domain.Dto;
using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Application.Repositoies;
using Bread.Infrastructure.Data.DbContexts;
using Bread.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.Infrastructure.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GroupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Group>> GetHostedGroups(string userId)
        {
            return await _dbContext.Groups.Where(g => g.AdministratorId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetParticipatedGroups(string userId)
        {
            var groups = (from g in _dbContext.Groups
                          join p in _dbContext.Participates on g.Id equals p.GroupId
                          where p.UserId == userId
                          select g);
            return await groups.ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetPublicGroups()
        {
            return await _dbContext.Groups.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetGroupMembers(int groupId)
        {
            var group = _dbContext.Groups.Find(groupId);
            if (groupId == 0) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            var members = await (from u in _dbContext.Users
                           join p in _dbContext.Participates on u.Id equals p.UserId
                           where p.GroupId == groupId
                           select u).ToListAsync();
            return members;
        }

        public async Task<Group> CreateGroup(string userId, GroupInfo info)
        {
            var user = _dbContext.Users.Find(userId);
            if (user == null) {
                throw new BreadException(BreadExceptionCode.UserIsUnknown, $"Invalid User Id: {userId}");
            }

            var group = new Group();
            group.SetAdministrator(userId);
            group.SetInfo(info);

            await _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync();

            await JoinGroup(userId, group.Id);
            return group;
        }

        public async Task<Group> ChangeAdministrator(int groupId, string userId)
        {
            var group = _dbContext.Groups.Find(groupId);
            if (groupId == 0) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            _dbContext.Groups.Update(group);
            group.SetAdministrator(userId);
            await _dbContext.SaveChangesAsync();
            return group;
        }

        public async Task UpdateGroupInfo(int groupId, GroupInfo info)
        {
            var group = _dbContext.Groups.Find(groupId);
            if (groupId == 0) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            _dbContext.Groups.Update(group);
            group.SetInfo(info);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CloseGroup(int groupId)
        {
            var group = _dbContext.Groups.Find(groupId);
            if (group == null) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task JoinGroup(string userId, int groupId)
        {
            if (groupId == 0) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new BreadException(BreadExceptionCode.UserIsUnknown, $"Invalid User Id: {userId}");
            }
            var existing = _dbContext.Participates.FirstOrDefault(p => p.UserId == userId && p.GroupId == groupId);
            if (existing == null) {
                _dbContext.Participates.Add(new Participate { UserId = userId, GroupId = groupId });
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task LeaveGroup(string userId, int groupId)
        {
            if (groupId == 0) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new BreadException(BreadExceptionCode.UserIsUnknown, $"Invalid User Id: {userId}");
            }

            var existing = _dbContext.Participates.FirstOrDefault(p => p.UserId == userId && p.GroupId == groupId);
            if (existing != null) {
                _dbContext.Participates.Remove(existing);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Group> GetGroupById(int groupId)
        {
            var existing = await _dbContext.Groups.FirstOrDefaultAsync(g => g.Id == groupId);
            if (existing == null) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown, $"Invalid Group Id: {groupId}");
            }
            return existing;
        }
    }
}
