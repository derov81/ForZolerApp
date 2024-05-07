using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ForZollerApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            var values = new AutoCompleteStringCollection();
            values.AddRange(new string[] 
            { "F1_R", 
              "F1_F",
              "F2_R", 
              "F2_F",
              "CENTR_1",
              "CENTR_1.6",
              "CENTR_2",
              "CENTR_2.5",
              "CENTR_3",
              "CENTR_3.15",
              "C2",
              "C3",
              "C4",
              "C5",
              "C6",
              "DRIL_0.5",
              "DRIL_0.6"
            
            
            
            });
            comboBox1.AutoCompleteCustomSource = values;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

       

        private void button1_Click(object sender, EventArgs e)
        {


          
                string str = string.Format($"{listBox1.Items.Count+1}_{comboBox1.Text}");

                listBox1.Items.Add(str);

           
            
               
                
          
            
        }
    }
}
