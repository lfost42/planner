﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        public int CreatorModelId { get; set; }
        [Display(Name = "Creator")]
        public virtual CreatorModel CreatorModel { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }

        public DateTimeOffset DateUploaded { get; set; }


        public string UserModelId { get; set; }
        [Display(Name = "User")]
        public UserModel UserModel { get; set; }

        public int ProjectModelId { get; set; }
        public ProjectModel ProjectModel { get; set; }
    }
}
