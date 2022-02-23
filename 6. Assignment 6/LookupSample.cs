internal class LookupSample {

    internal static void LookupMain() {


        var racers = new List<Racer>();
            racers.Add(new Racer(26, "Jacques", "Villeneuve", "Canada", 11));
            racers.Add(new Racer(18, "Alan", "Jones", "Australia", 12));
            racers.Add(new Racer(11, "Jackie", "Stewart", "United Kingdom", 27));
            racers.Add(new Racer(15, "James", "Hunt", "United Kingdom", 10));
            racers.Add(new Racer(5, "Jack", "Brabham", "Australia", 14));

            var lookupRacers = racers.ToLookup(r => r.Country);

            foreach (Racer r in lookupRacers["Australia"])
            {
                Console.WriteLine(r);
            }
    }
}

[Serializable]
    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }

        public Racer(int id, string firstName, string lastName, string country = null, int wins = 0)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Wins = wins;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch (format.ToUpper())
            {
                case "N": // name
                    return ToString();
                case "F": // first name
                    return FirstName;
                case "L": // last name
                    return LastName;
                case "W": // Wins
                    return String.Format("{0}, Wins: {1}", ToString(), Wins);
                case "C": // Country
                    return String.Format("{0}, Country: {1}", ToString(), Country);
                case "A": // All
                    return String.Format("{0}, {1} Wins: {2}", ToString(), Country, Wins);
                default:
                    throw new FormatException(String.Format(formatProvider,
                          "Format {0} is not supported", format));
            }
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public int CompareTo(Racer other)
        {
            int compare = this.LastName.CompareTo(other.LastName);
            if (compare == 0)
                return this.FirstName.CompareTo(other.FirstName);
            return compare;
        }
    }