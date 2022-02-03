using Microsoft.AspNetCore.Mvc;
using Movies_WebApp.Models;
using Movies_WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_WebApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<User> UsuariosList;
            UsuariosList = await _userService.GetAllAsync();
            return View("Index",UsuariosList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);
                return RedirectToAction("IndexAsync");
            }
            else
                return View("Create");
        }

        public async Task<IActionResult> Edit(int id)
        {
            User clsUsuario = await _userService.GetByIdAsync(id);

            return View("Edit", clsUsuario);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(User clsUsuario)
        {
            await _userService.UpdateAsync(clsUsuario);

            return RedirectToAction("IndexAsync");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            User clsUsuario = await _userService.GetByIdAsync(id);
            return View("Details", clsUsuario);
        }

        [HttpGet]
        //Ver detalle del registro y para la eliminacion de registro
        public async Task<IActionResult> Delete(int id)
        {

            User clsUsuario = await _userService.GetByIdAsync(id);

            return View(clsUsuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _ = await _userService.DeleteAsync(id);

            return RedirectToAction("IndexAsync");
        }

    }

}
