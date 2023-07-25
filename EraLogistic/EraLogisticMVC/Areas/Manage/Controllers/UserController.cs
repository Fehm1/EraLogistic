using AutoMapper.Execution;
using Core.Entities.Concrete;
using Core.Extentions;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.DTOs.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Member = Core.Entities.Concrete.Member;

namespace EraLogisticMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<Member> _userManager;

        public UserController(AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env, UserManager<Member> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _env = env;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();

            ViewBag.Roles = await _context.Roles.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = await _context.Roles.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserPostDto userPostDto)
        {
            ViewBag.Roles = await _context.Roles.ToListAsync();

            List<IdentityRole> roles = ViewBag.Roles;

            if (ModelState.IsValid)
            {
                Member member = new Member
                {
                    RoleId = userPostDto.RoleId,
                    Name = userPostDto.Name,
                    Surname = userPostDto.Surname,
                    UserName = userPostDto.UserName,
                    Email = userPostDto.Email,
                    Phone = userPostDto.Phone,
                    CompanyName = " ",
                    CompanyEmail = " ",
                    City = " ",
                    Country = " ",
                    Address = " ",
                    ZipCode = " ",
                    IsActive = true
                };

                if (roles.FirstOrDefault(x => x.Id == userPostDto.RoleId).Name == "Super Admin")
                {
                    member.IsSuperAdmin = true;
                }
                else if(roles.FirstOrDefault(x => x.Id == userPostDto.RoleId).Name == "Admin")
                {
                    member.IsAdmin = true;
                }


                if (userPostDto.ImageFile != null)
                {
                    if (!userPostDto.ImageFile.IsImageContent())
                    {
                        return View(userPostDto);
                    }

                    if (!userPostDto.ImageFile.IsValidImageLength())
                    {
                        return View(userPostDto);
                    }

                    string newImage = userPostDto.ImageFile.SaveImage(_env.WebRootPath, "uploads/Users");
                    member.Image = newImage;
                }
                else
                {
                    return View(userPostDto);
                }

                var result = await _userManager.CreateAsync(member, userPostDto.Password);

                var role = roles.FirstOrDefault(x => x.Id == userPostDto.RoleId).Name;

                await _userManager.AddToRoleAsync(member, role);

                return RedirectToAction("index");
            }

            return View(userPostDto);
        }
    }
}
