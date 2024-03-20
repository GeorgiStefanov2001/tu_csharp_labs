using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PrCSharp_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            string baseDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

            Console.WriteLine("1) Exercise 1");
            Console.WriteLine("2) Exercise 2");
            Console.WriteLine("3) Quit");

            Console.Write("Select option: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ParseGeoCoordinates(Path.Combine(baseDir, "input1.txt"), Path.Combine(baseDir, "output1.json"));
                    break;
                case 2:
                    TelephoneContacts(Path.Combine(baseDir, "input2.txt"), Path.Combine(baseDir, "output2.xml"));
                    break;
                case 3:
                    break;
                default:
                    throw new ArgumentException("Wrong option selected");
            }
        }

        static void ParseGeoCoordinates(string sourceFile, string outputFile)
        {
            List<GeographicCoordinates> coordinates = new List<GeographicCoordinates>();

            string[] coordPairs = File.ReadAllText(sourceFile).Split(";");

            foreach(var pair in coordPairs)
            {
                string[] coordinatesSplit = pair.Split(',');
                coordinates.Add(new GeographicCoordinates(double.Parse(coordinatesSplit[0]), double.Parse(coordinatesSplit[1])));
            }

            string resultJson = "[";
            for(int i = 0; i<coordinates.Count; i++)
            {
                resultJson += "{\"lat\":" + coordinates[i].Latitude + ",\"lng\":" + coordinates[i].Longitude + "}";
                if (i < coordinates.Count - 1) resultJson += ",";
            }
            resultJson += "]";

            File.WriteAllText(outputFile, resultJson);
        }

        static void TelephoneContacts(string sourceFile, string outputFile)
        {
            Console.OutputEncoding = Encoding.UTF8;
            char[] delimChars = new char[] { ' ', '\n', '\t' };
            const int offset = 6;

            List<PhoneContact> contacts = new List<PhoneContact>();

            string[] input = File.ReadAllText(sourceFile).Split(delimChars, StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < input.Length; i += offset)
            {
                PhoneContact contact = new PhoneContact();
                for(int currSel = i; currSel < i + offset; currSel++)
                {
                    var entity = input[currSel].Trim();

                    if (entity.Length == 6)
                    {
                        // we have found the id
                        contact.ID = entity.Trim();
                    }else if(Regex.IsMatch(entity, @"\p{IsCyrillic}"))
                    {
                        // we have found the name
                        contact.Name = entity.Trim();
                    }
                    else
                    {
                        // we have found the number
                        contact.Number = (entity + input[currSel + 1] + input[currSel + 2] + input[currSel + 3]).Trim();
                        currSel += 3;
                    }
                }

                contacts.Add(contact);
            }

            //write result to xml
            XmlDocument output = new XmlDocument();
            XmlElement root = output.CreateElement("Contacts");
            output.AppendChild(root);

            foreach (var contact in contacts)
            {
                XmlElement contactElement = output.CreateElement("Contact");

                XmlElement nameElement = output.CreateElement("Name");
                nameElement.InnerText = contact.Name;
                contactElement.AppendChild(nameElement);

                XmlElement idElement = output.CreateElement("ID");
                idElement.InnerText = contact.ID;
                contactElement.AppendChild(idElement);

                XmlElement phoneNumberElement = output.CreateElement("PhoneNumber");
                phoneNumberElement.InnerText = contact.Number;
                contactElement.AppendChild(phoneNumberElement);

                root.AppendChild(contactElement);
            }

            output.Save(outputFile);
        }
    }
}
