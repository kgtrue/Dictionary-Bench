using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Bench
{
    public abstract class BaseEntity<TType, TValue>: IEntity
    {
        public TValue Value { get; set; }

        public int HashCode => Value.GetHashCode();
    }
}
