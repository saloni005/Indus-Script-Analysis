namespace BigAlbum
{
    partial class NuNet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblMinErr = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveNn = new System.Windows.Forms.Button();
            this.btnLoadNn = new System.Windows.Forms.Button();
            this.btnNnData = new System.Windows.Forms.Button();
            this.btnNnReset = new System.Windows.Forms.Button();
            this.btnNnTrain = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIntErr = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.buttonoR = new System.Windows.Forms.Button();
            this.trackBarThreshould = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.labelThVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshould)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(176, 166);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(49, 17);
            this.lblCount.TabIndex = 41;
            this.lblCount.Text = "Count:";
            // 
            // lblMinErr
            // 
            this.lblMinErr.AutoSize = true;
            this.lblMinErr.Location = new System.Drawing.Point(176, 146);
            this.lblMinErr.Name = "lblMinErr";
            this.lblMinErr.Size = new System.Drawing.Size(53, 17);
            this.lblMinErr.TabIndex = 40;
            this.lblMinErr.Text = "MinErr:";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Location = new System.Drawing.Point(176, 127);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(31, 17);
            this.lblErr.TabIndex = 39;
            this.lblErr.Text = "Err:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "MinErr:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Err:";
            // 
            // btnSaveNn
            // 
            this.btnSaveNn.Location = new System.Drawing.Point(13, 87);
            this.btnSaveNn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveNn.Name = "btnSaveNn";
            this.btnSaveNn.Size = new System.Drawing.Size(83, 28);
            this.btnSaveNn.TabIndex = 35;
            this.btnSaveNn.Text = "SaveNn";
            this.btnSaveNn.UseVisualStyleBackColor = true;
            this.btnSaveNn.Click += new System.EventHandler(this.btnSaveNn_Click);
            // 
            // btnLoadNn
            // 
            this.btnLoadNn.Location = new System.Drawing.Point(13, 122);
            this.btnLoadNn.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadNn.Name = "btnLoadNn";
            this.btnLoadNn.Size = new System.Drawing.Size(83, 28);
            this.btnLoadNn.TabIndex = 34;
            this.btnLoadNn.Text = "LoadNn";
            this.btnLoadNn.UseVisualStyleBackColor = true;
            this.btnLoadNn.Click += new System.EventHandler(this.btnLoadNn_Click);
            // 
            // btnNnData
            // 
            this.btnNnData.Location = new System.Drawing.Point(13, 15);
            this.btnNnData.Margin = new System.Windows.Forms.Padding(4);
            this.btnNnData.Name = "btnNnData";
            this.btnNnData.Size = new System.Drawing.Size(83, 28);
            this.btnNnData.TabIndex = 33;
            this.btnNnData.Text = "NN Data";
            this.btnNnData.UseVisualStyleBackColor = true;
            this.btnNnData.Click += new System.EventHandler(this.btnNnData_Click);
            // 
            // btnNnReset
            // 
            this.btnNnReset.Location = new System.Drawing.Point(13, 50);
            this.btnNnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnNnReset.Name = "btnNnReset";
            this.btnNnReset.Size = new System.Drawing.Size(83, 28);
            this.btnNnReset.TabIndex = 32;
            this.btnNnReset.Text = "NN=0";
            this.btnNnReset.UseVisualStyleBackColor = true;
            this.btnNnReset.Click += new System.EventHandler(this.btnNnReset_Click);
            // 
            // btnNnTrain
            // 
            this.btnNnTrain.Location = new System.Drawing.Point(13, 158);
            this.btnNnTrain.Margin = new System.Windows.Forms.Padding(4);
            this.btnNnTrain.Name = "btnNnTrain";
            this.btnNnTrain.Size = new System.Drawing.Size(83, 28);
            this.btnNnTrain.TabIndex = 31;
            this.btnNnTrain.Text = "NN=>>";
            this.btnNnTrain.UseVisualStyleBackColor = true;
            this.btnNnTrain.Click += new System.EventHandler(this.btnNnTrain_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(321, 198);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 28);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Err:";
            // 
            // lblIntErr
            // 
            this.lblIntErr.AutoSize = true;
            this.lblIntErr.Location = new System.Drawing.Point(140, 92);
            this.lblIntErr.Name = "lblIntErr";
            this.lblIntErr.Size = new System.Drawing.Size(46, 17);
            this.lblIntErr.TabIndex = 43;
            this.lblIntErr.Text = "IntErr:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(302, 7);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 28);
            this.btnTest.TabIndex = 45;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // buttonoR
            // 
            this.buttonoR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonoR.Location = new System.Drawing.Point(302, 42);
            this.buttonoR.Name = "buttonoR";
            this.buttonoR.Size = new System.Drawing.Size(83, 23);
            this.buttonoR.TabIndex = 46;
            this.buttonoR.Text = "OR";
            this.buttonoR.UseVisualStyleBackColor = true;
            this.buttonoR.Click += new System.EventHandler(this.buttonoR_Click);
            // 
            // trackBarThreshould
            // 
            this.trackBarThreshould.LargeChange = 1;
            this.trackBarThreshould.Location = new System.Drawing.Point(267, 107);
            this.trackBarThreshould.Name = "trackBarThreshould";
            this.trackBarThreshould.Size = new System.Drawing.Size(130, 56);
            this.trackBarThreshould.TabIndex = 47;
            this.trackBarThreshould.Tag = "Threshould";
            this.trackBarThreshould.Value = 6;
            this.trackBarThreshould.Scroll += new System.EventHandler(this.trackBarThreshould_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "Threshould";
            // 
            // labelThVal
            // 
            this.labelThVal.AutoSize = true;
            this.labelThVal.Location = new System.Drawing.Point(332, 144);
            this.labelThVal.Name = "labelThVal";
            this.labelThVal.Size = new System.Drawing.Size(46, 17);
            this.labelThVal.TabIndex = 49;
            this.labelThVal.Text = "label6";
            // 
            // NuNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 239);
            this.Controls.Add(this.labelThVal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBarThreshould);
            this.Controls.Add(this.buttonoR);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIntErr);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblMinErr);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveNn);
            this.Controls.Add(this.btnLoadNn);
            this.Controls.Add(this.btnNnData);
            this.Controls.Add(this.btnNnReset);
            this.Controls.Add(this.btnNnTrain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NuNet";
            this.Text = "NuNet";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshould)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblMinErr;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveNn;
        private System.Windows.Forms.Button btnLoadNn;
        private System.Windows.Forms.Button btnNnData;
        private System.Windows.Forms.Button btnNnReset;
        private System.Windows.Forms.Button btnNnTrain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIntErr;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button buttonoR;
        private System.Windows.Forms.TrackBar trackBarThreshould;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelThVal;
    }
}