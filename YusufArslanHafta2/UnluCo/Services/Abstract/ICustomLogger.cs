using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Services.Abstract
{
    public interface ICustomLogger
    {
        public void Write(string message);
    }
}
