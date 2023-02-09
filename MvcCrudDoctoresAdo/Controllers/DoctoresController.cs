using Microsoft.AspNetCore.Mvc;
using MvcCrudDoctoresAdo.Models;
using MvcCrudDoctoresAdo.Repositories;

namespace MvcCrudDoctoresAdo.Controllers
{
    public class DoctoresController : Controller
    {

        private RepositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult Details(int idDoctor)
        {
            Doctor doctor = this.repo.FindDoctor(idDoctor);
            return View(doctor);
        }

        public IActionResult Create()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.InsertDoc(doctor.IdHospital, doctor.IdDoctor, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            //return View("Index");
            //EXITE UN METODO QUE NO MANDA UNA VISTA, SINO QUE MANDA AL ACTION
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idDoctor)
        {
            this.repo.DeleteDoc(idDoctor);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int idDoctor)
        {
            Doctor doctor = this.repo.FindDoctor(idDoctor);
            List<Hospital> hospitales =
                this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            List<Hospital> hospitales =
                this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;

            this.repo.UpdateDoc(doctor.IdHospital, doctor.IdDoctor, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return RedirectToAction("Index");
        }
    }
}
