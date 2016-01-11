using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        // Display the values in memory.
        private void listMemory()
        {
            int i, j;
            StringBuilder mRTB = new StringBuilder();
            string iVal;

            mRTB.Append("++++  0x00 0x01 0x02 0x03 0x04 0x05 0x06 "
                + "0x07 0x08 0x09 0x0A 0x0B 0x0C 0x0D 0x0E 0x0F ");

            memoryRTB.SelectionStart = memoryRTB.TextLength;
            memoryRTB.SelectionLength = 0;
            memoryRTB.SelectionBackColor = Color.LawnGreen;
            memoryRTB.AppendText(mRTB.ToString());
            memoryRTB.SelectionBackColor = Color.SkyBlue;

            mRTB.Clear();

            for (i = 0; i < 4096; i++)
            {
                iVal = i.ToString();
                for (int l = 0; 4 - iVal.Length > 0; l++)
                {
                    iVal = "0" + iVal;
                }

                mRTB.Append(Environment.NewLine + iVal + "  ");

                for (j = 0; j < 16; j++)
                {
                    mRTB.Append(string.Format("0x{0:X2}", core1.memory[16 * i + j]) + " ");
                }

                memoryRTB.SelectionBackColor = Color.SkyBlue;
                memoryRTB.AppendText(mRTB.ToString());
                mRTB.Clear();
            }
        }

        // Display the values in the register.
        private void listRegisters()
        {
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
            tboxRegST.Text = string.Format("0x{0:X2}", core1.regST);
            tboxStatZ.Text = "-";
            tboxStatS.Text = "-";
            tboxStatP.Text = "-";
            tboxStatCY.Text = "-";
            tboxStatAC.Text = "-";
        }

        private void Simulator_Load(object sender, EventArgs e)
        {
            // Display the data in the registers.
            listRegisters();
            //Thread t1 = new Thread(listRegisters);
            //t1.Start();

            // Display the data in the memory.
            listMemory();
            //Thread t2 = new Thread(listMemory);
            //t2.Start();

            //t1.Join();
            //t2.Join();
        }
    }
}
