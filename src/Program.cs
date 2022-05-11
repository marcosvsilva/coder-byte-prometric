using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; //Install Package

class MainClass
{
    public static void Main(string[] args)
    {
        List<Shape> forms = new List<Shape>();      //Array of shapes
        forms.Add(new Circle(13.2));                //Circle
        forms.Add(new Quadrilaterals(19.2, 19.2));  //Square
        forms.Add(new Quadrilaterals(19.5, 20.3));  //Rectangle
        forms.Add(new Triangle(7.1, 7.1, 7.1));     //Triangle equilateral
        forms.Add(new Triangle(9.3, 9.3, 7.1));     //Triangle isosceles
        forms.Add(new Triangle(9.3, 8.6, 7.1));     //Triangle scalene

        string title = "ORIGINAL FORMS";
        printPropertiesForm(forms, title);

        //Sort by Area
        title = "SORT BY AREA";
        forms.Sort(new SortByArea());
        printPropertiesForm(forms, title);

        //Sort by Perimete
        title = "SORT BY PERIMERER";
        forms.Sort(new SortByPerimeter());
        printPropertiesForm(forms, title);

        //Serialize to json
        string nameOfJson = "objects";
        if (serializeForms(forms, nameOfJson))
        {
            Console.Write("Serialize successful!\n");
        }

        List<Shape> newForms = deserializeJson(nameOfJson);
        if (newForms.Count > 0)
        {
            title = "DESERIALIZE PRINT FORMS";
            printPropertiesForm(newForms, title);
        }
    }

    private static void printPropertiesForm(List<Shape> listForms, string title)
    {
        Console.Write($"|----------------{title}----------------|\n");

        foreach (Shape f in listForms)
        {
            Console.Write("|-------------------------------------------|\n");
            Console.Write(" " + f.name + '\n');
            Console.Write(" " + f.getFullName() + '\n');
            Console.Write(" " + f.printArea() + '\n');
            Console.Write(" " + f.printPerimeter() + '\n');
        }
    }

    private static Boolean serializeForms(List<Shape> listForms, string jsonFile)
    {
        try
        {
            string jsonString = "[*,";
            foreach (Shape f in listForms)
            {
                if (f.GetType() == typeof(Circle))
                {
                    jsonString += "," + JsonSerializer.Serialize((Circle)f);
                }
                else if (f.GetType() == typeof(Quadrilaterals))
                {
                    jsonString += "," + JsonSerializer.Serialize((Quadrilaterals)f);
                }
                else if (f.GetType() == typeof(Triangle))
                {
                    jsonString += "," + JsonSerializer.Serialize((Triangle)f);
                }
            }

            jsonString = jsonString.Replace("*,,", "") + "]";
            File.WriteAllText($"{jsonFile}.json", jsonString);
            return true;
        }
        catch (JsonException e)
        {
            Console.Write($"Error {e}");
            return false;
        }

    }

    private static List<Shape> deserializeJson(string jsonString)
    {
        try
        {
            List<Shape> newForms = new List<Shape>();
            using (StreamReader r = new StreamReader($"{jsonString}.json"))
            {
                string json = r.ReadToEnd();
                List<JsonDeserialize> listObjects = JsonSerializer.Deserialize<List<JsonDeserialize>>(json);

                foreach (JsonDeserialize obj in listObjects)
                {
                    if (obj.name == "Circle")
                    {
                        newForms.Add(new Circle(obj.radius)); // Circle
                    }
                    else if(obj.name == "Triangle")
                    {
                        newForms.Add(new Triangle(obj.a, obj.b, obj.c));
                    }
                    else if (obj.name == "Quadrilaterals")
                    {
                        newForms.Add(new Quadrilaterals(obj.swidth, obj.length));
                    }
                }
            }

            return newForms;
        }
        catch (JsonException e)
        {
            Console.Write($"Error {e}");
            return null;
        }
    }
}