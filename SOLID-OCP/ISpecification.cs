﻿public interface ISpecification<T>
{
    bool IsSatisfied(T item);
}