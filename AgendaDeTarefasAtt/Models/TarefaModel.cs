using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDeTarefasAtt.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome da tarefa")]
        public string Titulotarefa { get; set; }

        [Required(ErrorMessage ="Digite a descrição da tarefa")]
        public string Descricaotarefa { get; set; }

        [Required(ErrorMessage ="A Data é obrigatório")]
        public int Data { get; set; }

        [Required(ErrorMessage ="Digite a hora de incicio da tarefa")]
        public int Horainicio { get; set; }

        [Required(ErrorMessage ="Digite a hora de finalização da tarefa")]
        public int Horafim { get; set; }

        [Required(ErrorMessage ="Digite a prioridade da tarefa")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage ="Digite se a tarefa foi finalizada")]
        public string Tarefafinalizada { get; set; }
    }
}

