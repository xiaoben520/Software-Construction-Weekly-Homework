using System;
using System.IO;
using System.Windows.Forms;

namespace sghw4._1_20260329
{
    /// <summary>
    /// 主窗体类：实现文本文件的选择与合并功能
    /// </summary>
    public partial class Form1 : Form
    {
        // 私有字段：存储用户选择的原始文件完整路径
        private string _path1 = "";
        private string _path2 = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 事件处理器：点击按钮选择第一个源文件
        /// </summary>
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            // 实例化文件打开对话框
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "请选择第一个文本文件";
                ofd.Filter = "文本文件|*.txt|所有文件|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _path1 = ofd.FileName; // 记录全路径用于后续读取
                    lblFile1.Text = Path.GetFileName(_path1); // UI 仅显示文件名，保持简洁
                }
            }
        }

        /// <summary>
        /// 事件处理器：点击按钮选择第二个源文件
        /// </summary>
        private void btnSelect2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "请选择第二个文本文件";
                ofd.Filter = "文本文件|*.txt|所有文件|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _path2 = ofd.FileName;
                    lblFile2.Text = Path.GetFileName(_path2);
                }
            }
        }

        /// <summary>
        /// 核心逻辑：读取两个文件内容并合并到程序目录下的 Data 文件夹
        /// </summary>
        private void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 参数校验（异常处理的一部分：预防性检查）
                if (string.IsNullOrEmpty(_path1) || string.IsNullOrEmpty(_path2))
                {
                    MessageBox.Show("错误：请确保已选择两个源文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. 动态构建目标路径：AppDomain.CurrentDomain.BaseDirectory 确保在不同机器运行路径依然正确
                string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

                // 3. 目录存在性检查：如果文件夹不存在则自动创建（文件操作必选点）
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                // 4. 定义输出文件名
                string newFilePath = Path.Combine(targetDir, "MergedFile.txt");

                // 5. 执行 IO 操作：
                // ReadAllText 将整个文件读入内存
                string content1 = File.ReadAllText(_path1);
                string content2 = File.ReadAllText(_path2);

                // WriteAllText 自动创建或覆盖文件
                // 使用 Environment.NewLine 确保在不同操作系统下的换行兼容性
                File.WriteAllText(newFilePath, content1 + Environment.NewLine + "--- 分割线 ---" + Environment.NewLine + content2);

                MessageBox.Show($"合并成功！\n文件已生成至：{newFilePath}", "任务完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                // 针对文件占用的细分异常处理
                MessageBox.Show($"文件操作失败：{ioEx.Message}", "IO 错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // 兜底异常处理
                MessageBox.Show($"发生未知错误：{ex.Message}", "系统异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}