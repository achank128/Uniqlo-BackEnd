﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Category
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionVi { get; set; }
        public Guid? ParentId { get; set; }
        public int GenderTypeId { get; set; }
    }
}
