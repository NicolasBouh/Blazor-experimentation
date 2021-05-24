using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Contracts
{
    public interface ILoggerService
    {
        void LogDebug(string message);

        void LogInfo(string message);

        void LogWarn(string message);

        void LogError(string message);

     
    }
}
