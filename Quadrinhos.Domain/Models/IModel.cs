namespace Quadrinhos.Domain.Models
{
    public interface IModel<T>
    {
        T Id { get; set; }
    }
}
