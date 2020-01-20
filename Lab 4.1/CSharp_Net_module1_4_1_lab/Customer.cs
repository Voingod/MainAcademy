using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Customer
    {
        // 6) declare private field name
        private string news;

        // 7) declare constructor to initialize name
        public Customer(string news)
        {
            this.news = news;
        }

        // 8) declare method GotNewGoods with 2 parameters:
        // 1 - object type
        // 2 - GoodsInfoEventArgs type
        public void GotNewGoods(object sender, GoodsInfoEventArgs goodsInfo)
        {
            Console.WriteLine(this.news + " " + goodsInfo.GoodsName);
        }

    }
}
