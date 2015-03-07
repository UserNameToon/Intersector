using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntersectorMethods
{
    public class IntersectorMethods
    {
        // **********************************************************************************
        // Method  :    public static void WriteToFile(List<float> lst, string filename)
        // Purpose :    Writes a given list to a file given a string for generating the file-
        //              name.
        // Returns :    Nothing.    (Maybe this should be boolean to catch success of write?)
        // **********************************************************************************
        // Cleaned up code and changed names to make it easier to combine things later. - Jonathan
        public static void WriteToFile(List<float> lst, string filename)
        {
            StreamWriter swOutFile;
            try
            {
                swOutFile = new StreamWriter(filename, false);

                // This should ensure that each number has exactly three significant figures
                // Something like 1.700 will be written 1.7 which cannot happen, so some
                // formatting should be added to the Write command.
                for (int i = 0; i < lst.Count; i++)
                    swOutFile.Write(lst[i] + " ");

                swOutFile.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error opening	{0}	occurred.", filename);
                Console.WriteLine("The error was: {0}", ex.Message);
            }   
        }
    }
}
