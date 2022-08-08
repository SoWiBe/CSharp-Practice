using CodeWarsKatas;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;

class LearnSharp
{
    public LearnSharp()
    {
        //products.Sort((x, y) => x.Name.CompareTo(y.Name));
        //foreach(Product product in products)
        //{
        //    Console.WriteLine(product);
        //}

        //List<Product> productsList = Product.GetSampleProducts();
        //Predicate<Product> test = delegate (Product p) { return p.Price > 10m; };
        //List<Product> matches = products.FindAll(test);
        //Action<Product> print = Console.WriteLine;
        //matches.ForEach(print);

        List<Product> products = Product.GetSampleProducts();
        List<Supplier> suppliers = new List<Supplier>();
        var filtered1 = from p in products
                       join s in suppliers
                       on p.SupplierId equals s.SupplierID
                       where p.Price > 10
                       orderby s.Name, p.Name
                       select new { SupplierName = s.Name, ProductName = p.Name };
        foreach (Product product in products.Where(p => p.Price > 10))
        {
            Console.WriteLine(product);
        }
        foreach (var v in filtered1)
        {
            Console.WriteLine("Supplier={0}; Product={1}",
                v.SupplierName, v.ProductName);
        }

        XDocument doc = XDocument.Load("data.xml");
        var filtered2 = from p in doc.Descendants("Product")
                       join s in doc.Descendants("Supplier")
                       on p.Attribute("SupplierID")
                       equals s.Attribute("SupplierID")
                       where (decimal)p.Attribute("Price") > 10
                       orderby s.Attribute("Name"), p.Attribute("Name")
                       select new
                       {
                           SupplierName = s.Attribute("Name"),
                           ProductName = p.Attribute("Name")
                       };
        foreach (var v in filtered2)
        {
            Console.WriteLine("Supplier={0}, Product={1}", v.SupplierName, v.ProductName);
        }
    }
}

//Kata's

class Alpha
{

    public static bool Alphanumeric(string str)
    {
        return Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
    }
}

class Bets
{
    public static int Score(int[] dice)
    {
        int score = 0;
        int numberToCheck = 0;
        int count = 0;
        foreach (int number in dice)
        {
            if(dice.Count(x => x == number) >= 3)
            {
                score = 100 * number;
                if (number == 1)
                    score *= 10;
                numberToCheck = number;
                break;
            }
        }

        foreach(int num in dice)
        {
            if(numberToCheck == num && count < 3)
            {
                count++;
                continue;
            }
            if (num == 1)
                score += 100;
            else if (num == 5)
                score += 50;
        }
        return score;
    }
}

class Omega
{
    public static int SumIntervals((int, int)[] intervals)
    {
        return intervals.Sum(x => x.Item2 - x.Item1);
    }
}

class KataSumString
{
    public static string SumStrings(string str1, string str2)
    {
        if (str1.Length > str2.Length)
        {
            string t = str1;
            str1 = str2;
            str2 = t;
        }

        // Take an empty string for storing result
        string str = "";

        // Calculate length of both string
        int n1 = str1.Length, n2 = str2.Length;
        int diff = n2 - n1;

        // Initially take carry zero
        int carry = 0;

        // Traverse from end of both strings
        for (int i = n1 - 1; i >= 0; i--)
        {
            // Do school mathematics, compute sum of
            // current digits and carry
            int sum = ((int)(str1[i] - '0') +
                    (int)(str2[i + diff] - '0') + carry);
            str += (char)(sum % 10 + '0');
            carry = sum / 10;
        }

        // Add remaining digits of str2[]
        for (int i = n2 - n1 - 1; i >= 0; i--)
        {
            int sum = ((int)(str2[i] - '0') + carry);
            str += (char)(sum % 10 + '0');
            carry = sum / 10;
        }

        // Add remaining carry
        if (carry > 0)
            str += (char)(carry + '0');

        // reverse resultant string
        char[] ch2 = str.ToCharArray();
        Array.Reverse(ch2);
        if (ch2[0].Equals('0'))
        {
            ch2 = new string(ch2).Remove(0, 1).ToCharArray();
        }
        return new string(ch2);
    }
    
}

class KataPigLatin
{
    public static string PigIt(string str)
    {
        string[] words = str.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            if (!Regex.IsMatch(words[i], @"^[a-zA-Z0-9]+$"))
                continue;
            char[] symbols = words[i].ToCharArray();
            char elem = symbols[0];
            symbols = new string(symbols).Remove(0, 1).ToCharArray();
            words[i] = new string(symbols) + elem + "ay"; 
        }
        str = "";
        for (int i = 0; i < words.Length; i++)
        {
            str += words[i];
            str += " ";
        }
        return str.Remove(str.Length - 1);
    }
}


