using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var playersSkills = new Dictionary<string, Dictionary<string, int>>();


            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    var line = input.Split(new string[]{" -> "}, StringSplitOptions.RemoveEmptyEntries);
                    string player = line[0];
                    string position = line[1];
                    int skill = int.Parse(line[2]);
                    if (!playersSkills.ContainsKey(player))
                    {
                        playersSkills.Add(player, new Dictionary<string, int>());
                    }

                    if (!playersSkills[player].ContainsKey(position))
                    {
                        playersSkills[player].Add(position, skill);
                    }

                    else
                    {
                        if (playersSkills[player][position] < skill)
                        {
                            playersSkills[player][position] = skill;
                        }
                    }
                }

                else
                {
                    string[] battle = input.Split(new string[] { " vs " }, StringSplitOptions.RemoveEmptyEntries);
                    string firstUser = battle[0];
                    string secondUser = battle[1];

                    bool usersExist = CheckUsers(playersSkills, firstUser, secondUser);



                    if (usersExist)
                    {
                        string samePosition = "Mortal Combat:)";
                        while (samePosition != null)
                        {
                            samePosition = CheckSamePositions(playersSkills, firstUser, secondUser);
                            if (samePosition != null)
                            {
                                Battle(playersSkills, samePosition, firstUser, secondUser);
                            }
                        }

                    }
                }

                input = Console.ReadLine();
            }

            foreach (var player in playersSkills.Where(x => x.Value.Count != 0).OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var skill in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {skill.Key} <::> {skill.Value}");
                }
            }
        }

        public static void Battle(Dictionary<string, Dictionary<string, int>> playersSkills, string samePosition, string firstUser, string secondUser)
        {
            if (playersSkills[firstUser][samePosition] > playersSkills[secondUser][samePosition])
            {
                playersSkills[secondUser].Remove(samePosition);
            }
            else if (playersSkills[firstUser][samePosition] < playersSkills[secondUser][samePosition])
            {
                playersSkills[firstUser].Remove(samePosition);
            }
        }

        public static bool CheckUsers(Dictionary<string, Dictionary<string, int>> playersSkills, string firstUser, string secondUser)
        {
            if (playersSkills.ContainsKey(firstUser) && playersSkills.ContainsKey(secondUser))
            {
                return true;
            }
            return false;
        }

        public static string CheckSamePositions(Dictionary<string, Dictionary<string, int>> playersSkills, string firstUser, string secondUser)
        {
            foreach (var firstPlayerPosition in playersSkills[firstUser])
            {
                foreach (var secondPlayerPosition in playersSkills[secondUser])
                {
                    if (firstPlayerPosition.Key == secondPlayerPosition.Key)
                    {
                        return firstPlayerPosition.Key;

                    }
                }
            }

            return null;
        }
    }
}
