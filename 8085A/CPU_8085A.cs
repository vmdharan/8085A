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

        // Flags register
        public byte regFL { get; set; }
        public int flag_Z { get; set; }
        public int flag_P { get; set; }
        public int flag_S { get; set; }
        public int flag_CY { get; set; }
        public int flag_AC { get; set; }

        // Interrupts
        public bool EN_interrupt { get; set; }

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

        // Convert a byte to a bit-string representation.
        // High order bit is in index 0.
        // Low order bit is in index 7.
        public char[] convertFromByte(byte byteVal)
        {
            int i;
            int n = 128;
            int b = (int)byteVal & 0x000000FF;
            char[] bufferVal = new char[8];

            for (i = 0; i < 8; i++)
            {
                if ((b / n) < 1.0)
                {
                    bufferVal[i] = (char)0;
                }
                else
                {
                    bufferVal[i] = (char)1;
                    b = b - n;
                }

                n = n / 2;
            }

            return bufferVal;
        }

        // Convert a bit-stringto a byte representation
        public byte convertToByte(char[] bytebuffer)
        {
            int i;
            int n = 0;

            for (i = 0; i < 8; i++)
            {
                if (bytebuffer[i] == 1)
                {
                    n += (1 << (7 - i));
                }
            }

            return (byte)n;
        }

        // Update Carry flag.
        private void updateCarryFlag(int carry)
        {
            // Set Carry flag.
            if (carry == 1)
            {
                flag_CY = 1;
            }
            else
            {
                flag_CY = 0;
            }
        }

        // Update Sign flag.
        private void updateSignFlag(char[] rb)
        {
            // Set Sign flag.
            if (rb[0] == 1)
            {
                flag_S = 1;
            }
            else
            {
                flag_S = 0;
            }
        }

        // Update Zero flag.
        private void updateZeroFlag(byte result)
        {
            // Set Zero flag.
            if (result == 0x00)
            {
                flag_Z = 1;
            }
            else
            {
                flag_Z = 0;
            }
        }

        // Update Parity flag.
        private void updateParityFlag(char[] rb)
        {
            int i;

            // Set Parity flag.
            flag_P = 0;
            for (i = 0; i < 8; i++)
            {
                if (rb[i] == 1)
                {
                    flag_P++;
                }
            }

            if ((flag_P % 2) == 0)
            {
                flag_P = 1;
            }
            else
            {
                flag_P = 0;
            }
        }

        // Add two bytes
        private byte addTwoBytes(byte b1, byte b2, int CF)
        {
            int i;
            byte result;
            int carry = 0;

            // Add with carry.
            if (CF == 1)
            {
                carry = flag_CY;
            }

            char[] op1 = convertFromByte(b1);
            char[] op2 = convertFromByte(b2);
            char[] rb = new char[8];

            flag_AC = 0;

            for (i = 7; i >= 0; i--)
            {
                // Add two '1's.
                if ((op1[i] == 1) & (op2[i] == 1))
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)1;
                    }
                    else
                    {
                        rb[i] = (char)0;
                    }
                    carry = 1;

                    // Update Auxiliary carry.
                    if (i == 4)
                    {
                        flag_AC = 1;
                    }
                }
                // Add two '0's.
                else if ((op1[i] == 0) & (op2[i] == 0))
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)1;
                    }
                    else
                    {
                        rb[i] = (char)0;
                    }
                    carry = 0;
                }
                // Add '1' and '0'
                else
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)0;
                        carry = 1;

                        // Update Auxiliary carry.
                        if (i == 4)
                        {
                            flag_AC = 1;
                        }
                    }
                    else
                    {
                        rb[i] = (char)1;
                    }
                }
            }

            updateSignFlag(rb);
            updateCarryFlag(carry);

            result = convertToByte(rb);

            updateZeroFlag(result);
            updateParityFlag(rb);

            return result;
        }

        // Returns the Ones Complement.
        private char[] onesComplement(char[] b)
        {
            int i;
            char[] result = new char[8];

            for(i = 0; i < 8; i++)
            {
                if(b[i] == (char) 0)
                {
                    result[i] = (char) 1;
                }
                else
                {
                    result[i] = (char) 0;
                }
            }

            return result;
        }

        // Subtract byte
        private byte subtractByte(byte b1, byte b2)
        {
            int i;
            byte result;
            int carry = 0;

            char[] op1 = convertFromByte(b1);
            char[] op2 = onesComplement(convertFromByte(b2));
            char[] rb = new char[8];

            flag_AC = 0;

            for (i = 7; i >= 0; i--)
            {
                // Add two '1's.
                if ((op1[i] == 1) & (op2[i] == 1))
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)1;
                    }
                    else
                    {
                        rb[i] = (char)0;
                    }
                    carry = 1;

                    // Update Auxiliary carry.
                    if (i == 4)
                    {
                        flag_AC = 1;
                    }
                }
                // Add two '0's.
                else if ((op1[i] == 0) & (op2[i] == 0))
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)1;
                    }
                    else
                    {
                        rb[i] = (char)0;
                    }
                    carry = 0;
                }
                // Add '1' and '0'
                else
                {
                    if (carry == 1)
                    {
                        rb[i] = (char)0;
                        carry = 1;

                        // Update Auxiliary carry.
                        if (i == 4)
                        {
                            flag_AC = 1;
                        }
                    }
                    else
                    {
                        rb[i] = (char)1;
                    }
                }
            }

            char[] rb2 = new char[8];

            if(carry == 1)
            {
                rb2 = addCarry(rb);
                carry = 0;
            }
            else
            {
                rb2 = rb;
            }

            updateSignFlag(rb2);
            updateCarryFlag(carry);

            result = convertToByte(rb2);

            updateZeroFlag(result);
            updateParityFlag(rb2);

            return result;
        }

        // Add carry to byte.
        private char[] addCarry(char[] b)
        {
            int i;
            char[] result = new char[8];
            int carry = 1;
            
            for(i=7;i>=0;i--)
            {
                if((b[i] == (char)0) && (carry==1))
                {
                    result[i] = (char)1;
                    carry = 0;
                }
                else if((b[i] == (char)0) && (carry==0))
                {
                    result[i] = (char)0;
                }
                else if((b[i] == (char)1) && (carry == 1))
                {
                    result[i] = (char)0;
                    carry = 1;

                    // Update Auxiliary carry.
                    if(i == 4)
                    {
                        flag_AC = 1;
                    }
                }
                else if((b[i] == (char)1) && (carry == 0))
                {
                    result[i] = (char)1;
                }
            }

            return result;
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
                case 0x80:
                    regA = addTwoBytes(regA, regB, 0);
                    break;
                case 0x81:
                    regA = addTwoBytes(regA, regC, 0);
                    break;
                case 0x82:
                    regA = addTwoBytes(regA, regD, 0);
                    break;
                case 0x83:
                    regA = addTwoBytes(regA, regE, 0);
                    break;
                case 0x84:
                    regA = addTwoBytes(regA, regH, 0);
                    break;
                case 0x85:
                    regA = addTwoBytes(regA, regL, 0);
                    break;
                case 0x87:
                    regA = addTwoBytes(regA, regA, 0);
                    break;

                // Add memory
                // ADD M
                case 0x86:
                    regA = addTwoBytes(regA, memory[(regH << 8) | regL], 0);
                    break;

                // Add immediate
                // ADI data
                case 0xC6:
                    regA = addTwoBytes(regA, d1, 0);
                    break;

                // Add register with carry
                // ADC r
                case 0x88:
                    regA = addTwoBytes(regA, regB, 1);
                    break;
                case 0x89:
                    regA = addTwoBytes(regA, regC, 1);
                    break;
                case 0x8A:
                    regA = addTwoBytes(regA, regD, 1);
                    break;
                case 0x8B:
                    regA = addTwoBytes(regA, regE, 1);
                    break;
                case 0x8C:
                    regA = addTwoBytes(regA, regH, 1);
                    break;
                case 0x8D:
                    regA = addTwoBytes(regA, regL, 1);
                    break;
                case 0x8F:
                    regA = addTwoBytes(regA, regA, 1);
                    break;

                // Add memory with carry
                // ADC M
                case 0x8E:
                    regA = addTwoBytes(regA, memory[(regH << 8) | regL], 1);
                    break;

                // Add immediate with carry
                // ACI data
                case 0xCE:
                    regA = addTwoBytes(regA, d1, 1);
                    break;

                // Subtract register
                // SUB r
                case 0x90:
                    regA = subtractByte(regA, regB);
                    break;
                case 0x91:
                    regA = subtractByte(regA, regC);
                    break;
                case 0x92:
                    regA = subtractByte(regA, regD);
                    break;
                case 0x93:
                    regA = subtractByte(regA, regE);
                    break;
                case 0x94:
                    regA = subtractByte(regA, regH);
                    break;
                case 0x95:
                    regA = subtractByte(regA, regL);
                    break;
                case 0x97:
                    regA = subtractByte(regA, regA);
                    break;

                // Subtract memory
                // SUB M
                case 0x96:
                    regA = subtractByte(regA, memory[(regH << 8) | regL]);
                    break;

                // Subtract immediate
                // SUI data
                case 0xD6:
                    regA = subtractByte(regA, d1);
                    break;

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
                case 0x04:
                    break;
                case 0x0C:
                    break;
                case 0x14:
                    break;
                case 0x1C:
                    break;
                case 0x24:
                    break;
                case 0x2C:
                    break;
                case 0x3C:
                    break;

                // Increment memory
                // INR M
                case 0x34:
                    break;

                // Decrement register
                // DCR r
                case 0x05:
                    break;
                case 0x0D:
                    break;
                case 0x15:
                    break;
                case 0x1D:
                    break;
                case 0x25:
                    break;
                case 0x2D:
                    break;
                case 0x3D:
                    break;

                // Decrement memory
                // DCR M
                case 0x35:
                    break;

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
                case 0x3F:
                    flag_CY = (flag_CY == 1 ? 0 : 1);
                    break;

                // Set carry
                // STC
                case 0x37:
                    flag_CY = 1;
                    break;


                //////////////////
                // Branch Group //
                //////////////////

                // -- 36 instructions -- //

                // Jump
                // JMP addr
                case 0xC3:
                    regPC = (ushort)((d2 << 8) | d1);
                    break;

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
                case 0xE9:
                    regPC = (ushort)((regH << 8) | regL);
                    break;


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
                case 0xE3:
                    regTM = regL;
                    regL = memory[regSP];
                    memory[regSP] = regTM;

                    regTM = regH;
                    regH = memory[regSP + 1];
                    memory[regSP + 1] = regTM;
                    break;

                // Move HL to SP
                // SPHL
                case 0xF9:
                    regSP = (ushort)((regH << 8) | regL);
                    break;

                // Input
                // IN port
                case 0xDB:
                    break;

                // Output
                // OUT port
                case 0xD3:
                    break;

                // Enable interrupts
                // EI
                case 0xFB:
                    EN_interrupt = true;
                    break;

                // Disable interrupts
                // DI
                case 0xF3:
                    EN_interrupt = false;
                    break;

                // Halt
                // HLT
                case 0x76:
                    break;

                // No op
                // NOP
                case 0x00:
                    break;

                // Read Interrupt Masks
                // RIM
                case 0x20:
                    break;

                // Set Interrupt Masks
                // SIM
                case 0x30:
                    break;

                ////////////////////////////
                // 250 instructions total //
                ////////////////////////////
                default: break;
            }
        }
    }
}
