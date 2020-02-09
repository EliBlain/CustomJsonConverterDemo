using JsonConverterDemo.Domain.Interfaces;
using System.Collections.Generic;

namespace JsonConverterDemo.Domain.Models
{
    public class ComplexCustomClass
    {
        public IEnumerable<CustomInterface> Collection { get; set; }
    }
}
