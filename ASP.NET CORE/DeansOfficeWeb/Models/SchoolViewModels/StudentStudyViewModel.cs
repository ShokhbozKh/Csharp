using DeansOfficeWeb.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DeansOfficeWeb.SchoolViewModels
{
    public class StudentStudyViewModel
    {   
        public SelectList Studies { get; set; }
        
        [Display(Name = "Choose Department")]
        public string StudyName { get; set; }

        public List<Student> StudentsList { get; set; }

        public string SearchString { get; set; }
        
        public int StudentsCount { get; set; }
    }
}
