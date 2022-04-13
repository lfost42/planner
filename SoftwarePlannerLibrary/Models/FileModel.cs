using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        [Display(Name = "UploadDate")]
        public DateTimeOffset UploadDate { get; set; }
        
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }

        [Display(Name = "Creator")]
        public int CreatorId { get; set; }



        //Navigation Properties
        public virtual CreatorModel Creator { get; set; }
    }
}
