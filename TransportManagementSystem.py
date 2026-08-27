from abc import ABC, abstractmethod


# Abstract class
class Vehicle(ABC):

    def __init__(self, vehicleId, number, capacity):
        self.__vehicleId = vehicleId
        self.__number = number
        self.__capacity = capacity

    def getVehicleId(self):
        return self.__vehicleId

    def getNumber(self):
        return self.__number

    def getCapacity(self):
        return self.__capacity

    @abstractmethod
    def calculateFare(self, distance):
        pass

    @abstractmethod
    def getType(self):
        pass

    def display(self):
        print(
            self.getType()
            + " | ID: " + str(self.__vehicleId)
            + " | Number: " + self.__number
            + " | Capacity: " + str(self.__capacity)
        )


# Bus class
class Bus(Vehicle):

    def __init__(self, id, number, capacity):
        super().__init__(id, number, capacity)

    def calculateFare(self, distance):
        return distance * 5

    def getType(self):
        return "Bus"


# Taxi class
class Taxi(Vehicle):

    def __init__(self, id, number, capacity):
        super().__init__(id, number, capacity)

    def calculateFare(self, distance):
        return 50 + distance * 12

    def getType(self):
        return "Taxi"


# Driver class
class Driver:

    def __init__(self, driverId, name):
        self.__driverId = driverId
        self.__name = name

    def getName(self):
        return self.__name


# Passenger class
class Passenger:

    def __init__(self, passengerId, name):
        self.__passengerId = passengerId
        self.__name = name

    def getName(self):
        return self.__name


# Route class
class Route:

    def __init__(self, source, destination, distance):
        self.__source = source
        self.__destination = destination
        self.__distance = distance

    def getDistance(self):
        return self.__distance

    def display(self):
        print(
            self.__source
            + " -> " + self.__destination
            + " (" + str(self.__distance) + " km)"
        )


# Payment class
class Payment:

    def __init__(self, amount, method):
        self.__amount = amount
        self.__method = method

    def display(self):
        print(
            "Payment: Rs."
            + str(self.__amount)
            + " by " + self.__method
        )


# Booking class
class Booking:

    def __init__(
        self,
        bookingId,
        passenger,
        vehicle,
        driver,
        route
    ):
        self.__bookingId = bookingId
        self.__passenger = passenger
        self.__vehicle = vehicle
        self.__driver = driver
        self.__route = route

        self.__payment = Payment(
            vehicle.calculateFare(route.getDistance()),
            "UPI"
        )

    def display(self):
        print("\n----- BOOKING DETAILS -----")
        print("Booking ID : " + str(self.__bookingId))
        print("Passenger  : " + self.__passenger.getName())
        print("Driver     : " + self.__driver.getName())

        print("Vehicle    : ", end="")
        self.__vehicle.display()

        print("Route      : ", end="")
        self.__route.display()

        self.__payment.display()


# Main program
print("===== TRANSPORT MANAGEMENT SYSTEM =====")

passenger = Passenger(101, "Ketan")

driver = Driver(201, "Rahul")

vehicle = Bus(301, "GA-01-B-2623", 40)

route = Route("Panaji", "Margao", 35)

booking = Booking(
    501,
    passenger,
    vehicle,
    driver,
    route
)

vehicle.display()
route.display()
booking.display()

print("\nFare is calculated using vehicle type.")
print("This demonstrates abstraction, inheritance,")
print("encapsulation and polymorphism.")

print("\n===== PROGRAM COMPLETED =====")