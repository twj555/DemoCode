namespace PictureCaiji
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCaiji = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.btnCaiJiById = new System.Windows.Forms.Button();
            this.txtPicId = new System.Windows.Forms.TextBox();
            this.lblPicId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(77, 36);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(75, 21);
            this.txtGroupId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "相册编号：";
            // 
            // btnCaiji
            // 
            this.btnCaiji.Location = new System.Drawing.Point(77, 211);
            this.btnCaiji.Name = "btnCaiji";
            this.btnCaiji.Size = new System.Drawing.Size(75, 23);
            this.btnCaiji.TabIndex = 2;
            this.btnCaiji.Text = "采集";
            this.btnCaiji.UseVisualStyleBackColor = true;
            this.btnCaiji.Click += new System.EventHandler(this.btnCaiji_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(77, 70);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(389, 21);
            this.txtSavePath.TabIndex = 0;
            this.txtSavePath.Text = "G:\\sqy设计收藏";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "保存地址：";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(185, 216);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 12);
            this.lblCount.TabIndex = 1;
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.AutoSize = true;
            this.lblGroupTitle.Location = new System.Drawing.Point(168, 40);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(65, 12);
            this.lblGroupTitle.TabIndex = 1;
            this.lblGroupTitle.Text = "相册名称：";
            // 
            // btnCaiJiById
            // 
            this.btnCaiJiById.Location = new System.Drawing.Point(382, 216);
            this.btnCaiJiById.Name = "btnCaiJiById";
            this.btnCaiJiById.Size = new System.Drawing.Size(75, 23);
            this.btnCaiJiById.TabIndex = 2;
            this.btnCaiJiById.Text = "定点采集";
            this.btnCaiJiById.UseVisualStyleBackColor = true;
            this.btnCaiJiById.Click += new System.EventHandler(this.btnCaiJiById_Click);
            // 
            // txtPicId
            // 
            this.txtPicId.Location = new System.Drawing.Point(391, 36);
            this.txtPicId.Name = "txtPicId";
            this.txtPicId.Size = new System.Drawing.Size(75, 21);
            this.txtPicId.TabIndex = 0;
            // 
            // lblPicId
            // 
            this.lblPicId.AutoSize = true;
            this.lblPicId.Location = new System.Drawing.Point(326, 40);
            this.lblPicId.Name = "lblPicId";
            this.lblPicId.Size = new System.Drawing.Size(65, 12);
            this.lblPicId.TabIndex = 1;
            this.lblPicId.Text = "相册编号：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 246);
            this.Controls.Add(this.btnCaiJiById);
            this.Controls.Add(this.btnCaiji);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.lblGroupTitle);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblPicId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPicId);
            this.Controls.Add(this.txtGroupId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCaiji;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.Button btnCaiJiById;
        private System.Windows.Forms.TextBox txtPicId;
        private System.Windows.Forms.Label lblPicId;
    }
}

