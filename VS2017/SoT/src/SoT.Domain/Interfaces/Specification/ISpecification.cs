﻿
namespace SoT.Domain.Interfaces.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
