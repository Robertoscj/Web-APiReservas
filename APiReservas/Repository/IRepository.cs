using APiReservas.Models;

namespace APiReservas.Repository
{
    public interface IRepository
    {
        IEnumerable<Reserva> Reservas { get; }
        Reserva this[int id] { get; }
        Reserva AddReserva(Reserva reserva);
        Reserva UpdateReserva(Reserva reserva);
        void DeleteReserva(int id);
    }
}
