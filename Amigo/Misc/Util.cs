using Amigo.ViewModel;
using AmigoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amigo
{
    public static class Util
    {
        public static Repositorio Repositorio { get; set; }
        public static IEnumerable<KeyValuePair<int, string>> ObterListaSocios()
        {
            return Repositorio.ObterLista<Pessoa>(nomeTabela: "Socios")
                .Select((p => new KeyValuePair<int, string>(p.Id, p.Nome)));
        }
        public static bool CheckTemUsuarios()
        {
            return Repositorio.ObterLista<Usuario>().Any();
        }
        public static bool ExisteUsuarioMaster()
        {
            return Repositorio.ObterLista<Usuario>().Any(p => p.Nivel >= (int)NiveisUsuarios.Master);
        }
        public static KeyValuePair<bool, object> CheckLogin(string login, string password)
        {
            var repo = Repositorio;
            var user = repo.Obter<Usuario>(x => x.Login.Equals(login));
            if (user == null)
            {
                return new KeyValuePair<bool, object>(false, "Usuário não encontrado");
            }
            if (PasswordSecurity.PasswordStorage.VerifyPassword(password, user.PasswordHash))
            {
                return new KeyValuePair<bool, object>(true, user);
            }


            return new KeyValuePair<bool, object>(false, "Senha inválida");
        }
        public static bool ValidarPermissaoComMensagem(Usuario usuario, PermissaoAtividadeUsuario permissaoSolicitada)
        {
            var permitido = ValidarPermissao(usuario, permissaoSolicitada);
            if (!permitido)
            {
                MessageBox.Show(string.Format("O usuário {0} não tem permissão para realizar esta operação", usuario.Nome));
                return false;
            }
            return true;
        }
        public static bool ValidarPermissao(Usuario usuario, PermissaoAtividadeUsuario permissaoSolicitada)
        {
            if (usuario == null)
            {
                return true;
            }
            return usuario.Nivel >= (int)permissaoSolicitada;
        }
        public static string ObterNomeTabela(TipoPessoa _tipoPessoa)
        {

            var _nomeTabela = string.Empty;
            switch (_tipoPessoa)
            {
                case TipoPessoa.Socio:
                    {
                        _nomeTabela = "Socios";
                    }
                    break;
                case TipoPessoa.Veterinario:
                    {
                        _nomeTabela = "Veterinarios";

                    }
                    break;
                case TipoPessoa.Clinica:
                    {
                        _nomeTabela = "Clinicas";


                    }
                    break;
                case TipoPessoa.Cliente:
                    {

                        _nomeTabela = "Clientes";

                    }
                    break;
                case TipoPessoa.MoradorComunitario:
                    {
                        _nomeTabela = "Morador";

                    }
                    break;
                case TipoPessoa.Fornecedor:
                    {
                        _nomeTabela = "Fornecedores";

                    }
                    break;
                case TipoPessoa.Entidade:
                    {
                        _nomeTabela = "Entidades";

                    }
                    break;
                case TipoPessoa.Parceiro:
                    {
                        _nomeTabela = "Parceiros";

                    }
                    break;
                case TipoPessoa.Doador:
                    {
                        _nomeTabela = "Doadores";

                    }
                    break;
                case TipoPessoa.Patrocinador:
                    {
                        _nomeTabela = "Patrocinadores";

                    }
                    break;
                default:
                    break;
            }
            return _nomeTabela;


        }
    }


}
