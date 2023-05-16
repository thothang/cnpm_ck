﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace WindowsFormsApp1
{
    public partial class QuanLyBanHang : Form
    {

        public QuanLyBanHang()
        {
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                bool dataExists = false;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == selectedRow.Cells[0].Value.ToString()
                        && row.Cells[1].Value != null && row.Cells[1].Value.ToString() == selectedRow.Cells[1].Value.ToString()
                        && row.Cells[2].Value != null && row.Cells[2].Value.ToString() == selectedRow.Cells[2].Value.ToString())
                    {
                        dataExists = true;
                        int quantity = Convert.ToInt32(row.Cells[3].Value) + 1;
                        row.Cells[3].Value = quantity;
                        row.Cells[4].Value = Convert.ToDouble(row.Cells[2].Value) * quantity;
                        break;
                    }
                }

                if (!dataExists)
                {
                    int index = dataGridView2.Rows.Add();
                    dataGridView2.Rows[index].Cells[0].Value = selectedRow.Cells[0].Value;
                    dataGridView2.Rows[index].Cells[1].Value = selectedRow.Cells[1].Value;
                    dataGridView2.Rows[index].Cells[2].Value = selectedRow.Cells[2].Value;
                    dataGridView2.Rows[index].Cells[3].Value = 1;
                    dataGridView2.Rows[index].Cells[4].Value = Convert.ToDouble(selectedRow.Cells[2].Value);
                }
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }



        private void cssButton2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log_in back = new Log_in();
            back.Closed += (s, args) => this.Close();
            back.Show();

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }




        QuanLyBanHangModel QLBHMD = new QuanLyBanHangModel();
        public void LoadData()
        {
            List<Dictionary<string, string>> rows = QLBHMD.FatchAllReader();
            foreach (Dictionary<string, string> row in rows)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = row["MaHH"];
                dataGridView1.Rows[index].Cells[1].Value = row["TenHH"];
                dataGridView1.Rows[index].Cells[2].Value = row["Gia"];
            }
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataToComboBox();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_reset_Click(object sender, EventArgs e)
        {

            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                double quantity = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
                double total = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                double newRowValue = quantity * total;
                dataGridView2.Rows[i].Cells[4].Value = newRowValue.ToString();
                sum += newRowValue;
            }
            double selectedItem;
            if (comboBox1.SelectedItem == null)
            {
                selectedItem = 0;
            }
            else
            {
                KhuyenMaiModel kmmodel = new KhuyenMaiModel(comboBox1.SelectedItem.ToString(), "");
                selectedItem = Convert.ToDouble(kmmodel.TiLeKhuyenMai(ConnectionSingleton.GetConnection()));
            }

            textbox3.Texts = sum.ToString();
            textbox4.Texts = (sum * selectedItem / 100).ToString();
            textbox5.Texts = (sum * 0.01).ToString();
            textbox6.Texts = (sum + sum * 0.01 - (sum * selectedItem / 100)).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(row.Index);
                ResetData();
            }
        }

        private void LoadDataToComboBox()
        {
            KhuyenMaiModel model = new KhuyenMaiModel();
            List<Dictionary<string, string>> data = model.FatchAllReader();

            foreach (Dictionary<string, string> row in data)
            {
                comboBox1.Items.Add(row["MaKM"]);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i] != null && dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() != textBox1.Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuanLyHoaDonModel hoaDonModel = new QuanLyHoaDonModel();
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }



                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value == null)
                                    {

                                    }
                                    else
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }

                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        private void tab_laphoadon_Click(object sender, EventArgs e)
        {

        }

        public void ResetData()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

        private void ClearDataGridView()
        {
            dataGridView2.Rows.Clear();
            for (int i = dataGridView2.Rows.Count - 1; i >= 1; i--)
            {
                dataGridView2.Rows.RemoveAt(i);
            }
        }
    }
}





