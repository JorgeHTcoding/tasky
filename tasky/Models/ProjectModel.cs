using System;
using System.ComponentModel.DataAnnotations;

namespace tasky.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id_Project { get; set; }
        [Required, StringLength(35)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(200)]
        public string Description { get; set; } = string.Empty;
        public bool Front { get; set; }
        public string Front_Framework { get; set; } = string.Empty;
        public bool API { get; set; }
        public string API_Framework { get; set; } = string.Empty;
        public bool DB { get; set; }
        public string DB_Management_Sys { get; set; } = string.Empty;
        public int ID_Languages { get; set; } 
        public bool Finished { get; set; }  
        public DateTime Date_Start { get; set;}
        public DateTime Date_Finish { get; set;}

    }
}
