using System;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex regex = new Regex(@"([A-Z '][a-z' ]+):([A-Z ]+)");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                var artist = regex.Match(input).Groups[1].Value;
                var song = regex.Match(input).Groups[2].Value;
                var match = regex.Match(input).Value;
                var result = "";

                if (match.Length==input.Length)
                {
                    for (int i = 0; i < artist.Length; i++)
                    {
                        if (artist[i] == ' ' || artist[i] == '\'')
                        {
                            result += artist[i];
                        }

                        else if (artist[i] == ':')
                        {
                            result += '@';
                        }
                        else
                        {
                            if (i == 0)
                            {
                                if (artist.Length + artist[i] > 90)
                                {
                                    result += (char)(artist[i] + artist.Length - 26);
                                }
                                else
                                {
                                    result += (char)(artist[i] + artist.Length);
                                }
                            }
                            else
                            {
                                if (artist.Length + artist[i] > 122)
                                {
                                    result += (char)(artist[i] + artist.Length - 26);
                                }
                                else
                                {
                                    result += (char)(artist[i] + artist.Length);
                                }
                            }


                        }
                    }

                    result += "@";

                    for (int i = 0; i < song.Length; i++)
                    {
                        if (song[i] == ' ')
                        {
                            result += song[i];
                        }

                        else if (song[i] == ':')
                        {
                            result += '@';
                        }
                        else
                        {

                            if (artist.Length + song[i] > 90)
                            {
                                result += (char)(song[i] + artist.Length - 26);
                            }
                            else
                            {
                                result += (char)(song[i] + artist.Length);
                            }

                        }
                    }
                    Console.WriteLine($"Successful encryption: {result}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }
    }
}
