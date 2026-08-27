using System;

// Abstract clas
abstract class Vehicle
{
    private int vehicleId;
    private string number;
    private int capacity;

    public Vehicle(int vehicleId, string number, int capacity)
    {
        this.vehicleId = vehicleId;
        this.number = number;
        this.capacity = capacity;
    }

    public int GetVehicleId()
    {
        return vehicleId;
    }

    public string GetNumber()
    {
        return number;
    }

    public int GetCapacity()
    {
        return capacity;
    }

    public abstract double CalculateFare(double distance);

    public abstract string GetType();

    public void Display()
    {
        Console.WriteLine(
            GetType() + " | ID: " + vehicleId +
            " | Number: " + number +
            " | Capacity: " + capacity);
    }
}


// Bus clas
class Bus : Vehicle
{
    public Bus(int id, string number, int capacity)
        : base(id, number, capacity)
    {
    }

    public override double CalculateFare(double distance)
    {
        return distance * 5;
    }

    public override string GetType()
    {
        return "Bus";
    }
}


// Taxi clas
class Taxi : Vehicle
{
    public Taxi(int id, string number, int capacity)
        : base(id, number, capacity)
    {
    }

    public override double CalculateFare(double distance)
    {
        return 50 + distance * 12;
    }

    public override string GetType()
    {
        return "Taxi";
    }
}


// Driver class
class Driver
{
    private int driverId;
    private string name;

    public Driver(int driverId, string name)
    {
        this.driverId = driverId;
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}


// Passenger clas
class Passenger
{
    private int passengerId;
    private string name;

    public Passenger(int passengerId, string name)
    {
        this.passengerId = passengerId;
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}


// Route clas
class Route
{
    private string source;
    private string destination;
    private double distance;

    public Route(string source, string destination, double distance)
    {
        this.source = source;
        this.destination = destination;
        this.distance = distance;
    }

    public double GetDistance()
    {
        return distance;
    }

    public void Display()
    {
        Console.WriteLine(
            source + " -> " + destination +
            " (" + distance + " km)");
    }
}


// Payment clas
class Payment
{
    private double amount;
    private string method;

    public Payment(double amount, string method)
    {
        this.amount = amount;
        this.method = method;
    }

    public void Display()
    {
        Console.WriteLine(
            "Payment: Rs." + amount + " by " + method);
    }
}


// Booking clas
class Booking
{
    private int bookingId;
    private Passenger passenger;
    private Vehicle vehicle;
    private Driver driver;
    private Route route;
    private Payment payment;

    public Booking(
        int bookingId,
        Passenger passenger,
        Vehicle vehicle,
        Driver driver,
        Route route)
    {
        this.bookingId = bookingId;
        this.passenger = passenger;
        this.vehicle = vehicle;
        this.driver = driver;
        this.route = route;

        this.payment = new Payment(
            vehicle.CalculateFare(route.GetDistance()),
            "UPI");
    }

    public void Display()
    {
        Console.WriteLine("\n----- BOOKING DETAILS -----");
        Console.WriteLine("Booking ID : " + bookingId);
        Console.WriteLine("Passenger  : " + passenger.GetName());
        Console.WriteLine("Driver     : " + driver.GetName());

        Console.Write("Vehicle    : ");
        vehicle.Display();

        Console.Write("Route      : ");
        route.Display();

        payment.Display();
    }
}


// Main clas
class TransportManagementSystem
{
    static void Main(string[] args)
    {
        Console.WriteLine(
            "===== TRANSPORT MANAGEMENT SYSTEM =====");

        Passenger passenger =
            new Passenger(101, "Ketan");

        Driver driver =
            new Driver(201, "Rahul");

        Vehicle vehicle =
            new Bus(301, "GA-01-B-2623", 40);

        Route route =
            new Route("Panaji", "Margao", 35);

        Booking booking =
            new Booking(
                501,
                passenger,
                vehicle,
                driver,
                route);

        vehicle.Display();
        route.Display();
        booking.Display();

        Console.WriteLine(
            "\nFare is calculated using vehicle type.");

        Console.WriteLine(
            "This demonstrates abstraction, inheritance,");

        Console.WriteLine(
            "encapsulation and polymorphism.");

        Console.WriteLine(
            "\n===== PROGRAM COMPLETED =====");
    }
}