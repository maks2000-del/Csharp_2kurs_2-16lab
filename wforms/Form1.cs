using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System.ComponentModel.DataAnnotations;

namespace oop_2_lab
{
    public partial class Form1 : Form
    {
        Saver water = new Saver(new OLevelGoodState());
        good g = new good();
        List<good> list = new List<good>();
        goodHistory history = new goodHistory();
        public int curent_num;

        private void Form1_Load(object sender, EventArgs e)
        {
            // установка обработчика события Scroll
            trackBar1.Scroll += trackBar1_Scroll;
            comboBox2.Items.AddRange(new string[] { "по ID", "по названию", "по примечанию", "по цене" });
            g.Type = "без примечаний";
            g.date = DateTime.Now;
        }
        public Form1()
        {
            InitializeComponent();
        }
        /////////////////////////////singleton////////////////////////////////////////
        class main_form
        {
            public settings height { get; set; }
            public void Launch(string height, string width, string color, string font)
            {
                this.height = settings.getInstance(height, width ,color, font);
            }
        }
        class settings
        {
            private static settings instance;

            public string Name { get; private set; }

            protected settings(string name1, string name2, string name3, string name4)
            {
                this.Name = name1 +" "+ name2 + " " + name3 + " " + name4;
            }

            public static settings getInstance(string name1, string name2, string name3, string name4)
            {
                if (instance == null)
                    instance = new settings(name1, name2, name3, name4);
                return instance;
            }
        }

