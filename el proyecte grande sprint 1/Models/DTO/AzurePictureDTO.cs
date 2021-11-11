using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Models.DTO
{
    public class AzurePictureDTO
    {
        public AzurePictureDTO(string url, string name, string title)
        {
            Url = url;
            Name = name;
            Title = title;
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
