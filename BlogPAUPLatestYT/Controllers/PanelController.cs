﻿using BlogPAUPLatestYT.Data.FileManager;
using BlogPAUPLatestYT.Data.Repository;
using BlogPAUPLatestYT.Models;
using BlogPAUPLatestYT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {

        private readonly IRepository _repo;
        private readonly IFileManager _fileManager;

        public PanelController(
            IRepository repo,
            IFileManager fileManager
            )
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new PostViewModel());
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel 
                {
                  Id=post.Id,
                  Title =post.Title,
                  ShortDescription=post.ShortDescription,
                  LongDescription=post.LongDescription,
                  Visible=post.Visible,
                  //SmjeroviFaksa treba izbrisat ak ne radi
                  SmjeroviFaksas=post.SmjeroviFaksas

                  
                  
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                ShortDescription = vm.ShortDescription,
                LongDescription = vm.LongDescription,
                Visible = vm.Visible,
                Image = await _fileManager.SaveImage(vm.Image),
                //Ako ne valja ukloniti smjerove faksa
                SmjeroviFaksas=vm.SmjeroviFaksas
            };
            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);


        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync(); 
            return RedirectToAction("Index");


        }
    }
}
