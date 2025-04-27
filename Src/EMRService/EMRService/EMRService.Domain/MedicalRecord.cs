namespace EMRService.EMRService.Domain
{
    public class MedicalRecord
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }

        public Patient Patient { get; set; }
    }
}
