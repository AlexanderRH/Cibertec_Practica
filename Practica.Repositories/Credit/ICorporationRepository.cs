using Practica.Models;

namespace Practica.Repositories.Credit
{
    public interface ICorporationRepository: IRepository<Corporation>
    {
        Corporation SearchByName(string corp_name);
    }
}
