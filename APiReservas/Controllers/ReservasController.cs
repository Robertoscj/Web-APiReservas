using APiReservas.Models;
using APiReservas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APiReservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private IRepository repository;

        public ReservasController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Reserva> Get() => repository.Reservas;

        [HttpGet("{id}")]
        public Reserva Get(int id) => repository[id];


    }

       
}