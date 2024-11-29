using BenefitsCalculator.Common.Models;
using BenefitsCalculator.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculator.Service
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly DbContext _context;

        public EmployeeService(DbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<IEnumerable<Employee>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<Employee>().ToListAsync();

                return new ServiceResponse<IEnumerable<Employee>>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Data = entities,
                    Message = $"Found {entities.Count()} records."
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ServiceResponse<IEnumerable<Employee>>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }

        public async Task<ServiceResponse<Employee>> GetAsync(params object[] keys)
        {
            try
            {
                var entity = await _context.Set<Employee>().FindAsync(keys);

                if (entity == null)
                {
                    return new ServiceResponse<Employee>
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "Entity not found or bad request."
                    };
                }

                return new ServiceResponse<Employee>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ServiceResponse<Employee>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }
    }
}
