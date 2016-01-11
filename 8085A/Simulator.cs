using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void Simulator_Load(object sender, EventArgs e)
        {
            int i, j;
            string mRTB;
            string iVal;

            mRTB = "++++  0x00 0x01 0x02 0x03 0x04 0x05 "
                + "0x06 0x07 0x08 0x09 0x0A 0x0B 0x0C 0x0D 0x0E 0x0F\n";

            for(i = 0; i < 4096; i++)
            {
                iVal = i.ToString();
                for(int l=0; 4 - iVal.Length > 0; l++)
                {
                    iVal = "0" + iVal;
                }

                mRTB += iVal + "  ";

                for (j = 0; j < 16; j++)
                {
                    mRTB += String.Format("0x{0:X2}",core1.memory[16 * i + j]) + " ";
                }

                mRTB += "\n";
            }

            memoryRTB.Text = mRTB;
        }
    }
}
