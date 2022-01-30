namespace cadastroSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T>Lista();
        T RetornarporId(int id);

        void Inserir(T entidade);

        void Excluir (int id);

        void Atualizar(int id, T entidade);

        int ProximoId();

    }
}