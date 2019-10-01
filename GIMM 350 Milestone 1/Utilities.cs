﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour

//This is an example of how to break apart a sentence to figure out each word in the sentence it will print it out in the console word by word
//The first string is a simple sentence it can be anything
    string phrase = "The quick brown fox jumps over the lazy dog.";
//This string is an array named words that takes the previous sentence named phrase and uses the split command to add each word to the array by finding each
//string instane of the ' ' (space) in the sentence, thus splitting the sentence up at each space making a new string for each value.
//Note: additional instances of the ' ' (space) character will add more characters to the array, because it is only splitting based on where the spaces are
    string[] words = phrase.Split(' ');
//This is a foreach loop declares that it is going to run for each var word in the array words that was delcared earlier so it will run this next line of code for each 
//word that was in the original sentence
foreach (var word in words)
{
    //This simply writes the var word to the console each time the loop runs so it will eventually individually write each word in the sentence.
    System.Console.WriteLine($"<{word}>");
}

//Below is another example to break apart a string using something called delimiters
//You first declare a string naming it delimiterChars and make it an array of strings
char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
//Below is a string that uses a multitude of different things to seperate the words from eachother like spaces and colons and commas
//Note: any consecutive uses of a deliminator will produce an empty string.
string text = "one\ttwo three:four,five six seven";
System.Console.WriteLine($"Original text: '{text}'");
//This array named words is made up of the text string split at the delimiters of the array we just declared earlier in the code
string[] words = text.Split(delimiterChars);
//This console write takes the length of the array we created and writes it in the console to check and make sure it recgonizes the correct amount of words in the string
System.Console.WriteLine($"{words.Length} words in text:");
//This is a foreach loop declares that it is going to run for each var word in the array words that was delcared earlier so it will run this next line of code for each 
//word that was in the original sentence
foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}

//Below is another example of how to break apart strings this one uses the option of substrings
//We first create an array naming it and then chose full strings to add to the array not just simple characters the difference is between ' ' and " "
string[] separatingStrings = { "<<", "..." };
//Next we need a string to break apart as we can see there are multiple different strings in them, but also a character
string text = "one<<two......three<four";
//This simply writes the original text to the console
System.Console.WriteLine($"Original text: '{text}'");
//Next we create a new variable named words and break apart the text using the split command this line goes a little more in depth adding some parameters to the split
//command it choses to sperate strings and tells the system to remove all empty entries meaning we wont have to worry about the code thinking that two deliminators
//right next to each other are actually holding a word in between them if that space is empty
string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
//We then tell the system to write to the console the length of the words array
System.Console.WriteLine($"{words.Length} substrings in text:");
//This for each loop is the same as the ones above you it simply writes to the console each string variable named word in the array we created called words.
foreach (var word in words)
{
    System.Console.WriteLine(word);
}

