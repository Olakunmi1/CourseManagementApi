using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int Totalcount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);

        public bool HasNext => (CurrentPage < TotalPages);


        public PagedList(List<T> items, int count, int pageNumber, int Pagesize)
        {
            Totalcount = count;
            PageSize = Pagesize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)Pagesize);
            AddRange(items);

        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int PageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, PageSize);
        }



    }
}
