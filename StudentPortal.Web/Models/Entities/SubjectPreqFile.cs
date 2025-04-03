﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    [PrimaryKey(nameof(SUBJCODE), nameof(SUBJPRECODE))]
    public class SubjectPreqFile
    {
        [StringLength(15)]
        public string SUBJCODE { get; set; }

        [StringLength(15)]
        public string SUBJPRECODE { get; set; }

        [StringLength(2)]
        [RegularExpression("CR|PR", ErrorMessage = "Must be 'CR' or 'PR'.")]
        public string SUBJCATEGORY { get; set; } // "CR" or "PR"

    }


}
