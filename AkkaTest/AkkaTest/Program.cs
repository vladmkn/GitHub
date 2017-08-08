using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Akka;
using Akka.Actor;

namespace AkkaTest
{
    public class Greet
    {
        public Greet(string who)
        {
            Who = who;
        }
        public string Who { get; private set; }
    }

    public class GreetingActor : ReceiveActor
    {
        string fName = String.Empty;

        public GreetingActor(int k)
        {
            IActorRef myActor = null;

            fName = String.Format("greeter{0}", k);

            if (k == 100000 || k == 90000 || k == 80000 || k == 70000 ||
                k == 60000 || k == 50000 || k == 40000 ||
                k == 30000 || k == 20000 || k == 10000) Console.WriteLine(fName);

            if (--k > 0)
            {
                myActor = Context.ActorOf(GreetingActor.Props(k), String.Format("greeter{0}", k));
            }
            
            // Сказать актору реагировать
            // на Greet (Приветствие) сообщение
            Receive<Greet>(greet => {
                Console.WriteLine("Hello {0}: {1}", greet.Who, k);
                //if(myActor != null) myActor.Tell(new Greet(String.Format("World{0}",k)));
                });

        }

        public static Props Props(int magicNumber)
        {
            return Akka.Actor.Props.Create(() => new GreetingActor(magicNumber));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создать новую систему акторов (контейнер для ваших акторов)
            var system = ActorSystem.Create("MySystem");

            // Создать вашего актора и получить ссылку на него.
            // Это будет "ActorRef", который не является
            // ссылкой на текущий экземпляр актора,
            // но является клиентом или прокси к нему.
            var greeter = system.ActorOf(GreetingActor.Props(100000), String.Format("greeter{0}", 100));

            // Отправить сообщение актору
            greeter.Tell(new Greet("World"));

            //var n = system.ActorSelection("greeter55000");
                
            //n.Tell(new Greet("World"));

            // Это блокирует выход из приложения
            // до тех пор, пока асинхронная работа
            // не будет выполнена.
            Console.ReadLine();
        }
    }
}
