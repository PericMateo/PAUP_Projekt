using BlogPAUPLatestYT.Models;
using BlogPAUPLatestYT.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDBContext _ctx;
        public Repository(AppDBContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
            
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        //Ovdje ako nesto ne radi greska je u converziji stringToInt
        public IndexViewModel GetAllPosts(string category,string search)
        {
            //return _ctx.Posts.Where(post => post.Category.ToLower().Equals(category.ToLower())).ToList();
            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };
            var query = _ctx.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query= query.Where(x => x.Category.Equals(category));
            //query = query.Where(x => InCategory(x));
            //query = query.Where(x => I);

            if (!String.IsNullOrEmpty(search))
                query = query.Where(x => x.Title.Contains(search)
                || x.ShortDescription.Contains(search) 
                || x.LongDescription.Contains(search));

            return new IndexViewModel
            {
                Posts=query.ToList()
            };
            
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == id); ;
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync()>0)
            {
                return true;
            }
            return false;
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }
    }
}
