using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;


namespace Algor_Project4
{
    public class BinaryFile
    {
        public BinaryWriter binOutFile; // Output file
        public BinaryReader binInFile;  // Input file
        private long position = 0,       // Current file position
            length = 0;         // Length of input file
        bool writing = false;            // Writing == true

        // Constructor
        // Open fileName for writing if writeit == true,
        // reading if writeit == false
        public BinaryFile(string fileName, bool writeit)
        {
            writing = writeit;
            if (writing)
            {
                binOutFile = new BinaryWriter(File.Open(fileName,
                    FileMode.Create, FileAccess.Write));
            }
            else
            {
                binInFile = new BinaryReader(File.Open(fileName,
                    FileMode.Open, FileAccess.Read));
                // Set the length of this file
                length = binInFile.BaseStream.Length;
            } // if
        } // BinaryFile()

        // Write one binary record
        public void write(byte[] buffer, int size)
        {
            binOutFile.Write(buffer, 0, size);
        } // write()

        // Read one binary record
        public byte[] read(int size)
        {
            byte[] buffer = new byte[size];
            binInFile.Read(buffer, 0, size);
            return (buffer);
        } // read()

        // Return file length
        public long getLength()
        {
            return length;
        } // getLength()

        public int Peek()
        {
            return binInFile.PeekChar();
        }

            

        // Close whichever file
        public void Close()
        {
            if (writing) binOutFile.Close();
            else binInFile.Close();
        } // Close()

    } // class BinaryFile
}