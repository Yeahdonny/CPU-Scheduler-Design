namespace Schd
{
    partial class Scheduling
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFile = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TRTime = new System.Windows.Forms.Label();
            this.avgRT = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fCFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sJF비선점ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비선점ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선점ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.resTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(11, 786);
            this.OpenFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(86, 29);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "OpenFile";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(103, 786);
            this.Run.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(86, 29);
            this.Run.TabIndex = 1;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(27, 628);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 129);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 55);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(632, 174);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "입력";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "출력";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(27, 269);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(632, 238);
            this.dataGridView2.TabIndex = 7;
            // 
            // TRTime
            // 
            this.TRTime.AutoSize = true;
            this.TRTime.Location = new System.Drawing.Point(27, 545);
            this.TRTime.Name = "TRTime";
            this.TRTime.Size = new System.Drawing.Size(112, 15);
            this.TRTime.TabIndex = 8;
            this.TRTime.Text = "전체 실행시간 :";
            // 
            // avgRT
            // 
            this.avgRT.AutoSize = true;
            this.avgRT.Location = new System.Drawing.Point(27, 573);
            this.avgRT.Name = "avgRT";
            this.avgRT.Size = new System.Drawing.Size(112, 15);
            this.avgRT.TabIndex = 9;
            this.avgRT.Text = "평균 대기시간 :";
            this.avgRT.Click += new System.EventHandler(this.avgRT_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fCFSToolStripMenuItem,
            this.sJF비선점ToolStripMenuItem,
            this.priorityToolStripMenuItem,
            this.rRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(690, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fCFSToolStripMenuItem
            // 
            this.fCFSToolStripMenuItem.Name = "fCFSToolStripMenuItem";
            this.fCFSToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fCFSToolStripMenuItem.Text = "FCFS";
            this.fCFSToolStripMenuItem.Click += new System.EventHandler(this.fCFSToolStripMenuItem_Click);
            // 
            // sJF비선점ToolStripMenuItem
            // 
            this.sJF비선점ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.비선점ToolStripMenuItem,
            this.선점ToolStripMenuItem});
            this.sJF비선점ToolStripMenuItem.Name = "sJF비선점ToolStripMenuItem";
            this.sJF비선점ToolStripMenuItem.Size = new System.Drawing.Size(41, 24);
            this.sJF비선점ToolStripMenuItem.Text = "SJF";
            this.sJF비선점ToolStripMenuItem.Click += new System.EventHandler(this.sJF비선점ToolStripMenuItem_Click);
            // 
            // 비선점ToolStripMenuItem
            // 
            this.비선점ToolStripMenuItem.Name = "비선점ToolStripMenuItem";
            this.비선점ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.비선점ToolStripMenuItem.Text = "비선점";
            this.비선점ToolStripMenuItem.Click += new System.EventHandler(this.비선점ToolStripMenuItem_Click);
            // 
            // 선점ToolStripMenuItem
            // 
            this.선점ToolStripMenuItem.Name = "선점ToolStripMenuItem";
            this.선점ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.선점ToolStripMenuItem.Text = "선점";
            this.선점ToolStripMenuItem.Click += new System.EventHandler(this.선점ToolStripMenuItem_Click);
            // 
            // priorityToolStripMenuItem
            // 
            this.priorityToolStripMenuItem.Name = "priorityToolStripMenuItem";
            this.priorityToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.priorityToolStripMenuItem.Text = "Priority";
            this.priorityToolStripMenuItem.Click += new System.EventHandler(this.priorityToolStripMenuItem_Click);
            // 
            // rRToolStripMenuItem
            // 
            this.rRToolStripMenuItem.Name = "rRToolStripMenuItem";
            this.rRToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.rRToolStripMenuItem.Text = "RR";
            this.rRToolStripMenuItem.Click += new System.EventHandler(this.rRToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "<<Scheduling>>";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(495, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(388, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Time Quantum";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 785);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // resTime
            // 
            this.resTime.AutoSize = true;
            this.resTime.Location = new System.Drawing.Point(27, 598);
            this.resTime.Name = "resTime";
            this.resTime.Size = new System.Drawing.Size(112, 15);
            this.resTime.TabIndex = 16;
            this.resTime.Text = "평균 응답시간 :";
            this.resTime.Click += new System.EventHandler(this.label5_Click);
            // 
            // Scheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 827);
            this.Controls.Add(this.resTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.avgRT);
            this.Controls.Add(this.TRTime);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Scheduling";
            this.Text = "Scheduling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label TRTime;
        private System.Windows.Forms.Label avgRT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sJF비선점ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 비선점ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선점ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priorityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rRToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem fCFSToolStripMenuItem;
        private System.Windows.Forms.Label resTime;
    }
}

