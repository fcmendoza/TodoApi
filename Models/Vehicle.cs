using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public Host Host { get; set; } // or simple public string HostName
        public VehicleProfile Profile { get; set; }
        public bool HasDelivery { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal HourlyRate { get; set; } // Price per hour
        public bool IsAvailable { get; set; }
        public int Millage { get; set; }
        public int Rating { get; set; } // from 1 to 5 stars
        public int NumberOfSeats { get; set; } // from 1 to 5 stars
        public TransmissionType TransmissionType { get; set; }
        public GreenType GreenType { get; set; }
        public decimal Longitude { get; set; } // coordinates
        public decimal Latitude { get; set; } // coordinates
        public ICollection<Feature> Features { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Color Color { get; set; }
        public string[] Tags { get; set; }

    }

    public class Host {
        public string Name { get; set; }
    }

    public class VehicleProfile {
        public string Description { get; set; }
        public string[] PhotoUrls { get; set; }
        public ICollection<VehicleReviews> Reviews { get; set; }
    }

    public class VehicleReviews {
        public int Rating { get; set; }
        public string Message { get; set; }
    }

    public enum VehicleType {
        Car,
        Truck,
        SUV,
        Van
    }

    public enum TransmissionType {
        Standard,
        Automatic
    }

    public enum GreenType {
        Hybrid,
        Electric,
        Normal
    }

    public enum Category {
        Elite,
        Convertible,
        FamiliFriendly,
        Deluxe,
        Bussiness,
    }

    public enum Feature {
        Bluetooth,
        Sunroof,
        SnowTires,
        ChildSeat,
        GPS,
        BikeRack,
        FourByFour,
        Convertible
    }

    public class Tag {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public struct Color {
        public int Blue;
        public int Green;
        public int Red;
    }

    public class SuggestedPrice{
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
