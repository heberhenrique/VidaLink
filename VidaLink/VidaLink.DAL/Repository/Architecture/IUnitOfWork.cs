﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.DAL.Repository.Architecture
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void setUsuarioIDContext(Guid usuarioID);
    }
}
