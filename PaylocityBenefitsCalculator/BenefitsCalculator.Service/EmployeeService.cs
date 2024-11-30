using BenefitsCalculator.Common.Entities;
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
        public async Task<ApiResponse<IEnumerable<Employee>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<Employee>().ToListAsync();

                return new ApiResponse<IEnumerable<Employee>>
                {
                    Success = true,
                    StatusCode = 200,
                    Data = entities,
                    Message = $"Found {entities.Count()} records."
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ApiResponse<IEnumerable<Employee>>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }

        public async Task<ApiResponse<Employee>> GetAsync(params object[] keys)
        {
            try
            {
                var entity = await _context.Set<Employee>().FindAsync(keys);

                if (entity == null)
                {
                    return new ApiResponse<Employee>
                    {
                        Success = false,
                        StatusCode = 400,
                        Message = "Entity not found or bad request."
                    };
                }

                return new ApiResponse<Employee>
                {
                    Success = true,
                    StatusCode = 200,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ApiResponse<Employee>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }
    }
}
