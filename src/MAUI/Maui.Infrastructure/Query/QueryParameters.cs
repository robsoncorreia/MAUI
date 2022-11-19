using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Infrastructure.Query
{
    public class QueryParameters
    {
        const decimal _maxSize = 100;
        private decimal _size = 50;

        public decimal Page { get; set; } = 1;

        public decimal Size
        {
            get { return _size; }
            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}
