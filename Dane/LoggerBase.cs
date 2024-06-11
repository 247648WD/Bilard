using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Dane
{
    public abstract class LoggerBase
    {
        public abstract void Log(string time, string message);
    }
}
