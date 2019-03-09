using System;
using System.Threading.Tasks;

namespace CMDataModel.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }

        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
