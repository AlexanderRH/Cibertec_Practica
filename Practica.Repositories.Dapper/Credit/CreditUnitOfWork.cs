using Practica.Repositories.Credit;
using Practica.UnitOfWork;

namespace Practica.Repositories.Dapper.Credit
{
    public class CreditUnitOfWork : IUnitOfWork
    {
        public CreditUnitOfWork(string connectionString)
        {
            Member = new MemberRepository(connectionString);
            Corporation = new CorporationRepository(connectionString);
        }

        public IMemberRepository Member { get; private set; }

        public ICorporationRepository Corporation { get; private set; }
    }
}
