
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddListener(int appointmentId, int clientId);
        Task<Appointment> ChangeStatus(int appointmentId, AppointmentStatusType status);
        Task<Appointment> Create(Appointment a, int maxListeners);
        Task<Appointment> Get(int appointmentId);
        Task<Appointment> GetByTime(int doctorId, DateTime date, TimeSpan time);
        Task<Appointment> GetCurrentActiveAppointment(int userId, int secondsBackOff = 600);
        Task<List<Appointment>> GetUserAppointments(int userId, DateTime fromDate = default, DateTime toDate = default);
        Task<bool> IsDoctorTimeHasVacancies(int doctorId, DateTime date, TimeSpan time);
        Task RemoveListener(int appointmentId, int clientId);
        Task SetListenerPainRateAfter(int rate, int appointmentId, int clientId);
        Task SetListenerPainRateBefore(int rate, int appointmentId, int clientId);
    }
}