using APiReservas.Models;
using System.Resources;

namespace APiReservas.Repository
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> items;

        public Repository()
        {
            items = new Dictionary<int, Reserva>();
            new List<Reserva>()
            {
                new Reserva {ReservaId=1, Nome = "Roberto", InicioLocacao = "João Pessoa", FimLocacao="Torre" },
                new Reserva {ReservaId=2, Nome = "Paulo", InicioLocacao = "Campinas", FimLocacao="São Paulo" },
                new Reserva {ReservaId=3, Nome = "Maria", InicioLocacao = "Jundiaí", FimLocacao="Campinas" }       
            }.ForEach(r =>AddReserva(r));
        }
        public Reserva this[int id] => items.ContainsKey(id)?items[id]:null;

        public IEnumerable<Reserva> Reservas => items.Values;

        public Reserva AddReserva(Reserva reserva)
        {
            if (reserva.ReservaId == 0)
            {
                int Key = items.Count;
                while (items.ContainsKey(Key)) { Key++; };
                reserva.ReservaId = Key;
            }
            items[reserva.ReservaId] = reserva;
            return reserva;


        }

        public void DeleteReserva(int id)
        {
            items.Remove(id);
        }

        public Reserva UpdateReserva(Reserva reserva)
        {
            AddReserva(reserva);
            return reserva;
        }
    }
}
