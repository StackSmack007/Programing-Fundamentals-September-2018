using System;
using System.Collections.Generic;
using System.Linq;
namespace zad_10
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> placeSingerProffit = new Dictionary<string, Dictionary<string, double>>();
            string inputRow = Console.ReadLine();
            while (inputRow != "End")
            {
                bool correctInput = true;//невинен до доказване на противното
                for (int i = 1; i < (inputRow + " ").Length - 2; i++)
                {
                    if (inputRow[i] == '@' & inputRow[i - 1] != ' ') { correctInput = false; }
                    if ((inputRow[i] >= 45 & inputRow[i] <= 57) &
                        ((!(inputRow[i - 1] >= 45 & inputRow[i - 1] <= 57) & inputRow[i - 1] != 32)
                        || (!(inputRow[i + 1] >= 45 & inputRow[i + 1] <= 57) & inputRow[i + 1] != 32)
                        ))
                    {
                        correctInput = false;
                    }
                }
                string[] nameAndPlace = inputRow.Split('@').ToArray();//разцепи на 2 име_ и дрън дрън нататък масив от 2 неща!
                nameAndPlace[0] = nameAndPlace[0].TrimEnd(' ');//махни спейса в края на името
                inputRow = nameAndPlace[1];//името го взехме вече презапиши мястото билетитите в стринга
                List<string> helpingList = inputRow.Split(' ').ToList();// правим лист(помощен) със 3 неща място ; билет цена ; билети бройка 
                inputRow = Console.ReadLine();//въвеждаме следващия вход приключили сме със стринга вече ще работим с листа само
                if (!correctInput) { continue; }//ако не е коректен стринга не прави следващите неща ами върни от уаила в началото наново.
                string place = "";
                double[] ticketPrice_Count = { 0.0, 0.0 }; //в тоз масив ще пазим цена и бройка на билети
                foreach (var item in helpingList)
                {
                    double result = 0.0;
                    bool isNumber = double.TryParse(item, out result);//търсим число ако го намерим вкарваме в променлива
                    if (isNumber)//ако е число
                    {
                        if (ticketPrice_Count[0] == 0)//попълваме първо цената на билета ако е празна 0ла
                        {
                            ticketPrice_Count[0] = result;
                        }
                        else //попълваме 2ро бройката на билетите ако цената не е празна 0ла
                        {
                            ticketPrice_Count[1] = result;
                        }
                    }
                    else //Ако не си число значи си място
                    {
                        if (place == "")//мястото е празно почни с това
                        {
                            place = item;
                        }
                        else//мястото НЕ Е празно добави един спейс и лепни нататък да се допише Велико + "_" + Търново
                        {
                            place += " " + item;
                        }
                    }
                }
                nameAndPlace[1] = place;   //вече в масива имаме име на певеца и място
                double proffit = ticketPrice_Count[0] * ticketPrice_Count[1];//тук се калкулират от масива за цена и бройка билети приходите
                if (!placeSingerProffit.ContainsKey(place))
                {
                    placeSingerProffit[nameAndPlace[1]] = new Dictionary<string, double>();
                    placeSingerProffit[nameAndPlace[1]].Add(nameAndPlace[0], proffit);
                }
                else if (!placeSingerProffit[nameAndPlace[1]].ContainsKey(nameAndPlace[0]))
                {
                    placeSingerProffit[nameAndPlace[1]][nameAndPlace[0]] = proffit;
                }
                else
                {
                    placeSingerProffit[nameAndPlace[1]][nameAndPlace[0]] += proffit;
                }
            }
            foreach (var kvp in placeSingerProffit)
            {
                Console.WriteLine(kvp.Key);
                foreach (var singer in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }
    }
}