using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        //Create an array of string values called values
        string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
        //Create a variable named number that is a double
        double number;
        //Create a variable named culture that is CultureInfo and set it to null
        CultureInfo culture = null;

        //Create a foreach loop that completes for each string value in values
        foreach (string value in values)
        {
            //Try to set the culture to a specific culture in this case en-US
            try
            {
                //This sets the variable culture to a specific culture that is en-US
                culture = CultureInfo.CreateSpecificCulture("en-US");
                //This sets that number to a parsed value of the string value turning it into a double with the value having the culture applied so specifically 
                //Correcting the number to match the norm for that culture.
                number = Double.Parse(value, culture);
                //This then writes the culture that worked and then writes the original number followed by the parsed number.
                Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
            }
            //This will catch any value that cannot be processed through the above try method.
            catch (FormatException)
            {
                //This simply writes to the console that it was unable to process it using the first culture that was selected
                Console.WriteLine("{0}: Unable to parse '{1}'.",
                                  culture.Name, value);
                //This line overwrites the previous culture going from en-US to fr-FR for france
                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                //Next we will try to see if that processes
                try
                {
                    //This sets number to equal the value that is parsed into a double and correctly matching the culture that was set previously
                    number = Double.Parse(value, culture);
                    //agains this writes the line showing the culture used the original value and the new parsed number
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                }
                //This last catch is to find all format exceptions
                catch (FormatException)
                {
                    //This will simply write to the console that none of the cultures parsed will work for the value
                    Console.WriteLine("{0}: Unable to parse '{1}'.",
                                      culture.Name, value);
                }
            }
            //This tells the system to run the Console.WriteLine() command.
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    en-US: 1,304.16 --> 1304.16
//    
//    en-US: Unable to parse '$1,456.78'.
//    fr-FR: Unable to parse '$1,456.78'.
//    
//    en-US: 1,094 --> 1094
//    
//    en-US: 152 --> 152
//    
//    en-US: Unable to parse '123,45 €'.
//    fr-FR: Unable to parse '123,45 €'.
//    
//    en-US: Unable to parse '1 304,16'.
//    fr-FR: 1 304,16 --> 1304.16
//    
//    en-US: Unable to parse 'Ae9f'.
//    fr-FR: Unable to parse 'Ae9f'.

using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        //Delcare the normal variables
        string value = "1,304";
        int number;
        //Set a IFormatProvider with the name provider to a culture of en-US
        IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
        //This tries to convert the value using a similar method that we were using above, but this wont work now because of the provider using a , when the culture
        //Cannot parse a number with a comma
        if (Int32.TryParse(value, out number))
            Console.WriteLine("{0} --> {1}", value, number);
        else
            Console.WriteLine("Unable to convert '{0}'", value);
        //This one is using the numberStyles which is a similar  way of parsing numbers except instead of using a specific culture we use a specific number style in this
        //case we allow integers or thousands and attempt to parse the value using those for a full list of the different number styles see: https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric
        if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                          provider, out number))
            Console.WriteLine("{0} --> {1}", value, number);
        else
            Console.WriteLine("Unable to convert '{0}'", value);
    }
}
// The example displays the following output:
//       Unable to convert '1,304'
//       1,304 --> 1304


using System;

public class Example
{
    public static void Main()
    {
        //The following are a list of strings with numbers written in different languages the first is basic latin using unicode the rest Fullwidth, Arabic-Indica, and Bangla
        string value;
        // Define a string of basic Latin digits 1-5.
        value = "\u0031\u0032\u0033\u0034\u0035";
        ParseDigits(value);

        // Define a string of Fullwidth digits 1-5.
        value = "\uFF11\uFF12\uFF13\uFF14\uFF15";
        ParseDigits(value);

        // Define a string of Arabic-Indic digits 1-5.
        value = "\u0661\u0662\u0663\u0664\u0665";
        ParseDigits(value);

        // Define a string of Bangla digits 1-5.
        value = "\u09e7\u09e8\u09e9\u09ea\u09eb";
        ParseDigits(value);
    }
    //This is a function that will parse each of the value strings that were defined above
    static void ParseDigits(string value)
    {
        try
        {
            //This line simply parses the string values from above with a catch below
            int number = Int32.Parse(value);
            Console.WriteLine("'{0}' --> {1}", value, number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Unable to parse '{0}'.", value);
        }
    }
}
//As you can see below only the normal latin will work none of the others will parse correctly
// The example displays the following output:
//       '12345' --> 12345
//       Unable to parse '１２３４５'.
//       Unable to parse '١٢٣٤٥'.
//       Unable to parse '১২৩৪৫'.

public static string ProcessText(string input)
{
    //Your code goes here:
    //determine whether user has input a word or a number,
    //return the string 'word' if user enters a word (includes "ab.23cd")
    //return the string 'number' if user enters a number (includes 1.3)
    float number;
    int numNums = 0;
    int numWords = 0;

    string[] wordsNumbers = input.Split(' ');

    foreach (var wAndN in wordsNumbers)
    {
        if (float.TryParse(wAndN, out number))
        {
            numNums++;
        }
        else
        {
            numWords++;
        }
    }

    return "The user entered " + numNums + " numbers and " + numWords + " words.";
}

//This is the code pulled from Unity Games by Tutorials crash course in c#
namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello, world!");

