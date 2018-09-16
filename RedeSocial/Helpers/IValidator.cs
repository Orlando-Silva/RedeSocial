namespace Helpers
{
    public interface IEntityValidator<T> where T : class
    {
        bool IsValid(T entidade);
    }
}
