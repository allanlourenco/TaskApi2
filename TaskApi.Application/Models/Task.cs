namespace TaskApi.Application.Models
{
    public class Task
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo {  get; set; }
    }

    public enum TaskStatus
    {
        NaoIniciado = 1,
        EmProgresso = 2,
        Finalizado = 3
    }
}
