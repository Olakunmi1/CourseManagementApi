﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.ReadDTO
{
    public class AuhtorResourceParameters
    {
        const int maxPageSize = 20;
        public string mainCategory { get; set; }
        public string searchQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize { get; set; } = 10;
        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

    }
}
