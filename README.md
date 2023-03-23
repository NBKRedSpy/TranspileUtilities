# Description 
A Harmony transpiler helper class that can take a local variable load or store operation and return the complement.

Useful when different versions of the target code may change operations.  For example, stloc_3 to stloc_s.

# Examples
## Code Matcher Example:

```csharp
StackVariableInstruction fooVariable = null;   //The local variable

return codeMatcher
    .MatchForward(true,
        ...
        //The first parameter determines if a load or store must be matched.
        new CodeMatch(instruction => StackVariableInstruction.Create(isStore: true, instruction, out fooVariable))
        ...
        )
    .ThrowIfNotMatch("Did not find load section")        
    .Insert(
        //Inserts a load operation
        fooVariable.Load,
        
        //Some function call
        CodeInstruction.Call(typeof(Foo), nameof(Bar)),
        
        //Inserts a store operation
        fooVariable.Store
    )
    .InstructionEnumeration()
```
## Using directly:
```csharp
            StackVariableInstruction instruction = new StackVariableInstruction(new CodeInstruction(OpCodes.Stloc_2));
            instruction.Load;   //Return the load version
            instruction.Store;  //Return the store version
```


# Using the Code
Copy the StackVariableInstruction.cs file in the root of this repository into your application.

# StackVariableInstruction.Create

A utility function to create a stack variable while using a code matcher.

|Parameter|Description|
|--|--|
|isStore|If true, will expect the codeInstruction to be a store opcode.  Otherwise a load opcode.|
|codeInstruction|The instruction source.|
|stackVariable|The newly created stack variable.  Will be null if no match.|
|returns|True if the opcode matched the isStore expectations.|


# Project Folders
|Project|Description|
|--|--|
|src/TranspileUtilities|Creates the /StackVariableInstruction.cs file|
|src/TranspileUtilitiesTest|The tests for the TranspileUtilities project|
|src/ILTest|Creates a DLL with the various load/store operations for testing purposes.  Not used in this project|
