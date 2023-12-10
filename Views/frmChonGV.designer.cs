
namespace Views
{
    partial class frmChonGV
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMoTa = new System.Windows.Forms.ComboBox();
            this.dgvDSGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã giáo viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(139, 123);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(296, 22);
            this.txtMa.TabIndex = 3;
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(139, 172);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(296, 22);
            this.txtHo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mô tả";
            // 
            // cboMoTa
            // 
            this.cboMoTa.FormattingEnabled = true;
            this.cboMoTa.Location = new System.Drawing.Point(139, 72);
            this.cboMoTa.Name = "cboMoTa";
            this.cboMoTa.Size = new System.Drawing.Size(380, 24);
            this.cboMoTa.TabIndex = 6;
            this.cboMoTa.SelectedIndexChanged += new System.EventHandler(this.cboMoTa_SelectedIndexChanged);
            this.cboMoTa.SelectedValueChanged += new System.EventHandler(this.cboMoTa_SelectedValueChanged);
            // 
            // dgvDSGV
            // 
            this.dgvDSGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSGV.Location = new System.Drawing.Point(541, 71);
            this.dgvDSGV.Name = "dgvDSGV";
            this.dgvDSGV.RowHeadersWidth = 51;
            this.dgvDSGV.RowTemplate.Height = 24;
            this.dgvDSGV.Size = new System.Drawing.Size(601, 339);
            this.dgvDSGV.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(139, 221);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(296, 22);
            this.txtTen.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(139, 270);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(296, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(139, 319);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(296, 22);
            this.txtSDT.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số điện thoại";
            // 
            // frmChonGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvDSGV);
            this.Controls.Add(this.cboMoTa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmChonGV";
            this.Text = "frmChonGV";
            this.Load += new System.EventHandler(this.frmChonGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMoTa;
        private System.Windows.Forms.DataGridView dgvDSGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label6;
    }
}