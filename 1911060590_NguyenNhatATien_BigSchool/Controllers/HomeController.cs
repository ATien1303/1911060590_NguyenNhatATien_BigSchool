using _1911060590_NguyenNhatATien_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using _1911060590_NguyenNhatATien_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;

namespace _1911060590_NguyenNhatATien_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now && c.IsCanceled == false).ToList();
            var isFollowCourses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Include(c => c.Course);
            var isFollowLecturers = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Include(c => c.Followee);
            var viewModel = new CoursesViewModel()
            {
                UpcommingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated,
                IsFollowCourses = isFollowCourses,
                IsFollowLecturers = isFollowLecturers,

            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}