        /////////////////////////////singleton////////////////////////////////////////
        XmlSerializer formatter = new XmlSerializer(typeof(good));
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public string ss(ComboBox cm, string message)
        {
            if (cm.SelectedItem is null)
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            else
                return cm.SelectedItem.ToString();
        }
        public void info(string message, int current_num,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            int defolt_num = 0;
            defolt_num += current_num;
            //количество объектов
            label15.Text = defolt_num.ToString();
            //последнее действие
            label14.Text = memberName;
            //дата и вермя
            label13.Text = DateTime.Now.ToString();

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Clear(); textBox5.Clear();
            string selectedState = ss(comboBox2, "выберите метод поиска");
                if (selectedState == "по цене") { textBox5.ReadOnly = false; label10.Text = "от"; label11.Text = "до"; }
                if (selectedState == "по ID") { textBox5.ReadOnly = true; label10.Text = "ID"; label11.Text = ""; }
                if (selectedState == "по названию") { textBox5.ReadOnly = true; label10.Text = "название"; label11.Text = ""; }
                if (selectedState == "по примечанию") { textBox5.ReadOnly = true; label10.Text = "примечание"; label11.Text = ""; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // содаем объект пекаря
            User user = new User();
            // создаем билдер для ржаного хлеба
            TovarBuilder builder = new StandartTovar();
            // выпекаем
            Tovar new_tovar = user.Make(builder, textBox2, textBox6, textBox1, textBox3, trackBar1, dateTimePicker1);
            // build
            new_tovar.Build(label1);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            IGood clonedGood = g.Clone();
            label1.Text = "объект клонирован"; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            water.Update(label12);
            item_info(label1, g);
        }
        protected void button2_Click(object sender, EventArgs e)
        {
            water.Update(label12);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(g);
            if (!Validator.TryValidateObject(g, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                using (FileStream fs = new FileStream($"{g.ID}.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, g);
                    label5.Text = "Объект сериализован";
                    curent_num++;
                }
                comboBox1.Items.Add(g.ID);
                using (FileStream fs = new FileStream($"{g.ID}.xml", FileMode.OpenOrCreate))
                {
                    good newg = (good)formatter.Deserialize(fs);
                    list.Add(newg);
                }
                info("", curent_num);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (ss(comboBox1, "нет сохранённых объектов") != "")
            {
                using (FileStream fs = new FileStream($"{comboBox1.SelectedItem}.xml", FileMode.OpenOrCreate))
                {
                    good g = (good)formatter.Deserialize(fs);

                    label5.Text = "Объект десериализован";

                    item_info(label1, g);
                    water.Backup(label12);
                    water.Backup(label12);
                }
                
            }
        }
        // паттерн memento сохранить и загрузить //
        private void button9_Click(object sender, EventArgs e)
        {
            water.Update(label12);
            history.History.Push(g.SaveState());
            //label12.Text = "сохранены\nтекущие парметры";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            g.RestoreState(history.History.Pop());
            water.Backup(label12);
            //label12.Text = "восстановлены\nсохранённые парметры";
        }
        // паттерн memento сохранить и загрузить //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { Convert.ToInt32(textBox1.Text);
                g.Quantity = Convert.ToInt32(textBox1.Text);
            }
            catch 
            {
               textBox1.Clear();
                g.Quantity = 0;
            }
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox2.Text);
                g.ID = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                textBox2.Clear();
                g.ID = 0;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox3.Text);
                g.Price = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                textBox3.Clear();
                g.Price = 0;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            g.Name = textBox6.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            g.date = dateTimePicker1.Value;
        }        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = String.Format($"вес: {trackBar1.Value} кг");
            g.Weight = trackBar1.Value;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                g.Type = "хрупкий товар";
            else g.Type = "без примечаний";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            g.Notes += "радиоактивный,";
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            g.Notes += "пища,";
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            g.Notes += "стекло,";
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            g.Notes += "большой размер;";
        }
        // для демонстрации декоратора
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            g = new wrap(g);
        }
        //о программе
        private void button7_Click(object sender, EventArgs e)
        {
            about();
        }
        // сортировка
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
            string str = "";
            if (checkBox7.Checked == true && checkBox6.Checked == false && checkBox5.Checked == false)
            {
                str = "";
                var selectedgoods = list.OrderBy(t => t.ID);
                
                    foreach (good s in selectedgoods)
                    {
                        newForm.label1.Text += $"{s.ID}" + $" {s.Name}\n";
                        str += $"{s.ID}" + $" {s.Name}\n";
                        
                    }
            }
                if (checkBox5.Checked == true && checkBox6.Checked == false && checkBox7.Checked == false)
                {
                str = "";
                var selectedgoods = list.OrderBy(t => t.Price);
                foreach (good s in selectedgoods)
                {
                    newForm.label1.Text += $"{s.ID}" + $" {s.Price}\n";
                    str += $"{s.ID}" + $" {s.Price}\n";
                }
            }
                if (checkBox6.Checked == true && checkBox5.Checked == false && checkBox7.Checked == false)
                {
                str = "";
                var selectedgoods = list.OrderBy(t => t.Date);
                foreach (good s in selectedgoods)
                {
                    newForm.label1.Text += $"{s.ID}" + $" {s.Date}\n";
                    str += $"{s.ID}" + $" {s.Date}\n";
                }
            }
                if(newForm.label1.Text=="") newForm.label1.Text = "Выберите что-то одно :3";

            writetofile(str, false);
        }
        //поиск
        private void button5_Click(object sender, EventArgs e)
        {
            good found = new good();
            List<good> found_list = new List<good>();

            string selectedState = ss(comboBox2, "выберите метод поиска");

            if (selectedState == "по названию")
            {
                Regex regex = new Regex(@"^" + textBox4.Text + @"(\w*)", RegexOptions.IgnoreCase);
                MatchCollection matches;
                foreach (good g in list)
                {
                    matches = regex.Matches(g.Name);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            label1.Text ="Полное название товара: " + match.Value;
                            break;
                        }
                    }
                }
            }
            
            if (selectedState == "по ID")
            {
                found = list.Find(item => item.ID == Convert.ToInt32(textBox4.Text));
                item_info(label1, found);
            }
            if (selectedState == "по примечанию")
            {
                found = list.Find(item => item.Notes.StartsWith(textBox4.Text));
                item_info(label1, found);
            }
            if (selectedState == "по цене")
            {
                found = list.Find(item => item.Price > Convert.ToInt32(textBox4.Text) && item.Price < Convert.ToInt32(textBox5.Text));
                item_info(label1, found);
            }

        }
        //меню
        //о программе
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            writetofile("", true);
        }
        //созранить результат сортировки
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            about();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            main_form mf = new main_form();
            mf.Launch(this.Height.ToString(), this.Width.ToString(), this.BackColor.ToString(), this.Font.ToString());
            show_settings(mf).Show();
        }























        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
