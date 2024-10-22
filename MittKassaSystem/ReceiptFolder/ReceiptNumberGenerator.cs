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
        private static readonly object fileLock = new object(); // Används för att synkronisera filoperationer

        public ReceiptNumberGenerator()
        {
            LoadReceiptNumber();
        }

        // Ladda kvittonumret från fil, om filen inte finns, skapa ett nytt nummer
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
                        // Hantera korrupt data i filen
                        Console.WriteLine("Invalid data in ReceiptNumber.txt. Starting with 1.");
                        nextReceiptNumber = 1;
                        SaveReceiptNumber(); // Spara ett nytt nummer
                    }
                }
                else
                {
                    nextReceiptNumber = 1;
                    SaveReceiptNumber();  // Spara om filen inte existerar
                }
            }
            catch (Exception ex)
            {
                // Fånga eventuella fel vid läsning av filen
                Console.WriteLine($"Error reading receipt number file: {ex.Message}");
                nextReceiptNumber = 1;
            }
        }

        // Hämta nästa kvittonummer och spara det till fil
        public byte GetNextReceiptNumber()
        {
            byte currentReceiptNumber = nextReceiptNumber;

            lock (fileLock)  // Synkronisera filoperationerna med ett lås
            {
                nextReceiptNumber++;
                SaveReceiptNumber();  // Uppdatera filen med nästa nummer
            }

            return currentReceiptNumber;
        }

        // Spara det nya kvittonumret till fil
        private void SaveReceiptNumber()
        {
            try
            {
                File.WriteAllText(filePathReceiptNumber, nextReceiptNumber.ToString());
            }
            catch (Exception ex)
            {
                // Fånga eventuella fel vid skrivning till filen
                Console.WriteLine($"Error saving receipt number file: {ex.Message}");
            }
        }
    }

}
