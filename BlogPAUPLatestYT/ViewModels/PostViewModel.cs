using BlogPAUPLatestYT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlogPAUPLatestYT.Models.Post;

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

        public CollageDirections CollageDirections { get; set; }
        //Ako ne radi ovdje sam zajebo
        public IdentityUser IdentityUser { get; set; }
        public string NazivKreatora { get; set; }
        //public Post.CollageDirections SmeroviFakultet { get; set; }
        //public ICollection<SmjeroviFaksa> SmjeroviFaksas { get; set; }


    }
}
