namespace BenefitsCalculator.Common.DTOs
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public decimal Salary{ get; set; }
        public DateTime DateOfBirth{ get; set; }
        public IEnumerable<GetDependentDto> Dependents { get; set; }
    }
}
