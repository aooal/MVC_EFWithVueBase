using Microsoft.AspNetCore.Mvc;
using MVC_EFCodeFirstWithVueBase.Models;
using MVC_EFCodeFirstWithVueBase.ModelsDto;
using MVC_EFCodeFirstWithVueBase.Services;
 
namespace MVC_EFCodeFirstWithVueBase.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly FileService _fileService;

        public UsersController(AppDbContext context, FileService fileService) 
        {
            _context = context;
            _fileService = fileService;
        }
        public IActionResult Index()
        {
            var users = _context.Users.Where(u => u.Active == true).OrderByDescending(u => u.CreatedTime).ToList();
            return View(users);
        }
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            
            if (userDto.ImageFile != null && !_fileService.IsImgFileSizeValid(userDto.ImageFile))
            {
                ModelState.AddModelError("ImageFile", "The file size should not exceed 100MB.");
            }
            else if (userDto.ImageFile != null && !_fileService.IsImageFile(userDto.ImageFile))
            {
                ModelState.AddModelError("ImageFile", "The file is not a valid image.");
            }
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            await userDto.SaveAsync(_context);

            return RedirectToAction("Index","Users");
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(string uid)
        {
            var user = await UserDto.GetUserAsyncById(_context, uid);
            if (user == null)
            {
                return NotFound(); 
            }
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ImagePath = user.ImageFileName,
                CreatedTimeFormat = user.CreatedTime.ToString("yyyy/MM/dd HH:mm"),
                Password = ""                             
            };

            return View(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string uid, UserDto userDto)
        {
            userDto.Id = uid;         
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            var result = await userDto.SaveAsync(_context);
            if (!result) return NotFound();
            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(string uid)
        {
            var user = new UserDto();        
            var result = await user.DeleteAsync(_context, uid);
            return RedirectToAction("Index", "Users");
        }
        #endregion
    }
}
