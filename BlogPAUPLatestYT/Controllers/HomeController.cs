using BlogPAUPLatestYT.Data;
using BlogPAUPLatestYT.Data.FileManager;
using BlogPAUPLatestYT.Data.Repository;
using BlogPAUPLatestYT.Models;
using BlogPAUPLatestYT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogPAUPLatestYT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;
        private readonly IFileManager _fileManager;

        public HomeController(IRepository repo,
            IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;

        }
        public IActionResult Index(string category,string search)
        {
            //var vm = new IndexViewModel
            //{
            //    Posts = string.IsNullOrEmpty(category) ?
            //  _repo.GetAllPosts() : 
            // _repo.GetAllPosts(category)
            //};

            //boolean?true:false

            //return View(vm);
            var vm = _repo.GetAllPosts(category,search);
            return View(vm);
        }
        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            post.Counter++;
            _repo.SaveChangesAsync().GetAwaiter().GetResult();
            return View(post);
            
        }
        
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image),$"image/{mime}");
        }

        
      
    }
}
