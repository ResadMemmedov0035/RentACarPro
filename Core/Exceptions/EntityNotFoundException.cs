using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : IEntity
    {
        public EntityNotFoundException(Expression<Func<T, bool>> condition)
            : base($"No entity found that matches the condition: {condition.Body}")
        { }
    }

}
