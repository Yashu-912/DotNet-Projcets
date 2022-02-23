using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;
using System.Text;


internal class StackSample {

    internal static void StackMain() {

        var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.Write("First iteration: ");
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write("Second iteration: ");
            while (alphabet.Count > 0)
            {
                Console.Write(alphabet.Pop());
            }
            Console.WriteLine();
    }
}

internal class SortedListSample {

    internal static void SortedListMain() {

        Console.Write("\n\n");

        var books = new SortedList<string, string>();
            books.Add("C# 2008 Wrox Box", "978–0–470–047205–7");
            books.Add("Professional ASP.NET MVC 1.0", "978–0–470–38461–9");

            books["Beginning Visual C# 2008"] = "978–0–470-19135-4";
            books["Professional C# 2008"] = "978–0–470–19137–6";

            foreach (KeyValuePair<string, string> book in books)
            {
                Console.WriteLine("{0}, {1}", book.Key, book.Value);
            }

            foreach (string isbn in books.Values)
            {
                Console.WriteLine(isbn);
            }

            foreach (string title in books.Keys)
            {
                Console.WriteLine(title);
            }

            {
                string isbn;
                string title = "Professional C# 7.0";
                if (!books.TryGetValue(title, out isbn))
                {
                    Console.WriteLine("{0} not found", title);
                }
            }
    }
}


internal class SetSample {

    internal static void SetMain() {

        Console.Write("\n\n");

        var companyTeams = new HashSet<string>() { "Ferrari", "McLaren", "Toyota", "BMW", "Renault" };
            var traditionalTeams = new HashSet<string>() { "Ferrari", "McLaren" };
            var privateTeams = new HashSet<string>() { "Red Bull", "Toro Rosso", "Force India", "Brawn GP" };

            if (privateTeams.Add("Williams"))
                Console.WriteLine("Williams added");
            if (!companyTeams.Add("McLaren"))
                Console.WriteLine("McLaren was already in this set");

            if (traditionalTeams.IsSubsetOf(companyTeams))
            {
                Console.WriteLine("traditionalTeams is subset of companyTeams");
            }

            if (companyTeams.IsSupersetOf(traditionalTeams))
            {
                Console.WriteLine("companyTeams is a superset of traditionalTeams");
            }


            traditionalTeams.Add("Williams");
            if (privateTeams.Overlaps(traditionalTeams))
            {
                Console.WriteLine("At least one team is the same with the traditional " +
                      "and private teams");
            }

            var allTeams = new SortedSet<string>(companyTeams);    
            allTeams.UnionWith(privateTeams);
            allTeams.UnionWith(traditionalTeams);

            Console.WriteLine();
            Console.WriteLine("all teams");
            foreach (var team in allTeams)
            {
                Console.WriteLine(team);
            }

            allTeams.ExceptWith(privateTeams);
            Console.WriteLine();
            Console.WriteLine("no private team left");
            foreach (var team in allTeams)
            {
                Console.WriteLine(team);
            }

    }
}


internal class ObservableCollectionSample
    {
        internal static void ObservableCollectionMain()
        {

            Console.Write("\n\n");
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");
            
        }

        internal static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("action: {0}", e.Action.ToString());

            if (e.OldItems != null)
            {
                Console.WriteLine("starting index for old item(s): {0}", e.OldStartingIndex);
                Console.WriteLine("old item(s):");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
            if (e.NewItems != null)
            {
                Console.WriteLine("starting index for new item(s): {0}", e.NewStartingIndex);
                Console.WriteLine("new item(s): ");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }


            Console.WriteLine();

        }
    }


internal class ConcurrentSample
    {
        internal static void ConcurrentMain()
        {
            
            Console.Write("\n\n");
            // BlockingDemo();
            BlockingDemoSimple();


        }

        internal static void BlockingDemoSimple()
        {
            var sharedCollection = new BlockingCollection<int>();
            var events = new ManualResetEventSlim[2];
            var waits = new WaitHandle[2];
            for (int i = 0; i < 2; i++)
			{
			    events[i] = new ManualResetEventSlim(false);
                waits[i] = events[i].WaitHandle;
			}


            var producer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;
                var r = new Random();

                for (int i = 0; i < 300; i++)
                {
                    coll.Add(r.Next(3000));
                }
                ev.Set();
            });
            producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[0]));

            var consumer = new Thread(obj =>
            {
                var state = (Tuple<BlockingCollection<int>, ManualResetEventSlim>)obj;
                var coll = state.Item1;
                var ev = state.Item2;

                for (int i = 0; i < 300; i++)
                {
                    int result = coll.Take();
                }
                ev.Set();
            });
            consumer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[1]));

            if (!WaitHandle.WaitAll(waits))
                Console.WriteLine("wait failed");
            else
                Console.WriteLine("reading/writing finished");

        }

        internal static void BlockingDemo()
        {
            const int threadCount = 10;
            ManualResetEventSlim[] events = new ManualResetEventSlim[threadCount];
            WaitHandle[] waits = new WaitHandle[threadCount];
            var consoleLock = new object();

            for (int thread = 0; thread < threadCount; thread++)
            {
                events[thread] = new ManualResetEventSlim(false);
                waits[thread] = events[thread].WaitHandle;
            }

            var sharedCollection = new BlockingCollection<int>();


            for (int thread = 0; thread < threadCount >> 1; thread++)
            {
                var producer = new Thread((state) =>
                {
                    var coll = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item1;
                    var wait = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item2;
                    var r = new Random();
                    for (int i = 0; i < 300; i++)
                    {
                        int data = r.Next(30000);
                        if (!coll.TryAdd(data))
                        {
                            Console.WriteLine("**** couldn't add");
                        }
                        else
                        {
                            lock (consoleLock)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" {0} ", data);
                                Console.ResetColor();
                            }
                        }
                        Thread.Sleep(r.Next(40));
                    }
                    wait.Set();
                });
                producer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[thread]));
            }

            Thread.Sleep(500);  // give the producers a headstart

            for (int thread = threadCount >> 1; thread < threadCount; thread++)
            {
                var consumer = new Thread((state) =>
                {
                    var coll = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item1;
                    var wait = ((Tuple<BlockingCollection<int>, ManualResetEventSlim>)state).Item2;
                    var r = new Random();
                    for (int i = 0; i < 3000; i++)
                    {
                        int result;
                        if (!coll.TryTake(out result))
                        {
                            Console.WriteLine("couldn't take");
                        }
                        else
                        {
                            lock (consoleLock)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" {0} ", result);
                                Console.ResetColor();
                            }
                        }

                        Thread.Sleep(r.Next(40));
                    }
                    wait.Set();
                });
                consumer.Start(Tuple.Create<BlockingCollection<int>, ManualResetEventSlim>(sharedCollection, events[thread]));
            }

            if (!WaitHandle.WaitAll(waits))
                Console.WriteLine("error waiting...");

        }
    }


