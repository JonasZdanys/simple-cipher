using System;
using System.Collections.Generic;

public class SimpleCipher
{
    public List<char> alphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    public SimpleCipher()
    {
        string key = "";
        Random randomReturn = new Random();
        for (int i = 0; i < 100; i++)
        {
            key += (char)randomReturn.Next('a', 'z');
        }
        Key = key;
    }

    public SimpleCipher(string key)
    {
        Key = key;
    }

    public string Key { get; }

    public string Encode(string plaintext)
    {
        string encoded = "";
        string theKey = Key;
        while (theKey.Length < plaintext.Length)
        {
            theKey += Key;
        }
        for (int i = 0; i < plaintext.Length; i++)
        {
            encoded += Encipher(plaintext[i], i, theKey);
        }
        return encoded;
    }

    private string Encipher(char singleLetter, int index, string theKey)
    {
        int currentLetterIndex = alphabet.IndexOf(singleLetter);
        int keyIndex = alphabet.IndexOf(theKey[index]);
        if (currentLetterIndex + keyIndex <= alphabet.Count - 1)
        {
            singleLetter = alphabet[currentLetterIndex + keyIndex];
        }
        else
        {
            singleLetter = alphabet[currentLetterIndex + keyIndex - alphabet.Count];
        }
        return singleLetter.ToString();
    }
    public string Decode(string ciphertext)
    {
        string decoded = "";
        string theKey = Key;
        while (theKey.Length < ciphertext.Length)
        {
            theKey += Key;
        }
        for (int i = 0; i < ciphertext.Length; i++)
        {
            decoded += Decipher(ciphertext[i], i, theKey);
        }
        return decoded;
    }
    private string Decipher(char singleLetter, int index, string theKey)
    {
        int currentLetterIndex = alphabet.IndexOf(singleLetter);
        int keyIndex = alphabet.IndexOf(theKey[index]);
        if ((currentLetterIndex - keyIndex) >= 0)
        {
            singleLetter = alphabet[currentLetterIndex - keyIndex];
        }
        else
        {
            singleLetter = alphabet[alphabet.Count - ((currentLetterIndex - keyIndex)*-1)];
        }
        return singleLetter.ToString();
    }
}