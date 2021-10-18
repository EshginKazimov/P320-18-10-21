using System;
using System.Text;

namespace SealedCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Kelvin ve Celsius(selsi) adli iki temperaturu gosteren klasslarimiz var ve
            //Degree adli property-leri var.
            //Celcius uchun implicit operatorunu yazmaginizi isteyirem.(0C=273K).
            //Input ve output console-da seliqeli ve aydin yazilishda olsun
            //(Meselen Kelvin = 273K ve s.)

            #region Sealed



        #endregion

            #region Upcasting, boxing, implicit

        Email e1 = new Email("Test", "Hello World!", "abc@abc.com");
            Email e2 = new Email("Test", "Hello World!", "abc@abc.com");
            Email e3 = new Email("Test", "Hello World!", "abc@abc.com");
            Email e4 = new Email("Test", "Hello World!", "abc@abc.com");
            //Print(e1);
            //Print(e2);
            //Print(e3);
            //Print(e4);

            Sms s1 = new Sms("Test", "Hello World", "1274815891758");
            //Print(s1);
            s1.Test = "";

            Notification s2 = new Sms("Test", "Hello World", "1274815891758");
            //s2.PhoneNumber
            //Print(s2);

            Notification n1 = s1;
            //n1.Tes

            #endregion

            #region Downcasting, unboxing, explicit

            Notification[] notifications = { e1, e2, e3, s1, s2, n1 };
            foreach (Notification item in notifications)
            {
                //Print(item);

                //Sms s11 = (Sms)item;
                //Console.WriteLine(s11.PhoneNumber);

                //if (item is Sms s11)
                //{
                //    //Sms s11 = (Sms)item;
                //    Console.WriteLine(s11.PhoneNumber);
                //}

                //Sms s11 = item as Sms;
                //if (s11 != null)
                //{
                //    Console.WriteLine(s11.PhoneNumber);
                //}

                //if (item is Email e11)
                //{
                //    Console.WriteLine(e11.MailAddress);
                //}
            }

            #endregion

            #region Object

            //Notification n2 = new Sms("", "", "1352352315215");
            //Console.WriteLine(n2.ToString());
            //Console.WriteLine(n2.GetType());

            //object o1 = s1;
            //object[] objects = { s1, e1, s2, 10, "safasf", true };
            //foreach (object item in objects)
            //{
            //    Console.WriteLine(item);
            //    //Console.WriteLine(item.ToString());
            //}

            //StringBuilder

            #endregion

            #region Operators in custom type

            Person p1 = new Person("Emil Kerimov", 25);
            Person p2 = new Person("Parviz Asadov", 20);

            //Console.WriteLine(p1 + p2);
            //Console.WriteLine(p1 > p2);
            //Console.WriteLine(p1 < p2);
            //Console.WriteLine(p1 == p2);
            //Console.WriteLine(2 + 2);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);
            //Console.WriteLine(p1.Age + p2.Age);

            #endregion

            #region Implicit, explicit

            //Dollar d1 = new Dollar(100);
            //Manat m1 = d1;
            //Console.WriteLine(m1.Value);
            ////Manat m1 = new Manat(d1.Value / 1.7);

            //Dollar d2 = (Dollar)m1;
            //Console.WriteLine(d2.Value);

            //Dollar d1 = new Dollar(100);
            ////Manat m1 = d1;
            //Manat m1 = new Manat(d1.Value / 1.7);

            //Dollar d1 = new Dollar(100);
            ////Manat m1 = d1;
            //Manat m1 = new Manat(d1.Value / 1.7);

            //Dollar d1 = new Dollar(100);
            ////Manat m1 = d1;
            //Manat m1 = new Manat(d1.Value / 1.7);

            //int a = 10;
            //long l = a;
            //int b = (int)l;
            //Console.WriteLine(b);

            long l = 1000000000000;
            int a = (int)l;
            Console.WriteLine(a);

            #endregion
        }

        static void Print(Notification notification)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            notification.Notify();
            Console.ResetColor();
        }

        //static void Print(Sms sms)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    sms.Notify();
        //    Console.ResetColor();
        //}

        //static void Print(Email email)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    email.Notify();
        //    Console.ResetColor();
        //}
    }

    class Dollar
    {
        public double Value { get; set; }

        public Dollar(double value)
        {
            Value = value;
        }

        //public static implicit operator Dollar(Manat manat)
        //{
        //    //Dollar d1 = new Dollar(manat.Value * 1.7);
        //    //return d1;
        //    return new Dollar(manat.Value / 1.7);
        //}

        public static explicit operator Dollar(Manat manat)
        {
            //Dollar d1 = new Dollar(manat.Value * 1.7);
            //return d1;
            return new Dollar(manat.Value / 1.7);
        }
    }

    class Manat
    {
        public double Value { get; set; }

        public Manat(double value)
        {
            Value = value;
        }

        public static implicit operator Manat(Dollar dollar)
        {
            return new Manat(dollar.Value * 1.7);
        }
    }

    class Person
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public Person(string fullname, int age)
        {
            FullName = fullname;
            Age = age;
        }

        public static int operator +(Person p1, Person p2)
        {
            return p1.Age + p2.Age;
        }

        public static bool operator >(Person p1, Person p2)
        {
            return p1.Age > p2.Age;
        }

        public static bool operator <(Person p1, Person p2)
        {
            return p1.Age < p2.Age;
        }
    }

    abstract class Notification 
    {
        public string Subject { get; }

        public string Text { get; }

        protected Notification(string subject, string text)
        {
            Subject = subject;
            Text = text;
        }

        public abstract void Notify();
    }

    class Sms : Notification
    {
        public string PhoneNumber { get; }

        public string Test;

        public Sms(string subject, string text, string phoneNumber) : base(subject, text)
        {
            PhoneNumber = phoneNumber;
        }

        public sealed override void Notify()
        {
            Console.WriteLine("Send as SMS");
        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }

    sealed class Email : Notification
    {
        public string MailAddress { get; }

        public Email(string subject, string text, string mailAddress) : base(subject, text)
        {
            MailAddress = mailAddress;
        }

        public override void Notify()
        {
            Console.WriteLine("Send as Email");
        }
    }

    //class Test : Sms
    //{
    //    public Test() : base("", "", "")
    //    {

    //    }

    //    public override void Notify()
    //    {
    //        Console.WriteLine("Send as Test");
    //    }
    //}
}
