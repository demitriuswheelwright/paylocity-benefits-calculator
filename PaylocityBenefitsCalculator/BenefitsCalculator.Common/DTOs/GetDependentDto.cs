using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.DTOs
{
    public class GetDependentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Relationship Relationship { get; set; }
        public DateTime DateOfBirth{ get; set; }
    }
}
