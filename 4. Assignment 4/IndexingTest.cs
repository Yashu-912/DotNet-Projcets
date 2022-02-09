class TempRecord
{
    float[] temps = new float[10] {
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
    };

    internal int Length => temps.Length;
    
    internal float this[int index]
    {
        get => temps[index];
        set => temps[index] = value;
    }
}

class DayCollection {

    string[] days = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

    internal int this[string day] => FindDay(day);

    private int FindDay(string day) {

        for(int i = 0; i < days.Length; i++) {

            if(days[i] == day)
                return i;
        }

        throw new ArgumentOutOfRangeException( nameof(day), $"Day {day} is not supported. \n Day must be in the form \"Sunday\"");
    }
}

public class IndexingTest {

    public static void TestIndex() {

        Console.Write("\n\n *** Testing Indexers ***");
        
        Console.Write("\n\n *** Indexing on float array ***\n");
        
        TempRecord tr = new TempRecord();
        for(int i = 0; i < tr.Length; i++) 
            Console.Write($"\n tr[{i}] : {tr[i]}");
        
        Console.Write("\n\n *** Indexers to find out Day index from string ***");

        DayCollection dc = new DayCollection();
        Console.Write($"\n\n dc[\"Sunday\"] : {dc["Sunday"]}");
        Console.Write($"\n dc[\"Friday\"] : {dc["Friday"]}");
        Console.Write($"\n dc[\"Wednesday\"] : {dc["Wednesday"]}");
        
    }
}