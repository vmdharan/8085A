﻿namespace _8085A
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
        public byte regTM { get; set; }

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

        // Temporary values
        public byte d1 { get; set; }
        public byte d2 { get; set; }

        // Constructor
        public CPU_8085A()
        {
            memory = new byte[0x010000];

            d1 = 0x00;
            d2 = 0x00;
        }

        // Main loop
        public void run()
        {
            // Fetch
            // Decode
            // Execute
        }

        // Decode instruction
        public void decode()
        {
            byte instr = regIN;

            switch (instr)
            {
                /////////////////////////
                // Data Transfer Group //
                /////////////////////////

                // -- 84 instructions -- //

                // Move Register
                // MOV r1, r2
                // Dest = Register B
                case 0x40: regB = regB; break;
                case 0x41: regB = regC; break;
                case 0x42: regB = regD; break;
                case 0x43: regB = regE; break;
                case 0x44: regB = regH; break;
                case 0x45: regB = regL; break;
                case 0x47: regB = regA; break;

                // Dest = Register C
                case 0x48: regC = regB; break;
                case 0x49: regC = regC; break;
                case 0x4A: regC = regD; break;
                case 0x4B: regC = regE; break;
                case 0x4C: regC = regH; break;
                case 0x4D: regC = regL; break;
                case 0x4F: regC = regA; break;

                // Dest = Register D
                case 0x50: regD = regB; break;
                case 0x51: regD = regC; break;
                case 0x52: regD = regD; break;
                case 0x53: regD = regE; break;
                case 0x54: regD = regH; break;
                case 0x55: regD = regL; break;
                case 0x57: regD = regA; break;

                // Dest = Register E
                case 0x58: regE = regB; break;
                case 0x59: regE = regC; break;
                case 0x5A: regE = regD; break;
                case 0x5B: regE = regE; break;
                case 0x5C: regE = regH; break;
                case 0x5D: regE = regL; break;
                case 0x5F: regE = regA; break;

                // Dest = Register H
                case 0x60: regH = regB; break;
                case 0x61: regH = regC; break;
                case 0x62: regH = regD; break;
                case 0x63: regH = regE; break;
                case 0x64: regH = regH; break;
                case 0x65: regH = regL; break;
                case 0x67: regH = regA; break;

                // Dest = Register L
                case 0x68: regL = regB; break;
                case 0x69: regL = regC; break;
                case 0x6A: regL = regD; break;
                case 0x6B: regL = regE; break;
                case 0x6C: regL = regH; break;
                case 0x6D: regL = regL; break;
                case 0x6F: regL = regA; break;

                // Dest = Register A
                case 0x78: regA = regB; break;
                case 0x79: regA = regC; break;
                case 0x7A: regA = regD; break;
                case 0x7B: regA = regE; break;
                case 0x7C: regA = regH; break;
                case 0x7D: regA = regL; break;
                case 0x7F: regA = regA; break;

                // Move from memory
                // MOV r, M
                case 0x46:
                    regB = memory[(regH << 8) | regL];
                    break;
                case 0x4E:
                    regC = memory[(regH << 8) | regL];
                    break;
                case 0x56:
                    regD = memory[(regH << 8) | regL];
                    break;
                case 0x5E:
                    regE = memory[(regH << 8) | regL];
                    break;
                case 0x66:
                    regH = memory[(regH << 8) | regL];
                    break;
                case 0x6E:
                    regL = memory[(regH << 8) | regL];
                    break;
                case 0x7E:
                    regA = memory[(regH << 8) | regL];
                    break;

                // Move to memory
                // MOV M, r
                case 0x70:
                    memory[(regH << 8) | regL] = regB;
                    break;
                case 0x71:
                    memory[(regH << 8) | regL] = regC;
                    break;
                case 0x72:
                    memory[(regH << 8) | regL] = regD;
                    break;
                case 0x73:
                    memory[(regH << 8) | regL] = regE;
                    break;
                case 0x74:
                    memory[(regH << 8) | regL] = regH;
                    break;
                case 0x75:
                    memory[(regH << 8) | regL] = regL;
                    break;
                case 0x77:
                    memory[(regH << 8) | regL] = regA;
                    break;

                // Move immediate
                // MVI r, data
                case 0x06:
                    regB = d1;
                    break;
                case 0x0E:
                    regC = d1;
                    break;
                case 0x16:
                    regD = d1;
                    break;
                case 0x1E:
                    regE = d1;
                    break;
                case 0x26:
                    regH = d1;
                    break;
                case 0x2E:
                    regL = d1;
                    break;
                case 0x3E:
                    regA = d1;
                    break;

                // Move to memory immediate
                // MVI M, data
                case 0x36:
                    memory[(regH << 8) | regL] = d1;
                    break;

                // Load register pair immediate
                // LXI rp, data 16
                case 0x01:
                    regB = d2;
                    regC = d1;
                    break;
                case 0x11:
                    regD = d2;
                    regE = d1;
                    break;
                case 0x21:
                    regH = d2;
                    regL = d1;
                    break;
                case 0x31:
                    regSP = (ushort)((d2 << 8) | d1);
                    break;

                // Load Accumulator direct
                // LDA addr
                case 0x3A:
                    regA = memory[(d2 << 8) | d1];
                    break;

                // Store Accumulator direct
                // STA addr
                case 0x32:
                    memory[(d2 << 8) | d1] = regA;
                    break;

                // Load H and L direct
                // LHLD addr
                case 0x2A:
                    regL = memory[(d2 << 8) | d1];
                    regH = memory[((d2 << 8) | d1) + 1];
                    break;

                // Store H and L direct
                // SHLD addr
                case 0x22:
                    memory[(d2 << 8) | d1] = regL;
                    memory[((d2 << 8) | d1) + 1] = regH;
                    break;

                // Load accumulator indirect (RP using only B-C or D-E)
                // LDAX rp
                case 0x0A:
                    regA = memory[(regB << 8) | regC];
                    break;
                case 0x1A:
                    regA = memory[(regD << 8) | regE];
                    break;

                // Store accumulator indirect (RP using only B-C or D-E)
                // STAX rp
                case 0x02:
                    memory[(regB << 8) | regC] = regA;
                    break;
                case 0x12:
                    memory[(regD << 8) | regE] = regA;
                    break;

                // Exchange H and L with D and E
                // XCHG
                case 0xEB:
                    regTM = regH;
                    regH = regD;
                    regD = regTM;

                    regTM = regL;
                    regL = regE;
                    regE = regTM;
                    break;


                //////////////////////
                // Arithmetic Group //
                //////////////////////

                // -- 65 instructions -- //

                // Add register
                // ADD r
                case 0x80: break;
                case 0x81: break;
                case 0x82: break;
                case 0x83: break;
                case 0x84: break;
                case 0x85: break;
                case 0x87: break;

                // Add memory
                // ADD M
                case 0x86: break;

                // Add immediate
                // ADI data
                case 0xC6: break;

                // Add register with carry
                // ADC r
                case 0x88: break;
                case 0x89: break;
                case 0x8A: break;
                case 0x8B: break;
                case 0x8C: break;
                case 0x8D: break;
                case 0x8F: break;

                // Add memory with carry
                // ADC M
                case 0x8E: break;

                // Add immediate with carry
                // ACI data
                case 0xCE: break;

                // Subtract register
                // SUB r
                case 0x90: break;
                case 0x91: break;
                case 0x92: break;
                case 0x93: break;
                case 0x94: break;
                case 0x95: break;
                case 0x97: break;

                // Subtract memory
                // SUB M
                case 0x96: break;

                // Subtract immediate
                // SUI data
                case 0xD6: break;

                // Subtract register with borrow
                // SBB r
                case 0x98: break;
                case 0x99: break;
                case 0x9A: break;
                case 0x9B: break;
                case 0x9C: break;
                case 0x9D: break;
                case 0x9F: break;

                // Subtract memory with borrow
                // SBB M
                case 0x9E: break;

                // Subtract immediate with borrow
                // SBI data
                case 0xDE: break;

                // Increment register
                // INR r
                case 0x04: break;
                case 0x0C: break;
                case 0x14: break;
                case 0x1C: break;
                case 0x24: break;
                case 0x2C: break;
                case 0x3C: break;

                // Increment memory
                // INR M
                case 0x34: break;

                // Decrement register
                // DCR r
                case 0x05: break;
                case 0x0D: break;
                case 0x15: break;
                case 0x1D: break;
                case 0x25: break;
                case 0x2D: break;
                case 0x3D: break;

                // Decrement memory
                // DCR M
                case 0x35: break;

                // Increment register pair
                // INX rp
                case 0x03: break;
                case 0x13: break;
                case 0x23: break;
                case 0x33: break;

                // Decrement register pair
                // DCX rp
                case 0x0B: break;
                case 0x1B: break;
                case 0x2B: break;
                case 0x3B: break;

                // Add register pair to H and L
                // DAD rp
                case 0x09: break;
                case 0x19: break;
                case 0x29: break;
                case 0x39: break;

                // Decimal Adjust Accumulator
                // DAA
                case 0x27: break;


                ///////////////////
                // Logical Group //
                ///////////////////

                // -- 47 instructions -- //

                // AND Register
                // ANA r
                case 0xA0: break;
                case 0xA1: break;
                case 0xA2: break;
                case 0xA3: break;
                case 0xA4: break;
                case 0xA5: break;
                case 0xA7: break;

                // AND Memory
                // ANA M
                case 0xA6: break;

                // AND immediate
                // ANI data
                case 0xE6: break;

                // Exclusive OR Register
                // XRA r
                case 0xA8: break;
                case 0xA9: break;
                case 0xAA: break;
                case 0xAB: break;
                case 0xAC: break;
                case 0xAD: break;
                case 0xAF: break;

                // Exclusive OR Memory
                // XRA M
                case 0xAE: break;

                // Exclusive OR immediate
                // XRI data
                case 0xEE: break;

                // OR Register
                // ORA r
                case 0xB0: break;
                case 0xB1: break;
                case 0xB2: break;
                case 0xB3: break;
                case 0xB4: break;
                case 0xB5: break;
                case 0xB7: break;

                // OR Memory
                // ORA M
                case 0xB6: break;

                // OR immediate
                // ORI data
                case 0xF6: break;

                // Compare Register
                // CMP r
                case 0xB8: break;
                case 0xB9: break;
                case 0xBA: break;
                case 0xBB: break;
                case 0xBC: break;
                case 0xBD: break;
                case 0xBF: break;

                // Compare Memory
                // CMP M
                case 0xBE: break;

                // Compare immediate
                // CPI data
                case 0xFE: break;

                // Rotate left
                // RLC
                case 0x07: break;

                // Rotate right
                // RRC
                case 0x0F: break;

                // Rotate left through carry
                // RAL
                case 0x17: break;

                // Rotate right through carry
                // RAR
                case 0x1F: break;

                // Complement accumulator
                // CMA
                case 0x2F: break;

                // Complement carry
                // CMC
                case 0x3F: break;

                // Set carry
                // STC
                case 0x37: break;


                //////////////////
                // Branch Group //
                //////////////////

                // -- 36 instructions -- //

                // Jump
                // JMP addr
                case 0xC3: break;

                // Conditional jump
                // Jcondition addr
                case 0xC2: break;
                case 0xCA: break;
                case 0xD2: break;
                case 0xDA: break;
                case 0xE2: break;
                case 0xEA: break;
                case 0xF2: break;
                case 0xFA: break;

                // Call
                // CALL addr
                case 0xCD: break;

                // Condition call
                // Ccondition addr
                case 0xC4: break;
                case 0xCC: break;
                case 0xD4: break;
                case 0xDC: break;
                case 0xE4: break;
                case 0xEC: break;
                case 0xF4: break;
                case 0xFC: break;

                // Return
                // RET
                case 0xC9: break;

                // Conditional return
                // Rcondition
                case 0xC0: break;
                case 0xC8: break;
                case 0xD0: break;
                case 0xD8: break;
                case 0xE0: break;
                case 0xE8: break;
                case 0xF0: break;
                case 0xF8: break;

                // Restart
                // RST n
                case 0xC7: break;
                case 0xCF: break;
                case 0xD7: break;
                case 0xDF: break;
                case 0xE7: break;
                case 0xEF: break;
                case 0xF7: break;
                case 0xFF: break;

                // Jump H and L indirect - move H and L to PC
                // PCHL
                case 0xE9: break;


                ///////////////////////////////////////////
                // Stack, I/O, and Machine Control Group //
                ///////////////////////////////////////////

                // -- 18 instructions -- //

                // Push (Cannot use RP = SP)
                // PUSH rp
                case 0xC5: break;
                case 0xD5: break;
                case 0xE5: break;

                // Push processor status word
                // PUSH PSW
                case 0xF5: break;

                // Pop (Cannot use RP = SP)
                case 0xC1: break;
                case 0xD1: break;
                case 0xE1: break;

                // Pop processor status word
                // POP PSW
                case 0xF1: break;

                // Exchange stack top with H
                // XTHL
                case 0xE3: break;

                // Move HL to SP
                // SPHL
                case 0xF9: break;

                // Input
                // IN port
                case 0xDB: break;

                // Output
                // OUT port
                case 0xD3: break;

                // Enable interrupts
                // EI
                case 0xFB: break;

                // Disable interrupts
                // DI
                case 0xF3: break;

                // Halt
                // HLT
                case 0x76: break;

                // No op
                // NOP
                case 0x00: break;

                // Read Interrupt Masks
                // RIM
                case 0x20: break;

                // Set Interrupt Masks
                // SIM
                case 0x30: break;

                ////////////////////////////
                // 250 instructions total //
                ////////////////////////////
                default: break;
            }
        }
    }
}
