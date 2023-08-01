using APiReservas.Models;
using APiReservas.Repository;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpPost]
        public Reserva Post([FromBody] Reserva res) =>
       repository.AddReserva(new Reserva
       {
           Nome = res.Nome,
           InicioLocacao = res.InicioLocacao,
           FimLocacao = res.FimLocacao
       });

        [HttpPut]
        public Reserva Put([FromForm] Reserva res) => repository.UpdateReserva(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm] JsonPatchDocument<Reserva> patch)
        {
            Reserva res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReserva(id);

    }

       
}