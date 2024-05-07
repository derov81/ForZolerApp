using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace ForZollerApp
{
    public partial class Form1 : Form
    {
        //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        Form2 create_list_tools;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "EvoM", "EcoS", "Hedelius" ,"Chiron1", "Chiron2", "EcoH","EvoH"});
           
        }

       public int Number_of_lines(string patH)
        {
            int count = 0;
            string line;
            TextReader reader = new StreamReader(patH);
            while ((line = reader.ReadLine()) != null)
            {
                count++;
            }
            reader.Close();
            return count;
        }

        string Scan(string path2)
        {
            string keyword = "ZActual";
            string result = null;
            string result2 = null;
            string str = null;
            
            using (StreamReader reader = new StreamReader(path2))
            {
                Regex regex = new Regex("\\b" + keyword + "\\b", RegexOptions.IgnoreCase);

                while ((result = reader.ReadLine()) != null)
                {
                    if (regex.IsMatch(result))
                    {
                        result2 = Regex.Replace(result, @"[^0-9,]", "");
                        str = Regex.Replace(result2, "331", "");

                    }


                }
            }

            return str;
        }


       public string Scan_Input(string path3)
        {
            
            string result = null;
            string text = null;
            //string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "settings.txt");
            var file = File.ReadAllLines(path3);
            int kol = Number_of_lines(@"c:\input_tools.txt");
            int r = kol;
            // string fileSettings = File.ReadAllText(fileName);

          //  listBox1.Items.Add($"Адаптер: {comboBox1.SelectedItem.ToString()} Деталь: {textBox1.Text}");
            Save_Title(@"c:\test.txt");
            foreach (var item in file)
                    {
                        result = item;
                //@"c:\home\zoller\backup\pilot_1\Log\BaseToolMeasureResultData_Transform_2.txt"
                text = Scan(@"c:\home\zoller\backup\pilot_1\Log\BaseToolMeasureResultData_Transform_2.txt");
                listBox1.Items.Add($"Инструмент: {result}\t вылет Z= {text}");
                Save_File(@"c:\test.txt", text, result);               
                MessageBox.Show($"Продолжить замер? , {r}/{kol.ToString()}");
                r--;
                        
                    }
              
            listBox1.Items.Add($"All tools: {Number_of_lines(@"c:\input_tools.txt")}");

            return result;
        }

        void Save_File(string path, string text, string tools)
        {
            // запись в файл
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{tools}\t Z={text}");
                writer.Close();
            }
        }

        void Save_Title(string path)
        {
            try
            {
                // запись в файл
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                   
                        writer.WriteLine($"Адаптер: {comboBox1.SelectedItem.ToString()} Деталь: {textBox1.Text}");
                        string s = string.Format($"Адаптер: {comboBox1.SelectedItem.ToString()} Деталь: {textBox1.Text}");
                        listBox1.Items.Add(s);
                        writer.Close();
                 
                }

            }

            catch(NullReferenceException )
            { MessageBox.Show("Укажите адаптер и/или деталь(операция)"); }

            finally { }
           
        }






        private void button1_Click(object sender, EventArgs e)
        {


            string input_tools = @"c:\input_tools.txt";
            Scan_Input(input_tools);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            create_list_tools = new Form2();

            create_list_tools.ShowDialog();
        }







        /*private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream;

            string fileName = System.IO.Path.Combine(Environment.CurrentDirectory, "settings.txt");
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // запись в файл
                    using (StreamWriter writer = new StreamWriter(fileName, false))
                    {
                        writer.WriteLine(saveFileDialog1.FileName);
                       
                       
                        writer.Close();
                    }


                    myStream.Close();
                }
            }
        }*/
    }
}
