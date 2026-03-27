using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAlarmClock
{
    public partial class Form1 : Form
    {
        //存储用户设置的闹钟时间
        private List<DateTime> alarmList = new List<DateTime>();
        public Form1()
        {
            InitializeComponent();
        }
        //使用异步时钟模拟timer
        private async Task StartDigitalClock()
        {
            while (!this.IsHandleCreated)
            {
                await Task.Delay(100);
            }
            while (true)
            {
                DateTime now = DateTime.Now;
                //如果控件的句柄创建才开始执行，防止卡死我的程序
                if (lblTime.IsHandleCreated)
                {
                    //使用Invoke确保在UI线程更新控件
                    lblTime.Invoke(new Action(() => {
                        lblTime.Text = now.ToString("HH:mm:ss");
                    }));
                }
                CheckAlarms(now);
                await Task.Delay(1000);
            }
        }
        private void CheckAlarms(DateTime now)
        {
            foreach (var alarm in alarmList)
            {
                if (alarm.Hour == now.Hour && alarm.Minute == now.Minute && alarm.Second == now.Second)
                {
                    Task.Run(() => {
                        MessageBox.Show($"闹钟时间到！", "提醒");
                    });
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _ = StartDigitalClock();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime selectedTime=dtpAlarms.Value;
            alarmList.Add(selectedTime);
            listAlarms.Items.Add(selectedTime.ToString("HH:mm:ss"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 获取用户选中的索引
            int index = listAlarms.SelectedIndex;

            if (index != -1)
            {
                // 同步删除后台数据和前端显示
                alarmList.RemoveAt(index);
                listAlarms.Items.RemoveAt(index);
            }
        }
    }
}
