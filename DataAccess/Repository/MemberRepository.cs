using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetAllMembers() => MemberDAO.Instance.GetAllMembers();

        public void AddMember(Member member) => MemberDAO.Instance.AddMember(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
        
        public void DeleteMember(Member member) => MemberDAO.Instance.DeleteMember(member);

        public Member getMemberById(int id) => MemberDAO.Instance.getMemberById(id);

        public Member getMemberByEmail(string email, string password) => MemberDAO.Instance.getMemberByEmail(email, password);

    }
}