internal class BitArraySample
    {
        internal static void BitArrayDemo()
        {
            Console.Write("\n\n");
            var bits1 = new BitArray(8);
            bits1.SetAll(true);
            bits1.Set(1, false);
            bits1[5] = false;
            bits1[7] = false;
            Console.Write("initialized: ");
            DisplayBits(bits1);
            Console.WriteLine();


            DisplayBits(bits1);
            bits1.Not();
            Console.Write(" not ");
            DisplayBits(bits1);
            Console.WriteLine();

            var bits2 = new BitArray(bits1);
            bits2[0] = true;
            bits2[1] = false;
            bits2[4] = true;
            DisplayBits(bits1);
            Console.Write(" or ");
            DisplayBits(bits2);
            Console.Write(" : ");
            bits1.Or(bits2);
            DisplayBits(bits1);
            Console.WriteLine();


            DisplayBits(bits2);
            Console.Write(" and ");
            DisplayBits(bits1);
            Console.Write(" : ");
            bits2.And(bits1);
            DisplayBits(bits2);
            Console.WriteLine();

            DisplayBits(bits1);
            Console.Write(" xor ");
            DisplayBits(bits2);
            bits1.Xor(bits2);
            Console.Write(" : ");
            DisplayBits(bits1);
            Console.WriteLine();
        }

        internal static void BitVectorDemo()
        {

            var bits1 = new BitVector32();
            int bit1 = BitVector32.CreateMask();
            int bit2 = BitVector32.CreateMask(bit1);
            int bit3 = BitVector32.CreateMask(bit2);
            int bit4 = BitVector32.CreateMask(bit3);
            int bit5 = BitVector32.CreateMask(bit4);

            bits1[bit1] = true;
            bits1[bit2] = false;
            bits1[bit3] = true;
            bits1[bit4] = true;
            Console.WriteLine(bits1);

            bits1[0xabcdef] = true;
            Console.WriteLine(bits1);


            int received = 0x79abcdef;

            var bits2 = new BitVector32(received);
            Console.WriteLine(bits2);
            // sections: FF EEE DDD CCCC BBBBBBBB AAAAAAAAAAAA
            BitVector32.Section sectionA = BitVector32.CreateSection(0xfff);
            BitVector32.Section sectionB = BitVector32.CreateSection(0xff, sectionA);
            BitVector32.Section sectionC = BitVector32.CreateSection(0xf, sectionB);
            BitVector32.Section sectionD = BitVector32.CreateSection(0x7, sectionC);
            BitVector32.Section sectionE = BitVector32.CreateSection(0x7, sectionD);
            BitVector32.Section sectionF = BitVector32.CreateSection(0x3, sectionE);



            Console.WriteLine("Section A: " + IntToBinaryString(bits2[sectionA], true));
            Console.WriteLine("Section B: " + IntToBinaryString(bits2[sectionB], true));
            Console.WriteLine("Section C: " + IntToBinaryString(bits2[sectionC], true));
            Console.WriteLine("Section D: " + IntToBinaryString(bits2[sectionD], true));
            Console.WriteLine("Section E: " + IntToBinaryString(bits2[sectionE], true));
            Console.WriteLine("Section F: " + IntToBinaryString(bits2[sectionF], true));


        }

        internal static string IntToBinaryString(int bits, bool removeTrailingZero)
        {
            var sb = new StringBuilder(32);

            for (int i = 0; i < 32; i++)
            {
                if ((bits & 0x80000000) != 0)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                bits = bits << 1;
            }
            string s = sb.ToString();
            if (removeTrailingZero)
                return s.TrimStart('0');
            else
                return s;
        }

        internal static void BitArrayMain()
        {
            // BitArrayDemo();
            BitVectorDemo();


        }


        internal static void DisplayBits(BitArray bits)
        {
            foreach (bool bit in bits)
            {
                Console.Write(bit ? 1 : 0);
            }
        }
    }


    