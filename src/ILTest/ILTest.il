
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly ILTest
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 06 49 4C 54 65 73 74 00 00 )                // ...ILTest..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 06 49 4C 54 65 73 74 00 00 )                // ...ILTest..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 33 00 00 )                            //  2023..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 34 32 36 36 30 38 36 31 2D 39 32 34 37   // ..$42660861-9247
                                                                                                  2D 34 39 31 62 2D 39 38 32 31 2D 61 39 39 38 39   // -491b-9821-a9989
                                                                                                  63 35 32 66 62 62 31 00 00 )                      // c52fbb1..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 36 2E 32 01   // ,Version=v4.6.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 36 2E 32 )          // amework 4.6.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module ILTest.dll
// MVID: {587FE35C-0200-4B89-BE17-62CBCD18C286}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06BD0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit ILTest.Source
       extends [mscorlib]System.Object
{
  .method public hidebysig static int32 
          StoreLoc() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  2
    .locals init ([0] int32 a,
             [1] int32 b,
             [2] int32 V_2)
    IL_0000:  nop
    IL_0001:  ldc.i4.1
    IL_0002:  stloc 0
    IL_0003:  ldc.i4.2
    IL_0004:  stloc.1
    IL_0005:  ldloc 0
    IL_0006:  ldloc.1
    IL_0007:  add
    IL_0008:  stloc.2
    IL_0009:  br.s       IL_000b

    IL_000b:  ldloc.2
    IL_000c:  ret
  } // end of method Source::StoreLoc

  .method public hidebysig static int32 
          StoreNum() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  2
    .locals init ([0] int32 a,
             [1] int32 b,
             [2] int32 V_2)
    IL_0000:  nop
    IL_0001:  ldc.i4.1
    IL_0002:  stloc.0
    IL_0003:  ldc.i4.2
    IL_0004:  stloc.1
    IL_0005:  ldloc.0
    IL_0006:  ldloc.1
    IL_0007:  add
    IL_0008:  stloc.2
    IL_0009:  br.s       IL_000b

    IL_000b:  ldloc.2
    IL_000c:  ret
  } // end of method Source::StoreNum

  .method public hidebysig static int32 
          StoreS() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  2
    .locals init ([0] int32 a,
             [1] int32 b,
             [2] int32 V_2)
    IL_0000:  nop
    IL_0001:  ldc.i4.1
    IL_0002:  stloc.s 0
    IL_0003:  ldc.i4.2
    IL_0004:  stloc.1
    IL_0005:  ldloc.s 0
    IL_0006:  ldloc.1
    IL_0007:  add
    IL_0008:  stloc.2
    IL_0009:  br.s       IL_000b

    IL_000b:  ldloc.2
    IL_000c:  ret
  } // end of method Source::StoreS

} // end of class ILTest.Source


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file ILTest.res
