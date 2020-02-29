using System.ComponentModel;

namespace Exceptions.Messages
{
    public enum ExceptionMessages
    {
        [Description("Erro ao buscar dados")]
        ErrorOnRetrievingData,

        [Description("Não foi possível atualizar a Task, tente novamente.")]
        ExceptionOnUpdatingTask,

        [Description("Erro ao criar a Task.")]
        ExceptionOnCreateTask,

        [Description("Não foi possível excluir a task selecionada")]
        ExceptionOnDelete
    }
}
