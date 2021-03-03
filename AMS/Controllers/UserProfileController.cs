using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AMS.Models;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Admin Page";
        }

        [HttpGet]
        [Authorize(Roles = "students")]
        [Route("ForStudent")]
        public string GetForStudent()
        {
            return "Student Page";
        }


        [HttpGet]
        [Authorize(Roles = "admin, students")]
        [Route("ForAdminOrStudents")]
        public string GetForAdminOrStudents()
        {
            return "Admin Page or Student Page";
        }
    }
}
