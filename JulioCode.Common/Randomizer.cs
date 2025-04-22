using System.Text;

namespace JulioCode12.Common;

// ReSharper disable once IdentifierTypo
public class Randomizer
{
    public Random Seeder { get; set; } = new Random();

    //public char[] ConsonantsArray = "BCDFGJKLMNPQSTVXZHRWY.".ToCharArray();
    public char[] ConsonantsArray = "bcdfgjklmnpqstvxzhrwy.".ToCharArray();
    public char[] VowelsArray = "aeiou.".ToCharArray();
    public char[] Numbers = "0123456789.".ToCharArray();

    public char Consonant {
        get {
            var ix = Seeder.Next(0, ConsonantsArray.Length - 1);
            return ConsonantsArray[ix];
        }
    }

    public char Vowel {
        get {
            var ix = Seeder.Next(0, VowelsArray.Length - 1);
            return VowelsArray[ix];
        }
    }

    public string GetCV {
        get {
            return "" + Consonant + Vowel;
        }
    }

    public string GetVC {
        get {
            return "" + Vowel + Consonant;
        }
    }


    public string GetCVC {
        get {
            return "" + Consonant + Vowel + Consonant;
        }
    }

    public string GetVCV {
        get {
            return ""  + Vowel + Consonant + Vowel;
        }
    }

    private Func<string>[] _syllablesFunctions;
    public Func<string>[] SyllablesFunctions {
        get {
            if (_syllablesFunctions == null) { _syllablesFunctions = new Func<string>[] {() => GetCV, () => GetVC, () => GetCVC, () => GetVCV};}
            return _syllablesFunctions;
        }
    }

    public string Syllable {
        get {
            var ix = Seeder.Next(0, 5);
            // this is a distribution algorithm.
            // this is used to get 2 times more two-characters syllables than three-characters' one
            switch (ix)
            {
                case 5:
                    return SyllablesFunctions[4].Invoke();
                case 4:
                    return SyllablesFunctions[3].Invoke();
                default:
                    ix %= 2;
                    return SyllablesFunctions[ix].Invoke();
            }
        }
    }

    public string Word {
        get {
            // used to provide a distribution of word length/type
            var length = Seeder.Next(1, 20); 
            switch (length) {
                case (>16):
                    return Syllable + Syllable + Syllable + Syllable;
                case (>10):
                    return Syllable + Syllable + Syllable;
                case (> 4):
                    return Syllable + Syllable;
                case (> 1):
                    return Syllable;
                default:
                    return Vowel.ToString();
            }
        }
    }

    public string GetWord(int minLength, int maxLength) {
            // used to provide a distribution of word length/type
        var length = Seeder.Next(minLength, maxLength);
        var word = string.Empty;
        while (word.Length <= length) {
            word = word + Syllable;
        }
        if (word.Length > maxLength) { word = word.Substring(0, maxLength); }
        return word;
   }

    public string Paragraph => GetParagraph(5, 30);

    public string GetParagraph(int min, int max)
    {
        var length = Seeder.Next(min, max);
        var paragraph = new StringBuilder();
        var firstWord = Word + " ";
        firstWord = firstWord.Substring(0, 1).ToUpper() + firstWord.Substring(1);
        paragraph.Append(firstWord + " ");

        for (var i = 1; i < length - 1; i++) {
            paragraph.Append(Word + " ");
        }

        paragraph.Append(Word);

        return paragraph.ToString();
    }

    public string Month => Seeder.Next(1,12).ToString();

    public string GetDay(int month)
    {
        int day;
        if (month == 2) day = Seeder.Next(1, 28);
        else
        {
            if (month % 2 == 0) day = Seeder.Next(1, 30);
            else day = Seeder.Next(1, 31);
        }

        return day.ToString().PadLeft(2, '0');
    }
}
