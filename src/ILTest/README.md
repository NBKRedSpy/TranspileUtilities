# ILTest

This is a simple IL project which creates a DLL with each of the IL Store/Load types.
The purpose is to have an easy project to test Harmony Transpiler functions against the local store/load operations.

It is not used in this project.

# Building 
To build, run build.bat with ilasm.exe in the path.  It will create the ILTest.dll.

# Functions
The resulting DLL will have the following functions:

|Function|Store/Loc type|
|--|--|
|StoreLoc|stloc n, ldloc n|
|StoreNum|stloc_n,  ldloc_n|
|StoreS|stloc_S n,  ldloc_S n|

