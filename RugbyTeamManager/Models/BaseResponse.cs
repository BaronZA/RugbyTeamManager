using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyTeamManager.Models
{
    public class BaseResponse
    {
        public ResponseMessage ResponseMessage { get; set; }
    }

    public enum ResponseMessage
    {
        Success,
        Failure,
        Error
    }
}
