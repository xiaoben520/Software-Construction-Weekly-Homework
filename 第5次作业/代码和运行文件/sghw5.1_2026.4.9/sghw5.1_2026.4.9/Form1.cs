using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sghw5._1_2026._4._9
{
    public partial class Form1 : Form
    {
        double resultValue = 0;       // 存储当前的计算结果
        string operationPerformed = ""; // 记录点击了哪个运算符 (+, -, *, /)
        bool isOperationPerformed = false; // 记录是否刚刚点击过运算符
        bool isShowingResult = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // 整合逻辑判断：
            // 1. 如果文本框里只有 "0"
            // 2. 或者刚刚按下了运算符 (isOperationPerformed == true)
            // 3. 或者刚刚显示了计算结果 (isShowingResult == true)
            // 此时不进行拼接，而是直接用按下的数字替换掉现有文本
            // 替换后，把这些状态位重置为 false，否则下一次点击数字还会继续替换
            if (txtDisplay.Text == "0" || isOperationPerformed || isShowingResult)
            {
                txtDisplay.Text = button.Text;
                
                isOperationPerformed = false;
                isShowingResult = false;
            }
            else
            {
                // 正常状态：当前的数字不是 "0"，且在输入数字过程中，执行字符串拼接
                txtDisplay.Text = txtDisplay.Text + button.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isShowingResult)
            {
                // resultValue 已经在上一次等号时存好了结果，所以这里不用重新 Parse
                isShowingResult = false;
            }
            else
            {
                // 如果不是在显示结果，就正常获取当前输入的数字
                if (txtDisplay.Text != "")
                {
                    resultValue = double.Parse(txtDisplay.Text);
                }
            }

            operationPerformed = button.Text;
            isOperationPerformed = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            // 如果当前文本框里还没有小数点，才允许加上去
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text = txtDisplay.Text + ".";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operationPerformed == "") return;

            double secondValue = double.Parse(txtDisplay.Text);
            double finalResult = 0;

            switch (operationPerformed)
            {
                case "+": finalResult = resultValue + secondValue; break;
                case "-": finalResult = resultValue - secondValue; break;
                case "×": finalResult = resultValue * secondValue; break;
                case "÷":
                    if (secondValue != 0) finalResult = resultValue / secondValue;
                    else { txtDisplay.Text = "除数不能为0"; return; }
                    break;
            }

            // 显示完整表达式
            txtDisplay.Text = $"{resultValue} {operationPerformed} {secondValue} = {finalResult}";
            txtDisplay.SelectionStart = txtDisplay.Text.Length; // 把光标移到最后
            txtDisplay.ScrollToCaret(); // 滚动到光标位置

            // 重要：存下这个结果，供下一次“连续计算”使用
            resultValue = finalResult;
            isShowingResult = true; // 标记现在显示的是表达式，不是纯数字
            operationPerformed = ""; // 重置运算符
        }
    }
}
