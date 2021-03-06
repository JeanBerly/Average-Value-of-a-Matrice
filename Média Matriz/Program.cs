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
            calculateAvgValue(matrice, dimensionMatrice);
            Console.ReadKey();
        }
        static public async void calculateAvgValue(int[,] matrice, int dimension)
        {
            List<Task <float>> tasks = new List<Task <float>>();
            for (int i = 0; i < (dimension - 1); i++) {
                tasks.Add(Task.Factory.StartNew((a) => {
                    string k = a.ToString();
                    int l = int.Parse(k);
                    float averageValue = 0;
                    for (int j = 0; j < (dimension -1); j++) {
                        averageValue += matrice[l,j] / 10;
                    }
                   return averageValue;
                }, i));
            }
            Task.WaitAll(tasks.ToArray());
            Task <float>[] arrayTasks = tasks.ToArray();
            float avgValue = 0;
            for (int k = 0; k < (dimension - 1); k++) {
                avgValue += (float)arrayTasks[k].Result / dimension;
            }
            Console.WriteLine("avgValue: " + avgValue);
        }
    }
}
