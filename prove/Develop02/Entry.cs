// By Nate Boulton
// The Entry object holds information on the date, prompt, and response from 
// the user. In this class this object's attributes and methods are described.
public class Entry
{
    /* Attributes */

    // This is the different possible prompts that could be used.
    private List<string> _prompts = new List<string>
                    {
                        "How have I seen the hand of the Lord in my life today?",
                        "What is something cool that happened today?",
                        "What is something I am grateful for?",
                        "If I had one thing I could do over today, what would it be?",
                        "What am I looking forward to tomorrow?",
                        "What was the strongest emotion I felt today?"
                    };
    // private string _promptFilename = "prompts.csv";
    private string _date;
    private string _response;
    // For referencing which prompt. It's better for storage and the such.
    private int _count;


    /* Constructors */
    public Entry(string date, int count, string response)
    {
        _date = date;
        _count = count;
        _response = response;
    }

    // This constructor is for when a new Entry is to be created, and there is not yet 
    // a prompt or response.
    public Entry(string date)
    {
        _date = date;
    }


    /* Methods */

    // Converts the Entry into a CSV friendly string that can be processed.
    public string toCSV()
    {
        return $"{_date},{_count},{_response}";
    }

    // Converts the Entry into a user friendly string that can be understood.
    public string GetEntry()
    {
        return $"{_date}\n{_prompts[_count]}\n{_response}";
    }

    // This method chooses at (almost) random the prompt, and then has the user
    // enter in their response.
    public void DisplayPrompt()
    {
        _count = new Random().Next(0, _prompts.Count);
        Console.WriteLine(_prompts.Count);
        Console.Write(_date + ": ");
        Console.Write(_prompts[_count] + "\n>");
        string response = Console.ReadLine();

        // This part right here takes into account the fact that CSV files use commas
        // to separate values. That's no good if the user wants to enter in a comma in 
        // their response. So this statement replaces the comma with the ASCII value of 
        // 0x01B, which is [ESC] or something like that, which the user would probably 
        // never enter. When the file is processed later in the Journal object, it turns
        // the [ESC]s back into commas. 
        _response = response.Replace(',', '\u001B');
    }

    // Allows the response to be set. 
    public void SetResponse(string response)
    {
        _response = response;
    }

    // This method also replaces the commas with ASCII 0x01B, but is on its own for when
    // the Journal object needs to rewrite all of the entries back into the file.
    public void FixCommas()
    {
        _response = _response.Replace(',', '\u001B');
    }

    // Methods to access the encapsulated fields
    public List<string> GetPrompts()
    {
        return _prompts;
    }
    public string GetResponse()
    {
        return _response;
    }
    public DateTime GetDate()
    {
        DateTime.TryParse(_date, out DateTime result);
        return result;
    }
}

















// The forgotten. It got too messy

/* public void LoadPrompts()
{
    _prompts = new List<string>{""};

        try{

            using(StreamReader reader = new StreamReader(_promptFilename))
            {
                int lineCount = File.ReadLines(_promptFilename).Count();
                for (int i = 0; i <= lineCount; i++)
                {
                    string csvLine = reader.ReadLine();
                    if(csvLine!="\n"){
                        _prompts.Add(csvLine);
                        Console.WriteLine("Test");
                    }
                    else
                    {
                        Console.WriteLine("egiub");
                    }
                    Console.WriteLine("This o2egnoiregrere");
                }
            }
            if (_prompts.Count == 0)
            {
                _prompts = new List<string>
                {
                    "How have I seen the hand of the Lord in my life today?",
                    "What is something cool that happened today?",
                    "What is something I am grateful for?",
                    "If I had one thing I could do over today, what would it be?",
                    "What am I looking forward to tomorrow?",
                    "What was the strongest emotion I felt today?"
                };
                Console.WriteLine("Test 1");
            }
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("This exception was hit");
            if(new FileInfo(_promptFilename).Length == 0)
            {
                _prompts = new List<string>
                {
                    "How have I seen the hand of the Lord in my life today?",
                    "What is something cool that happened today?",
                    "What is something I am grateful for?",
                    "If I had one thing I could do over today, what would it be?",
                    "What am I looking forward to tomorrow?",
                    "What was the strongest emotion I felt today?"
                };
            }

        }

    catch (FileNotFoundException)
    {
         using(File.Create(_promptFilename)){}
         _prompts = new List<string>
            {
                "How have I seen the hand of the Lord in my life today?",
                "What is something cool that happened today?",
                "What is something I am grateful for?",
                "If I had one thing I could do over today, what would it be?",
                "What am I looking forward to tomorrow?",
                "What was the strongest emotion I felt today?"
            };

    }
}
*/

/* public void AddPrompt(string prompt)
    {
        if (_prompts.Count != 0)
        {
            _prompts.Add(prompt);
            this.WritePrompts();
        }
    }
    public void WritePrompts()
    {
        string final = "";
        // First it creates a string that holds the entire Journal,
        foreach (string prompt in _prompts)
        {
            final+= $"{prompt}\n";
            
        }
        // And then it writes that whole string to the file.
        using (StreamWriter writer = new StreamWriter(_promptFilename))
        {
            final=final.Trim();
            writer.Write(final);
        }
    
    } */