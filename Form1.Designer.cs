namespace Buoi8Api
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
            dataGridView1 = new DataGridView();
            btn_add = new Button();
            txtHo = new TextBox();
            txtTen = new TextBox();
            txtLop = new TextBox();
            label1 = new Label();
            lbten = new Label();
            label3 = new Label();
            btn_edit = new Button();
            btn_del = new Button();
            btn_search = new Button();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(738, 401);
            dataGridView1.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(790, 292);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(88, 29);
            btn_add.TabIndex = 1;
            btn_add.Text = "Thêm";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // txtHo
            // 
            txtHo.Location = new Point(865, 113);
            txtHo.Name = "txtHo";
            txtHo.Size = new Size(202, 27);
            txtHo.TabIndex = 2;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(865, 171);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(202, 27);
            txtTen.TabIndex = 3;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(865, 230);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(202, 27);
            txtLop.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(790, 120);
            label1.Name = "label1";
            label1.Size = new Size(29, 20);
            label1.TabIndex = 5;
            label1.Text = "Họ";
            // 
            // lbten
            // 
            lbten.AutoSize = true;
            lbten.Location = new Point(791, 171);
            lbten.Name = "lbten";
            lbten.Size = new Size(32, 20);
            lbten.TabIndex = 6;
            lbten.Text = "Tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(791, 230);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 7;
            label3.Text = "Lớp";
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(884, 292);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(79, 29);
            btn_edit.TabIndex = 8;
            btn_edit.Text = "Sửa";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click; // Gán sự kiện Click
            // 
            // btn_del
            // 
            btn_del.Location = new Point(973, 292);
            btn_del.Name = "btn_del";
            btn_del.Size = new Size(94, 29);
            btn_del.TabIndex = 9;
            btn_del.Text = "Xóa";
            btn_del.UseVisualStyleBackColor = true;
            btn_del.Click += btn_del_Click; // Gán sự kiện Click
            // 
            // btn_search
            // 
            btn_search.Location = new Point(669, 49);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(94, 29);
            btn_search.TabIndex = 10;
            btn_search.Text = "Tìm kiếm";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click; // Gán sự kiện Click
            // 
            // textBox3
            // 
            textBox3.Location = new Point(25, 51);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(615, 27);
            textBox3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 544);
            Controls.Add(textBox3);
            Controls.Add(btn_search);
            Controls.Add(btn_del);
            Controls.Add(btn_edit);
            Controls.Add(label3);
            Controls.Add(lbten);
            Controls.Add(label1);
            Controls.Add(txtLop);
            Controls.Add(txtTen);
            Controls.Add(txtHo);
            Controls.Add(btn_add);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_add;
        private TextBox txtHo;
        private TextBox txtTen;
        private TextBox txtLop;
        private Label label1;
        private Label lbten;
        private Label label3;
        private Button btn_edit;
        private Button btn_del;
        private Button btn_search;
        private TextBox textBox3;
    }
}