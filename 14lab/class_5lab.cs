using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_lab_oop
{
    
    [Serializable]
    public partial class Publishing_house
    {
        //запрет на сериализацию
        [NonSerialized]
        public string accNumber;

        public string Name;
        

        public Publishing_house()
        {
            Console.WriteLine("был вызван конструкотр по умолчанию");
        }
        public Publishing_house(string Name)
        {
            this.Name = Name;
        }

        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Publishing_house person = (Publishing_house)obj;
            return (this.Name == person.Name);
        }

    }
    [Serializable]
    public class Print_addition : Publishing_house
    {
        public string Type;

        public Print_addition(string Type, string Name) : base(Name)
        {
            this.Type = Type;
        }
        public Print_addition() 
        {
            
        }
    }
}
