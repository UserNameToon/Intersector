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

        // **************************************************************************
        // Method  :    public static float[] GenerateFloats(Random rng, int arrSize)
        // Purpose :    Generates an array of floats of a specified size wherein the
        //              floats are in the range [1,2].
        // Returns :    float[] of specified size with random floats in range [1,2].
        // **************************************************************************
        public static float[] GenerateFloats(Random rng, int arrSize = 240)
        {
            float[] generated = new float[arrSize];     // Array to be returned
            float toGen = 0;                           // Float to be generated

            for (int i = 0; i < arrSize; ++i)
            {
                // Increase toFloat by one to make range between 1 and 2
                toGen = (float)rng.NextDouble() + 1;

                // Shear off numbers beyond the last decimal we care about
                toGen = (float)Math.Round(toGen, 3);
                generated[i] = toGen;
            }
            return generated;
        }

        // **************************************************************************************
        // Method  :    public static void BubbleSort(List<float> lst)
        // Purpose :    Sorts a list of floats in ascending order using the BubbleSort algorithm.
        // Returns :    Nothing.
        // **************************************************************************************
        public static void BubbleSort(List<float> lst)
        {
            bool hasSwapped = false;        // Flag for having swapped two elements
            int index = 0;                  // Index for use when swapping
            float temp = 0;                 // Temporary variable for use when swapping

            do
            {
                hasSwapped = false;         // Reset flag
                index = 0;                  // Reset index
                // The counter will not work per se, I was thinking about InsertSort rather than BubbleSort.
                // Bubblesort should bubble up large numbers to the very top, so it should be sorted at the end
                // instead of the beginning.  It could be possible to limit the upper bound as you progress
                // which would be the same thing we talked about before.
                do
                {
                    if ((index + 1) < lst.Count)
                    {
                        if (lst[index] > lst[index + 1])
                        {
                            temp = lst[index];
                            lst[index] = lst[index + 1];
                            lst[index + 1] = temp;
                            hasSwapped = true;
                        }
                    }
                    ++index;
                }
                // Consider changing the negation here: !(index > (list.Count -1)) should be equal to index <= list.Count - 1
                // Which is a bit more readable
                while (!(index > (lst.Count - 1)));
            }
            while (hasSwapped);
        }
    }
}
