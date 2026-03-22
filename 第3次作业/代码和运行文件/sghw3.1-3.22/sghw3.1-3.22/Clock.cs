using System;
using System.Threading;

namespace sghw3._1_3._22
{
    public class AlarmEventArgs : EventArgs
    {
        public int CurrentTime { get; set; }
        public AlarmEventArgs(int time) { CurrentTime = time; }
    }

    public class Clock
    {
        public delegate void ClockHandler(object sender, AlarmEventArgs e);
        public event ClockHandler Tick;
        public event ClockHandler Alarm;

        public void Start(int seconds)
        {
            for (int i = 1; i <= seconds; i++)
            {
                Thread.Sleep(1000); // 停顿一秒
                Tick?.Invoke(this, new AlarmEventArgs(i)); // 发射嘀嗒信号
            }
            Alarm?.Invoke(this, new AlarmEventArgs(seconds)); // 发射响铃信号
        }
    }
}