using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class ExceptionAdapter
    {
        public static DataTransferObjects.DotNetReport ToReport(this Exception exception)
        {
            var report = new DataTransferObjects.DotNetReport();

            report.Timestamp = DateTime.UtcNow;
            report.Application = new DataTransferObjects.Application();
            report.Application.Name = "Sett API";
            report.Exception = exception.ToDto();

            return report;
        }

        public static DataTransferObjects.DotNetException ToDto(this Exception exception)
        {
            if (exception == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.DotNetException();
            dto.Message = exception.Message;
            dto.StackTrace = exception.StackTrace;
            dto.InnerException = exception.InnerException.ToDto();

            return dto;
        }
    }
}
