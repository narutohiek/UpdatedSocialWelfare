using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialWelfarre.Models;
using SocialWelfarre.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SocialWelfarre.Controllers
{
    public class UsersController : Controller
    {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _context;
    
        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser>userManager,RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser user)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser registereduser = new();
             
                registereduser.EmpNo = user.EmpNo;
               
                registereduser.First_Name = user.First_Name;
                registereduser.Middle_Name = user.Middle_Name;
                registereduser.Last_Name = user.Last_Name;
                registereduser.Age = user.Age;
                registereduser.IsMale = user.Gender == "Male";
                registereduser.PhoneNumber = user.PhoneNumber;
                registereduser.EmailConfirmed = true;
                registereduser.DateOfBirth = user.DateOfBirth;
                registereduser.Address = user.Address;
                var result = await _userManager.CreateAsync(registereduser, user.PasswordHash);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UsersController/Edit/5
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, ApplicationUser model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    // Update the properties
                    user.EmpNo = model.EmpNo;
             
                    user.First_Name = model.First_Name;
                    user.Middle_Name = model.Middle_Name;
                    user.Last_Name = model.Last_Name;
                    user.Age = model.Age;
                    user.IsMale = model.Gender == "Male";
                    user.PhoneNumber = model.PhoneNumber;
                    user.Email = model.Email;
                    user.DateOfBirth = model.DateOfBirth;
                    user.Address = model.Address;

                    await _userManager.UpdateAsync(user);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }


        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            // If deletion failed, stay on the same page and maybe show an error
            return View(user);
        }

    }
}
