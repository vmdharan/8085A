namespace _8085A
{
    partial class Simulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registersGB = new System.Windows.Forms.GroupBox();
            this.tboxRegST = new System.Windows.Forms.TextBox();
            this.labelStatReg = new System.Windows.Forms.Label();
            this.tboxStatAC = new System.Windows.Forms.TextBox();
            this.labelStatAC = new System.Windows.Forms.Label();
            this.tboxStatCY = new System.Windows.Forms.TextBox();
            this.labelStatCY = new System.Windows.Forms.Label();
            this.tboxStatP = new System.Windows.Forms.TextBox();
            this.labelStatP = new System.Windows.Forms.Label();
            this.tboxStatS = new System.Windows.Forms.TextBox();
            this.labelStatS = new System.Windows.Forms.Label();
            this.tboxRegTM = new System.Windows.Forms.TextBox();
            this.labelRegTMP = new System.Windows.Forms.Label();
            this.tboxStatZ = new System.Windows.Forms.TextBox();
            this.tboxRegC = new System.Windows.Forms.TextBox();
            this.tboxRegPC = new System.Windows.Forms.TextBox();
            this.labelStatZ = new System.Windows.Forms.Label();
            this.labelRegPC = new System.Windows.Forms.Label();
            this.tboxRegSP = new System.Windows.Forms.TextBox();
            this.labelRegSP = new System.Windows.Forms.Label();
            this.tboxRegIN = new System.Windows.Forms.TextBox();
            this.labelRegIN = new System.Windows.Forms.Label();
            this.tboxRegL = new System.Windows.Forms.TextBox();
            this.labelRegL = new System.Windows.Forms.Label();
            this.tboxRegH = new System.Windows.Forms.TextBox();
            this.labelRegH = new System.Windows.Forms.Label();
            this.tboxRegE = new System.Windows.Forms.TextBox();
            this.labelRegE = new System.Windows.Forms.Label();
            this.labelRegC = new System.Windows.Forms.Label();
            this.tboxRegD = new System.Windows.Forms.TextBox();
            this.labelRegD = new System.Windows.Forms.Label();
            this.tboxRegB = new System.Windows.Forms.TextBox();
            this.labelRegB = new System.Windows.Forms.Label();
            this.tboxRegA = new System.Windows.Forms.TextBox();
            this.labelRegA = new System.Windows.Forms.Label();
            this.memoryGB = new System.Windows.Forms.GroupBox();
            this.memoryRTB = new System.Windows.Forms.RichTextBox();
            this.registersGB.SuspendLayout();
            this.memoryGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // registersGB
            // 
            this.registersGB.Controls.Add(this.tboxRegST);
            this.registersGB.Controls.Add(this.labelStatReg);
            this.registersGB.Controls.Add(this.tboxStatAC);
            this.registersGB.Controls.Add(this.labelStatAC);
            this.registersGB.Controls.Add(this.tboxStatCY);
            this.registersGB.Controls.Add(this.labelStatCY);
            this.registersGB.Controls.Add(this.tboxStatP);
            this.registersGB.Controls.Add(this.labelStatP);
            this.registersGB.Controls.Add(this.tboxStatS);
            this.registersGB.Controls.Add(this.labelStatS);
            this.registersGB.Controls.Add(this.tboxRegTM);
            this.registersGB.Controls.Add(this.labelRegTMP);
            this.registersGB.Controls.Add(this.tboxStatZ);
            this.registersGB.Controls.Add(this.tboxRegC);
            this.registersGB.Controls.Add(this.tboxRegPC);
            this.registersGB.Controls.Add(this.labelStatZ);
            this.registersGB.Controls.Add(this.labelRegPC);
            this.registersGB.Controls.Add(this.tboxRegSP);
            this.registersGB.Controls.Add(this.labelRegSP);
            this.registersGB.Controls.Add(this.tboxRegIN);
            this.registersGB.Controls.Add(this.labelRegIN);
            this.registersGB.Controls.Add(this.tboxRegL);
            this.registersGB.Controls.Add(this.labelRegL);
            this.registersGB.Controls.Add(this.tboxRegH);
            this.registersGB.Controls.Add(this.labelRegH);
            this.registersGB.Controls.Add(this.tboxRegE);
            this.registersGB.Controls.Add(this.labelRegE);
            this.registersGB.Controls.Add(this.labelRegC);
            this.registersGB.Controls.Add(this.tboxRegD);
            this.registersGB.Controls.Add(this.labelRegD);
            this.registersGB.Controls.Add(this.tboxRegB);
            this.registersGB.Controls.Add(this.labelRegB);
            this.registersGB.Controls.Add(this.tboxRegA);
            this.registersGB.Controls.Add(this.labelRegA);
            this.registersGB.Location = new System.Drawing.Point(13, 12);
            this.registersGB.Name = "registersGB";
            this.registersGB.Size = new System.Drawing.Size(213, 293);
            this.registersGB.TabIndex = 0;
            this.registersGB.TabStop = false;
            this.registersGB.Text = "Registers";
            // 
            // tboxRegST
            // 
            this.tboxRegST.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxRegST.Location = new System.Drawing.Point(30, 217);
            this.tboxRegST.Name = "tboxRegST";
            this.tboxRegST.ReadOnly = true;
            this.tboxRegST.Size = new System.Drawing.Size(65, 20);
            this.tboxRegST.TabIndex = 34;
            // 
            // labelStatReg
            // 
            this.labelStatReg.AutoSize = true;
            this.labelStatReg.Location = new System.Drawing.Point(5, 220);
            this.labelStatReg.Name = "labelStatReg";
            this.labelStatReg.Size = new System.Drawing.Size(24, 13);
            this.labelStatReg.TabIndex = 33;
            this.labelStatReg.Text = "ST:";
            // 
            // tboxStatAC
            // 
            this.tboxStatAC.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxStatAC.Location = new System.Drawing.Point(152, 267);
            this.tboxStatAC.Name = "tboxStatAC";
            this.tboxStatAC.ReadOnly = true;
            this.tboxStatAC.Size = new System.Drawing.Size(20, 20);
            this.tboxStatAC.TabIndex = 32;
            // 
            // labelStatAC
            // 
            this.labelStatAC.AutoSize = true;
            this.labelStatAC.Location = new System.Drawing.Point(151, 251);
            this.labelStatAC.Name = "labelStatAC";
            this.labelStatAC.Size = new System.Drawing.Size(21, 13);
            this.labelStatAC.TabIndex = 31;
            this.labelStatAC.Text = "AC";
            // 
            // tboxStatCY
            // 
            this.tboxStatCY.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxStatCY.Location = new System.Drawing.Point(126, 267);
            this.tboxStatCY.Name = "tboxStatCY";
            this.tboxStatCY.ReadOnly = true;
            this.tboxStatCY.Size = new System.Drawing.Size(20, 20);
            this.tboxStatCY.TabIndex = 30;
            // 
            // labelStatCY
            // 
            this.labelStatCY.AutoSize = true;
            this.labelStatCY.Location = new System.Drawing.Point(125, 251);
            this.labelStatCY.Name = "labelStatCY";
            this.labelStatCY.Size = new System.Drawing.Size(21, 13);
            this.labelStatCY.TabIndex = 29;
            this.labelStatCY.Text = "CY";
            // 
            // tboxStatP
            // 
            this.tboxStatP.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxStatP.Location = new System.Drawing.Point(101, 267);
            this.tboxStatP.Name = "tboxStatP";
            this.tboxStatP.ReadOnly = true;
            this.tboxStatP.Size = new System.Drawing.Size(20, 20);
            this.tboxStatP.TabIndex = 28;
            // 
            // labelStatP
            // 
            this.labelStatP.AutoSize = true;
            this.labelStatP.Location = new System.Drawing.Point(105, 251);
            this.labelStatP.Name = "labelStatP";
            this.labelStatP.Size = new System.Drawing.Size(14, 13);
            this.labelStatP.TabIndex = 27;
            this.labelStatP.Text = "P";
            // 
            // tboxStatS
            // 
            this.tboxStatS.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxStatS.Location = new System.Drawing.Point(75, 267);
            this.tboxStatS.Name = "tboxStatS";
            this.tboxStatS.ReadOnly = true;
            this.tboxStatS.Size = new System.Drawing.Size(20, 20);
            this.tboxStatS.TabIndex = 26;
            // 
            // labelStatS
            // 
            this.labelStatS.AutoSize = true;
            this.labelStatS.Location = new System.Drawing.Point(79, 251);
            this.labelStatS.Name = "labelStatS";
            this.labelStatS.Size = new System.Drawing.Size(14, 13);
            this.labelStatS.TabIndex = 25;
            this.labelStatS.Text = "S";
            // 
            // tboxRegTM
            // 
            this.tboxRegTM.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxRegTM.Location = new System.Drawing.Point(128, 176);
            this.tboxRegTM.Name = "tboxRegTM";
            this.tboxRegTM.ReadOnly = true;
            this.tboxRegTM.Size = new System.Drawing.Size(65, 20);
            this.tboxRegTM.TabIndex = 24;
            // 
            // labelRegTMP
            // 
            this.labelRegTMP.AutoSize = true;
            this.labelRegTMP.Location = new System.Drawing.Point(101, 179);
            this.labelRegTMP.Name = "labelRegTMP";
            this.labelRegTMP.Size = new System.Drawing.Size(26, 13);
            this.labelRegTMP.TabIndex = 23;
            this.labelRegTMP.Text = "TM:";
            // 
            // tboxStatZ
            // 
            this.tboxStatZ.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxStatZ.Location = new System.Drawing.Point(49, 267);
            this.tboxStatZ.Name = "tboxStatZ";
            this.tboxStatZ.ReadOnly = true;
            this.tboxStatZ.Size = new System.Drawing.Size(20, 20);
            this.tboxStatZ.TabIndex = 17;
            // 
            // tboxRegC
            // 
            this.tboxRegC.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegC.Location = new System.Drawing.Point(128, 45);
            this.tboxRegC.Name = "tboxRegC";
            this.tboxRegC.ReadOnly = true;
            this.tboxRegC.Size = new System.Drawing.Size(65, 20);
            this.tboxRegC.TabIndex = 22;
            // 
            // tboxRegPC
            // 
            this.tboxRegPC.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxRegPC.Location = new System.Drawing.Point(128, 138);
            this.tboxRegPC.Name = "tboxRegPC";
            this.tboxRegPC.ReadOnly = true;
            this.tboxRegPC.Size = new System.Drawing.Size(65, 20);
            this.tboxRegPC.TabIndex = 19;
            // 
            // labelStatZ
            // 
            this.labelStatZ.AutoSize = true;
            this.labelStatZ.Location = new System.Drawing.Point(53, 251);
            this.labelStatZ.Name = "labelStatZ";
            this.labelStatZ.Size = new System.Drawing.Size(14, 13);
            this.labelStatZ.TabIndex = 16;
            this.labelStatZ.Text = "Z";
            // 
            // labelRegPC
            // 
            this.labelRegPC.AutoSize = true;
            this.labelRegPC.Location = new System.Drawing.Point(103, 141);
            this.labelRegPC.Name = "labelRegPC";
            this.labelRegPC.Size = new System.Drawing.Size(24, 13);
            this.labelRegPC.TabIndex = 18;
            this.labelRegPC.Text = "PC:";
            // 
            // tboxRegSP
            // 
            this.tboxRegSP.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxRegSP.Location = new System.Drawing.Point(30, 138);
            this.tboxRegSP.Name = "tboxRegSP";
            this.tboxRegSP.ReadOnly = true;
            this.tboxRegSP.Size = new System.Drawing.Size(65, 20);
            this.tboxRegSP.TabIndex = 15;
            // 
            // labelRegSP
            // 
            this.labelRegSP.AutoSize = true;
            this.labelRegSP.Location = new System.Drawing.Point(5, 141);
            this.labelRegSP.Name = "labelRegSP";
            this.labelRegSP.Size = new System.Drawing.Size(24, 13);
            this.labelRegSP.TabIndex = 14;
            this.labelRegSP.Text = "SP:";
            // 
            // tboxRegIN
            // 
            this.tboxRegIN.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tboxRegIN.Location = new System.Drawing.Point(30, 176);
            this.tboxRegIN.Name = "tboxRegIN";
            this.tboxRegIN.ReadOnly = true;
            this.tboxRegIN.Size = new System.Drawing.Size(65, 20);
            this.tboxRegIN.TabIndex = 3;
            // 
            // labelRegIN
            // 
            this.labelRegIN.AutoSize = true;
            this.labelRegIN.Location = new System.Drawing.Point(6, 179);
            this.labelRegIN.Name = "labelRegIN";
            this.labelRegIN.Size = new System.Drawing.Size(21, 13);
            this.labelRegIN.TabIndex = 2;
            this.labelRegIN.Text = "IN:";
            // 
            // tboxRegL
            // 
            this.tboxRegL.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegL.Location = new System.Drawing.Point(128, 97);
            this.tboxRegL.Name = "tboxRegL";
            this.tboxRegL.ReadOnly = true;
            this.tboxRegL.Size = new System.Drawing.Size(65, 20);
            this.tboxRegL.TabIndex = 13;
            // 
            // labelRegL
            // 
            this.labelRegL.AutoSize = true;
            this.labelRegL.Location = new System.Drawing.Point(103, 100);
            this.labelRegL.Name = "labelRegL";
            this.labelRegL.Size = new System.Drawing.Size(16, 13);
            this.labelRegL.TabIndex = 12;
            this.labelRegL.Text = "L:";
            // 
            // tboxRegH
            // 
            this.tboxRegH.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegH.Location = new System.Drawing.Point(30, 97);
            this.tboxRegH.Name = "tboxRegH";
            this.tboxRegH.ReadOnly = true;
            this.tboxRegH.Size = new System.Drawing.Size(65, 20);
            this.tboxRegH.TabIndex = 11;
            // 
            // labelRegH
            // 
            this.labelRegH.AutoSize = true;
            this.labelRegH.Location = new System.Drawing.Point(5, 100);
            this.labelRegH.Name = "labelRegH";
            this.labelRegH.Size = new System.Drawing.Size(18, 13);
            this.labelRegH.TabIndex = 10;
            this.labelRegH.Text = "H:";
            // 
            // tboxRegE
            // 
            this.tboxRegE.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegE.Location = new System.Drawing.Point(128, 71);
            this.tboxRegE.Name = "tboxRegE";
            this.tboxRegE.ReadOnly = true;
            this.tboxRegE.Size = new System.Drawing.Size(65, 20);
            this.tboxRegE.TabIndex = 9;
            // 
            // labelRegE
            // 
            this.labelRegE.AutoSize = true;
            this.labelRegE.Location = new System.Drawing.Point(103, 74);
            this.labelRegE.Name = "labelRegE";
            this.labelRegE.Size = new System.Drawing.Size(17, 13);
            this.labelRegE.TabIndex = 8;
            this.labelRegE.Text = "E:";
            // 
            // labelRegC
            // 
            this.labelRegC.AutoSize = true;
            this.labelRegC.Location = new System.Drawing.Point(104, 48);
            this.labelRegC.Name = "labelRegC";
            this.labelRegC.Size = new System.Drawing.Size(17, 13);
            this.labelRegC.TabIndex = 6;
            this.labelRegC.Text = "C:";
            // 
            // tboxRegD
            // 
            this.tboxRegD.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegD.Location = new System.Drawing.Point(30, 71);
            this.tboxRegD.Name = "tboxRegD";
            this.tboxRegD.ReadOnly = true;
            this.tboxRegD.Size = new System.Drawing.Size(65, 20);
            this.tboxRegD.TabIndex = 5;
            // 
            // labelRegD
            // 
            this.labelRegD.AutoSize = true;
            this.labelRegD.Location = new System.Drawing.Point(5, 74);
            this.labelRegD.Name = "labelRegD";
            this.labelRegD.Size = new System.Drawing.Size(18, 13);
            this.labelRegD.TabIndex = 4;
            this.labelRegD.Text = "D:";
            // 
            // tboxRegB
            // 
            this.tboxRegB.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegB.Location = new System.Drawing.Point(30, 45);
            this.tboxRegB.Name = "tboxRegB";
            this.tboxRegB.ReadOnly = true;
            this.tboxRegB.Size = new System.Drawing.Size(65, 20);
            this.tboxRegB.TabIndex = 3;
            // 
            // labelRegB
            // 
            this.labelRegB.AutoSize = true;
            this.labelRegB.Location = new System.Drawing.Point(6, 48);
            this.labelRegB.Name = "labelRegB";
            this.labelRegB.Size = new System.Drawing.Size(17, 13);
            this.labelRegB.TabIndex = 2;
            this.labelRegB.Text = "B:";
            // 
            // tboxRegA
            // 
            this.tboxRegA.BackColor = System.Drawing.Color.PaleGreen;
            this.tboxRegA.Location = new System.Drawing.Point(30, 20);
            this.tboxRegA.Name = "tboxRegA";
            this.tboxRegA.ReadOnly = true;
            this.tboxRegA.Size = new System.Drawing.Size(65, 20);
            this.tboxRegA.TabIndex = 1;
            // 
            // labelRegA
            // 
            this.labelRegA.AutoSize = true;
            this.labelRegA.Location = new System.Drawing.Point(6, 23);
            this.labelRegA.Name = "labelRegA";
            this.labelRegA.Size = new System.Drawing.Size(17, 13);
            this.labelRegA.TabIndex = 0;
            this.labelRegA.Text = "A:";
            // 
            // memoryGB
            // 
            this.memoryGB.Controls.Add(this.memoryRTB);
            this.memoryGB.Location = new System.Drawing.Point(232, 12);
            this.memoryGB.Name = "memoryGB";
            this.memoryGB.Size = new System.Drawing.Size(553, 293);
            this.memoryGB.TabIndex = 1;
            this.memoryGB.TabStop = false;
            this.memoryGB.Text = "Memory";
            // 
            // memoryRTB
            // 
            this.memoryRTB.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryRTB.Location = new System.Drawing.Point(7, 23);
            this.memoryRTB.Name = "memoryRTB";
            this.memoryRTB.ReadOnly = true;
            this.memoryRTB.Size = new System.Drawing.Size(540, 264);
            this.memoryRTB.TabIndex = 0;
            this.memoryRTB.Text = "";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 313);
            this.Controls.Add(this.memoryGB);
            this.Controls.Add(this.registersGB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Simulator";
            this.Text = "8085A";
            this.Load += new System.EventHandler(this.Simulator_Load);
            this.registersGB.ResumeLayout(false);
            this.registersGB.PerformLayout();
            this.memoryGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox registersGB;
        private System.Windows.Forms.TextBox tboxRegPC;
        private System.Windows.Forms.Label labelRegPC;
        private System.Windows.Forms.TextBox tboxStatZ;
        private System.Windows.Forms.Label labelStatZ;
        private System.Windows.Forms.TextBox tboxRegSP;
        private System.Windows.Forms.Label labelRegSP;
        private System.Windows.Forms.TextBox tboxRegIN;
        private System.Windows.Forms.Label labelRegIN;
        private System.Windows.Forms.TextBox tboxRegL;
        private System.Windows.Forms.Label labelRegL;
        private System.Windows.Forms.TextBox tboxRegH;
        private System.Windows.Forms.Label labelRegH;
        private System.Windows.Forms.TextBox tboxRegE;
        private System.Windows.Forms.Label labelRegE;
        private System.Windows.Forms.Label labelRegC;
        private System.Windows.Forms.TextBox tboxRegD;
        private System.Windows.Forms.Label labelRegD;
        private System.Windows.Forms.TextBox tboxRegB;
        private System.Windows.Forms.Label labelRegB;
        private System.Windows.Forms.TextBox tboxRegA;
        private System.Windows.Forms.Label labelRegA;
        private System.Windows.Forms.TextBox tboxRegTM;
        private System.Windows.Forms.Label labelRegTMP;
        private System.Windows.Forms.TextBox tboxRegC;
        private System.Windows.Forms.TextBox tboxRegST;
        private System.Windows.Forms.Label labelStatReg;
        private System.Windows.Forms.TextBox tboxStatAC;
        private System.Windows.Forms.Label labelStatAC;
        private System.Windows.Forms.TextBox tboxStatCY;
        private System.Windows.Forms.Label labelStatCY;
        private System.Windows.Forms.TextBox tboxStatP;
        private System.Windows.Forms.Label labelStatP;
        private System.Windows.Forms.TextBox tboxStatS;
        private System.Windows.Forms.Label labelStatS;
        private System.Windows.Forms.GroupBox memoryGB;
        private System.Windows.Forms.RichTextBox memoryRTB;
    }
}

