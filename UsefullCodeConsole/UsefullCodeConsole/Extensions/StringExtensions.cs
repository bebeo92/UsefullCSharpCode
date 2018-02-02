using System.Collections.Generic;
using System.Linq;

namespace UsefullCodeConsole.Extensions
{
    public static class StringExtensions
    {
	    public static string ReplaceNonAsciiCharater(this string input)
	    {
		    var inputArray = input.ToCharArray();
		    //Filter not printable ASCII characters
		    var specialCharacter = inputArray.Where(x => x < 32 || x > 126);
		    if (!specialCharacter.Any())
		    {
			    return input;
		    }

		    var nonAsciiCharacters = new Dictionary<string, string>
		    {
			    {"ae" , "äæǽ"},
			    {"oe" , "öœ"},
			    {"ue" , "ü"},
			    {"Ae" , "Ä"},
			    {"Ue" , "Ü"},
			    {"Oe" , "Ö"},
			    {"A" , "ÀÁÂÃÄÅǺĀĂĄǍ"},
			    {"a" , "àáâãåǻāăąǎª"},
			    {"C" , "ÇĆĈĊČ"},
			    {"c" , "çćĉċč"},
			    {"D" , "ÐĎĐ"},
			    {"d" , "ðďđ"},
			    {"E" , "ÈÉÊËĒĔĖĘĚ"},
			    {"e" , "èéêëēĕėęě"},
			    {"G" , "ĜĞĠĢ"},
			    {"g" , "ĝğġģ"},
			    {"H" , "ĤĦ"},
			    {"h" , "ĥħ"},
			    {"I" , "ÌÍÎÏĨĪĬǏĮİ"},
			    {"i" , "ìíîïĩīĭǐįı"},
			    {"J" , "Ĵ"},
			    {"j" , "ĵ"},
			    {"K" , "Ķ"},
			    {"k" , "ķ"},
			    {"L" , "ĹĻĽĿŁ"},
			    {"l" , "ĺļľŀł"},
			    {"N" , "ÑŃŅŇ"},
			    {"n" , "ñńņňŉ"},
			    {"O" , "ÒÓÔÕŌŎǑŐƠØǾ"},
			    {"o" , "òóôõōŏǒőơøǿº"},
			    {"R" , "ŔŖŘ"},
			    {"r" , "ŕŗř"},
			    {"S" , "ŚŜŞŠ"},
			    {"s" , "śŝşšſ"},
			    {"T" , "ŢŤŦ"},
			    {"t" , "ţťŧ"},
			    {"U" , "ÙÚÛŨŪŬŮŰŲƯǓǕǗǙǛ"},
			    {"u" , "ùúûũūŭůűųưǔǖǘǚǜ"},
			    {"Y" , "ÝŸŶ"},
			    {"y" , "ýÿŷ"},
			    {"W" , "Ŵ"},
			    {"w" , "ŵ"},
			    {"Z" , "ŹŻŽ"},
			    {"z" , "źżž"},
			    {"AE" , "ÆǼ"},
			    {"ss" , "ß"},
			    {"IJ" , "Ĳ"},
			    {"ij" , "ĳ"},
			    {"OE" , "Œ"},
			    {"f" , "ƒ"}
		    };		    

		    foreach (var normalCharacter in nonAsciiCharacters.Keys)
		    {
			    var specialCharaters = nonAsciiCharacters[normalCharacter].ToCharArray();
			    var specialCharacterFound = inputArray.Intersect(specialCharaters).ToList();
			    if (!specialCharacterFound.Any())
			    {
				    continue;
			    }

			    foreach (var special in specialCharacterFound)
			    {
				    input = input.Replace(special + "", normalCharacter);
			    }
		    }

		    return input;
	    }
    }
}
