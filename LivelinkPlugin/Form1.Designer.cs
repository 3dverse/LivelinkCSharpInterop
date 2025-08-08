namespace LivelinkClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            leftValue = new TextBox();
            rightValue = new TextBox();
            buttonAdd = new Button();
            labelResult = new Label();
            labelOperator = new Label();
            buttonConnectLivelink = new Button();
            buttonStartAnim = new Button();
            buttonStopAllAnims = new Button();
            buttonDisconnectLivelink = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // leftValue
            // 
            leftValue.Location = new Point(12, 41);
            leftValue.Name = "leftValue";
            leftValue.Size = new Size(100, 23);
            leftValue.TabIndex = 0;
            leftValue.Text = "2";
            // 
            // rightValue
            // 
            rightValue.Location = new Point(139, 41);
            rightValue.Name = "rightValue";
            rightValue.Size = new Size(100, 23);
            rightValue.TabIndex = 1;
            rightValue.Text = "40";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(245, 41);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "=";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.BackColor = SystemColors.ControlLightLight;
            labelResult.BorderStyle = BorderStyle.FixedSingle;
            labelResult.Location = new Point(326, 45);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(38, 17);
            labelResult.TabIndex = 3;
            labelResult.Text = "result";
            // 
            // labelOperator
            // 
            labelOperator.AutoSize = true;
            labelOperator.Location = new Point(118, 45);
            labelOperator.Name = "labelOperator";
            labelOperator.Size = new Size(15, 15);
            labelOperator.TabIndex = 5;
            labelOperator.Text = "+";
            // 
            // buttonConnectLivelink
            // 
            buttonConnectLivelink.Location = new Point(12, 113);
            buttonConnectLivelink.Name = "buttonConnectLivelink";
            buttonConnectLivelink.Size = new Size(125, 23);
            buttonConnectLivelink.TabIndex = 6;
            buttonConnectLivelink.Text = "Connect Livelink";
            buttonConnectLivelink.UseVisualStyleBackColor = true;
            buttonConnectLivelink.Click += buttonConnectLivelink_Click;
            // 
            // buttonStartAnim
            // 
            buttonStartAnim.Location = new Point(12, 142);
            buttonStartAnim.Name = "buttonStartAnim";
            buttonStartAnim.Size = new Size(125, 23);
            buttonStartAnim.TabIndex = 7;
            buttonStartAnim.Text = "Start new cube anim";
            buttonStartAnim.UseVisualStyleBackColor = true;
            buttonStartAnim.Click += buttonStartAnim_Click;
            // 
            // buttonStopAllAnims
            // 
            buttonStopAllAnims.Location = new Point(146, 142);
            buttonStopAllAnims.Name = "buttonStopAllAnims";
            buttonStopAllAnims.Size = new Size(122, 23);
            buttonStopAllAnims.TabIndex = 8;
            buttonStopAllAnims.Text = "stop all anims";
            buttonStopAllAnims.UseVisualStyleBackColor = true;
            buttonStopAllAnims.Click += buttonStopAllAnims_Click;
            // 
            // buttonDisconnectLivelink
            // 
            buttonDisconnectLivelink.Location = new Point(143, 113);
            buttonDisconnectLivelink.Name = "buttonDisconnectLivelink";
            buttonDisconnectLivelink.Size = new Size(125, 23);
            buttonDisconnectLivelink.TabIndex = 9;
            buttonDisconnectLivelink.Text = "Disconnect Livelink";
            buttonDisconnectLivelink.UseVisualStyleBackColor = true;
            buttonDisconnectLivelink.Click += buttonDisconnectLivelink_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 10;
            label1.Text = "Simple Interop:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 11;
            label2.Text = "Livelink Interop:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 182);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonDisconnectLivelink);
            Controls.Add(buttonStopAllAnims);
            Controls.Add(buttonStartAnim);
            Controls.Add(buttonConnectLivelink);
            Controls.Add(labelOperator);
            Controls.Add(labelResult);
            Controls.Add(buttonAdd);
            Controls.Add(rightValue);
            Controls.Add(leftValue);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox leftValue;
        private TextBox rightValue;
        private Button buttonAdd;
        private Label labelResult;
        private Label labelOperator;
        private Button buttonConnectLivelink;
        private Button buttonStartAnim;
        private Button buttonStopAllAnims;
        private Button buttonDisconnectLivelink;
        private Label label1;
        private Label label2;
    }
}
