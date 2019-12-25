using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    enum CurrencyTypes { UAH, USD, EU }

    class Money
    {

        // 2) declare 2 properties Amount, CurrencyType
        public double Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        // 3) declare parameter constructor for properties initialization
        public Money(double amount, CurrencyTypes currencyType)
        {
            Amount = amount;
            CurrencyType = currencyType;
        }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static double operator +(Money m1, Money m2)
        {
            return m1.Amount + m2.Amount;
        }
        public static double operator +(Money m1, double m2)
        {
            return m1.Amount + m2;
        }
        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money m1)
        {
            Money money = new Money(--m1.Amount, m1.CurrencyType);
            return money;
        }

        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money m1, int m2)
        {
            Money money = new Money(m1.Amount * m2, m1.CurrencyType);
            return money;
        }
        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator <(Money m1, Money m2)
        {
            return m1.Amount < m2.Amount;
        }
        public static bool operator >(Money m1, Money m2)
        {
            return m1.Amount > m2.Amount;
        }
        public static bool operator <(Money m1, string m2)
        {
            if (!int.TryParse(m2, out int money))
            {
                Console.Write("Entered value is uncorrect ");
                return false;
            }
            return m1.Amount < money;
        }
        public static bool operator >(Money m1, string m2)
        {
            if (!int.TryParse(m2, out int money))
            {
                Console.Write("Entered value is uncorrect ");
                return false;
            }
            return m1.Amount > money;
        }
        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money m1)
        {
            if (m1.CurrencyType == CurrencyTypes.USD || m1.CurrencyType == CurrencyTypes.EU)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Money m1)
        {
            if (m1.CurrencyType != CurrencyTypes.USD || m1.CurrencyType != CurrencyTypes.EU)
            {
                return true;
            }
            return false;
        }
        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static explicit operator double(Money m)
        {
            return (double)m.Amount;
        }
        public static explicit operator Money(double m)
        {
            Money money = new Money(m, CurrencyTypes.EU);
            return money;
        }
        public static explicit operator string(Money m)
        {
            return m.Amount.ToString()+" "+m.CurrencyType.ToString();
        }
        public static explicit operator Money(string m)
        {
            Money resultMoney = null;
            if (!double.TryParse(m, out double money))
            {
                Console.WriteLine("Entered value is uncorrect");
            }
            else
            {
                resultMoney = new Money (money, CurrencyTypes.EU);
            }
            return resultMoney;
        }
        public override string ToString()
        {
            return Amount.ToString() +" "+ CurrencyType.ToString();
        }
    }
}
