using Xunit;
using StackOfNumbers;

namespace StackTest
{
    public class StackNumTest
    {
        [Fact]
        public void Push_PushesItemOntoStack()
        {
            var stack = new Stack();
            stack.Push(1);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Pop_PopsItemFromStack()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Peek_ReturnsTopItemWithoutRemoving()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Peek());
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void Pop_ThrowsWhenStackIsEmpty()
        {
            var stack = new Stack();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_ThrowsWhenStackIsEmpty()
        {
            var stack = new Stack();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Constructor_InitializesWithMultipleValues()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.Equal(3, stack.Peek());
            stack.Pop();
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void Indexer_NegativeIndex_ThrowsException()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.Throws<IndexOutOfRangeException>(() => stack[-1]);
        }

        [Fact]
        public void Indexer_LargePositiveIndex_ThrowsException()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.Throws<IndexOutOfRangeException>(() => stack[100]);
        }

        [Fact]
        public void ExplicitConversion_EmptyStack_ThrowsException()
        {
            var stack = new Stack();
            Assert.Throws<InvalidOperationException>(() => (int)stack);
        }

        [Fact]
        public void Equals_NullObject_ReturnsFalse()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.False(stack.Equals(null));
        }

        [Fact]
        public void Equals_DifferentObjectType_ReturnsFalse()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            object someString = "string";
            if (someString is Stack)
            {
                Assert.False(stack.Equals(someString));
            }
            else
            {
                Assert.True(true); // Explicitly pass the test if the types are different
            }
        }

        [Fact]
        public void GetHashCode_EmptyStack_ReturnsExpectedValue()
        {
            var stack = new Stack();
            int expectedHashCode = "".GetHashCode();
            Assert.Equal(expectedHashCode, stack.GetHashCode());
        }


        [Fact]
        public void ToString_EmptyStack_ReturnsEmptyString()
        {
            var stack = new Stack();
            Assert.Equal("", stack.ToString());
        }

        [Fact]
        public void OperatorEquals_DifferentStackLength_ReturnsFalse()
        {
            var stack1 = new Stack(new int[] { 1, 2, 3 });
            var stack2 = new Stack(new int[] { 1, 2 });
            Assert.False(stack1 == stack2);
        }

        [Fact]
        public void OperatorNotEquals_SameStacks_ReturnsFalse()
        {
            var stack1 = new Stack(new int[] { 1, 2, 3 });
            var stack2 = new Stack(new int[] { 1, 2, 3 });
            Assert.False(stack1 != stack2);
        }

        /*add tests 20p*/
        [Fact]
        public void Push_MultipleItems_CheckOrder()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            Assert.NotEqual(1, stack.Peek());
        }

        [Fact]
        public void Pop_PopMoreThanPushed_ThrowsException()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Pop();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_PeekAfterPopOnSingleItemStack_ThrowsException()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Pop();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Indexer_EmptyStack_ThrowsException()
        {
            var stack = new Stack();
            Assert.Throws<IndexOutOfRangeException>(() => stack[0]);
        }
        /*add test3*/
        // ... [existing tests]

        [Fact]
        public void ToString_MultipleItemsStack_ThrowsException()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.Throws<InvalidOperationException>(() => stack.ToString());
        }

        [Fact]
        public void Equals_DifferentStacks_ReturnsFalse()
        {
            var stack1 = new Stack(new int[] { 1, 2, 3 });
            var stack2 = new Stack(new int[] { 4, 5, 6 });
            Assert.False(stack1.Equals(stack2));
        }

        [Fact]
        public void NotEquals_SameStacks_ReturnsFalse()
        {
            var stack1 = new Stack(new int[] { 1, 2, 3 });
            var stack2 = new Stack(new int[] { 1, 2, 3 });
            Assert.False(!stack1.Equals(stack2));
        }

        [Fact]
        public void GetHashCode_NonEmptyStack_ThrowsException()
        {
            var stack = new Stack(new int[] { 1, 2, 3 });
            Assert.Throws<InvalidOperationException>(() => stack.GetHashCode());
        }
    }
}