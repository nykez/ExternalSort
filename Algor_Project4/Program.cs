using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algor_Project4
{

    public struct BinStruct
    {
        public int id;
        public BinaryFile file;
        public BinStruct(int num, BinaryFile bFile)
        {
            id = num;
            file = bFile;
        }
    }


    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Console.Write("Please select your file:");

            string FilePath = string.Empty;

            // Prompt the user to get the .dat file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;
                }
            }

            // Filepath string
            Console.WriteLine(FilePath);


            // Heap Size
            Console.Write("Please enter heap size:");
            int MAX_HEAP_SIZE = Convert.ToInt32(Console.ReadLine());


            Console.Write("Please Enter Merge Amount(k):");
            int MERGE_K = Convert.ToInt32(Console.ReadLine());


            if (string.IsNullOrEmpty(FilePath))
            {
                Console.WriteLine("Not a valid file path.");
                return;
            }

            bool bDisplayValues = false;

            // Ask to display sorted values
            Console.WriteLine("Do you want to display sorted results? ([Y]/[N])");

            // Display the sorted values
            if (Console.ReadLine().ToLower() == "y")
                bDisplayValues = true;


            // Create Heap
            Heap<int> BinaryHeap = new Heap<int>();

            // Read in our Binary data file, Int32 at a time. 
            BinaryReader binaryReader = new BinaryReader(File.Open(FilePath, FileMode.OpenOrCreate));

            int Counter = 0; // Counter for Records in a Heap <= MAX_HEAP
            int FileCounter = 0; // Naming convention FileName = FileTotal + 1



            // Read all the binary data
            while (binaryReader.PeekChar() != -1)
            {

                if (Counter >= MAX_HEAP_SIZE)
                {
                    

                    BinaryHeap.WriteToFile("data_" + FileCounter.ToString() + ".bin");

                    FileCounter++;
                    Counter = 0;
                }

                BinaryHeap.Insert(binaryReader.ReadInt32());
                Counter++;


            }

            binaryReader.Close();

            // Write out the final Heap 
            BinaryHeap.WriteToFile("data_" + FileCounter.ToString() + ".bin");

            FileCounter++;


            BinStruct[] binStructs = new BinStruct[MERGE_K];

            Heap<int> fileHeap = new Heap<int>();

            int TOTAL_JUMPS = FileCounter / 2;

            // Now start the Merging files process to form 1 sorted file
            // Merge = k

            int counter = 0;

            // Merge Files:
            while (true)
            {



                TOTAL_JUMPS = TOTAL_JUMPS / 2;

                if (TOTAL_JUMPS <= 0)
                {
                    break;
                }
            }

            if (bDisplayValues)
            {
                BinaryReader bwBinaryReader = new BinaryReader(File.Open("data_" + (FileCounter - 1) + ".bin", FileMode.OpenOrCreate));

                int newCount = 0;
                while (bwBinaryReader.PeekChar() != -1)
                {
                    Console.WriteLine($"[{newCount}] - {bwBinaryReader.ReadInt32()}");
                    newCount++;
                }

                bwBinaryReader.Close();
            }

            // Cleanup
            CleanupFiles(FileCounter);

            

            Console.ReadLine();
        }

        public static void CleanupFiles(int amount)
        {
            // Delete all files but the last, that's our fully sorted file.
            for (int i = 0; i < amount-1; i++)
            {
                File.Delete("data_" + i + ".bin");
            }
        }

    }
}
