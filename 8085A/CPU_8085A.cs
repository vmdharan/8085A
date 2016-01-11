using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8085A
{
    class CPU_8085A
    {
        // --------------------- //
        // ----- Registers ----- //
        // --------------------- //

        // Accumulator
        protected byte regA;

        // Register pair B-C
        protected byte regB;
        protected byte regC;

        // Register pair D-E
        protected byte regD;
        protected byte regE;

        // Register pair H-L
        protected byte regH;
        protected byte regL;

        // Temporary register
        protected byte regTM;

        // Instruction register
        protected byte regIN;

        // Status register
        protected byte regST;

        // Program counter
        protected ushort regPC;

        // Stack point
        protected ushort regSP;

        // ------ //
        // Memory //
        // ------ //
        public byte[] memory;


        // Constructor
        public CPU_8085A()
        {
            memory = new byte[65536];
        }
    }
}
