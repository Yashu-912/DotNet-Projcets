[Serializable]
    public class Racer1 : IComparable<Racer1>, IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }

        public Racer1(int id, string firstName, string lastName, string country = null, int wins = 0)
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
            switch (format.ToUpper())
            {
                case null:
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

        public int CompareTo(Racer1 other)
        {
            int compare = this.LastName.CompareTo(other.LastName);
            if (compare == 0)
                return this.FirstName.CompareTo(other.FirstName);
            return compare;
        }
    }

public enum CompareType
    {
        FirstName,
        LastName,
        Country,
        Wins
    }

    public class RacerComparer : IComparer<Racer1>
    {
        private CompareType compareType;
        public RacerComparer(CompareType compareType)
        {
            this.compareType = compareType;
        }

        public int Compare(Racer1 x, Racer1 y)
      {
         if (x == null) throw new ArgumentNullException("x");
         if (y == null) throw new ArgumentNullException("y");
         
         int result;
         switch (compareType)
         {
            case CompareType.FirstName:
               return x.FirstName.CompareTo(y.FirstName);
            case CompareType.LastName:
               return x.LastName.CompareTo(y.LastName);
            case CompareType.Country:
               if ((result = x.Country.CompareTo(y.Country)) == 0)
                  return x.LastName.CompareTo(y.LastName);
               else
                  return result;
            case CompareType.Wins:
               return x.Wins.CompareTo(y.Wins);
            default:
               throw new ArgumentException("Invalid Compare Type");
         }
      }
    }

    internal class ListSample {

        internal static void ListMain() {

            var graham = new Racer1(7, "Graham", "Hill", "UK", 14);
            var emerson = new Racer1(13, "Emerson", "Fittipaldi", "Brazil", 14);
            var mario = new Racer1(16, "Mario", "Andretti", "USA", 12);

            var racers = new List<Racer1>(20) { graham, emerson, mario };

            racers.Add(new Racer1(24, "Michael", "Schumacher", "Germany", 91));
            racers.Add(new Racer1(27, "Mika", "Hakkinen", "Finland", 20));

            racers.AddRange(new Racer1[] {
               new Racer1(14, "Niki", "Lauda", "Austria", 25),
               new Racer1(21, "Alain", "Prost", "France", 51)});

            var racers2 = new List<Racer1>(new Racer1[] {
               new Racer1(12, "Jochen", "Rindt", "Austria", 6),
               new Racer1(22, "Ayrton", "Senna", "Brazil", 41) });


        }
    }