using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Services.Abstract;

namespace UnluCo.Services.Concrete
{
    public class Logger : ICustomLogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
