using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 9) declare object of OnlineShop 
            OnlineShop onlineShop = new OnlineShop();
            // 10) declare several objects of Customer
            Customer customer1 = new Customer("New good");
            Customer customer2 = new Customer("New very good");
            Customer customer3 = new Customer("New super good");
            // 11) subscribe method GotNewGoods() of every Customer instance 
            // to event NewGoodsInfo of object of OnlineShop
            onlineShop.NewGoodsInfo += customer1.GotNewGoods;
            onlineShop.NewGoodsInfo += customer2.GotNewGoods;
            onlineShop.NewGoodsInfo += customer3.GotNewGoods;
            // 12) invoke method NewGoods() of object of OnlineShop
            onlineShop.NewGoods("Hmmm...");
            // discuss results

            Console.ReadLine();
        }
    }
}
