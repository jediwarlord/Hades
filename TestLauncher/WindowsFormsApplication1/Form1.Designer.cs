﻿namespace HadesTestLauncher
{
    partial class Form1
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
            this.TestList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Testing = new System.Windows.Forms.GroupBox();
            this.TestResult = new System.Windows.Forms.TextBox();
            this.ResultButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Testing.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestList
            // 
            this.TestList.FormattingEnabled = true;
            this.TestList.ItemHeight = 16;
            this.TestList.Location = new System.Drawing.Point(15, 86);
            this.TestList.Name = "TestList";
            this.TestList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.TestList.Size = new System.Drawing.Size(213, 180);
            this.TestList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(83, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Initiation";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 36);
            this.button3.TabIndex = 0;
            this.button3.Text = "Begin UEFI Test Suite";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(369, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(370, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 31);
            this.button5.TabIndex = 5;
            this.button5.Text = "Del";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Testing
            // 
            this.Testing.Controls.Add(this.TestResult);
            this.Testing.Location = new System.Drawing.Point(481, 65);
            this.Testing.Name = "Testing";
            this.Testing.Size = new System.Drawing.Size(387, 444);
            this.Testing.TabIndex = 6;
            this.Testing.TabStop = false;
            this.Testing.Text = "Test Results";
            // 
            // TestResult
            // 
            this.TestResult.Location = new System.Drawing.Point(7, 21);
            this.TestResult.Multiline = true;
            this.TestResult.Name = "TestResult";
            this.TestResult.Size = new System.Drawing.Size(374, 417);
            this.TestResult.TabIndex = 0;
            // 
            // ResultButton
            // 
            this.ResultButton.Location = new System.Drawing.Point(608, 26);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(165, 38);
            this.ResultButton.TabIndex = 7;
            this.ResultButton.Text = "Get Latest Results";
            this.ResultButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 531);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.Testing);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.Testing.ResumeLayout(false);
            this.Testing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox TestList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox Testing;
        private System.Windows.Forms.TextBox TestResult;
        private System.Windows.Forms.Button ResultButton;

    }
}

