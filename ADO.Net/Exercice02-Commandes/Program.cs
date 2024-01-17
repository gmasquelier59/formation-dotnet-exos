using Exercice02_Commandes.Classes;
using Exercice02_Commandes.Classes.DAO;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Client client = new Client("BING", "Chandler", "495 Grove Street", "10014", "New York City", "+1 (646)649-3493");
//ClientDAO.Save(client);

Client client = ClientDAO.GetById(1);
Order order = new Order(client, DateTime.Now, 1000M);
client.AddOrder(order);
ClientDAO.Save(client);

//  ClientDAO.Delete(client);



//List<Client> clients = ClientDAO.All();
//foreach(Client client in clients)
//    AnsiConsole.MarkupLine(client.ToString());


AnsiConsole.MarkupLine(order.ToString());