﻿using System;
using System.Linq;

namespace Mountain_Goats_Bike_App
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalEntries { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) 
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalEntries = count;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create (List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1)* pageSize).Take(pageSize).ToList();
            return new PaginatedList<T> (items, count, pageIndex, pageSize);
        }
    }
}
