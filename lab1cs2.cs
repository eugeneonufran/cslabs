using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                char[] alphabet = new char[33] {'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и',
                                            'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я' };
                double[] numberOfOccurence = new double[33];
                double frequency = 0;
                double entropy = 0;
                int amount_of_letters = 0;
                string file_address = @"D:\zakop(base64).txt";
                FileInfo file = new FileInfo(file_address);
                using (StreamReader sr = new StreamReader(file_address))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < 33; i++)
                        {
                            var count = line.Count(x => x == alphabet[i]);
                            numberOfOccurence[i] += count;
                            amount_of_letters += line.Count(Char.IsLetter);
                        }
                        Console.WriteLine();
                    }
                }
                for (int i = 0; i < 33; i++)
                {
                    frequency = numberOfOccurence[i] / 33; 
                    Console.WriteLine("Відносна частота появи символу \"" + alphabet[i] + "\" у тексті = " + frequency);
                    if (frequency != 0)
                    {
                        entropy += frequency * (Math.Log(1 / frequency, 2));
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Середня ентропія нерівномірно алфавіту у заданому тексті: " + entropy);
                Console.WriteLine("Кількість інформації у тексті: " + amount_of_letters/8);
                if (amount_of_letters/8 > file.Length)
                {
                    Console.WriteLine("");
                }
                else if (amount_of_letters / 8 < file.Length)
                {
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Кількість інформації у тексті така ж, як і розмір файлу: " + file.Length);
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
