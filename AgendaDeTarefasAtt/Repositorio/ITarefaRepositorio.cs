using AgendaDeTarefasAtt.Models;
using System.Collections.Generic;

namespace AgendaDeTarefasAtt.Repositorio
{
    public interface ITarefaRepositorio
    {
        TarefaModel ListarPorId(int id);
        List<TarefaModel> BuscarTodos();
        TarefaModel Adicionar(TarefaModel tarefa);
        TarefaModel Atualizar(TarefaModel tarefa);
        bool VerificaSobreposto(TarefaModel tarefa);
        bool Deletar(int id);
    }
}
