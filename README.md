# Description 
A Harmony transpiler helper class that can take a local variable load or store operation and return the complement.

Useful when different versions of the target code may change operations.  For example, stloc_3 to stloc_s.

# Example:

```csharp
StackVariableInstruction fooVariable = null;   //The local variable

codeMatcher
            .MatchForward(true,
                ...
                //The first parameter determines if a load or store is expected.
                new CodeMatch(instruction => StackVariableInstruction.Create(true, instruction, out cardListVariable))
                ...
                )
            .Insert(
                //Inserts a load operation
                cardListVariable.Load,
                
                //Some function call
                CodeInstruction.Call(typeof(Foo), nameof(Bar), new Type[] { typeof(List<Fizz>) }),  
                
                //Inserts the store operation
                cardListVariable.Store
            )
            .InstructionEnumeration()
```


# StackVariableInstruction.Create

A utility function to create a stack variable while using a code matcher.

|Parameter|Description|
|--|--|
|isStore|If true, will expect the codeInstruction to be a store opcode.  Otherwise a load opcode.|
|codeInstruction|The instruction source.|
|stackVariable|The newly created stack variable.  Will be null if no match.|
|returns|True if the opcode matched the isStore expectations.|

