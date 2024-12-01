using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculator.Service
{
    /// <summary>
    /// I am a firm believer in the try-catch pattern. I use it here in the domain/business logic layer,
    /// so it doesn't need to be used in the controller.
    /// </summary>
    public class DependentService : IDependentService
    {
        protected readonly DbContext _context;

        public DependentService(DbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<IEnumerable<Dependent>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.Set<Dependent>().ToListAsync();

                return new ApiResponse<IEnumerable<Dependent>>
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

                return new ApiResponse<IEnumerable<Dependent>>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }

        public async Task<ApiResponse<Dependent>> GetAsync(params object[] keys)
        {
            try
            {
                var entity = await _context.Set<Dependent>().FindAsync(keys);

                if (entity == null)
                {
                    return new ApiResponse<Dependent>
                    {
                        Success = false,
                        StatusCode = 400,
                        Message = "Entity not found or bad request."
                    };
                }

                return new ApiResponse<Dependent>
                {
                    Success = true,
                    StatusCode = 200,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                // Typically I wouldnt return any part of the stacktrace or internal message for security reasons.

                return new ApiResponse<Dependent>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = $"{ex.Message}-{ex.InnerException?.Message}"
                };
            }
        }
    }
}