            //const will help me keep variable exactly what I want them to be no matter what
            const bool likesPizza = true;
            //likesPizza = false;
            //If i ran the above commented out line it would send an error

            //Arrays are created by declaring what kind of array I am using and then listing the parts of the array
            string[] writers = { "Anthony", "Brian", "Eric", "Sean" };
            //All you have to do is call the string below you can call one at a time, but only one at a time the below outputs Anthony
            Console.WriteLine(writers[0]);
            //You can also create a new array without adding anything to it at first
            string[] editors = new string[5];
            //you can edit strings as follows
            writers[0] = "Ray";
            //This will replace Anthony with Ray
            //the following is a simple if statement
            if (likesPizza == false)
            {
                Console.WriteLine("You monster!");
            }
            //You can also write simple if statements into variables to make things a little smoother
            bool isMonster = (likesPizza == true) ? false : true;
            //for loops are very important the following is a basic for loop
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("C# Rocks!");
            }
            //for loops are set up by first declaring a variable like the one above i; then deciding how long it will run until ending; 
            //lastly you decide what will happen to the variable everytime the loop runs
            //This following array will print all names in the following array
            for (int i = 0; i < writers.Length; i++)
            {
                string writer = writers[i];
                Console.WriteLine(writer);
            }
            //foreach loops are specially made for arrays and other collections as they let you go through each item in the collection
            foreach (string writer in writers)
            {
                Console.WriteLine(writer);
            }
            //to write a foreach loop you need a variable that is defined for each item in the collection

            //to use structures you must add them to the script here
            Point2D myPoint = new Point2D();
            //This will add the reference to the script
            myPoint.X = 10;
            myPoint.Y = 20;

            //We will need to create another structure here in the main
            Point2D anotherPoint = new Point2D();
            anotherPoint.X = 5;
            anotherPoint.Y = 15;

            //Now that we have two points we can call the AddPoint method her in this script
            myPoint.AddPoint(anotherPoint);
            //by calling that method and passing the point into it we will see it adding the two points together

            //We can call things for garbage collection by setting things to a null property
            anotherRef.X = 125;
            Console.WriteLine(anotherRef.X);
            //this will run and print out 125
            anotherRef = null;
            //This will tell the code to no longer run anotherRef removing it from the memory
        }
    }
}

//Structures can store data like classes except they are stored as values while classes are a reference
//Classes are structured the same using methods to allow them to be called from the main and forcing you
//to add the class to the script
//class Point2D
struct Point2D
{
    //This defines the structure as containing to integers
    public int X;
    public int Y;

    //you can add methods to the structure to change the behaviour
    public void AddPoint(Point2D anotherPoint)
    {
        //This will preform the below code when called by the main script
        this.X = this.X + anotherPoint.X;
        this.Y = this.Y + anotherPoint.Y;
    }
}

//You can use inheritance to allow other classes to 'inherit' methods and variables from other classes
class Person
{
    public string Name;
    public virtual void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

//The classe below inherits from the person class
class RenFairePerson : Person
{
    //This override method will allow you to change what SayHello does so instead of saying hello it will say huzzah
    public override void SayHello()
    {
        Console.Write("Huzzah!");
    }
}

//This is an example of how a do while loop works you first you tell it what to do and then you feed it a while condition so the do part will run before it checks the while condition
//The while loop and do while loop are exactly the same
int counter = 0;
do
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
} while (counter< 10);


//This searches the list for the specified choice and then makes an if statement to determine if the index in the list
//is not at -1 because -1 would be a non-existent item in the list
var index = names.IndexOf("Felipe");
if (index != -1) {
    Console.WriteLine($"The name {names[index]} is at index {index}");

    var notFound = names.IndexOf("Not Found");
Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");
}

//This sorts the names to an alphabetical sellection
names.Sort();
foreach (var name in names) {
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

//This creates a new list that has 1 and 1
var fibonacciNumbers = new List<int> { 1, 1 };

//This while loop goes throught and adds up the list following the fibonacci sequence
while (fibonacciNumbers.Count< 20) {
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);
}

//This prints the list
foreach(var item in fibonacciNumbers) {
    Console.WriteLine(item);
}