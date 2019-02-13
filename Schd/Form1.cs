using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Schd
{
    public partial class Scheduling : Form
    {
        string[] readText;
        private bool readFile = false;
        List<Process> pList, pView;
        List<Result> resultList;
        int timeQuantum;
        int menuCheck;
 
        public Scheduling()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            pView.Clear();
            pList.Clear();

            //파일 오픈
            string path = SelectFilePath();
            if (path == null) return;

            readText = File.ReadAllLines(path);

            //토큰 분리
            for (int i = 0; i < readText.Length; i++)
            {
                string[] token = readText[i].Split(' ');
                Process p = new Process(int.Parse(token[1]), int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4]));
                pList.Add(p);
            }

            //Grid에 process 출력
            dataGridView1.Rows.Clear();
            string[] row = { "", "", "", "" };
            foreach (Process p in pList)
            {
                row[0] = p.processID.ToString();
                row[1] = p.arriveTime.ToString();
                row[2] = p.burstTime.ToString();
                row[3] = p.priority.ToString();

                dataGridView1.Rows.Add(row);
            }

            //arriveTime으로 정렬
          
            pList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else
                {
                    return x.processID.CompareTo(y.processID);
                }
                //return x.arriveTime.CompareTo(y.arriveTime);
            });
             
            
            readFile = true;
        }
        
        private string SelectFilePath()
        {
            openFileDialog1.Filter = "텍스트파일|*.txt";
            return (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : null;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (!readFile) return;

            if (menuCheck == 1) { resultList = FCFS.Run(pList, resultList); }
            else if (menuCheck == 2) { resultList = Non_Preemptive_SJF.Run(pList, resultList); }
            else if (menuCheck == 3) { resultList = Preemptive_SJF.Run(pList, resultList); }
            else if (menuCheck == 4) { resultList = Non_Preemptive_Priority.Run(pList, resultList); }
            else if (menuCheck == 5) { resultList = RR.Run(pList, resultList, timeQuantum); }

            //결과출력
            dataGridView2.Rows.Clear();



            //값을 받아 왔다 확인해주는 값;
            //값을 집어넣어두는 곳
            if (menuCheck == 3 || menuCheck == 5)
            {
                int[] turnaround = new int[resultList.Count + 1];
                int[] time = new int[resultList.Count + 1];
                for (int t = 0; t < resultList.Count; t++) turnaround[t] = -1;

                for (int t = resultList.Count - 1; t >= 0; t--)
                {
                    if (turnaround[resultList[t].processID] == -1)
                    {
                        turnaround[resultList[t].processID] = resultList[t].turnaroundTime;
                    }
                    else continue;
                }
                for (int t = 0; t < resultList.Count; t++)
                {
                    int tt;
                    for (tt = 0; tt != resultList[t].processID; tt++) ;
                    resultList[t].turnaroundTime = turnaround[tt];

                }
            }
            string[] row = { "", "", "", "","" };

            double waitingTime = 0.0;
            foreach (Result r in resultList)
            {
                row[0] = r.processID.ToString();
                row[1] = r.burstTime.ToString();
                row[2] = r.waitingTime.ToString();
                waitingTime += r.waitingTime;
                row[3] = r.responseTime.ToString();
                row[4] = r.turnaroundTime.ToString();
                dataGridView2.Rows.Add(row);
            }
            //////////////
            double avercount = 0.0;
            int[] j = new int[resultList.Count + 1];

            for (int i = 0; i < resultList.Count; i++)
            {
                j[resultList[i].processID] = -1;
            }
            for (int l = 0; l <= resultList.Count; l++)    
            {
                if (j[l] == -1)
                    ++avercount;
            }


            double responseTime = 0.0;          

            for (int i = 0; i < resultList.Count; i++)
            {
                responseTime += resultList[i].responseTime;
            }
            /////////////////
            TRTime.Text = "전체 실행시간: " + (resultList[resultList.Count - 1].startP + resultList[resultList.Count - 1].burstTime).ToString();
            avgRT.Text = "평균 대기시간: " + (waitingTime / avercount).ToString();//원래 resultList.Count
            resTime.Text = "평균 응답시간: " + (responseTime / avercount).ToString();
            panel1.Invalidate();
            
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int startPosition = 10;
            double waitingTime = 0.0;

            int resultListPosition = 0;
          
                foreach (Result r in resultList)
                {
                    e.Graphics.DrawString("p" + r.processID.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition);
                    e.Graphics.DrawRectangle(Pens.Red, startPosition + (r.startP * 10), resultListPosition + 20, r.burstTime * 10, 30);
                    e.Graphics.DrawString(r.burstTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition + 60);
                    e.Graphics.DrawString(r.waitingTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition + 80);
                    waitingTime += (double)r.waitingTime;

                }
            
           
        }

        private void sJF비선점ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void fCFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuCheck = 1;
            label3.Text = "<<FCFS>>";
        }

        private void 비선점ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            menuCheck = 2;
            label3.Text = "<<SJF비선점>>";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           timeQuantum = Convert.ToInt32(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void 선점ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            menuCheck = 3;
            label3.Text = "<<SJF선점>>";
           
        }

        private void priorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuCheck = 4;
            label3.Text = "<<Priority비선점>>";
        }

        private void rRToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            menuCheck = 5;
            label3.Text = "<<RR>>";
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            panel1.Controls.Clear();
            resultList.Clear();
            panel1.Invalidate();
            menuCheck = 0;
            TRTime.Text = "전체 실행시간: ";
            avgRT.Text = "평균 대기시간: ";
            resTime.Text = "평균 응답시간: ";
            label3.Text = "<<Scheduling>>";
            textBox1.Text = "";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void avgRT_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pList = new List<Process>();
            pView = new List<Process>();
            resultList = new List<Result>();

            //입력창
            DataGridViewTextBoxColumn processColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn arriveTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn burstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn priorityColumn = new DataGridViewTextBoxColumn();

            processColumn.HeaderText = "프로세스";
            processColumn.Name = "process";
            arriveTimeColumn.HeaderText = "도착시간";
            arriveTimeColumn.Name = "arriveTime";
            burstTimeColumn.HeaderText = "실행시간";
            burstTimeColumn.Name = "burstTime";
            priorityColumn.HeaderText = "우선순위";
            priorityColumn.Name = "priority";

            dataGridView1.Columns.Add(processColumn);
            dataGridView1.Columns.Add(arriveTimeColumn);
            dataGridView1.Columns.Add(burstTimeColumn);
            dataGridView1.Columns.Add(priorityColumn);


            //결과창
            DataGridViewTextBoxColumn resultProcessColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultBurstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultWaitingTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultResponseTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultTurnaroundTimeColumn = new DataGridViewTextBoxColumn();

            resultProcessColumn.HeaderText = "프로세스";
            resultProcessColumn.Name = "process";
            resultBurstTimeColumn.HeaderText = "실행시간";
            resultBurstTimeColumn.Name = "resultBurstTimeColumn";
            resultWaitingTimeColumn.HeaderText = "대기시간";
            resultWaitingTimeColumn.Name = "waitingTime";

            //
            resultResponseTimeColumn.HeaderText = "응답시간";
            resultResponseTimeColumn.Name = "responseTime";
            resultTurnaroundTimeColumn.HeaderText = "Process별 실행시간";
            resultTurnaroundTimeColumn.Name = "turnaroundTime";
            //
            

            dataGridView2.Columns.Add(resultProcessColumn);
            dataGridView2.Columns.Add(resultBurstTimeColumn);
            dataGridView2.Columns.Add(resultWaitingTimeColumn);
            dataGridView2.Columns.Add(resultResponseTimeColumn);
            dataGridView2.Columns.Add(resultTurnaroundTimeColumn);
        }
    }
}
