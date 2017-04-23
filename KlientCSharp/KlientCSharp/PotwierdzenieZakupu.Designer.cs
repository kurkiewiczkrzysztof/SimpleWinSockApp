namespace KlientCSharp
{
    partial class PotwierdzenieZakupu
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnKup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(30, 33);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 0;
            // 
            // btnKup
            // 
            this.btnKup.Location = new System.Drawing.Point(43, 59);
            this.btnKup.Name = "btnKup";
            this.btnKup.Size = new System.Drawing.Size(75, 26);
            this.btnKup.TabIndex = 1;
            this.btnKup.Text = "Kupuje!";
            this.btnKup.UseVisualStyleBackColor = true;
            this.btnKup.Click += new System.EventHandler(this.btnKup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Podaj dokladnie id przedmiotu";
            // 
            // PotwierdzenieZakupu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 88);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKup);
            this.Controls.Add(this.txtID);
            this.Name = "PotwierdzenieZakupu";
            this.Text = "PotwierdzenieZakupu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnKup;
        private System.Windows.Forms.Label label1;
    }
}