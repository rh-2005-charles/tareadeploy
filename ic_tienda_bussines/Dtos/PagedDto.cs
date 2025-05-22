using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos
{
    public class PagedDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        // Se puede agregar más propiedades si es necesario
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}