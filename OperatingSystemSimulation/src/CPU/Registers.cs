using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.CPU
{
    public class Registers
    {
        public Int32 ProgramCounter { get; set; }
        
        public Registers()
        {
            SetupMyRegisters();
        }

        #region intialization helpers
        
        private IList<IRegister> MyRegisters;

        private void SetupMyRegisters()
        {
            MyRegisters = GetNewRegisterSet().ToList();
        }

        private IRegister Accumulator = new Register()
        {
            Address = 0, // 0000
            Value = 0
        };

        private IEnumerable<IRegister> GetNewRegisterSet()
        {
            yield return Accumulator;
            yield return new ZeroRegister();

            for (int addr = 2; addr < 16; addr++) // registers for address space 2 -> 15 (0010b -> 1111b)
            {
                yield return new Register()
                {
                    Address = addr,
                    Value = 0
                };
            }            
        }

        #endregion

        public UInt32 GetRegisterValue(UInt32 registerAddress)
        {
            IRegister reg = GetRegisterAtAddress(registerAddress);
            return reg.Value;
        }

        public void SetRegisterValue(UInt32 registerAddress, UInt32 value)
        {
            IRegister reg = GetRegisterAtAddress(registerAddress);
            reg.Value = value;
        }

        #region register access helpers
        
        private IRegister GetRegisterAtAddress(UInt32 address)
        {
            return MyRegisters.First(reg => reg.Address == address);
        }

        #endregion

        #region register definition

        private interface IRegister
        {
            Int32 Address { get; set; }
            UInt32 Value { get; set; }
        }

        private struct Register : IRegister
        {
            public Int32 Address { get; set; }
            public UInt32 Value { get; set; }
        }

        private struct ZeroRegister : IRegister
        {

            public int Address
            {
                get
                {
                    return 1; // 0001
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public uint Value
            {
                get
                {
                    return 0;
                }
                set
                {
                    return;
                }
            }
        }

        #endregion
    }
}
