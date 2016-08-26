using System.Collections.Generic;

public static class ColorWrapper {
    public static Dictionary<string, string> colorWrap = new Dictionary<string, string>()
    {
		{"sample" ,"#61380B"}

	};
    
    public static string Colorize(this string text)
    {
        var result = "";
        foreach (var word in text.Split(' '))
        {
			if (word == "\\n")
			{
				result += '\n';
				continue;
			}
			
			var findedBind = "";
            foreach (var bind in colorWrap.Keys)
                if (word.ToLower().StartsWith(bind))
                    findedBind = bind;

            if (findedBind != "")
                result += "<b><color=" + colorWrap[findedBind] + ">" + word + "</color></b> ";
            else
                result += word + ' ';
        }
        return result.Substring(0, result.Length-1);
    }
}
