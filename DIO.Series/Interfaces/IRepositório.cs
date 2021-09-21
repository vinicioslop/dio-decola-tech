using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositório<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Desativa(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}