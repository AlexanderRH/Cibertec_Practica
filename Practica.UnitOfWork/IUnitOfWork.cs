using Practica.Repositories.Credit;

namespace Practica.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMemberRepository Member { get; }
        ICorporationRepository Corporation { get; }
    }
}
