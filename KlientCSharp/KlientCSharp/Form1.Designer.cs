namespace KlientCSharp
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWroc = new System.Windows.Forms.Button();
            this.btnKup = new System.Windows.Forms.Button();
            this.btnHistoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nazwa});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(557, 230);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nazwa
            // 
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            // 
            // btnWroc
            // 
            this.btnWroc.Enabled = false;
            this.btnWroc.Location = new System.Drawing.Point(494, 249);
            this.btnWroc.Name = "btnWroc";
            this.btnWroc.Size = new System.Drawing.Size(75, 23);
            this.btnWroc.TabIndex = 2;
            this.btnWroc.Text = "Wroc";
            this.btnWroc.UseVisualStyleBackColor = true;
            this.btnWroc.Click += new System.EventHandler(this.btnWroc_Click);
            // 
            // btnKup
            // 
            this.btnKup.Enabled = false;
            this.btnKup.Location = new System.Drawing.Point(413, 249);
            this.btnKup.Name = "btnKup";
            this.btnKup.Size = new System.Drawing.Size(75, 23);
            this.btnKup.TabIndex = 4;
            this.btnKup.Text = "Kup";
            this.btnKup.UseVisualStyleBackColor = true;
            this.btnKup.Click += new System.EventHandler(this.btnKup_Click);
            // 
            // btnHistoria
            // 
            this.btnHistoria.Location = new System.Drawing.Point(332, 249);
            this.btnHistoria.Name = "btnHistoria";
            this.btnHistoria.Size = new System.Drawing.Size(75, 23);
            this.btnHistoria.TabIndex = 6;
            this.btnHistoria.Text = "Historia";
            this.btnHistoria.UseVisualStyleBackColor = true;
            this.btnHistoria.Click += new System.EventHandler(this.btnHistoria_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 281);
            this.Controls.Add(this.btnHistoria);
            this.Controls.Add(this.btnKup);
            this.Controls.Add(this.btnWroc);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Aplikacja sklep";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.Button btnWroc;
        private System.Windows.Forms.Button btnKup;
        private System.Windows.Forms.Button btnHistoria;
    }
}

