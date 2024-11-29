using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<ServiceResponse<IEnumerable<T>>> GetAllAsync();
        Task<ServiceResponse<T>> GetAsync(params object[] keys);
    }
}
