using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Example;

namespace PictureCaiji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCaiji_Click(object sender, EventArgs e)
        {

            HuaBanCaiji cj = new HuaBanCaiji(int.Parse(txtGroupId.Text), txtSavePath.Text);
            //cj.ShowInfo += ShowInfo;

            cj.ShowInfo = ShowInfo;
            cj.Start();
            lblGroupTitle.Text = "相册名称：" + cj.GroupTitle;
            lblCount.Text = cj.imgList.Count.ToString();

        }

        private void ShowInfo()
        {
            MessageBox.Show("下载完毕");
        }

        private void btnCaiJiById_Click(object sender, EventArgs e)
        {
            HuaBanCaiji2 cj = new HuaBanCaiji2(int.Parse(txtGroupId.Text), txtSavePath.Text,int.Parse(txtPicId.Text));
            //cj.ShowInfo += ShowInfo;

            cj.ShowInfo = ShowInfo;
            cj.Start();
            lblGroupTitle.Text = "相册名称：" + cj.GroupTitle;
            lblCount.Text = cj.imgList.Count.ToString();
        }
    }
}
