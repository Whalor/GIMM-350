using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{

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
}
