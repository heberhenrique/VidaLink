using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.Interfaces.Base
{
    public interface IBaseAspNetIdentity
    {
        DateTime? DataCriacao { get; set; }
        DateTime? DataUltimaAlteracao { get; set; }
        Guid CriadoPorID { get; set; }
        Guid AlteradoPorID { get; set; }
        bool Excluido { get; set; }
    }
}
