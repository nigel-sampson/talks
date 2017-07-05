using System;
using System.Collections.Generic;

namespace NDC.Build.Core.Model
{
    public class ListResponse<T>
    {
        public ICollection<T> Value { get; set; }
    }
}
