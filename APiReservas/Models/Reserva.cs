﻿namespace APiReservas.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public string Nome { get; set; }
        public string InicioLocacao { get; set; }
        public string FimLocacao { get; set; }
    }
}
