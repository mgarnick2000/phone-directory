using System;
using System.Text.RegularExpressions;

namespace phone_directory
{
    class Program
    {
        static void Main(string[] args)
        {

            string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
            + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
            + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
            + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
            + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
            + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
            + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
            + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
            + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
            + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
            + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";
            // string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n";
            Phone(dr, "+1-541-754-3010");
            // string dr = "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n";
            // Phone(dr, "+1-908-512-2222");
            // Phone(dr, "+48-421-674-8974");
            // Phone(dr, "+1-098-512-2222");
            Phone(dr,"*+19-421-674-8974" );
        }

        static string Phone(string strng, string num)
        {
            string[] phone = strng.Split(new Char[] { '\n' });
            string item = Array.Find(phone, x => x.Contains(num));
            Console.WriteLine(item);
            int found = strng.IndexOf(num);
            string result;
            if (found != -1)
            {
                result = "Error => Too many people: {num}";
            }
            if (found == -1)
            {
                result = $"Error => Not found: {num}";
            }
            string[] words = strng.Split(new Char[] { '/', '$', '!', '\n', '?', '*', '.' });


            int namenum = item.IndexOf("<");

            int startphonenum = item.IndexOf(num);

            int endphonenum = num.Length + 1;
            // Console.WriteLine(endphonenum);

            // string name = Array.Find<string>(words, x => x.StartsWith("<") | x.EndsWith(">"));
            int startname = item.IndexOf("<");
            int endName = item.IndexOf(">");
            string name = item.Substring(startname, endName - startname).Trim(new Char[] { '<', '>' });
            // string person = name.Trim(new Char[] { ' ', '<', '>' });
            // Console.WriteLine(name);

            string noname = item.Replace($"<{name}>", String.Empty).Replace(num, String.Empty).Replace(";", "").Replace("  ", " ").Replace("+", "").Replace("*", "").Replace(":", "").Replace(",", "").Replace("_", " ").Replace("!!", "").Replace("-", "-").Replace("$", "").Trim(new Char[] { '/', ' ', '+' });
            string fname = Regex.Replace(noname, @"\s+", " ");
            char[] delimiter = { '/', '$', '!', '\n', '?', '*', '.' };

            string[] split = strng.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            string phoneNum = num.Trim(new Char[] { '+', ' ', '*' });
            result = $"Phone => {phoneNum}, Name => {name}, Address => {fname}";
            Console.WriteLine(result);
            return result;
        }

    }
}
