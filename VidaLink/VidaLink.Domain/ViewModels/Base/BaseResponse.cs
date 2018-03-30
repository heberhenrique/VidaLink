using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.ViewModels.Base
{
    public class BaseResponse<T> : BaseResponse
    {
        public T Model { get; set; }
    }

    public class BaseListResponse<T> : BaseResponse
    {
        public ICollection<T> List { get; set; }
    }

    public class BaseResponse
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
