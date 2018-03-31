using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.DAL.Repository.Architecture
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        //private MeuArmarioContext _context;
        private Guid _usuarioID;
        //private static UnitOfWork instance = new UnitOfWork(new MeuArmarioContext());

        //public static IUnitOfWork Instance { get { return instance; } }

        //public UnitOfWork(MeuArmarioContext context)
        //{
        //    _context = context;
        //}

        public void Commit()
        {
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_context != null)
                //{
                //    _context.Dispose();
                //    _context = null;
                //}
            }
        }

        public void setUsuarioIDContext(Guid usuarioID)
        {
            _usuarioID = usuarioID;
        }
    }
}
