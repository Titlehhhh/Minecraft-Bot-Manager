

string[] list = {"BANANA","CARS","HOUSE","WOMEN","UNITED","HAPPY","CUPBOARD" };
var query = list.GroupBy(x => x.Length).OrderBy(x => x.Key)
.SelectMany(x => x.OrderByDescending(c => c)).ToArray();
Console.WriteLine(string.Join("\n",query));
Console.ReadLine();
