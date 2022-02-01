using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Média_Matriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d = new Random();
            int dimensionMatrice = 10;
            int[,] matrice = new int[dimensionMatrice, dimensionMatrice];
            for (int i = 0; i < dimensionMatrice; i++) {
                for (int j = 0; j < dimensionMatrice; j++) {
                    matrice[i,j] = d.Next(50);
                }
            }
            doTasks(matrice, dimensionMatrice);
            Console.ReadKey();
        }
        static public async void doTasks(int[,] matrice, int dimension)
        {
            List<Task <int>> tasks = new List<Task <int>>();
            for (int i = 0; i < (dimension - 1); i++) {
                tasks.Add(Task.Factory.StartNew((a) => {
                    string k = a.ToString();
                    int l = int.Parse(k);
                    Console.WriteLine(l);
                    int averageValue = 0;
                    for (int j = 0; j < (dimension -1); j++) {
                        averageValue += matrice[l,j];
                    }
                   return averageValue;
                }, i));
            }
            Task.WaitAll(tasks.ToArray());
            Task <int>[] arrayTasks = tasks.ToArray();
            float avgValue = 0;
            for (int k = 0; k < (dimension - 1); k++) {
                avgValue += (float)arrayTasks[k].Result / dimension;
                Console.WriteLine("avgValue in loop: " + avgValue);
                Console.WriteLine(arrayTasks[k].Result);
            }
            Console.WriteLine("avgValue: " + avgValue);
        }
    }
}
