using Microsoft.Extensions.Logging;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Services
{
    public class AppointmentRepo : IAppointmentRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<AppointmentRepo> _logger;

        public AppointmentRepo(DataContext context, ILogger<AppointmentRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Appointment> Get(int appointmentId)
        {
            //using (var session = new AsyncSession())
            //{
            //    var query = session.Query<Appointment>()
            //        .Include(a => a.Listeners)
            //        .Include(a => a.Speaker)
            //        .Where(a => a.Id == appointmentId);

            //    var result = await query.FirstOrDefaultAsync();
            //    return result;
            //}
            return null;
        }

        public async Task<Appointment> GetByTime(int doctorId, DateTime date, TimeSpan time)
        {
            //using (var session = new AsyncSession())
            //{
            //    var query = session.Query<Appointment>()
            //        .Where(a => a.SpeakerId == doctorId && a.Date == date.Date && a.Time == time);

            //    var result = await query.FirstOrDefaultAsync();
            //    return result;
            //}
            return null;

        }

        public async Task<Appointment> GetCurrentActiveAppointment(int userId, int secondsBackOff = 10 * 60)
        {
            //using (var session = new AsyncSession())
            //{
            //    var query = session.Query<Appointment>()
            //        .Include(a => a.Speaker)
            //        .Include(a => a.Listeners)
            //        .Where(a => (a.SpeakerId == userId || a.Listeners.Any(l => l.Id == userId)) &&
            //            (a.Status == AppointmentStatusType.Active ||
            //             a.UpdatedAt > DateTime.UtcNow.AddSeconds(-secondsBackOff)));

            //    var result = await query.FirstOrDefaultAsync();
            //    return result;
            //}
            return null;

        }

        public async Task<Appointment> Create(Appointment a, int maxListeners)
        {
            //using (var session = new AsyncSession())
            //{
            //    using (var transaction = await session.BeginTransactionAsync())
            //    {
            //        var appointment = new Appointment
            //        {
            //            Date = a.Date,
            //            Time = a.Time,
            //            SpeakerId = a.DoctorId,
            //            Status = AppointmentStatusType.pending,
            //            MaxListeners = maxListeners
            //        };

            //        session.Add(appointment);
            //        await transaction.CommitAsync();

            //        return await AddListener(appointment.Id, a.ClientId);
            //    }
            //}
            return null;

        }

        public async Task<Appointment> AddListener(int appointmentId, int clientId)
        {
            //using (var session = new AsyncSession())
            //{
            //    using (var transaction = await session.BeginTransactionAsync())
            //    {
            //        var listener = new AppointmentClientsORM
            //        {
            //            ClientId = clientId,
            //            AppointmentId = appointmentId
            //        };

            //        session.Add(listener);
            //        await transaction.CommitAsync();

            //        return await Get(appointmentId);
            //    }
            //}
            return null;

        }

        public async Task RemoveListener(int appointmentId, int clientId)
        {
            //using (var session = new AsyncSession())
            //{
            //    using (var transaction = await session.BeginTransactionAsync())
            //    {
            //        var listener = await session.Query<AppointmentClients>()
            //            .Where(l => l.AppointmentId == appointmentId && l.ClientId == clientId)
            //            .FirstOrDefaultAsync();

            //        if (listener != null)
            //        {
            //            session.Remove(listener);
            //        }

            //        var appointment = await Get(appointmentId);
            //        if (appointment.Listeners.Count == 0)
            //        {
            //            session.Remove(appointment);
            //        }

            //        await transaction.CommitAsync();
            //    }
            //}
        }

        public async Task SetListenerPainRateBefore(int rate, int appointmentId, int clientId)
        {
            //var listener = await GetAppointmentListener(appointmentId, clientId);
            //if (listener != null)
            //{
            //    listener.PainRateBefore = rate;

            //    using (var session = new AsyncSession())
            //    {
            //        using (var transaction = await session.BeginTransactionAsync())
            //        {
            //            session.Update(listener);
            //            await transaction.CommitAsync();
            //        }
            //    }
            //}
        }

        public async Task SetListenerPainRateAfter(int rate, int appointmentId, int clientId)
        {
            var listener = await GetAppointmentListener(appointmentId, clientId);
            if (listener != null)
            {
                listener.PainRateAfter = rate;

                //using (var session = new AsyncSession())
                //{
                //    using (var transaction = await session.BeginTransactionAsync())
                //    {
                //        session.Update(listener);
                //        await transaction.CommitAsync();
                //    }
                //}
            }
        }

        private async Task<AppointmentClient> GetAppointmentListener(int appointmentId, int clientId)
        {
            //using (var session = new AsyncSession())
            //{
            //    var query = session.Query<AppointmentClients>()
            //        .Where(l => l.AppointmentId == appointmentId && l.ClientId == clientId);

            //    var result = await query.FirstOrDefaultAsync();
            //    return result;
            //}
            return null;

        }

        public async Task<Appointment> ChangeStatus(int appointmentId, AppointmentStatusType status)
        {
            //using (var session = new AsyncSession())
            //{
            //    using (var transaction = await session.BeginTransactionAsync())
            //    {
            //        var appointment = await session.Query<Appointment>()
            //            .Where(a => a.Id == appointmentId)
            //            .FirstOrDefaultAsync();

            //        if (appointment != null)
            //        {
            //            appointment.Status = status;
            //            appointment.UpdatedAt = DateTime.UtcNow;
            //            session.Update(appointment);
            //        }

            //        await transaction.CommitAsync();
            //        return await Get(appointmentId);
            //    }
            //}
            return null;

        }

        public async Task<bool> IsDoctorTimeHasVacancies(int doctorId, DateTime date, TimeSpan time)
        {
            //var appointment = await GetByTime(doctorId, date, time);
            //return appointment == null || appointment.Listeners.Count < appointment.MaxListeners;
            return false;
        }

        public async Task<List<Appointment>> GetUserAppointments(int userId, DateTime fromDate = default, DateTime toDate = default)
        {
            //using (var session = new AsyncSession())
            //{
            //    var query = session.Query<Appointment>()
            //        .Include(a => a.Speaker)
            //        .Include(a => a.Listeners)
            //        .Where(a => a.SpeakerId == userId || a.Listeners.Any(l => l.Id == userId))
            //        .Where(a => a.Date >= (fromDate == default ? DateTime.MinValue.Date : fromDate.Date))
            //        .Where(a => a.Date <= (toDate == default ? DateTime.MaxValue.Date : toDate.Date))
            //        .OrderBy(a => a.Date)
            //        .ThenBy(a => a.Time);

            //    var appointments = await query.ToListAsync();
            //    return appointments.Select(a => Appointment.FromORM(a)).ToList();
            //}
            return null;

        }
    }
}
