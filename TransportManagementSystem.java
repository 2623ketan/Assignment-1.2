import java.util.*;

abstract class Vehicle {
    private int vehicleId;
    private String number;
    private int capacity;

    Vehicle(int vehicleId, String number, int capacity) {
        this.vehicleId = vehicleId;
        this.number = number;
        this.capacity = capacity;
    }

    public int getVehicleId() { return vehicleId; }
    public String getNumber() { return number; }
    public int getCapacity() { return capacity; }

    abstract double calculateFare(double distance);
    abstract String getType();

    public void display() {
        System.out.println(getType() + " | ID: " + vehicleId +
                " | Number: " + number + " | Capacity: " + capacity);
    }
}

class Bus extends Vehicle {
    Bus(int id, String number, int capacity) {
        super(id, number, capacity);
    }

    double calculateFare(double distance) {
        return distance * 5;
    }

    String getType() { return "Bus"; }
}

class Taxi extends Vehicle {
    Taxi(int id, String number, int capacity) {
        super(id, number, capacity);
    }

    double calculateFare(double distance) {
        return 50 + distance * 12;
    }

    String getType() { return "Taxi"; }
}

class Driver {
    private int driverId;
    private String name;

    Driver(int driverId, String name) {
        this.driverId = driverId;
        this.name = name;
    }

    public String getName() { return name; }
}

class Passenger {
    private int passengerId;
    private String name;

    Passenger(int passengerId, String name) {
        this.passengerId = passengerId;
        this.name = name;
    }

    public String getName() { return name; }
}

class Route {
    private String source;
    private String destination;
    private double distance;

    Route(String source, String destination, double distance) {
        this.source = source;
        this.destination = destination;
        this.distance = distance;
    }

    public double getDistance() { return distance; }

    public void display() {
        System.out.println(source + " -> " + destination +
                " (" + distance + " km)");
    }
}

class Payment {
    private double amount;
    private String method;

    Payment(double amount, String method) {
        this.amount = amount;
        this.method = method;
    }

    public void display() {
        System.out.println("Payment: Rs." + amount + " by " + method);
    }
}

class Booking {
    private int bookingId;
    private Passenger passenger;
    private Vehicle vehicle;
    private Driver driver;
    private Route route;
    private Payment payment;

    Booking(int bookingId, Passenger passenger, Vehicle vehicle,
            Driver driver, Route route) {
        this.bookingId = bookingId;
        this.passenger = passenger;
        this.vehicle = vehicle;
        this.driver = driver;
        this.route = route;
        this.payment = new Payment(
                vehicle.calculateFare(route.getDistance()), "UPI");
    }

    public void display() {
        System.out.println("\n----- BOOKING DETAILS -----");
        System.out.println("Booking ID : " + bookingId);
        System.out.println("Passenger  : " + passenger.getName());
        System.out.println("Driver     : " + driver.getName());
        System.out.print("Vehicle    : ");
        vehicle.display();
        System.out.print("Route      : ");
        route.display();
        payment.display();
    }
}

public class TransportManagementSystem {
    public static void main(String[] args) {
        System.out.println("===== TRANSPORT MANAGEMENT SYSTEM =====");

        Passenger passenger = new Passenger(101, "Ketan");
        Driver driver = new Driver(201, "Rahul");

        Vehicle vehicle = new Bus(301, "GA-01-B-2623", 40);
        Route route = new Route("Panaji", "Margao", 35);

        Booking booking = new Booking(501, passenger, vehicle, driver, route);

        vehicle.display();
        route.display();
        booking.display();

        System.out.println("\nFare is calculated using vehicle type.");
        System.out.println("This demonstrates abstraction, inheritance,");
        System.out.println("encapsulation and polymorphism.");
        System.out.println("\n===== PROGRAM COMPLETED =====");
    }
}
