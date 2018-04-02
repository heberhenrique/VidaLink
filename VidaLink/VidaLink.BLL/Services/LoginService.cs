using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.BLL.Interfaces;
using VidaLink.BLL.Services.Base;
using VidaLink.DAL.Repository.Architecture;
using VidaLink.DAL.Repository.Interfaces;
using VidaLink.Domain.Mappers;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;
using VidaLink.Infra.Log.Interfaces;
using VidaLink.Infra.Util;

namespace VidaLink.BLL.Services
{
    public class LoginService : BaseService<Sessoes, SessoesViewModel>, ILoginService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly ISessoesRepository _sessaoRepository;
        public LoginService(
            IBaseLogger logger,
            IUnitOfWork unitOfWork,
            IMapperConfig mapInstace,
            IUsuariosRepository usuariosRepository,
            ISessoesRepository sessaoRepository) : base(logger, unitOfWork, mapInstace, sessaoRepository)
        {
            _usuariosRepository = usuariosRepository;
            _sessaoRepository = sessaoRepository;
        }

        public LoginResponseViewModel EfetuarLogin(string login, string senha)
        {
            var retorno = new LoginResponseViewModel();
            retorno.Valido = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(senha))
                {

                    var user = _usuariosRepository.ReadAll().Where(u => u.UserName == login).FirstOrDefault();

                    if (user == null)
                    {
                        var mensagem = $"Usuario {login} não encontrado no sistema";
                        var ex = new Exception(mensagem);
                        _logger.Erro("EfetuarLogin", ex);
                        throw ex;
                    }
                    else if (!user.PasswordHash.Equals(PasswordHash.CreatePasswordHash(senha)))
                    {
                        var mensagem = $"Senha inválida";
                        var ex = new Exception(mensagem);
                        _logger.Erro("EfetuarLogin", ex);
                        throw ex;
                    }
                    else
                    {
                        //Obter ou registrar token
                        var sessao = _sessaoRepository.ObterSessaoAtiva(user.ID);
                        if (sessao == null)
                        {
                            //Cria nova sessão
                            var newSesion = new Sessoes();
                            newSesion.ID = Guid.NewGuid();
                            newSesion.CriadoPorID = user.ID;
                            newSesion.DataExpiracao = DateTime.Now.ToUniversalTime().AddDays(1);
                            newSesion.IDUsuario = user.ID;
                            newSesion.Token = TokenGenerator.GerarToken();
                            newSesion.Usuario = user;
                            _sessaoRepository.Create(newSesion);

                            if (Commit())
                            {
                                retorno.Valido = true;
                                retorno.Token = newSesion.Token;
                                retorno.ValidoAte = newSesion.DataExpiracao.Value;
                            }
                            else
                            {
                                retorno.Valido = false;
                                retorno.Token = string.Empty;
                                retorno.ValidoAte = DateTime.Now;
                            }
                        }
                        else
                        {
                            retorno.Valido = true;
                            retorno.Token = sessao.Token;
                            retorno.ValidoAte = sessao.DataExpiracao.Value;
                        }
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(login))
                    {
                        sb.AppendLine("E-mail não preenchido");
                    }
                    if (string.IsNullOrWhiteSpace(senha))
                    {
                        sb.AppendLine("Senha não preenchida");
                    }

                    var mensagem = sb.ToString();
                    var ex = new Exception(mensagem);
                    _logger.Erro("EfetuarLogin", ex);
                    throw ex;
                }

                _logger.Informacao("ValidarLogin", $"Acesso permitido a {login} ");
                return retorno;

            }
            catch (Exception ex)
            {
                _logger.Erro($"ValidarLogin: Login: {login}", ex);
                throw ex;
            }
        }
    }
}
