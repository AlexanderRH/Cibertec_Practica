using Practica.Models;

namespace Practica.Repositories.Credit
{
    public interface IMemberRepository: IRepository<Member>
    {
        Member SearchByNames(string firstName, string lastName);
    }
}
