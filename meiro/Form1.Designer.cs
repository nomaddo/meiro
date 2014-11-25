namespace meiro
{
    partial class top
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.field = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(13, 13);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(454, 19);
            this.fileNameBox.TabIndex = 0;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(13, 39);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(95, 39);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 2;
            this.runBtn.Text = "run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(177, 38);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 3;
            this.testBtn.Text = "test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // field
            // 
            this.field.AutoSize = true;
            this.field.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.field.Location = new System.Drawing.Point(13, 68);
            this.field.MinimumSize = new System.Drawing.Size(100, 100);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(100, 100);
            this.field.TabIndex = 4;
            this.field.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.field.Resize += new System.EventHandler(this.field_Resize);
            // 
            // top
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 424);
            this.Controls.Add(this.field);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.fileNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "top";
            this.Text = "迷路";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.top_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Panel field;
    }
}

