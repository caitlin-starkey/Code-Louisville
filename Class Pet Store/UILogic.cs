using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    public interface UILogic <T> where T : Product
    {
        public static T CreateProduct()=> throw new NotImplementedException();
    }
}
