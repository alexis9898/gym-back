using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IMuscleRepository
    {
        Task<List<Muscle>> GetAll();
        Task<Muscle> Get(int id);
        Task<Muscle> Add(Muscle muscle);
        Task Set(Muscle muscle);
        Task Delete(Muscle muscle);
    }
}
