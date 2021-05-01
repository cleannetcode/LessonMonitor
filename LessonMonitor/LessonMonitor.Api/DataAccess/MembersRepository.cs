using LessonMonitor.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.Api.DataAccess
{
    public class MembersRepository
    {
        private readonly List<Member> _members;

        public MembersRepository()
        {
            _members = new List<Member>()
            {
                new Member { Id = 1, UserName = "pingvin1308", FullName = "Роман" },
                new Member { Id = 2, UserName = "coder", FullName = "Михаил" },
                new Member { Id = 3, UserName = "eniluck", FullName = "Андрей" },
                new Member { Id = 4, UserName = "emedvedeva", FullName = "Евгения" },
                new Member { Id = 5, UserName = "kalilask4", FullName = "Диана" },
            };
        }

        public void Add(Member member)
        {
            if (member == null)
                throw new ArgumentNullException();

            member.Id = _members.Count + 1;
            _members.Add(member);
        }

        public void Update(Member member)
        {
            if (member == null)
                throw new ArgumentNullException();

            var idx = _members.IndexOf(member);

            if (idx > 0)
            {
                _members[idx] = member;
            }
        }

        public Member GetById(int id) => _members.FirstOrDefault(x => x.Id.Equals(id));
        public Member[] All() => _members.ToArray();
    }
}
