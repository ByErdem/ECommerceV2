using ECommerceV2.Shared.Utilities.Results.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(EResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(EResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(EResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public EResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
