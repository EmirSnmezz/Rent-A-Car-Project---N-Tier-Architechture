using Business.Concrete;
using ConsoleUI;
using Entities.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());

        foreach(Car car in carManager.GetAll())
        {
            Console.WriteLine(
                $"Brand : {car.Brand.Name}\n" +
                $"Model : {car.Model.Name}\n" + 
                $"Color : {car.Color.Name}\n" +
                $"Gearbox: {car.GearBoxOption}\n" +
                $"Year : {car.ModelYear} \n" +
                $"Is Rented : {car.IsRented} \n" +
                $"Company Name: {car.Company.Name}"
                );
        }
    }
}
