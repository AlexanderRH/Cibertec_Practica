using Practica.Models;
using Practica.Repositories.Dapper.Credit;
using System;
using System.Linq;
using Xunit;

namespace Practica.Repositories.DapperTest
{
    public class MemberRepositoryTest
    {
        private readonly CreditUnitOfWork repo;

        public MemberRepositoryTest()
        {
            repo = new CreditUnitOfWork("Server=.;Database=Credit; Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        [Fact(DisplayName = "[MemberRepository] GelAll")]
        public void Member_Repository_GetAll()
        {
            var result = repo.Member.GetList();
            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "[MemberRepository] Insert")]
        public void Member_Repository_Insert()
        {
            var member = GetNewMember();
            var result = repo.Member.Insert(member);
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "[MemberRepository] Delete")]
        public void Member_Repository_Delete()
        {
            Member member = GetNewMember();
            var result = repo.Member.Insert(member);
            Assert.True(repo.Member.Delete(member));
        }

        private Member GetNewMember()
        {
            return new Member
            {
                lastname = "DORR",
                firstname = "PULRAUPCEY",
                middleinitial = "",
                street = "",
                city = "",
                state_prov = "",
                country = "",
                mail_code = "",
                phone_no = "",
                issue_dt = DateTime.Now,
                expr_dt = DateTime.Now,
                corp_no = 10,
                prev_balance = 0,
                curr_balance = 0,
                member_code = ""
            };
        }

        [Fact(DisplayName = "[MemberRepository] Update")]
        public void Member_Repository_Update()
        {
            var member = repo.Member.GetById(10);
            Assert.True(member != null);

            member.firstname = "Nuevo Nombre";
            Assert.True(repo.Member.Update(member));
        }

        [Fact(DisplayName = "[MemberRepository] GetById")]
        public void Member_Repository_GetById()
        {
            var member = repo.Member.GetById(10);
            Assert.True(member != null);
        }

        [Fact(DisplayName = "[MemberRepository] SearchByNames")]
        public void Member_Repository_SearchByNames()
        {
            var member = repo.Member.SearchByNames("PULRAUPCEY", "DORR");
            Assert.True(member != null);
        }
    }
}
