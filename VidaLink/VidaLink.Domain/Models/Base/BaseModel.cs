using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Interfaces.Base;

namespace VidaLink.Domain.Models.Base
{
    public class BaseModel : IBaseModel
    {
        public Guid ID { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public Guid CriadoPorID { get; set; }
        public Guid AlteradoPorID { get; set; }
        public bool Excluido { get; set; }
    }
}
