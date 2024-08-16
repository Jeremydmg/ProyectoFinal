using System.Web.Mvc;

namespace v6.Controllers
{
    public class HomeController : Controller
    {
        // Variables para contar los votos
        private static int votosJuan = 0;
        private static int votosMaria = 0;

        // Acción para la página de inicio
        public ActionResult Index()
        {
            return View();
        }

        // Acción para la página de registro de candidatos
        public ActionResult Candidatos()
        {
            return View();
        }

        // Acción para manejar el formulario de registro de candidatos
        [HttpPost]
        public ActionResult GuardarCandidatos(string nombreVotante, string apellidoVotante)
        {
            // Guardar la información del votante en variables ViewBag para mostrarlas
            ViewBag.NombreVotante = $"{nombreVotante} {apellidoVotante}";

            // Puedes guardar esta información en una base de datos o en un almacenamiento temporal aquí si es necesario

            return View("CandidatosGuardados");
        }

        // Acción para la página de votaciones
        public ActionResult Votaciones()
        {
            return View();
        }

        // Acción para manejar el formulario de votaciones
        [HttpPost]
        public ActionResult RegistrarVoto(string candidato)
        {
            // Contar los votos según el candidato seleccionado
            if (candidato == "Juan Pérez")
            {
                votosJuan++;
            }
            else if (candidato == "María López")
            {
                votosMaria++;
            }

            return RedirectToAction("Resultado");
        }

        // Acción para la página de resultados
        public ActionResult Resultado()
        {
            // Calcular porcentajes
            int totalVotos = votosJuan + votosMaria;
            double porcentajeJuan = totalVotos > 0 ? (double)votosJuan / totalVotos * 100 : 0;
            double porcentajeMaria = totalVotos > 0 ? (double)votosMaria / totalVotos * 100 : 0;

            // Determinar el ganador
            string ganador = votosJuan > votosMaria ? "Juan Pérez" : (votosMaria > votosJuan ? "María López" : "Empate");

            // Pasar datos a la vista
            ViewBag.Ganador = ganador;
            ViewBag.VotosJuan = votosJuan;
            ViewBag.PorcentajeJuan = porcentajeJuan.ToString("0.00");
            ViewBag.VotosMaria = votosMaria;
            ViewBag.PorcentajeMaria = porcentajeMaria.ToString("0.00");

            return View();
        }
    }
}
