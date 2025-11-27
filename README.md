1. How Do the Stack and the Heap Work?

A helpful way to understand the stack is to imagine a stack of plates.
To take a plate, you must remove the one on the very top, this represents the pop operation.
To add a new plate, you place it on top, this represents the push operation.
The stack always follows a First In, Last Out (FILO) pattern.

A heap, on the other hand, can be understood as a structure that organizes items by priority.
A good analogy is managing tasks by urgency: the most urgent task is kept at the top so it can be handled first.
Whenever you insert a new item or remove the top item, the heap automatically rearranges itself to maintain its priority order.

2. What Are Value Types and Reference Types?

In C#, value types store the actual data directly in the variable.
Reference types, however, store a reference (an address) that points to the location in memory where the data is held.

For example, an array variable does not contain the array itself — it contains a reference to the memory address where the array elements are stored.

3. Why Do the Two Methods Return Different Results?

The first method works with value types.
When you write y = x, the value stored in x (for example, 3) is copied into y.
Changing y later does not affect x, so the method returns 3.

The second method works with reference types (MyInt objects).
When you write y = x, both variables now refer to the same object in memory.
So when you change y.MyValue to 4, you are modifying the same object that x points to — meaning x.MyValue also becomes 4.
That is why the method returns 4.
