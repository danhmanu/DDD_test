namespace EMRService.EMRService.Application
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(Guid id);
        Task<Guid> CreatePatientAsync(CreatePatientDto dto);
    }
}
