// See https://aka.ms/new-console-template for more information
using NotificationSystem;
Console.WriteLine("Hello, World!");

var pubsubsystem = new PubSubSystem();
var firstSubscriber = new Subscriber { Name = "FirstSubscriber" };
var secondSubscriber = new Subscriber { Name = "SecondSubscriber" };
var thirdSubscriber = new Subscriber { Name = "ThirdSubscriber" };
var publisher = new Publisher(pubsubsystem);    
pubsubsystem.Subscribe(1, firstSubscriber);
pubsubsystem.Subscribe(2, secondSubscriber);
pubsubsystem.Subscribe(3, thirdSubscriber);

publisher.Publish(new Message("Hello Subscribers!",  1));
Console.ReadKey();
publisher.Publish(new Message("Hello Subscribers!", 2));
Console.ReadKey();
publisher.Publish(new Message("Hello Subscribers!", 3));
Console.ReadKey();
