using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyWork
{
    public partial class frmExportExcel : Form
    {
        public List<string> AvailableColumns { get; private set; }
        public bool IsClosedWithButton { get; private set; } = false;

        public frmExportExcel(List<string> availableColumns)
        {
            InitializeComponent();
            AvailableColumns = availableColumns;

            // Thêm cột tên cột và cột ô chọn vào DataGridView
            DataGridViewTextBoxColumn columnNameColumn = new DataGridViewTextBoxColumn();
            columnNameColumn.Name = "ColumnName";
            columnNameColumn.HeaderText = "Tên cột";
            columnNameColumn.FillWeight = 70; // Thiết lập FillWeight cho cột tên cột
            dataGridView1.Columns.Add(columnNameColumn);

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "ColumnCheckbox";
            checkBoxColumn.HeaderText = "Xuất excel";
            checkBoxColumn.FillWeight = 30; // Thiết lập FillWeight cho cột ô chọn
            dataGridView1.Columns.Add(checkBoxColumn);

            // Điền dữ liệu vào DataGridView
            foreach (string columnName in AvailableColumns)
            {
                int rowIndex = dataGridView1.Rows.Add(columnName, true); // Đặt giá trị mặc định là true
                                                                         // Thay đổi màu nền của dòng thành màu vàng
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }

            // Thiết lập để cột tự động điều chỉnh chiều rộng dựa trên FillWeight
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem cột thay đổi có phải là ColumnCheckbox và dòng không phải là dòng mới
            if (e.ColumnIndex == dataGridView1.Columns["ColumnCheckbox"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["ColumnCheckbox"];

                // Kiểm tra giá trị ô ColumnCheckbox
                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);

                // Thay đổi màu nền của dòng dựa trên giá trị ô ColumnCheckbox
                if (isChecked)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    // Nếu không chọn, sử dụng màu nền mặc định của DataGridView
                    row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                }
            }
        }

        // Các phương thức và sự kiện khác của form...

        public List<string> GetSelectedColumns()
        {
            // Kiểm tra xem form có đóng bằng nút Đóng hay không
            if (IsClosedWithButton)
            {
                // Nếu form được đóng bằng nút Đóng, trả về null
                return null;
            }
            // Lấy danh sách các cột đã chọn
            List<string> selectedColumns = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["ColumnCheckbox"];
                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    selectedColumns.Add(row.Cells["ColumnName"].Value.ToString());
                }
            }
            return selectedColumns;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Xử lý khi người dùng nhấn nút OK
            List<string> selectedColumns = GetSelectedColumns();
            // Đóng form hoặc thực hiện các hành động khác dựa trên cột đã chọn
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsClosedWithButton = true;
            List<string> selectedColumns = GetSelectedColumns();
            this.Close();
        }

        private void btnChonTatCa_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["ColumnCheckbox"];
                checkBoxCell.Value = true;

                // Thay đổi màu nền của dòng thành màu vàng
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void btnBoChonTatCa_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["ColumnCheckbox"];
                checkBoxCell.Value = false;
                // Thay đổi màu nền của dòng thành màu vàng
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
