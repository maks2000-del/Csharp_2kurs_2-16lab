using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace oop_2_lab
{
    public partial class Form1 : Form
    {
        static string str = "";
        static void writetofile(string s, bool tf)
        {
            if (tf)
            {
                using (StreamWriter sw = new StreamWriter($"Sort.txt"))
                {
                    sw.WriteLine(str);
                }
            }
            else str = s;

        }
        static Form2 show_settings(main_form mf)
        {
            
                Form2 newForm = new Form2();
                newForm.label1.Text = $"{mf.height.Name}";
            
            return newForm;
        }
        static void about()
        {
            Form2 newForm = new Form2();
            newForm.label1.Text = "Shakalsky v1.0";
            newForm.Show();
        }
        static void item_info(Label l, good g)
            {
            if (g != null)
            {
                l.Text = $"Индекс товара: {g.ID}\n" +
                $"Название товара: {g.Name}\n" +
                $"Вес товара: {g.Weight}\n" +
                $"Примечания: {g.Notes}\n" +
                $"Тип товара: {g.Type}\n" +
                $"Дата поступления товара товара: {g.Date}\n" +
                $"Количество: {g.Quantity}\n" +
                $"Цена товара: {g.Price}\n";
            }
            else l.Text = "объект не найден :c";
            }


    }
}
