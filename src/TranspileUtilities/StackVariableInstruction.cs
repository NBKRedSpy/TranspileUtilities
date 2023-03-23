using System;
using System.Reflection.Emit;
using HarmonyLib;

namespace TranspileUtilities
{
    /// <summary>
    /// Handles creating the complementary load or store operand for a code instruction.
    /// </summary>
    public class StackVariableInstruction
    {

        /// <summary>
        /// The load version of the source instruction
        /// </summary>
        public CodeInstruction Load { get; private set; }

        /// <summary>
        /// The store version of the source instruction
        /// </summary>
        public CodeInstruction Store { get; private set; }

        /// <summary>
        /// The code instruction to create the load/store CodeInstructions from.
        /// </summary>
        /// <param name="instruction"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public StackVariableInstruction(CodeInstruction instruction)
        {
            if(instruction == null) throw new ArgumentNullException(nameof(instruction));


            switch (instruction)
            {
                case CodeInstruction x when x.IsStloc():
                    Load = GetLoadLocal(instruction);
                    Store = instruction;
                    break;
                case CodeInstruction x when x.IsLdloc():
                    Load = instruction;
                    Store = GetStoreLocal(instruction);
                    break;
                default:
                    throw new ArgumentException($"Instruction OpCode is not a local load or store type.", nameof(instruction));
            };
        }

        /// <summary>
        /// A utility function to create a stack variable while using a code matcher.
        /// </summary>
        /// <param name="isStore">If true, will expect the codeInstruction to be a store opcode.  Otherwise a load opcode</param>
        /// <param name="codeInstruction">The instruction source</param>
        /// <param name="stackVariable">The newly created stack variable.  Will be null if no match</param>
        /// <returns>True if the opcode matched the isStore expectations</returns>
        /// <example>
        /// StackVariableInstruction cardListVariable = null;
        /// ...
        /// new CodeMatch(instruction => StackVariableInstruction.Create(true, instruction, out cardListVariable))
        /// ...
        /// </example>
        public static bool Create(bool isStore, CodeInstruction codeInstruction, out StackVariableInstruction stackVariable)
        {
            stackVariable = null;

            if((isStore && codeInstruction.IsStloc()) || (isStore == false && codeInstruction.IsLdloc()))
            {
                stackVariable = new StackVariableInstruction(codeInstruction);
                return true;

            }

            return false;
        }


        /// <summary>
        /// Gets the store version of the instruction
        /// </summary>
        /// <param name="storeInstruction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        private CodeInstruction GetLoadLocal(CodeInstruction storeInstruction)
        {
            if (storeInstruction?.IsStloc() == false)
            {
                throw new ArgumentException("Must be a store instruction", nameof(storeInstruction));
            }

            switch (storeInstruction.opcode)
            {
                case OpCode x when x == OpCodes.Stloc:
                    VerifyLocalBuilder(storeInstruction.operand);
                    return new CodeInstruction(OpCodes.Ldloc, storeInstruction.operand);
                case OpCode x when x == OpCodes.Stloc_S:
                    VerifyLocalBuilder(storeInstruction.operand);
                    return new CodeInstruction(OpCodes.Ldloc_S, storeInstruction.operand);
                case OpCode x when x == OpCodes.Stloc_0:
                    return new CodeInstruction(OpCodes.Ldloc_0);
                case OpCode x when x == OpCodes.Stloc_1:
                    return new CodeInstruction(OpCodes.Ldloc_1);
                case OpCode x when x == OpCodes.Stloc_2:
                    return new CodeInstruction(OpCodes.Ldloc_2);
                case OpCode x when x == OpCodes.Stloc_3:
                    return new CodeInstruction(OpCodes.Ldloc_3);
                default:
                    throw new ApplicationException($"Unexpected opcode: {storeInstruction.opcode}");
            }
        }


        /// <summary>
        /// Gets the load version of the instruction
        /// </summary>
        /// <param name="loadInstruction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ApplicationException"></exception>
        private CodeInstruction GetStoreLocal( CodeInstruction loadInstruction)
        {
            if (loadInstruction?.IsLdloc() == false)
            {
                throw new ArgumentException("Must be a load instruction", nameof(loadInstruction));
            }

            switch (loadInstruction.opcode)
            {
                case OpCode x when x == OpCodes.Ldloc:
                    VerifyLocalBuilder(loadInstruction.operand);
                    return new CodeInstruction(OpCodes.Stloc, loadInstruction.operand);
                case OpCode x when x == OpCodes.Ldloc_S:
                    VerifyLocalBuilder(loadInstruction.operand);
                    return new CodeInstruction(OpCodes.Stloc_S, loadInstruction.operand);
                case OpCode x when x == OpCodes.Ldloc_0:
                    return new CodeInstruction(OpCodes.Stloc_0);
                case OpCode x when x == OpCodes.Ldloc_1:
                    return new CodeInstruction(OpCodes.Stloc_1);
                case OpCode x when x == OpCodes.Ldloc_2:
                    return new CodeInstruction(OpCodes.Stloc_2);
                case OpCode x when x == OpCodes.Ldloc_3:
                    return new CodeInstruction(OpCodes.Stloc_3);
                default:
                    throw new ApplicationException($"Unexpected opcode: {loadInstruction.opcode}");
            }
        }

        /// <summary>
        /// throws an exception if the operand is not a LocalBuilder or is null.
        /// </summary>
        /// <param name="storeInstruction"></param>
        /// <exception cref="ApplicationException"></exception>
        private void VerifyLocalBuilder(object operand)
        {
            if ((operand is LocalBuilder localBuilder) == false || localBuilder == null)
            {
                throw new ApplicationException("*loc/*loc_s operand is not a local builder or is null");
            }
        }
    }
}
