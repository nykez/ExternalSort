# ExternalSort

1) Ask the user which file to sort.   The file will be a binary file of integers.

2)  Ask the user for the heap size to use.   Read in integers from the file, place them into the heap. When the heap becomes full or end of file is reached, sort the heap and write the contents out to a temp file.

3) Repeat #2 until the end of the file has been reached.

4) Merge the temp files, merging k files at a time (or all the files if the number of files <k), creating new temp files.   Ask the user for the value of k, the number of files to merge.

                4a) Create a struct containing two items:    int  and BinaryFile

                4b) Create an array of structs in 4a of size k (one for each binary file)

                4c) Create a min heap with the array in 4b and place the first integer in

                       each file in the struct (in the int field).
               4d) Extract the top node from the min heap, writing the int of that node into the output file.  Read in from the binary file of the node (just extracted) the next record and insert that into the min heap.  If the node (just extracted) has reached the end of file, then reduce5) Repeat 4 until there is one file, the sorted file. 

6) Delete the temp files with only the sorted file remaining.  Give a option not to display the sorted file, because we will be using large files which take a very long time to display.


Test Case: 300.bin h=1, k=2
Test Case: 10,000,000 bin h=9999 k=7, under 2 minutes
