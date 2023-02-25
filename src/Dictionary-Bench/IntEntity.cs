using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Bench
{
    public class IntEntity : BaseEntity<IntEntity, int>
    {
        public IntEntity(int value)
        {
            this.Value = value;
        }
    }
}
