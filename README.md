# CPU-Scheduler-Design
프로세스 스케쥴러 구현 (C#)

Schd.sln 파일을 실행한 후 CPU Scheduler Testing 방법.pdf 파일을 참고하여 테스트하면 됩니다.

## 구현한 Scheduling 기법

1.FCFS Scheduling
---
>>먼저, FCFS(First-Come, First-Served) Scheduling 방식이다. 이는 가장 단순한 구조인데 프로세스의 정보 중 도착시간과 실행시간만을 고려한다. 도착시간이 빠른 순으로 프로세스를 실행한다. FCFS는 비선점 방식으로 실행되기 때문에 작업시간이 짧은 프로세스라 하더라도 늦게 도착한다면 계속해서 먼저 도착한 앞의 프로세스가 종료되기만을 기다려야하는 convoy effect상태가 발생한다.

2.SJF (Non_Preemptive) Scheduling
---
>SJF(Shortest-Job-First) Scheduling방식 또한 프로세스의 정보 중 도착시간과 실행시간만을 고려한다. SJF는 실행시간이 짧은 프로세스를 먼저 실행한다. 그러나 이는 비선점 방식으로 실행되기 때문에 현재 실행 중인 프로세스 보다 더 실행시간이 짧은 프로세스가 들어오더라도 현재 실행 중인 프로세스가 종료될 때 까지 기다려야 한다. 만약,  프로세스들 간의 실행시간이 동일할 경우, 먼저 도착한 프로세스를 실행한다.

3.SRTF (Preemptive) Scheduling
---
>선점방식을 이용하는 SJF이다. 프로세스 실행도중 실행시간이 더 짧은 프로세스가 ready Queue에 들어왔을 때, 현재 실행중인 프로세스를 중단하고 더 짧은 프로세스를 실행한다. 만약, 새로 들어온 프로세스의 실행시간과 현재 실행중인 프로세스의 실행시간이 같을 경우, 현재 실행중인 프로세스를 중단하지 않고 계속 진행한다. 

4.Priority Scheduling (Non_Preemptive)
---
>Priority Scheduling 방식은 프로세스의 정보 모두를 고려한다. 프로세스의 우선순위가 높은 것을 먼저 실행한다. 비선점 방식으로 실행되기 때문에 현재 실행중인 프로세스보다 더 높은 우선순위의 프로세스가 준비되더라도 현재 진행 중인 프로세스가 다 종료된 후에 실행이 가능 하다. 계속해서 우선순위가 높은 프로세스가 들어와 상대적으로 낮은 우선순위인 프로세스를 실행하지 못하는 경우가 발생할 수 있다.

5.Round Robin Scheduling
---
>Round Robin Scheduling 방식은 프로세스의 정보 중 실행시간만을 고려한다.
모든 프로세스가 ready Queue에 들어와 있다고 가정한다. 각 프로세스들은 설정된 Time slice(Time Quantum)만큼 실행되고 다시 자신의 순서가 오기를 기다린다. 만약 프로세스의 실행시간이 Time slice보다 짧을 경우, Time slice만큼 다 실행하지 않고 프로세스의 실행시간만큼만 진행한다.



