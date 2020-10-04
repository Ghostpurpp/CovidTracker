using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTracker.Models
{
    public class ArticleData
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
