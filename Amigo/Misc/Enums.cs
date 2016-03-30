using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo
{
   public enum NiveisUsuarios
    {
        Master= 9999,
        Geral=1000,
        GeralRestrito=100,
        SomenteLeitura=10
    }

    public enum PermissaoAtividadeUsuario
    {
        GerarBackup=NiveisUsuarios.Master,
        RestaurarBackup = NiveisUsuarios.Master,
        AlterarUsuarios =NiveisUsuarios.Master,
        Leitura=NiveisUsuarios.SomenteLeitura,
        Adicionar=NiveisUsuarios.GeralRestrito,
        Alterar = NiveisUsuarios.GeralRestrito,
        Excluir=NiveisUsuarios.Geral
    }
    public enum EnumSimNao
    {
        NaoColocado,
        Sim,
        Nao
    }
}
