using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pull__Confirmation
{
   
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        int indexRow;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (textBox1.Text.Length > 7 && textBox1.Text.Length < 9)
                {
                    if (textBox2.Text.Length > 5 && textBox2.Text.Length < 8)
                    {
                        dt.Rows.Add(textBox1.Text, textBox2.Text);
                        this.dataGridView1.DataSource = dt;
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("{Please enter valid Operator ID");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please enter valid policy number");
                }
             
            }
            else
            {
                MessageBox.Show("Please provide details");
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("PolicyNo",typeof(string)),
                new DataColumn("OperatorID", typeof(string))});
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
        }

        private void ClearData()
        {
            textBox2.Text = "";
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
           if(textBox1.Text !="" && textBox2.Text != "")
           {
               if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
               {
                   DataGridViewRow newDatarow = dataGridView1.Rows[indexRow];
                   newDatarow.Cells[0].Value = textBox1.Text;
                   newDatarow.Cells[1].Value = textBox2.Text;
                   ClearData();
               }
           }
           else
           {
               MessageBox.Show("Please select Record to Update");
           }
         }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to Delet this Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowindex = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowindex);
                    }
                    else
                    {
                        MessageBox.Show("Rows Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please select Record to Delete");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\periy\Desktop\pull_confirmation.txt");
            for (int i = 0; i < dataGridView1.Rows.Count-1;i++){
                for (int j = 0; j < dataGridView1.Columns.Count;j++){
                   writer.Write(" "+dataGridView1.Rows[i].Cells[j].Value.ToString()+" ");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Message Exported");
        }
       



        
    }
}
