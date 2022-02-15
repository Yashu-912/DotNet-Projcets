internal interface IVehicle {

    internal enum Renttype {

        Kilometer, Day
    }

    internal decimal CalculateRent(int TrvaelUnits);
    internal void getDetails();
    internal DateOnly getLastMaintenanceDate();
}



internal class Indica : IVehicle {

    
    internal string? type, number;
    internal IVehicle.Renttype renttype;

    internal int age, rentperunit, seater;

    internal DateOnly last_maintenance_date;

    internal Indica(string type, int seater, string number, IVehicle.Renttype r, int age, int rentperunit, DateOnly d) {

        this.type = type;
        this.seater = seater;
        this.number = number;
        renttype = r;
        this.age = age;
        this.rentperunit = rentperunit;
        last_maintenance_date = d;
    }

    public decimal CalculateRent(int TrvaelUnits) {

        return (decimal)rentperunit*TrvaelUnits;
    }

    public void getDetails() {

        Console.Write("\n\n Brand : Indica");
        Console.Write($"\n Car Number : {number}");
        Console.Write($"\n Seat Capacity : {seater}");
        Console.Write($"\n Fuel type : {type}");
        Console.Write($"\n Car age : {age}");
        Console.Write($"\n Rent per Unit : {rentperunit}");
        
    }

    public DateOnly getLastMaintenanceDate() {

        return last_maintenance_date;
    }
}



internal class Qualis : IVehicle {

    internal string? type, number;
    internal IVehicle.Renttype renttype;

    internal int age, rentperunit, seater;

    internal DateOnly last_maintenance_date;

    internal Qualis(string type, int seater, string number, IVehicle.Renttype r, int age, int rentperunit, DateOnly d) {

        this.type = type;
        this.seater = seater;
        this.number = number;
        renttype = r;
        this.age = age;
        this.rentperunit = rentperunit;
        last_maintenance_date = d;
    }

    public decimal CalculateRent(int TrvaelUnits) {

        return (decimal)rentperunit*TrvaelUnits;
    }

    public void getDetails() {

        Console.Write("\n\n Brand : Qualis");
        Console.Write($"\n Car Number : {number}");
        Console.Write($"\n Seat Capacity : {seater}");
        Console.Write($"\n Fuel type : {type}");
        Console.Write($"\n Car age : {age}");
        Console.Write($"\n Rent per Unit : {rentperunit}");
        
    }

    
    public DateOnly getLastMaintenanceDate() {

        return last_maintenance_date;
    }
}



internal class DavidHarley : IVehicle {

    internal string? number;
    internal IVehicle.Renttype renttype;

    internal int age, rentperunit;

    internal DateOnly last_maintenance_date;

    internal DavidHarley(string number, IVehicle.Renttype r, int age, int rentperunit, DateOnly d) {

        this.number = number;
        renttype = r;
        this.age = age;
        this.rentperunit = rentperunit;
        last_maintenance_date = d;
    }

    public decimal CalculateRent(int TrvaelUnits) {

        return (decimal)rentperunit*TrvaelUnits;
    }

    public void getDetails() {

        Console.Write("\n\n Brand : DavidHarley");
        Console.Write($"\n Car Number : {number}");
        Console.Write($"\n Car age : {age}");
        Console.Write($"\n Rent per Unit : {rentperunit}");
        
    }

    
    public DateOnly getLastMaintenanceDate() {

        return last_maintenance_date;
    }
}



internal class MBenzEclass : IVehicle {

    internal string? number;
    internal IVehicle.Renttype renttype;

    internal int age, rentperunit, seater;

    internal DateOnly last_maintenance_date;

    internal MBenzEclass(int seater, string number, IVehicle.Renttype r, int age, int rentperunit, DateOnly d) {

        this.seater = seater;
        this.number = number;
        renttype = r;
        this.age = age;
        this.rentperunit = rentperunit;
        last_maintenance_date = d;
    }

    public decimal CalculateRent(int TrvaelUnits) {

        return (decimal)rentperunit*TrvaelUnits;
    }

    public void getDetails() {

        Console.Write("\n\n Brand : MBenzEclass");
        Console.Write($"\n Car Number : {number}");
        Console.Write($"\n Seat Capacity : {seater}");
        Console.Write($"\n Car age : {age}");
        Console.Write($"\n Rent per Unit : {rentperunit}");
        
    }

    
    public DateOnly getLastMaintenanceDate() {

        return last_maintenance_date;
    }
}