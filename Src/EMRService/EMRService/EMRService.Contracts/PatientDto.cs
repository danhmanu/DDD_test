namespace EMRService.EMRService.Contracts
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
