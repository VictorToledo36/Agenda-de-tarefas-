using AgendaDeTarefasAtt.Data;
using AgendaDeTarefasAtt.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgendaDeTarefasAtt.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public TarefaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public TarefaModel ListarPorId(int id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x => x.Id == id);
        }
        public List<TarefaModel> BuscarTodos()
        {
            return _bancoContext.Tarefas.ToList();
        }

        public bool VerificaSobreposto(TarefaModel tarefa)
        {
            return _bancoContext.Tarefas.Any(x => tarefa.Data == x.Data &&
                                                   ((tarefa.Horainicio >= x.Horainicio && tarefa.Horainicio < x.Horafim) ||
                                                  (tarefa.Horafim <= x.Horafim && tarefa.Horafim > x.Horainicio)));
        }


        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();

            return tarefa;
        }

        public TarefaModel Atualizar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na atualização da tarefa! ");

            tarefaDB.Titulotarefa = tarefa.Titulotarefa;
            tarefaDB.Descricaotarefa = tarefa.Descricaotarefa;
            tarefaDB.Data = tarefa.Data;
            tarefaDB.Horainicio = tarefa.Horainicio;
            tarefaDB.Horafim = tarefa.Horafim;
            tarefaDB.Prioridade = tarefa.Prioridade;
            tarefaDB.Tarefafinalizada = tarefa.Tarefafinalizada;

            _bancoContext.Tarefas.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }

        public bool Deletar(int id)
        {
            TarefaModel tarefaDB = ListarPorId(id);

            if (tarefaDB == null) throw new System.Exception("Houve um erro na deleção da tarefa! ");

            _bancoContext.Tarefas.Remove(tarefaDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
