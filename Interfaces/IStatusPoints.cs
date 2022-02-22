using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
    public interface IStatusPoints<T> 
    {
        public int AddPoint();
        public int RemovePoint();
        public int ResetPoints();
        public int SetPoints();
    }
}