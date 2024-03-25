using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new GigFormViewModel
            {
                Genres = GetAllGenres()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = GetAllGenres();
                return View(viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreId = viewModel.GenreId,
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue
            };

            try
            {

                _context.Gigs.Add(gig);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }


        private List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }
    }
}