using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ReceiptFolder
{
    public class ReceiptNumberGenerator
    {
        private readonly string filePathReceiptNumber = "../../../Files/ReceiptNumber.txt";
        private byte nextReceiptNumber;
        private static readonly object fileLock = new object(); 
        public ReceiptNumberGenerator()
        {
            LoadReceiptNumber();
        }
        private void LoadReceiptNumber()
        {
            try
            {
                if (File.Exists(filePathReceiptNumber))
                {
                    string content = File.ReadAllText(filePathReceiptNumber);
                    if (byte.TryParse(content, out nextReceiptNumber))
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid data in ReceiptNumber.txt. Starting with 1.");
                        nextReceiptNumber = 1;
                        SaveReceiptNumber();
                    }
                }
                else
                {
                    nextReceiptNumber = 1;
                    SaveReceiptNumber(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading receipt number file: {ex.Message}");
                nextReceiptNumber = 1;
            }
        }
        public byte GetNextReceiptNumber()
        {
            byte currentReceiptNumber = nextReceiptNumber;

            lock (fileLock)
            {
                nextReceiptNumber++;
                SaveReceiptNumber();
            }

            return currentReceiptNumber;
        }
        private void SaveReceiptNumber()
        {
            try
            {
                File.WriteAllText(filePathReceiptNumber, nextReceiptNumber.ToString());
            }
            catch (Exception ex)
            {
                
            }
        }
    }

}
