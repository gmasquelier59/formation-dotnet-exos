using Exercice09_Hotel.Classes;
using Spectre.Console;
using System.Runtime.InteropServices;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int roomNumber = 0;
        List<Room> rooms = Enumerable.Range(0, 10).Select(x =>
        {
            Random rand = new Random();
            roomNumber++;
            if (roomNumber == 13)
                roomNumber++;
            return new Room(roomNumber, (RoomStatus)rand.Next(1, 4), 5, (decimal)rand.Next(50, 500));
        }).ToList();

        Hotel hotel = new Hotel("Hôtel Ducsman *****", rooms);

        hotel.AddClient(new Client("MASQUELIER", "Guillaume", "0612345678"));
        hotel.AddClient(new Client("DUPONT", "Jean", "0789457215"));
        hotel.AddClient(new Client("SMITH", "John", "+3256456566565"));

        List<Room> occupiedRooms = hotel.FindRoomsByStatus(RoomStatus.Occupied);
        foreach(Room room in occupiedRooms)
        {
            Random rand = new Random();
            Client client = hotel.Clients[rand.Next(0, hotel.Clients.Count)];
            hotel.AddBooking(new Booking(BookingStatus.OnGoing, room, client));
        }

        //  AFFICHAGE

        Layout layoutTitle = new Layout("Title");
        Layout layoutContent = new Layout("Content");
        layoutContent.Ratio = 6;

        var layout = new Layout("Root")
            .SplitRows(
                layoutTitle,
                layoutContent
                .SplitColumns(
                    new Layout("Rooms"),
                    new Layout("Right")
                        .SplitRows(
                            new Layout("Clients"),
                            new Layout("Booking"))));

        layout["Title"].Update(
            new Panel(
                Align.Center(
                    new Markup($"[blue]{hotel.Name}[/]")))
                );

        StringBuilder clientsList = new StringBuilder();
        foreach (Client client in hotel.Clients)
            clientsList.AppendLine(client.ToString());

        StringBuilder roomsList = new StringBuilder();
        foreach (Room room in hotel.Rooms.OrderBy(x => x.Status))
            roomsList.AppendLine(room.ToString());

        StringBuilder bookingsList = new StringBuilder();
        foreach (Booking booking in hotel.Bookings.OrderBy(x => x.Status))
            bookingsList.AppendLine(booking.ToString());

        layout["Clients"].Update(
            new Panel(
                    new Markup(clientsList.ToString())).Header($"Clients ({hotel.Clients.Count})").Expand()
                );

        layout["Rooms"].Update(
            new Panel(
                    new Markup(roomsList.ToString())).Header($"Rooms ({hotel.Rooms.Count}) - [green]{hotel.Rooms.Where(x => x.Status == RoomStatus.Free).Count()} free[/] - [red]{hotel.Rooms.Where(x => x.Status == RoomStatus.Occupied).Count()} occupied[/] - [blue]{hotel.Rooms.Where(x => x.Status == RoomStatus.InCleaning).Count()} in cleaning[/]").Expand()
                );

        layout["Booking"].Update(
            new Panel(
                new Markup(bookingsList.ToString())).Header($"Booking ({hotel.Bookings.Count})").Expand()
        );

        AnsiConsole.Write(layout);

        Console.ReadKey();
    }
}