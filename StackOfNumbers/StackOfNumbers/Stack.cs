using System;
using System.Collections.Generic;

namespace StackOfNumbers
{
    public class Stack : IStack<int>
    {
        private class Node
        {
            public int Value { get; set; }
            public Node? Next { get; set; } // Made nullable

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _head; // Renamed to _head and made nullable

        public Stack()
        {
            _head = null;
        }

        public Stack(params int[] initialValues) // Removed explicit array type specification
        {
            foreach (int value in initialValues)
            {
                Push(value);
            }
        }

        public override string ToString()
        {
            if (_head?.Next != null) // Если в стеке более одного элемента
            {
                throw new InvalidOperationException("Stack contains multiple items.");
            }

            return _head?.Value.ToString() ?? "";
        }

        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = _head;
            _head = newNode;
        }

        public int Pop()
        {
            if (_head == null) throw new InvalidOperationException("Stack is empty");
            int value = _head.Value;
            _head = _head.Next;
            return value;
        }

        public int Peek()
        {
            if (_head == null) throw new InvalidOperationException("Stack is empty");
            return _head.Value;
        }

        public int this[int index] // Indexer
        {
            get
            {
                Node? current = _head;
                int currentIndex = 0;

                while (current != null)
                {
                    if (currentIndex == index)
                        return current.Value;

                    current = current.Next;
                    currentIndex++;
                }

                throw new IndexOutOfRangeException("Index out of range of the stack.");
            }
        }

        public static explicit operator int(Stack stack) // Explicit type conversion
        {
            return stack.Peek();
        }

        public static implicit operator Stack(int value) // Implicit type conversion
        {
            return new Stack(value);
        }

        public static bool operator true(Stack stack)
        {
            return stack._head != null;
        }

        public static bool operator false(Stack stack)
        {
            return stack._head == null;
        }

        public static bool operator ==(Stack stack1, Stack stack2)
        {
            return AreStacksEqual(stack1, stack2);
        }

        public static bool operator !=(Stack stack1, Stack stack2)
        {
            return !AreStacksEqual(stack1, stack2);
        }

        private static bool AreStacksEqual(Stack stack1, Stack stack2)
        {
            Node? current1 = stack1._head;
            Node? current2 = stack2._head;

            while (current1 != null && current2 != null)
            {
                if (current1.Value != current2.Value)
                    return false;

                current1 = current1.Next;
                current2 = current2.Next;
            }

            return current1 == null && current2 == null;
        }

        public override bool Equals(object? obj) // Adjusted signature to match base class
        {
            if (obj is Stack otherStack)
            {
                return this == otherStack;
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (_head != null)
            {
                throw new InvalidOperationException("Cannot get hash code for a non-empty stack.");
            }

            return "".GetHashCode();
        }
    }
}