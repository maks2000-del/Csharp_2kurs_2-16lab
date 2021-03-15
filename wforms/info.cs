using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace oop_2_lab
{
    public partial class Form1 : Form
    {
        //параметры товара порожд повед структур
        class ID
        {
            public int Name { get; set; }
        }
        class Weight
        {
            public int Name { get; set; }
        }
        
        class GoodName
        {
            [Required(ErrorMessage = "Не указано название товара")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия")]
            public string Name { get; set; }
        }
        class Date
        {
            public DateTime date;
            public string Name { get { return date.ToLongDateString(); } }
        }
        class Quantity
        {
            public int Name { get; set; }
        }
        class Price
        {
            public int Name { get; set; }
        }
        class Tovar
        {
            public ID ID { get; set; }
            public Weight Weight { get; set; }
            public GoodName GoodName { get; set; }
            public Date Date { get; set; }
            public Quantity Quantity { get; set; }
            public Price Price { get; set; }

            public void Build(Label l)
            {
                l.Text = $"Индекс товара: {ID.Name}\n" +
               $"Название товара: {GoodName.Name}\n" +
               $"Вес товара: {Weight.Name}\n" +
               $"Дата поступления товара товара: {Date.Name}\n" +
               $"Количество: {Quantity.Name}\n" +
               $"Цена товара: {Price.Name}\n";
            }
        }
        // абстрактный класс строителя
        abstract class TovarBuilder
        {
            public Tovar Tovar { get; private set; }
            public void CreateTovar()
            {
                Tovar = new Tovar();
            }
            public abstract void SetID(TextBox tb);
            public abstract void SetWeight(TrackBar tb);
            public abstract void SetGoodName(TextBox tb);
            public abstract void SetDate(DateTimePicker dt);
            public abstract void SetQuantity(TextBox tb);
            public abstract void SetPrice(TextBox tb);
        }
        // клиент
        class User
        {
            public Tovar Make(TovarBuilder tovarBuilder, TextBox textBox2, TextBox textBox6, TextBox textBox1, TextBox textBox3, TrackBar trackBar1, DateTimePicker dateTimePicker1)
            {
                tovarBuilder.CreateTovar();
                tovarBuilder.SetID(textBox2);
                tovarBuilder.SetWeight(trackBar1);
                tovarBuilder.SetGoodName(textBox6);
                tovarBuilder.SetDate(dateTimePicker1);
                tovarBuilder.SetQuantity(textBox1);
                tovarBuilder.SetPrice(textBox3);
                return tovarBuilder.Tovar;
            }
        }
        // строитель для дефолтного товара
        class StandartTovar : TovarBuilder
        {
            public override void SetID(TextBox textBox2)
            {
                this.Tovar.ID = new ID { Name = Convert.ToInt32(textBox2.Text) };
            }
            public override void SetWeight(TrackBar trackBar1)
            {
                this.Tovar.Weight = new Weight { Name = trackBar1.Value };
            }
            public override void SetGoodName(TextBox textBox6)
            {
                this.Tovar.GoodName = new GoodName { Name = textBox6.Text };
            }
            public override void SetDate(DateTimePicker dateTimePicker1)
            {
                this.Tovar.Date = new Date { date = dateTimePicker1.Value };
            }
            public override void SetQuantity(TextBox textBox1)
            {
                this.Tovar.Quantity = new Quantity { Name = Convert.ToInt32(textBox1.Text) };
            }
            public override void SetPrice(TextBox textBox3)
            {
                this.Tovar.Price = new Price { Name = Convert.ToInt32(textBox3.Text) };
            }
        }
    }
    public class goodIDAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string ID = value.ToString();
                if (!ID.StartsWith("0"))
                    return true;
                else
                    this.ErrorMessage = "ID не должно начинаться с 0";
            }
            return false;
        }
    }
    public interface IGood
    {
        IGood Clone();
    }
    public partial class Form1 : Form
    {
    
        [Serializable]
       public class good : IGood
        {

            public good( int ID, int Weight, string Name, int Quantity, int Price)
            {
                this.ID = ID;
                this.Weight = Weight;
                this.Name = Name;
                this.Quantity = Quantity;
                this.Price = Price;
            }
            public good()
            { 
                
            }
            public IGood Clone()
            {
                return new good(this.ID, this.Weight, this.Name, this.Quantity, this.Price);
            }
            [Required]
            [goodID]
            public int ID { get; set; }
            public int Weight { get; set; }
            [Required(ErrorMessage = "Не указано название товара")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия")]
            public string Name { get; set; }
            public string Notes { get; set; }
            public string Type { get; set; }

            public DateTime date;
            public string Date { get { return date.ToLongDateString(); }  }
            public int Quantity { get; set; }
            public int Price { get; set; }

            // сохранение состояния
            public goodMemento SaveState()
            {
                return new goodMemento(ID, Weight, Name, Quantity, Price);
            }

            // восстановление состояния
            public void RestoreState(goodMemento memento)
            {
                this.ID = memento.ID;
                this.Weight = memento.Weight;
                this.Name = memento.Name;
                this.Quantity = memento.Quantity;
                this.Price = memento.Price;
            }
        }
        public class goodMemento
        {
            public int ID { get; set; }
            public int Weight { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }

            public goodMemento(int ID, int Weight, string Name, int Quantity, int Price)
            {
                this.ID = ID;
                this.Weight = Weight;
                this.Name = Name;
                this.Quantity = Quantity;
                this.Price = Price;
            }
        }

        // Caretaker
        public class goodHistory
        {
            public Stack<goodMemento> History { get; private set; }
            public goodHistory()
            {
                History = new Stack<goodMemento>();
            }
        }
        // decorator //
        abstract class Decorator : good
        {
            protected good good;
            public Decorator(int ID, int Weight, string Name, int Quantity, int Price, good g) : base(ID, Weight, Name, Quantity, Price)
            {
                this.good = g;
            }
        }
        class wrap : Decorator
        {
            public wrap(good g) : base(g.ID, g.Weight, g.Name, g.Quantity, g.Price + 3, g)
            { }

        }
        // decorator //
        // state //
        class Saver 
        {
            public ISaverState State { get; set; }

            public Saver(ISaverState ws)
            {
                State = ws;
            }

            public void Update(Label lb)
            {
                State.Update(this, lb);
            }
            public void Backup(Label lb)
            {
                State.Backup(this, lb);
            }
        }

        interface ISaverState
        {
            void Update(Saver water, Label lb);
            void Backup(Saver water, Label lb);
        }
        class OLevelGoodState : ISaverState
        {
            public void Update(Saver good, Label lb) 
            {
                good.State = new FirstLevelGoodState();
                lb.Text = "товар введён";
            }

            public void Backup(Saver good, Label lb) { }
        }
        class FirstLevelGoodState : ISaverState
        {
            public void Update(Saver good, Label lb)
            {
                lb.Text = "товар сохранён в буфер"; 
                good.State = new SecondLevelGoodState();
            }

            public void Backup(Saver good, Label lb) { }
        }
        class SecondLevelGoodState : ISaverState
        {
            public void Update(Saver good, Label lb)
            {
                lb.Text = "товар сохранён в файл";
                good.State = new ThirdLevelGoodState();
            }

            public void Backup(Saver good, Label lb)
            {
                lb.Text = "товар введён";
                good.State = new FirstLevelGoodState();
            }
        }
        class ThirdLevelGoodState : ISaverState
        {
            public void Update(Saver good, Label lb) { }

            public void Backup(Saver good, Label lb)
            {
                lb.Text = "товар сохранён в буфер";
                good.State = new SecondLevelGoodState();
            }
        }
        // state //
    }
}
