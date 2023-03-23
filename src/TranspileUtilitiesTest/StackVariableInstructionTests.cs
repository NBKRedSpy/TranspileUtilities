using Xunit;
using TranspileUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using HarmonyLib;
using Xunit.Sdk;
using System.Reflection;

namespace TranspileUtilities.Tests
{
    public class StackVariableInstructionTests
    {
        #region Ctor
        [Fact()]
        public void ctor__Numbered_OpCodes__LoadTranslation__Success()
        {
            var numberedOps = new List<(OpCode source, OpCode target)>() {
                (OpCodes.Ldloc_0,  OpCodes.Stloc_0),
                (OpCodes.Ldloc_1,  OpCodes.Stloc_1),
                (OpCodes.Ldloc_2,  OpCodes.Stloc_2),
                (OpCodes.Ldloc_3,  OpCodes.Stloc_3),
            };

            foreach (var opTranslation in numberedOps)
            {


                //Opcode translation test.
                CodeInstruction instruction = new CodeInstruction(opTranslation.source);
                StackVariableInstruction variable = new StackVariableInstruction(instruction);


                //Original Load
                Assert.Equal(variable.Load.opcode, opTranslation.source);
                Assert.Null(variable.Load.operand);

                //Translated Store
                Assert.Equal(variable.Store.opcode, opTranslation.target);
                Assert.Null(variable.Store.operand);
            }


        }


        [Fact()]
        public void ctor__Numbered_OpCodes__StoreTranslation__Success()
        {
            var numberedOps = new List<(OpCode source, OpCode target)>() {
                (OpCodes.Stloc_0, OpCodes.Ldloc_0),
                (OpCodes.Stloc_1, OpCodes.Ldloc_1),
                (OpCodes.Stloc_2, OpCodes.Ldloc_2),
                (OpCodes.Stloc_3, OpCodes.Ldloc_3)
            };



            foreach (var opTranslation in numberedOps)
            {


                //Opcode translation test.
                CodeInstruction instruction = new CodeInstruction(opTranslation.source);
                StackVariableInstruction variable = new StackVariableInstruction(instruction);


                //Original Load
                Assert.Equal(variable.Load.opcode, opTranslation.target);
                Assert.Null(variable.Load.operand);

                //Translated Store
                Assert.Equal(variable.Store.opcode, opTranslation.source);
                Assert.Null(variable.Store.operand);
            }


        }


        [Fact()]
        public void ctor__LocalBuilder_Store_Translation__Success()
        {

            var numberedOps = new List<(OpCode source, OpCode target)>() {
                (OpCodes.Stloc, OpCodes.Ldloc),
                (OpCodes.Stloc_S, OpCodes.Ldloc_S),
            };

            foreach (var opTranslation in numberedOps)
            {

                LocalBuilder localBuilder = (LocalBuilder)Activator.CreateInstance(typeof(LocalBuilder), true);

                CodeInstruction instruction = new CodeInstruction(opTranslation.source, localBuilder);
                StackVariableInstruction variable = new StackVariableInstruction(instruction);

                //Translation asserts
                Assert.Equal(variable.Load.opcode, opTranslation.target);
                Assert.Equal(variable.Store.opcode, opTranslation.source);
                Assert.Same(localBuilder, instruction.operand);
            }
        }

        [Fact()]
        public void ctor__Missing_LocalBuilder__Error()
        {

            var ops = new List<OpCode>()
            {
                OpCodes.Ldloc,
                OpCodes.Ldloc_S,
                OpCodes.Stloc,
                OpCodes.Stloc_S
            };



            foreach (var op in ops)
            {
                CodeInstruction instruction = new CodeInstruction(op, null);

                try
                {
                    StackVariableInstruction variable = new StackVariableInstruction(instruction);
                    Assert.Fail("Exception not thrown");
                }
                catch (Exception ex)
                {
                    Assert.IsType<ApplicationException>(ex);
                    Assert.Equal("*loc/*loc_s operand is not a local builder or is null", ex.Message);
                }
            }
         
        }


        [Fact()]
        public void ctor__LocalBuilder_Load_Translation__Success()
        {

            var numberedOps = new List<(OpCode source, OpCode target)>() {
                (OpCodes.Ldloc, OpCodes.Stloc),
                (OpCodes.Ldloc_S, OpCodes.Stloc_S),
            };

            foreach (var opTranslation in numberedOps)
            {
                LocalBuilder localBuilder = (LocalBuilder)Activator.CreateInstance(typeof(LocalBuilder), true);

                CodeInstruction instruction = new CodeInstruction(opTranslation.source, localBuilder);
                StackVariableInstruction variable = new StackVariableInstruction(instruction);

                //Translation asserts
                Assert.Equal(variable.Load.opcode, opTranslation.source);
                Assert.Equal(variable.Store.opcode, opTranslation.target);
                Assert.Same(localBuilder, instruction.operand);
            }
        }

        [Fact()]
        public void Ctor__NotLoadOrStoreOp__Exception()
        {
            Assert.Throws<ArgumentException>("instruction", () =>
            {
                var instruction = new StackVariableInstruction(new CodeInstruction(OpCodes.Add));
            });

        }

        [Fact()]
        public void Ctor__LoadAddressNotSupported__Exception()
        {

            try
            {
                var instruction = new StackVariableInstruction(new CodeInstruction(OpCodes.Ldloca));
                Assert.Fail("Exception not thrown");
            }
            catch (Exception ex)
            {
                Assert.IsType<ApplicationException>(ex);
                Assert.Equal("Unexpected opcode: ldloca", ex.Message);
            }

        }


        [Fact()]
        public void Ctor__NullInstruction__Exception()
        {
            Assert.Throws<ArgumentNullException>("instruction", () =>
            {
                var instruction = new StackVariableInstruction(null);
            });
        }

        
        
        #endregion

        [Fact()]
        public void Create__Tests__Success()
        {

            var facts = new List<(bool isStore, OpCode op, bool expectedIsMatch)>()
            {
                //Stores
                (true, OpCodes.Stloc_3, true),
                (true, OpCodes.Ldloc_3, false),

                //Loads
                (false, OpCodes.Stloc_3, false),
                (false, OpCodes.Ldloc_3, true),
                
                //No match
                (false, OpCodes.Add, false),
                (true, OpCodes.Add, false),

                //Ldloca not compatbile
                (false, OpCodes.Ldloca, false),
                (false, OpCodes.Ldloca_S, false),
            };


            foreach (var fact in facts)
            {
                StackVariableInstruction variable;

                bool result = StackVariableInstruction.Create(expectStore: fact.isStore, new CodeInstruction(fact.op), out variable);

                Assert.Equal(fact.expectedIsMatch, result);
                
                if (fact.expectedIsMatch) Assert.NotNull(variable);
                else Assert.Null(variable);
            }
        }

    }
}