namespace DirtyPig
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.playername = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.socket = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.gameStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // playername
            // 
            this.playername.AutoSize = true;
            this.playername.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.playername.Location = new System.Drawing.Point(70, 175);
            this.playername.Name = "playername";
            this.playername.Size = new System.Drawing.Size(137, 38);
            this.playername.TabIndex = 3;
            this.playername.Text = "玩家名稱";
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name.Location = new System.Drawing.Point(12, 216);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(245, 57);
            this.name.TabIndex = 4;
            this.name.Text = "1";
            // 
            // socket
            // 
            this.socket.AutoSize = true;
            this.socket.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.socket.Location = new System.Drawing.Point(411, 175);
            this.socket.Name = "socket";
            this.socket.Size = new System.Drawing.Size(105, 38);
            this.socket.TabIndex = 5;
            this.socket.Text = "輸入IP";
            // 
            // ip
            // 
            this.ip.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ip.Location = new System.Drawing.Point(263, 216);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(409, 57);
            this.ip.TabIndex = 6;
            this.ip.Text = "127.0.0.1";
            // 
            // gameStart
            // 
            this.gameStart.Location = new System.Drawing.Point(343, 325);
            this.gameStart.Name = "gameStart";
            this.gameStart.Size = new System.Drawing.Size(263, 92);
            this.gameStart.TabIndex = 7;
            this.gameStart.Text = "start";
            this.gameStart.UseVisualStyleBackColor = true;
            this.gameStart.Click += new System.EventHandler(this.gameStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(775, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "輸入port";
            // 
            // port
            // 
            this.port.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.port.Location = new System.Drawing.Point(678, 216);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(327, 57);
            this.port.TabIndex = 9;
            this.port.Text = "1234";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 531);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameStart);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.socket);
            this.Controls.Add(this.name);
            this.Controls.Add(this.playername);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playername;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label socket;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Button gameStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox port;
    }
}

