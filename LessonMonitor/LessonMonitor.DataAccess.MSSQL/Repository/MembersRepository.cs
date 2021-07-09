using System;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class MembersRepository : IMembersRepository
    {
        private LMonitorDbContext _context;
        public MembersRepository(LMonitorDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Core.CoreModels.Member newMember)
        {
            if (newMember is null)
                throw new ArgumentNullException(nameof(newMember));

            var newMemberEntity = new Entities.Member
            {
                Name = newMember.Name,
                GitHubAccountId = newMember.GitHubAccountId
            };

            var result = await _context.AddAsync(newMemberEntity);

            if (result.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();

                return newMemberEntity.Id;
            }
            else
            {
                throw new Exception("Model not added.");
            }
        }

        public async Task<bool> Delete(int memberId)
        {
            if (memberId == default)
                throw new ArgumentException(nameof(memberId));

            var memberExist = await _context.Members.SingleOrDefaultAsync(f => f.Id == memberId && f.DeletedDate == null);

            if (memberExist != null)
            {
                memberExist.DeletedDate = DateTime.Now;

                _context.Members.Update(memberExist);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Core.CoreModels.Member> Get(int memberId)
        {
            if (memberId == default)
                throw new ArgumentException(nameof(memberId));

            var memberExist = await _context.Members.SingleOrDefaultAsync(f => f.Id == memberId && f.DeletedDate == null);

            if (memberExist != null)
            {
                return new Core.CoreModels.Member
                {
                    Id = memberExist.Id,
                    Name = memberExist.Name,
                    GitHubAccountId = memberExist.GitHubAccountId
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Core.CoreModels.Member[]> Get()
        {

            var members = await _context.Members.Where(f => f.DeletedDate == null).ToArrayAsync();

            var coreMembers = new List<Core.CoreModels.Member>();

            if (members.Length != 0 || members is null)
            {
                foreach (var member in members)
                {
                    coreMembers.Add(new Core.CoreModels.Member
                    {
                        Id = member.Id,
                        Name = member.Name,
                        GitHubAccountId = member.GitHubAccountId
                    });
                };

                if (coreMembers.Count > 0)
                {
                    return coreMembers.ToArray();
                }
                else
                {
                    throw new ArgumentNullException(nameof(coreMembers));
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<int> Update(Core.CoreModels.Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            var memberEntity = _context.Members.Where(f => f.Id == member.Id).FirstOrDefault();

            _context.Entry(memberEntity).State = EntityState.Modified;

            memberEntity.Id = member.Id;
            memberEntity.Name = member.Name;
            memberEntity.GitHubAccountId = member.GitHubAccountId;
            memberEntity.UpdatedDate = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return memberEntity.Id;
        }
    }
}
