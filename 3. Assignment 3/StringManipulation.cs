public class StringManipulation {

    public string? str;
    public void length() {

        Console.Write("\n Enter a String : ");
        str = Console.ReadLine();

        if(str is not null)
            Console.Write($" The length of string {str} is : {str.Length}");

    }

    public void SentenceDetection() {

        Console.Write("\n\n Enter a sentence : ");
        str = Console.ReadLine();

        if(str is not null) {
            
            switch(str.Substring(str.Length-1)) {

                case ".":
                    Console.WriteLine(" The Sentence is in Declarative mode."); break;
                    
                case "?":
                    Console.WriteLine(" The Sentence is in Interrogatory mode."); break;

                case "!":
                    Console.WriteLine(" The Sentence is an Exclamation."); break;
                
                default:
                    Console.WriteLine(" The input is not a sentence."); break;
            }
        }
    }

    public void NameChange() {

        Console.Write("\n Enter your name : ");
        str = Console.ReadLine();

        if(str is not null) {

            string? new_str = " ";
            int index = str.IndexOf(" ");
            
            if(index == -1)
                new_str = str;
            else 
                new_str = str.Substring(index + 1) + ", " + str.Substring(0, index);


            Console.WriteLine($" The changed name is : {new_str}");

        }
    }
}