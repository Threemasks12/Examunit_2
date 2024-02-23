using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Examunit 2");

// SETUP 
const string myPersonalID = "44f424a3df706ad568149c2eb75e0d65d56ab9f15eae8a629e29b7913110bcd6"; 
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; 
const string taskEndpoint = "task/";   

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n");
string taskID = "otYK2";

// FIRST TASK 

Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Console.WriteLine(task1Response);

Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

string parameters = task1.parameters;


List<string> uniqueWordsList = GetUniqueWordsList(parameters);
uniqueWordsList.Sort();
Console.WriteLine($"Unique Words: {string.Join(",", uniqueWordsList)}");


static List<string> GetUniqueWordsList(string parameterString)
{
    string[] words = parameterString.Split(',');
    List<string> uniqueWordsList = words.Distinct().ToList();
    return uniqueWordsList;
}

var answer1 = uniqueWordsList;

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, $"{string.Join(",", answer1)}");
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

taskID = "psu31_4";

Console.WriteLine("\n----------------------------------------------------------------------\n");


// SECOUND TASKS
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

string numberParameters = task2.parameters;

string[] numberString = numberParameters.Split(',');

int sum = 0;

foreach (string numStr in numberString)
{
    string trimmedNumbersString = numStr.Trim();

    if (int.TryParse(trimmedNumbersString, out int number))
    {
        sum += number;
    }
}

var answer2 = sum;

Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, $"{string.Join(",", answer2)}");
Console.WriteLine($"Answer: {Colors.Cyan}{task2AnswerResponse}{ANSICodes.Reset}");


taskID = "rEu25ZX";

Console.WriteLine("\n----------------------------------------------------------------------\n");


// THIRD TASK
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");

string romanParameters = task3.parameters;

int arabicNumbers = RomanToArabic(romanParameters);

static int RomanToArabic(string romanParameters)
{
    var romanValues = new System.Collections.Generic.Dictionary<char, int>
    {
        { 'I', 1},
        { 'V', 5},
        { 'X', 10},
        { 'L', 50},
        { 'C', 100},
        { 'D', 500}
    };

    int sumOfRoman = 0;

    for (int i = 0; i < romanParameters.Length; i++)
    {
        int currentValue = romanValues[romanParameters[i]];

        if (i + 1 < romanParameters.Length && romanValues[romanParameters[i + 1]] > currentValue)
        {
            sumOfRoman -= currentValue;
        }
        else
        {
            sumOfRoman += currentValue;
        }
    }

    return sumOfRoman;
}


var answer3 = RomanToArabic(romanParameters); ;

Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, $"{string.Join(",", answer3)}");
Console.WriteLine($"Answer: {Colors.Blue}{task3AnswerResponse}{ANSICodes.Reset}");

taskID = "aLp96";

Console.WriteLine("\n----------------------------------------------------------------------\n");

// FOURTH TASK

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");

string task4Parameters = task4.parameters;




if (int.TryParse(task4Parameters, out int oddOrEven))
        {
            string result = CheckOddOrEven(oddOrEven);   
        }

static string CheckOddOrEven(int number)
{
    return (number % 2 == 0) ? "even" : "odd";
}

var anwser4 = CheckOddOrEven(oddOrEven);
Console.WriteLine(anwser4);

Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, $"{string.Join(",", anwser4)}");
Console.WriteLine($"Answer: {Colors.Blue}{task4AnswerResponse}{ANSICodes.Reset}");

class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? userID { get; set; }
    public string? parameters { get; set; }
}