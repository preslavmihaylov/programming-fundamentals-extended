using System;
using System.Linq;
using System.Collections.Generic;

class LambadaExpressions
{
    static void Main()
    {
        var data =
            new Dictionary<string, Dictionary<string, string>>();

        string input = Console.ReadLine();
        while (input != "lambada")
        {
            string[] inputTokens = input
                .Split(new string[] { " => ", "." },
                       StringSplitOptions.RemoveEmptyEntries);

            if (inputTokens[0] == "dance")
            {
                /*
                data = data
                    .ToDictionary(selectorData => selectorData.Key,
                                  selectorData => selectorData.Value
                                      .ToDictionary(selectorObjectData => selectorObjectData.Key,
                                                    selectorObjectData => selectorObjectData.Key + "." + selectorObjectData.Value)); 
                 */

                var selectors = data.Keys.ToList();

                foreach (var selector in selectors)
                {
                    var selectorObjects = data[selector].Keys.ToList();
                    foreach (var selectorObject in selectorObjects)
                    {
                        data[selector][selectorObject] = 
                            selectorObject + "." + data[selector][selectorObject];
                    }
                }
            }
            else
            {
                string selector = inputTokens[0];
                string selectorObject = inputTokens[1];
                string selectorProperty = inputTokens[2];

                if (!data.ContainsKey(selector))
                {
                    data.Add(selector, new Dictionary<string, string>());
                }

                data[selector][selectorObject] = selectorProperty;
            }
            
            input = Console.ReadLine();
        }

        foreach (var selectorData in data)
	    {
            string selector = selectorData.Key;
            var selectorObjectsData = selectorData.Value;
            foreach (var selectorObjectData in selectorObjectsData)
	        {
		        string selectorObject = selectorObjectData.Key;
                string property = selectorObjectData.Value;

                Console.WriteLine("{0} => {1}.{2}",
                    selector,
                    selectorObject,
                    property);
	        }

	    }
    }
}
