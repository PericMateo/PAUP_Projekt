using BlogPAUPLatestYT.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public bool Visible { get; set; }
        public int Counter { get; set; }
        public IFormFile Image { get; set; }
        //public ICollection<SmjeroviFaksa> SmjeroviFaksas { get; set; }
    }
}
