using BlogPAUPLatestYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPAUPLatestYT.ViewModels
{
    public class IndexViewModel
    {
        public string Category { get; set; }
        public string Search { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
