#include <iostream>
#include <string>
using namespace std;

// Abstract clas
class Vehicle {
private:
    int vehicleId;
    string number;
    int capacity;

public:
    Vehicle(int vehicleId, string number, int capacity) {
        this->vehicleId = vehicleId;
        this->number = number;
        this->capacity = capacity;
    }

    int getVehicleId() {
        return vehicleId;
    }

    string getNumber() {
        return number;
    }

    int getCapacity() {
        return capacity;
    }

    virtual double calculateFare(double distance) = 0;
    virtual string getType() = 0;

    virtual void display() {
        cout << getType() << " | ID: " << vehicleId
             << " | Number: " << number
             << " | Capacity: " << capacity << endl;
    }

    virtual ~Vehicle() {}
};


// Bus clas
class Bus : public Vehicle {
public:
    Bus(int id, string number, int capacity)
        : Vehicle(id, number, capacity) {
    }

    double calculateFare(double distance) override {
        return distance * 5;
    }

    string getType() override {
        return "Bus";
    }
};


// Taxi clas
class Taxi : public Vehicle {
public:
    Taxi(int id, string number, int capacity)
        : Vehicle(id, number, capacity) {
    }

    double calculateFare(double distance) override {
        return 50 + distance * 12;
    }

    string getType() override {
        return "Taxi";
    }
};


// Driver clas
class Driver {
private:
    int driverId;
    string name;

public:
    Driver(int driverId, string name) {
        this->driverId = driverId;
        this->name = name;
    }

    string getName() {
        return name;
    }
};


// Passenger clas
class Passenger {
private:
    int passengerId;
    string name;

public:
    Passenger(int passengerId, string name) {
        this->passengerId = passengerId;
        this->name = name;
    }

    string getName() {
        return name;
    }
};


// Route clas
class Route {
private:
    string source;
    string destination;
    double distance;

public:
    Route(string source, string destination, double distance) {
        this->source = source;
        this->destination = destination;
        this->distance = distance;
    }

    double getDistance() {
        return distance;
    }

    void display() {
        cout << source << " -> " << destination
             << " (" << distance << " km)" << endl;
    }
};


// Payment clas
class Payment {
private:
    double amount;
    string method;

public:
    Payment(double amount, string method) {
        this->amount = amount;
        this->method = method;
    }

    void display() {
        cout << "Payment: Rs." << amount
             << " by " << method << endl;
    }
};


// Booking clas
class Booking {
private:
    int bookingId;
    Passenger passenger;
    Vehicle* vehicle;
    Driver driver;
    Route route;
    Payment* payment;

public:
    Booking(int bookingId, Passenger passenger, Vehicle* vehicle,
            Driver driver, Route route)
        : passenger(passenger), vehicle(vehicle),
          driver(driver), route(route) {

        payment = new Payment(
            vehicle->calculateFare(route.getDistance()), "UPI");
    }

    void display() {
        cout << "\n----- BOOKING DETAILS -----" << endl;
        cout << "Booking ID : " << bookingId << endl;
        cout << "Passenger  : " << passenger.getName() << endl;
        cout << "Driver     : " << driver.getName() << endl;

        cout << "Vehicle    : ";
        vehicle->display();

        cout << "Route      : ";
        route.display();

        payment->display();
    }

    ~Booking() {
        delete payment;
    }
};


//Mainfunction
int main() {

    cout << "===== TRANSPORT MANAGEMENT SYSTEM =====" << endl;

    Passenger passenger(101, "Ketan");
    Driver driver(201, "Rahul");

    Vehicle* vehicle = new Bus(301, "GA-01-B-2623", 40);

    Route route("Panaji", "Margao", 35);

    Booking booking(501, passenger, vehicle, driver, route);

    vehicle->display();
    route.display();
    booking.display();

    cout << "\nFare is calculated using vehicle type." << endl;
    cout << "This demonstrates abstraction, inheritance," << endl;
    cout << "encapsulation and polymorphism." << endl;

    cout << "\n===== PROGRAM COMPLETED =====" << endl;

    delete vehicle;

    return 0;
}