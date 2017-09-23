using Practica.Models;
using Practica.Repositories.Dapper.Credit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Practica.Repositories.DapperTest
{
    public class CorporationRepositoryTest
    {
        private readonly CreditUnitOfWork repo;

        public CorporationRepositoryTest()
        {
            repo = new CreditUnitOfWork("Server=.;Database=Credit; Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        [Fact(DisplayName = "[CorporationRepository] GelAll")]
        public void Corporation_Repository_GetAll()
        {
            var result = repo.Corporation.GetList();
            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "[CorporationRepository] Insert")]
        public void Corporation_Repository_Insert()
        {
            var corporation = GetNewCorporation();
            var result = repo.Corporation.Insert(corporation);
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "[CorporationRepository] Delete")]
        public void Corporation_Repository_Delete()
        {
            Corporation corporation = GetNewCorporation();
            var result = repo.Corporation.Insert(corporation);
            Assert.True(repo.Corporation.Delete(corporation));
        }

        private Corporation GetNewCorporation()
        {
            return new Corporation
            {
                corp_name = "New Corporation",
                street = "",
                city = "",
                state_prov = "",
                country = "",
                mail_code = "",
                phone_no = "",
                expr_dt = DateTime.Now,
                corp_code = ""
            };
        }

        [Fact(DisplayName = "[CorporationRepository] Update")]
        public void Corporation_Repository_Update()
        {
            var corporation = repo.Corporation.GetById(10);
            Assert.True(corporation != null);

            corporation.corp_name = "Nuevo Nombre";
            Assert.True(repo.Corporation.Update(corporation));
        }

        [Fact(DisplayName = "[CorporationRepository] GetById")]
        public void Corporation_Repository_GetById()
        {
            var corporation = repo.Corporation.GetById(10);
            Assert.True(corporation != null);
        }

        [Fact(DisplayName = "[CorporationRepository] SearchByName")]
        public void Corporation_Repository_SearchByName()
        {
            var member = repo.Corporation.SearchByName("Corp. Apex NeedleworkInc.");
            Assert.True(member != null);
        }
    }
}
