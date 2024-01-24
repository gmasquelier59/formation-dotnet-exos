using Hotel.Classes;
using Hotel.Classes.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        //Hotel.Classes.Hotel hotel = new Hotel.Classes.Hotel();
        //hotel.Nom = "Hôtel Concordia *****";

        //HotelRepository.Save(hotel);

        Hotel.Classes.Hotel hotel = HotelRepository.GetById(2);

        Chambre chambre = new Chambre(1, 2, 50);
        ChambreRepository.Save(chambre);

        hotel.Chambres.Add(chambre);

        HotelRepository.Update(hotel);
    }
}