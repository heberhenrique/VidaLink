using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.Interfaces.Base
{
    public interface IBaseModel : IBaseAspNetIdentity
    {
        Guid ID { get; set; }
    }
}
