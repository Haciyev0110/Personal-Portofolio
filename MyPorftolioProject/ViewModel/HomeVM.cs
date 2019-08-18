using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPorftolioProject.Models;

namespace MyPorftolioProject.ViewModel
{
    public class HomeVM
    {
        public About about { get; set; }
        public List<Frontskil> frontskils { get; set; }
        public List<Backskil> backskils { get; set; }
        public List<Education> educations { get; set; }
        public List<Exprience> expriences { get; set; }
        public List<Porftilio> porftilios { get; set; }


    }
}