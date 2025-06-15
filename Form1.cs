using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi8Api
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5092/") };
        private int? selectedStudentId = null;

        // Định nghĩa lớp Student để khớp với mô hình mà API mong đợi
        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int GradeId { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            LoadStudents();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private async void LoadStudents(string search = "")
        {
            try
            {
                var students = await _httpClient.GetFromJsonAsync<List<StudentDto>>("api/StudentApi");
                if (!string.IsNullOrWhiteSpace(search))
                {
                    students = students.FindAll(s =>
                        s.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        s.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        s.GradeId.ToString() == search 
                        );
                }

                // Cấu hình các cột của DataGridView
                dataGridView1.AutoGenerateColumns = false; // Tắt tự động tạo cột
                dataGridView1.Columns.Clear(); // Xóa các cột hiện có (nếu có)

                // Thêm các cột thủ công với tiêu đề tiếng Việt
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StudentId",
                    HeaderText = "Mã Sinh Viên",
                    Name = "StudentId"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "LastName",
                    HeaderText = "Họ",
                    Name = "LastName"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FirstName",
                    HeaderText = "Tên",
                    Name = "FirstName"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GradeId",
                    HeaderText = "Mã Lớp",
                    Name = "GradeId"
                });

                // Gán dữ liệu cho DataGridView
                dataGridView1.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is StudentDto student)
            {
                selectedStudentId = student.StudentId;
                txtHo.Text = student.LastName;
                txtTen.Text = student.FirstName;
                txtLop.Text = student.GradeId.ToString();
            }
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text) || !int.TryParse(txtLop.Text, out var gradeId))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin (Họ, Tên, Lớp).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                FirstName = txtTen.Text,
                LastName = txtHo.Text,
                GradeId = gradeId
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/StudentApi", student);
                if (response.IsSuccessStatusCode)
                {
                    LoadStudents();
                    ClearInputs();
                    MessageBox.Show("Thêm sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thêm sinh viên thất bại: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_edit_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text) || !int.TryParse(txtLop.Text, out var gradeId))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin (Họ, Tên, Lớp).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                StudentId = selectedStudentId.Value,
                FirstName = txtTen.Text,
                LastName = txtHo.Text,
                GradeId = gradeId
            };

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/StudentApi/{student.StudentId}", student);
                if (response.IsSuccessStatusCode)
                {
                    LoadStudents();
                    ClearInputs();
                    MessageBox.Show("Sửa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Sửa sinh viên thất bại: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_del_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/StudentApi/{selectedStudentId}");
                if (response.IsSuccessStatusCode)
                {
                    LoadStudents();
                    ClearInputs();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Xóa sinh viên thất bại: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            LoadStudents(textBox3.Text.Trim());
        }

        private void ClearInputs()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtLop.Text = "";
            selectedStudentId = null;
            dataGridView1.ClearSelection();
        }
    }

    // Lớp StudentDto để hiển thị dữ liệu trong DataGridView
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
    }
}