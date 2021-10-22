using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Test_2
{
    public class Funktions
    {
        public static List<Result> CreateList()
        {
            List<Result> res = new List<Result>
                {
                    new Result { Key = "Blocker", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Critical", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Major", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Medium", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Minor", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Normal", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Total", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Unresolved", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0}
                };
            return res;
        }

        public static void FillList(ref List<Result> res)
        {
            string path = "../../bugs-2002.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                foreach (var r in records)
                {
                    string temp = "";
                    foreach (var key in r)
                    {
                        if (key.Key == "Labels") { temp = key.Value; }

                        if (key.Key == "Priority")
                        {
                            for (int i = 0; i < res.Count - 2; i++)
                            {
                                if (key.Value == res[i].Key)
                                {
                                    if (temp.Contains("TEAM_BEAUJOLAIS")) res[i].TEAM_BEAUJOLAIS++;
                                    else if (temp.Contains("TEAM_BORDEAUX")) res[i].TEAM_BORDEAUX++;
                                    else if (temp.Contains("TEAM_BURGUNDY")) res[i].TEAM_BURGUNDY++;
                                    else if (temp.Contains("TEAM_LOIRE")) res[i].TEAM_LOIRE++;
                                    else if (temp.Contains("TEAM_PROVENCE")) res[i].TEAM_PROVENCE++;
                                    else if (temp.Contains("TEAM_RHONE")) res[i].TEAM_RHONE++;
                                    else if (temp.Contains("MISC")) res[i].MISC++;

                                    // Подсчет строки Unresolved
                                    if (temp.Contains("TEAM_BEAUJOLAIS") && temp.Contains(",")) res[7].TEAM_BEAUJOLAIS++;
                                    else if (temp.Contains("TEAM_BORDEAUX") && temp.Contains(",")) res[7].TEAM_BORDEAUX++;
                                    else if (temp.Contains("TEAM_BURGUNDY") && temp.Contains(",")) res[7].TEAM_BURGUNDY++;
                                    else if (temp.Contains("TEAM_LOIRE") && temp.Contains(",")) res[7].TEAM_LOIRE++;
                                    else if (temp.Contains("TEAM_PROVENCE") && temp.Contains(",")) res[7].TEAM_PROVENCE++;
                                    else if (temp.Contains("TEAM_RHONE") && temp.Contains(",")) res[7].TEAM_RHONE++;
                                    else if (temp.Contains("MISC") && temp.Contains(",")) res[7].MISC++;

                                    res[i].Total = res[i].TEAM_BEAUJOLAIS + res[i].TEAM_BORDEAUX + res[i].TEAM_BURGUNDY + res[i].TEAM_LOIRE + res[i].TEAM_PROVENCE + res[i].TEAM_RHONE + res[i].MISC;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < res.Count - 2; i++)
            {
                res[6].TEAM_BEAUJOLAIS += res[i].TEAM_BEAUJOLAIS;
                res[6].TEAM_BORDEAUX += res[i].TEAM_BORDEAUX;
                res[6].TEAM_BURGUNDY += res[i].TEAM_BURGUNDY;
                res[6].TEAM_LOIRE += res[i].TEAM_LOIRE;
                res[6].TEAM_PROVENCE += res[i].TEAM_PROVENCE;
                res[6].TEAM_RHONE += res[i].TEAM_RHONE;
                res[6].MISC += res[i].MISC;
                res[6].Total += res[i].Total;
            }

            res[7].Total = res[7].TEAM_BEAUJOLAIS + res[7].TEAM_BORDEAUX + res[7].TEAM_BURGUNDY + res[7].TEAM_LOIRE + res[7].TEAM_PROVENCE + res[7].TEAM_RHONE + res[7].MISC;
        }

        public static void WriteList(List<Result> res)
        {
            using (var writer = new StreamWriter("../../bug-summary-2002.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(res);
                Console.WriteLine("Запись данных произведена успешно!");
            }
        }
    }
}

