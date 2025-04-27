namespace EMRService.EMRService.Contracts
{
    public class CreatePatientDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
