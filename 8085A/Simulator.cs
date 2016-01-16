using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _8085A
{
    public partial class Simulator : Form
    {
        private CPU_8085A core1;

        public Simulator()
        {
            InitializeComponent();

            core1 = new CPU_8085A();
        }

        // Display the memory header.
        private void listMemoryHeader()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            StringBuilder mRTB = new StringBuilder();
            mRTB.Append("++++  0x00 0x01 0x02 0x03 0x04 0x05 0x06 "
                + "0x07 0x08 0x09 0x0A 0x0B 0x0C 0x0D 0x0E 0x0F ");

            memHdrRTB.AppendText(mRTB.ToString());

            sw.Stop();
            File.AppendAllText("performance.out", "listMemoryHeader: "
                + sw.ElapsedMilliseconds.ToString() + "\n");
        }

        // Display the values in memory.
        private void listMemory()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int i, j, k;
            StringBuilder mRTB = new StringBuilder();
            string iVal;

            for (i = 0; i < 4096; i++)
            {
                iVal = i.ToString();
                for (int l = 0; 4 - iVal.Length > 0; l++)
                {
                    iVal = "0" + iVal;
                }

                mRTB.Append(iVal + "  ");

                k = i << 4;

                for (j = 0; j < 15; j++)
                {
                    mRTB.Append(string.Format("0x{0:X2}", core1.memory[k + j]) + " ");
                }
                mRTB.Append(string.Format("0x{0:X2}", core1.memory[k + j]) + " \n");
            }

            memoryRTB.AppendText(mRTB.ToString());
            mRTB.Clear();

            sw.Stop();
            File.AppendAllText("performance.out", "listMemory: "
                + sw.ElapsedMilliseconds.ToString() + "\n");
        }

        // Display the values in the register.
        private void listRegisters()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            // Display accumulator.
            tboxRegA.Text = string.Format("0x{0:X2}", core1.regA);

            // Display register pair B-C.
            tboxRegB.Text = string.Format("0x{0:X2}", core1.regB);
            tboxRegC.Text = string.Format("0x{0:X2}", core1.regC);

            // Display register pair D-E.
            tboxRegD.Text = string.Format("0x{0:X2}", core1.regD);
            tboxRegE.Text = string.Format("0x{0:X2}", core1.regE);

            // Display register pair H-L.
            tboxRegH.Text = string.Format("0x{0:X2}", core1.regH);
            tboxRegL.Text = string.Format("0x{0:X2}", core1.regL);

            // Display registers stack pointer and program counter.
            tboxRegSP.Text = string.Format("0x{0:X4}", core1.regSP);
            tboxRegPC.Text = string.Format("0x{0:X4}", core1.regPC);

            // Display instruction register and temporary register.
            tboxRegIN.Text = string.Format("0x{0:X2}", core1.regIN);
            tboxRegTM.Text = string.Format("0x{0:X2}", core1.regTM);

            // Display status register.
            tboxRegST.Text = string.Format("0x{0:X2}", core1.regFL);
            tboxStatZ.Text = core1.flag_Z.ToString();
            tboxStatS.Text = core1.flag_S.ToString();
            tboxStatP.Text = core1.flag_P.ToString();
            tboxStatCY.Text = core1.flag_CY.ToString();
            tboxStatAC.Text = core1.flag_AC.ToString();

            sw.Stop();
            File.AppendAllText("performance.out","listRegisters: " 
                + sw.ElapsedMilliseconds.ToString() + "\n");
        }

        private void Simulator_Load(object sender, EventArgs e)
        {
            // Display the data in the registers.
            listRegisters();

            // Display the memory header.
            listMemoryHeader();

            // Display the data in the memory.
            listMemory();
        }

        private void btnRunCmd_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tboxCmd.Text);

            /*
            rtbCmdWin.SelectionStart = 0;
            rtbCmdWin.SelectionLength = rtbCmdWin.Width;
            if(cmdLineNo % 2 == 0)
            {
                rtbCmdWin.SelectionBackColor = Color.PaleGreen;
            }
            else
            {
                rtbCmdWin.SelectionBackColor = Color.PowderBlue;
            }
            */

            rtbCmdWin.AppendText(sb.ToString());
            tboxCmd.Clear();

            // Parse the instruction.
            try
            {
                string[] words = sb.ToString().Trim('\r','\n').Split(' ');

                // Single-byte instruction.
                if (words.Length == 1)
                {
                    core1.regIN = Convert.ToByte(words[0].ToString(), 16);
                }
                // Two-byte instruction.
                else if(words.Length == 2)
                {
                    core1.regIN = Convert.ToByte(words[0].ToString(), 16);
                    core1.d1 = Convert.ToByte(words[1].ToString(), 16);
                }
                // Three-byte instruction.
                else if(words.Length == 3)
                {
                    core1.regIN = Convert.ToByte(words[0].ToString(), 16);
                    core1.d1 = Convert.ToByte(words[1].ToString(), 16);
                    core1.d2 = Convert.ToByte(words[2].ToString(), 16);
                }

                //core1.regIN = Convert.ToByte(sb.ToString().TrimEnd('\r', '\n'), 16);
                core1.decode();
            }
            catch (Exception ex)
            {
                // Perform error handling.
            }
            
            // Update the register debug info.
            listRegisters();
            // Update the memory debug info.
            memoryRTB.Clear();
            listMemory();

            //cmdLineNo++;
        }
    }
}
