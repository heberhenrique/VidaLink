using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Infra.Log.Interfaces
{
    public interface IBaseLogger
    {
        void Erro(string Title, Exception ex);
        void Informacao(string Title, string Text);
        void Atencao(string Title, string Text);
        void Critico(Object ErroCritico);
    }
}
