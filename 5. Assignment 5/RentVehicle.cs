public class Car<T> {

    internal T carobj;

    internal DateOnly start_date, end_date;
    internal int TravelUnits;
    internal decimal advanced_Payment;

    internal Car(T carobj, DateOnly start_date, DateOnly end_date, decimal adv_pay) {

        this.carobj = carobj;
        this.advanced_Payment = adv_pay;
        this.end_date = end_date;
        this.start_date = start_date;
    }

    internal Car(T carobj) {

        this.carobj = carobj;
    }
    internal int CalculateDays() {

        int y = end_date.Year - start_date.Year;
        int m = end_date.Month - start_date.Month;
        int d = end_date.Day - start_date.Day;

        return 365*y + 31*m + d;
    }
}

internal class RentedVehicle<T> {

    List<Car<T>> Vehiclelist;

    internal RentedVehicle() {

        Vehiclelist = new List<Car<T>>();
    }

    internal void AddVehicle(T carobj) {

        Car<T> c = new Car<T>(carobj);
    }

    internal void GiveForRent(T carobj, DateOnly start_date, DateOnly end_date, decimal adv_pay) {

        Car<T> c = new Car<T>(carobj, start_date, end_date, adv_pay);
        Vehiclelist.Add(c);
    }

    internal decimal CalculateRent(T carobj, int TrvaelUnits) {

        foreach(Car<T> c in Vehiclelist) {

            if(c.carobj!.Equals(carobj)) {
                
                c.TravelUnits = TrvaelUnits;
                return ((IVehicle)carobj).CalculateRent(TrvaelUnits) - c.advanced_Payment;
            }
        }

        return 0;
    }


    internal decimal CalculateTotalRentToday(T carobj, int TrvaelUnits) {

        foreach(Car<T> c in Vehiclelist) {

            if(c.carobj!.Equals(carobj)) {

                return (((IVehicle)carobj).CalculateRent(TrvaelUnits) - c.advanced_Payment)/c.CalculateDays();
            }
        }

        return 0;
    }

    internal void GetCheckListRentedVehicle() {

        foreach(Car<T> c in Vehiclelist) {

            ((IVehicle)c.carobj!).getDetails();
            Console.Write($"\n Rented From {c.start_date} to {c.end_date}");
        }
    }

    internal bool CheckVehiclesInMaintenance(T carobj) {

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        foreach(Car<T> c in Vehiclelist) {
            
            IVehicle car = ((IVehicle)c.carobj!);
            if(c.carobj!.Equals(carobj) && car.getLastMaintenanceDate().CompareTo(today) > 0) 
                return true;
        }

        return false;
    }

    internal void ShowAvailableByDate(DateOnly date) {

        Console.Write($"\n\n Available Vehicles on {date}");

        foreach(Car<T> c in Vehiclelist) {
            
            if(c.start_date.CompareTo(date) > 0) {

                ((IVehicle)c.carobj!).getDetails();
            }
        }
    }
    
}