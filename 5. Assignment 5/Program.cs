Console.Write("\n\n Adding Cars to the list");

Indica i1 = new Indica("Petrol", 5, "IND-001", IVehicle.Renttype.Kilometer, 2, 5, new DateOnly(2022, 02,28 ));
DavidHarley dv1 = new DavidHarley("DV-011", IVehicle.Renttype.Day, 5, 1100, new DateOnly(2022, 02,28 ));
MBenzEclass mb1 = new MBenzEclass(10, "MBZ-101", IVehicle.Renttype.Kilometer, 1, 3, new DateOnly(2022, 02,28 ));
Qualis q1 = new Qualis("Diesel", 7, "QU-201", IVehicle.Renttype.Kilometer, 7, 5, new DateOnly(2022, 02,28 ));
DavidHarley dv2 = new DavidHarley("DV-021", IVehicle.Renttype.Day, 2, 1500, new DateOnly(2022, 02,28 ));
Qualis q2 = new Qualis("Petrol", 5, "QU-331", IVehicle.Renttype.Day, 5, 1400, new DateOnly(2022, 02,28 ));

RentedVehicle<IVehicle> rv = new RentedVehicle<IVehicle>();

rv.AddVehicle(i1);
rv.AddVehicle(dv1);
rv.AddVehicle(mb1);
rv.AddVehicle(q1);
rv.AddVehicle(dv2);
rv.AddVehicle(q2);

rv.GiveForRent(i1, new DateOnly(2022, 02, 16), new DateOnly(2022, 02, 20), 0);
rv.GiveForRent(q2, new DateOnly(2022, 03, 1), new DateOnly(2022, 03, 7), 0);
rv.GiveForRent(mb1, new DateOnly(2022, 04, 5), new DateOnly(2022, 04, 10), 0);

Console.Write("\n\n **********************************************");

Console.Write("\n Finding total rent per day for the given car for 5 days : ");
q2.getDetails();

Console.Write($"\n\n Total rent per day : {rv.CalculateTotalRentToday(q2, 5):C2}");


Console.Write("\n\n **********************************************");

Console.Write("\n\n Show how many vehicles are available before 17-Feb-2022");

rv.ShowAvailableByDate(new DateOnly(2022, 02, 17));


Console.Write("\n\n **********************************************");

Console.Write("\n\n Show how many vehicles are currently rented");

rv.GetCheckListRentedVehicle();


