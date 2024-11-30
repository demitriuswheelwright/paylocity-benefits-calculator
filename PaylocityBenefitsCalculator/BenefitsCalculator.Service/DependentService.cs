using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculator.Service
{
    public class DependentService : IDependentService
    {
        protected readonly DbContext _context;

        public DependentService(DbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<IEnumerable<Dependent>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<Dependent>().ToListAsync();

                return new ServiceResponse<IEnumerable<Dependent>>
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

                return new ServiceResponse<IEnumerable<Dependent>>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }

        public async Task<ServiceResponse<Dependent>> GetAsync(params object[] keys)
        {
            try
            {
                var entity = await _context.Set<Dependent>().FindAsync(keys);

                if (entity == null)
                {
                    return new ServiceResponse<Dependent>
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "Entity not found or bad request."
                    };
                }

                return new ServiceResponse<Dependent>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ServiceResponse<Dependent>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }
    }
}
