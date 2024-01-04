

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using UnityEngine;

public class test: MonoBehaviour {
    public List<string> a=new List<string>();
   public List<int> x = new List<int>();
    private void Start() {
        //countingSort(a);
        // nim("abcd", "dbcae");
        // noPrefix(a);
        minimumBribes(x);
    }
    //public static void minimumBribes(List<int> q) {
    //    int bribes = 0;
    //    bool a=false;
    //    string s = "";
    //    for (int i = 0; i < q.Count; i++) {
    //        if (q[i] - (i + 1) > 2) { Debug.Log("here"); a = true; s = "Too chaotic"; }
    //    }
    //    for (int i = 0; i < q.Count; i++) {
    //        for (int j = q[Math.Abs(i-2)]; j < i; j++) {
    //            if (q[j] > q[i]) {
    //                int temp = q[j];
    //                q[j] = q[j + 1];
    //                q[j + 1] = temp;
    //                bribes++; }
    //        }
    //    }
    //    if (a) {
    //        Debug.Log(bribes);
    //        Debug.Log(s);
    //    } else
    //    Debug.Log(bribes+"here");
    //}
    public static void minimumBribes(List<int> q) {
        bool chaotic = false;
    int bribes = 0;
 for (int i = 0; i<q.Count; i++) {
 if ((q[i]-(i+1))>2)
            { chaotic = true; }
for (int j = 0; j < i; j++) {
    if (q[j] > q[i]) { bribes++; }
}
   }
 if (chaotic == true) {
    Console.Write("Too chaotic");
} else {
    Console.Write(bribes);
}
 }
     public static int superDigit(string n, int k) {
        int a = 0;
        char[] charArry;
        int sum = 0;
        int superDigit=0;
        while (a < k) {
            n = string.Concat(n, n);
        }
        charArry = n.ToCharArray();
         for(int j = 0; j < charArry.Length; j++) {
              sum += (int)charArry[j];
        }
        string s = sum.ToString();
        char[] scnd = s.ToCharArray();
        for(int i = 0; i < scnd.Length; i++) {
            superDigit += (int)scnd[i];
        }
        return superDigit;
    }
    public static void noPrefix(List<string> words) {
        bool equal = false;
        string result = " ", goodResult = " ";
        string a = " ", b = "";
        for (int i = 0; i < words.Count; i++) {
            for (int j = i + 1; j < words.Count; j++) {
                if (words[j].Contains(words[i]) || words[i].Contains(words[j])) {
                    equal = true;
                    result = "BAD SET";
                    a = (words[j]);
                } else {
                    goodResult = "GOOD SET";
                    b = (words[j]);
                }
            }
        }
        if (equal == true) {
            Console.Write(result + "\n");
            Console.Write(a + "\n");
        } else {
            Console.Write(goodResult + "\n");

        }
    }


    public static char nim(string s, string t) {
        int difference, i;
        difference = 0;
        for (i = 0; i < s.Length; i++) {
            difference -= s[i];
            difference += t[i];
        }
        difference += t[t.Length - 1];
        Debug.Log((char)difference);
        return (char)difference;
    }
public static List<int> countingSort(List<int> arr) {
        List<int> list = new List<int>();
        for (int i = 0; i < 100; i++) {
            int c = 0;
            for (int j = 0; j < arr.Count; j++)
                { if (i == arr[j]) { c++; } }
            list.Add(c);
        }
        return list;
    }
}






//class Solution {
//    public static void Main(string[] args) {
//        int n = Convert.ToInt32(Console.ReadLine().Trim());

//        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

//       // test.plusMinus(a);
//    }
//}
class Result {

    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q) {


        bool chaotic = false;
        int bribes = 0;
        for (int i = 0; i < q.Count; i++) {
            if ((q[i] - (i + 1)) > 2) { chaotic = true; }
            for (int j = 0; j < i; j++) {
                if (q[j] > q[i]) { bribes++; }
            }
        }
        if (chaotic == true) {
            Console.Write("Too chaotic");
        } else {
            Console.Write(bribes);
        }
    }


    class Solution {
        public static void Main(string[] args) {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++) {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

                Result.minimumBribes(q);
            }
        }
    }
}

