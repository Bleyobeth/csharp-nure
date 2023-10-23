using System;
using System.Collections.Generic;

namespace StackOfNumbers
{
    public interface IPushable<T>
    {
        void Push(T item);
    }

    public interface IPoppable<T>
    {
        T Pop();
    }

    public interface IPeekable<T>
    {
        T Peek();
    }

    public interface IStack<T> : IPushable<T>, IPoppable<T>, IPeekable<T>
    {
    }
}