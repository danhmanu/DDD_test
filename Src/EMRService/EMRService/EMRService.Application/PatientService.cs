using EMRService.EMRService.Contracts;
using EMRService.EMRService.Domain;
using EMRService.EMRService.Infrastructure;

namespace EMRService.EMRService.Application
{
    public class PatientService : IPatientService
    {
        private readonly EMRDbContext _context;

        public PatientService(EMRDbContext context)
        {
            _context = context;
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return null;

            return new PatientDto
            {
                Id = patient.Id,
                FullName = patient.FullName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Address = patient.Address
            };
        }

        public async Task<Guid> CreatePatientAsync(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Address = dto.Address
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }
    }

}
