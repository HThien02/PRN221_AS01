using BusinessObject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> memberList;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    memberList = sale.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return memberList;
        }

        public Member getMemberById(int id)
        {
            Member member = null;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    member = sale.Members.SingleOrDefault(m => m.MemberId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public Member getMemberByEmail(string email, string password)
        {
            Member member = null;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    member = sale.Members.SingleOrDefault(m =>
                    m.Email.Equals(email) && m.Password.Equals(password));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m == null)
                {
                    using (var sale = new PRN221_AS1Context())
                    {
                        sale.Members.Add(member);
                        sale.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("This member already exists");
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m != null)
                {
                    using (var MySale = new PRN221_AS1Context())
                    {
                        MySale.Entry<Member>(member).State = EntityState.Modified;
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void DeleteMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m != null)
                {
                    using (var sale = new PRN221_AS1Context())
                    {
                        sale.Members.Remove(member);
                        sale.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("The member doesn't exist");
            }
        }

    }
}
