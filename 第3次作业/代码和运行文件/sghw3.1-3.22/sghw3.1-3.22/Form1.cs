using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sghw3._1_3._22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            lblDisplay.Text = "闹钟已启动...";

            Clock clock = new Clock();

            // 订阅嘀嗒事件：更新标签
            clock.Tick += (s, ex) => {
                this.Invoke(new Action(() => {
                    lblDisplay.Text = $"已走时：{ex.CurrentTime} 秒";
                }));
            };

            //订阅响铃事件：弹窗并恢复按钮
            clock.Alarm += (s, ex) => {
                this.Invoke(new Action(() => {
                    MessageBox.Show("⏰ 时间到！");
                    btnStart.Enabled = true;
                    lblDisplay.Text = "等待启动...";
                }));
            };
            Task.Run(() => clock.Start(5));
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Clock clock = new Clock();

            // 订阅嘀嗒（更新界面）
            clock.Tick += (s, ex) => {
                this.Invoke(new Action(() => {
                    lblDisplay.Text = $"当前秒数：{ex.CurrentTime}";
                }));
            };

            // 订阅响铃（弹窗并恢复）
            clock.Alarm += (s, ex) => {
                this.Invoke(new Action(() => {
                    MessageBox.Show("时间到！");
                    btnStart.Enabled = true;
                }));
            };
            Task.Run(() => clock.Start(5));
        }
    }
}
