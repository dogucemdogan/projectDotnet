using System;
using System.IO.Compression;
using System.Xml;

enum DocumentTypes 
    {
        Invoice,
        DespatchAdvice
    }

namespace dotnetProject
{
    class Program
    {

        static void ExtractZipFile(string zipPath, string destinationPath)
        {

            try
            {
                ZipFile.ExtractToDirectory(zipPath, destinationPath);
            }
            catch (Exception e)
            {
                if (e.Message != null)
                    Console.WriteLine(e.Message);
                throw;
            }
        }

        static void ReadXml(string xmlPath)
        {
            try
            {
                using (XmlReader xmlData = XmlReader.Create(xmlPath))
                {
                    while (xmlData.Read())
                    {
                        if(xmlData.IsStartElement())
                        {
                            switch (xmlData.Name.ToString())
                            {
                                case "Identifier": 
                                Console.WriteLine(xmlData.ReadString());  
                                    break;
                                case "Title":
                                     xmlData.ReadString();
                                     break;
                                case "Type":
                                    xmlData.ReadString();
                                    break;
                                case "FirstCreationTime":
                                    xmlData.ReadString();
                                    break;
                                case "AccountType":
                                    xmlData.ReadString();
                                    break;
                                case "Name":
                                    xmlData.ReadString();
                                    break;
                                case "CreationTime":
                                    Console.WriteLine(xmlData.ReadString()); 
                                    break;    
                            
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message != null)
                    Console.WriteLine(e.Message);
                throw;
            }



        }

         static void Main(string[] args)
    {

        //ExtractZipFile("./ResourceFiles/newUserGbListxml.zip", "./ResourceFiles");
        ReadXml("./ResourceFiles/newUserGbList.xml");
    }



    }

   
}

