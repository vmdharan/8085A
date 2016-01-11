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
        public byte regA { get; set; }

        // Register pair B-C
        public byte regB { get; set; }
        public byte regC { get; set; }

        // Register pair D-E
        public byte regD { get; set; }
        public byte regE { get; set; }

        // Register pair H-L
        public byte regH { get; set; }
        public byte regL { get; set; }

        // Temporary register
        public byte regTM {get; set; }

        // Instruction register
        public byte regIN { get; set; }

        // Status register
        public byte regST { get; set; }

        // Program counter
        public ushort regPC { get; set; }

        // Stack point
        public ushort regSP { get; set; }

        // ------ //
        // Memory //
        // ------ //
        public byte[] memory { get; set; }


        // Constructor
        public CPU_8085A()
        {
            memory = new byte[65536];
        }
    }
}
