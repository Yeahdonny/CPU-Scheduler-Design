using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Schd
{
    class ReadyQueueElement
    {
        public int processID;
        public int burstTime;
        public int waitingTime;
        public int arriveTime;
        public int priority;
        public int responseCheck;
        public int responseTime;
        public int SchedulingcpuTime = 0;
        public int turnaroundTime;
        // public int timeQuantum;

        public ReadyQueueElement(int processID, int burstTime, int waitingTime, int priority, int arriveTime, int responseCheck, int responseTime)
        {
            this.processID = processID;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
            this.priority = priority;
            this.arriveTime = arriveTime;
            this.responseCheck = responseCheck;
            this.responseTime = responseTime;
        }
       
    }
    /// <summary>
    /// ///////////////////////////////////////////
    /// </summary>
    class FCFS
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;

            int runTime = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                        jobList.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }

                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);                                                         
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime, runTime - rq.arriveTime, rq.burstTime+rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);

                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                {
                    readyQueue.ElementAt(i).waitingTime++;
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
    /// <summary>
    /// //////////////////////////////
    /// </summary>
    class Non_Preemptive_SJF
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;

            int runTime = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        if (readyQueue.Count != 0)
                        {
                            int i;
                            for (i = 0; i < readyQueue.Count; i++)
                            {
                                if (readyQueue[i].burstTime > frontJob.burstTime)
                                    break;
                                else continue;

                            }

                            readyQueue.Insert(i, new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }

                        else
                        {
                            readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);

                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime, runTime - rq.arriveTime, rq.burstTime + rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);

                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                {
                    readyQueue.ElementAt(i).waitingTime++;
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Preemptive_SJF
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;        //compare로 바꿀까?!바꿔라!
            int runTime = 0;
            
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == cpuTime)
                    {

                        if (readyQueue.Count != 0)//runtime!=0해야할까?
                        {
                            int i;
                            for (i = 0; i < readyQueue.Count; i++)
                            {
                                if (readyQueue[i].SchedulingcpuTime > frontJob.burstTime|| readyQueue[i].SchedulingcpuTime == frontJob.burstTime)
                                    continue;
                                else break;

                            }
                            readyQueue.Insert(i, new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            readyQueue[i].SchedulingcpuTime = frontJob.burstTime;
                            jobList.RemoveAt(0);
                        }

                        else
                        {
                            readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            readyQueue[0].SchedulingcpuTime = frontJob.burstTime;
                            jobList.RemoveAt(0);

                        }
                    }
                    else
                    {
                        break;
                    }
                }

                currentProcess = readyQueue.Count - 1;
  
                if ((readyQueue[currentProcess].SchedulingcpuTime-- == 0))                  //그냥 시간 다 보냈을 경우
                {
                    
                    if (readyQueue.ElementAt(currentProcess).responseCheck == 0)
                    {
                        readyQueue.ElementAt(currentProcess).responseTime = runTime - readyQueue.ElementAt(currentProcess).arriveTime;
                        readyQueue.ElementAt(currentProcess).responseCheck = -1;
                        readyQueue.ElementAt(currentProcess).turnaroundTime = readyQueue.ElementAt(currentProcess).burstTime;

                    }
                    ReadyQueueElement rq = readyQueue.ElementAt(currentProcess);

                    resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime, rq.responseTime,rq.turnaroundTime+rq.waitingTime));
                    cpuDone = 0;
                    readyQueue.RemoveAt(currentProcess);
                    runTime = cpuTime;
                    continue;
                }
                else if ((currentProcess != cpuDone && readyQueue[currentProcess].processID != readyQueue[cpuDone].processID
                                                       && (readyQueue[cpuDone].burstTime - readyQueue[cpuDone].SchedulingcpuTime != 0)))
                {    //아직 시간 남아있지만 더 적은게 들어와서 넘겨주는 경우

                    if (readyQueue.ElementAt(cpuDone).responseCheck == 0)
                    {
                        readyQueue.ElementAt(cpuDone).responseTime = runTime - readyQueue.ElementAt(cpuDone).arriveTime;
                        readyQueue.ElementAt(cpuDone).responseCheck = -1;
                        readyQueue.ElementAt(cpuDone).turnaroundTime = readyQueue.ElementAt(cpuDone).burstTime;

                    }
                    ReadyQueueElement rq = readyQueue.ElementAt(cpuDone);

                    resultList.Add(new Result(rq.processID, runTime, rq.burstTime - rq.SchedulingcpuTime, rq.waitingTime, rq.responseTime,rq.turnaroundTime+rq.waitingTime));
                    readyQueue[cpuDone].burstTime = readyQueue[cpuDone].SchedulingcpuTime;
                    cpuDone = currentProcess;
                    runTime = cpuTime;
                }
                else
                {
                    cpuDone = currentProcess;
                }
                cpuTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                {
                    if (i == currentProcess || i == cpuDone)
                        continue;
                    else
                        readyQueue.ElementAt(i).waitingTime++;
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////
    
    class RR
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList, int timeQuantum)
        {
            int currentProcess = 0;
            int previousprocess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;
            int check = 0;
            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
               
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        if (readyQueue.Count != 0)
                        {
                            int i;
                            for (i = 0; i < readyQueue.Count; i++)
                            {
                                if (readyQueue.ElementAt(i).responseCheck == -1) break;
                                else continue;
                            }
                            readyQueue.Insert(i, new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }
                        else
                        {
                            readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, 0, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        break;
                    }

                }

                    if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {

                        if (readyQueue.ElementAt(currentProcess).responseCheck == 0)
                        {
                            readyQueue.ElementAt(currentProcess).responseTime = runTime - readyQueue.ElementAt(currentProcess).arriveTime;
                            readyQueue.ElementAt(currentProcess).responseCheck = -1;
                            readyQueue.ElementAt(currentProcess).turnaroundTime = readyQueue.ElementAt(currentProcess).burstTime;
                        }
                        ReadyQueueElement rq = readyQueue.ElementAt(0);
                        if (rq.burstTime > timeQuantum)
                        {
                            resultList.Add(new Result(rq.processID, runTime, timeQuantum, rq.waitingTime, rq.responseTime, rq.turnaroundTime + rq.waitingTime));
                            rq.burstTime -= timeQuantum;
                            cpuDone = timeQuantum;
                          
                          
                            readyQueue.Add(new ReadyQueueElement(rq.processID, rq.burstTime,0, 0, rq.arriveTime, -1,rq.responseTime));
                            readyQueue.ElementAt(readyQueue.Count-1).turnaroundTime = rq.turnaroundTime + rq.waitingTime;
                           
                            check = 1;
                        }
                        else
                        {
                            resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime,rq.responseTime, rq.turnaroundTime + rq.waitingTime));
                            cpuDone = rq.burstTime;
                            check = 0;
                        }
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        previousprocess = rq.processID;
                        readyQueue.RemoveAt(0);

                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {

                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                {
                    if (check == 1 && i == readyQueue.Count - 1)
                        break;
                    if (readyQueue.ElementAt(0).processID != previousprocess)
                        readyQueue.ElementAt(i).waitingTime++;
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
    /// <summary>
    /// //////////////////
    /// </summary>
    //////////////////////////////
    class Non_Preemptive_Priority
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;

            int runTime = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    int ppppp = frontJob.processID;
                    if (frontJob.arriveTime == runTime)
                    {
                        if (readyQueue.Count != 0)
                        {
                            int i;
                            for (i = 0; i < readyQueue.Count; i++)
                            {
                                if (readyQueue[i].priority > frontJob.priority)
                                    break;
                                else continue;

                            }

                            readyQueue.Insert(i, new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, frontJob.priority, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }
                       
                        else
                        {
                            readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, frontJob.priority, frontJob.arriveTime, 0, 0));
                            jobList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);

                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime, runTime - rq.arriveTime, rq.burstTime + rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);

                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                {
                    readyQueue.ElementAt(i).waitingTime++;
                }

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
   
}