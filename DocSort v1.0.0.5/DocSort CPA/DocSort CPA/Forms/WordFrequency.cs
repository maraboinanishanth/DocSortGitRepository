using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MoveMyFiles.Forms
{
    public struct WordSet
    {
        public string fName;
        public List<string> wordList;
        //public List<DictionaryEntry> WordDictionary;
    };
    static class WordFrequency
    {
        public static List<string> Words(string imgdata, int freq, int length)
        {

            #region words freqency

            String fullbook = String.Copy(imgdata);

            // remove numbers and punctuation
            fullbook = Regex.Replace(fullbook.ToString(), "\\.|;|-|_|:,|[0-9]|'", "");

            // create collection of words 
            MatchCollection wordCollection = Regex.Matches(fullbook, @"[\w]+", RegexOptions.Multiline);

            // create linked list for words
            LinkedList<string> wordList = new LinkedList<string>();

            // create hash table
            Hashtable frequencyHash = new Hashtable();

            // create linked list for unique words 
            LinkedList<string> uniqueWord = new LinkedList<string>();

            // populate wordList with content of collection

            for (int idx = 0; idx < wordCollection.Count; idx++)
            {
                wordList.AddLast(wordCollection[idx].ToString().ToLower().Trim());
            }

            // populate hashtable of word frequency
            // for everyword in full word list
            foreach (var word in wordList)
            {
                // if unique linked list does not contain a word. add it as a key, and set the value to 1
                // if unique linked list contains the word increment the value 
                if (uniqueWord.Contains(word))
                {
                    int wordCount = int.Parse(frequencyHash[word].ToString());
                    wordCount++;
                    frequencyHash[word] = wordCount;
                }
                else
                {
                    uniqueWord.AddLast(word);
                    frequencyHash.Add(word, 1);
                }
            }
            // sort hash table 
            var ret = new List<DictionaryEntry>(frequencyHash.Count);

            
            foreach (DictionaryEntry entry in frequencyHash)
            {
                ret.Add(entry);
            }

            // sort dictonary based on frequency
            ret.Sort(
                (x, y) =>
                {
                    IComparable comparable = x.Value as IComparable;
                    if (comparable != null)
                    {
                        return comparable.CompareTo(y.Value); 
                    }
                    return 0;
                }
                );

            // extract only keys ; keys are words 
            List<string> keys = new List<string>();
            for (int idx = 0; idx < ret.Count; idx++)
            {
                string ky = ret[idx].Key.ToString();
                if ((Int32.Parse(ret[idx].Value.ToString()) >= freq) && (ky.Length > length)) 
                  keys.Add(ky);
            }

            // sort the words 
            keys.Sort();

            

            return keys;

            #endregion
        }
    }
}
