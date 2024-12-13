using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMvcPostgres.Data;
using Entidad.Models;

namespace MiMvcPostgres.Controllers
{
    public class EnfermedadCronicaController : Controller
    {
        private readonly AppDbContext _context;

        public EnfermedadCronicaController(AppDbContext context)
        {
            _context = context;
        }

        public EnfermedadCronica enfermedad = new EnfermedadCronica();

        [HttpGet]
        public ActionResult Index()
        {
            var enfermedades = _context.EnfermedadesCronicas.Where(enfermedad => enfermedad.estado == true).OrderBy(x => x.id_enf_cronica).ToList();
            return View(enfermedades);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(EnfermedadCronica enfermedad)
        {
            _context.EnfermedadesCronicas.Add(enfermedad);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var enfermedad = await _context.EnfermedadesCronicas.FindAsync(id);
            return View("mostrar_id", enfermedad);
        }

        public ActionResult Actualizar(int id)
        {
            var enfermedad = _context.EnfermedadesCronicas.Find(id);
            return View("Actualizar", enfermedad);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(EnfermedadCronica enfermedad)
        {
            _context.Update(enfermedad);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var enfermedad = _context.EnfermedadesCronicas.Find(id);
            return View("Delete", enfermedad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EnfermedadCronica enfermedad)
        {
            enfermedad.estado = false;

            _context.Update(enfermedad);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Atras()
        {
            return RedirectToAction("Index");
        }




        // Metodos de postman
        [HttpGet("api/EnfermedadCronica")]
        public async Task<IActionResult> GetEnfermedades()
        {
            var enfermedades = await _context.EnfermedadesCronicas.OrderBy(x => x.id_enf_cronica).ToListAsync();
            return Ok(enfermedades);
        }

        // Obtener una enfermedad por ID
        [HttpGet("api/EnfermedadCronica/{id}")]
        public async Task<IActionResult> GetEnfermedadById(int id)
        {
            var enfermedad = await _context.EnfermedadesCronicas.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound($"No se encontró una enfermedad crónica con el ID {id}.");
            }

            return Ok(enfermedad);
        }

        // Crear una nueva enfermedad
        [HttpPost("api/EnfermedadCronica")]
        public async Task<IActionResult> CreateEnfermedad([FromBody] EnfermedadCronica nuevaEnfermedad)
        {
            _context.EnfermedadesCronicas.Add(nuevaEnfermedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnfermedadById), new { id = nuevaEnfermedad.id_enf_cronica }, nuevaEnfermedad);
        }

        [HttpPut("api/EnfermedadCronica/{id}")]
        public async Task<IActionResult> UpdateEnfermedad(int id, [FromBody] EnfermedadCronica enfermedadActualizada)
        {
            var enfermedadExistente = await _context.EnfermedadesCronicas.FindAsync(id);
            if (enfermedadExistente == null)
            {
                return NotFound($"No se encontró una enfermedad crónica con el ID {id}.");
            }

            enfermedadExistente.nombre = enfermedadActualizada.nombre;
            enfermedadExistente.descripcion = enfermedadActualizada.descripcion;
            enfermedadExistente.estado = enfermedadActualizada.estado;
            enfermedadExistente.fecha_actualizacion = DateOnly.FromDateTime(DateTime.Now);

            await _context.SaveChangesAsync();

            return Ok(enfermedadExistente);
        }



        [HttpDelete("api/EnfermedadCronica/{id}")]
        public async Task<IActionResult> DeleteEnfermedad(int id)
        {
            var enfermedad = await _context.EnfermedadesCronicas.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound($"No se encontró una enfermedad crónica con el ID {id}.");
            }

            enfermedad.estado = false;
            enfermedad.fecha_actualizacion = DateOnly.FromDateTime(DateTime.Now);

            await _context.SaveChangesAsync();

            return Ok($"La enfermedad con ID {id} fue desactivada exitosamente.");
        }

    }
}
