﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.Models.RequestModels.Product
{
    public class FilterProductRequest : FilterBaseRequest
    {
        public Guid? CategoryId { get; set; }
        public Guid? CollectionId { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<int>? ColorIds { get; set; }
        public List<int>? PriceTypes { get; set; }
        public bool? IsSale { get; set; }
        public bool? IsOnlineOnly { get; set; }
        public bool? IsLimited { get; set; }

    }
}