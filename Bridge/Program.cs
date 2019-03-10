using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved ");
        }

        public abstract void Send(Body body);

    }

    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender",body.Title);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was  sent SmsSender", body.Text);
        }
    }

    class Body
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title="Bridge DesignPattern",Text="Brid Course Sendered"});
            Console.WriteLine("Customer Updated");
        }
    }

    class NewCustomerManager : CustomerManager //Refind Bridge 
    {
        public NewCustomerManager()
        {

        }
    }
}
