namespace EMRService.EMRService.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }

}
