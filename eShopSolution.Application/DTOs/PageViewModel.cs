using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.DTOs
{
    public class PageViewModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
