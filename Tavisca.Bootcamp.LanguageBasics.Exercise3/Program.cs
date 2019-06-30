using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.




            int[] cal = new int[protein.Length] ;
            
            List<int> temp_list = new List<int>();
            List<int> new_temp_list = new List<int>();
            int[] Answer = new int[dietPlans.Length];

            for (int j = 0; j < protein.Length; j++)
            {
                cal[j] = (fat[j] * 9) + 5 * (protein[j] + carbs[j]);
                

            }
            int count = 0;
            foreach (string plan in dietPlans)
            {
                count += 1;
                if (plan == "")
                {
                    Console.WriteLine("0");
                    continue;
                }
                
                 
                foreach (char element in plan)
                {
                    switch (element)
                    {
                        case 'C':
                            if (temp_list.Count == 0)
                            {
                                int max_carb = carbs.Max();

                                for (int i = 0; i < carbs.Length; i++)
                                {
                                    if (carbs[i] == max_carb)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 0;
                                

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var < carbs[idx])
                                    {
                                        temp_var = carbs[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == carbs[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {

                                    break;
                                }

                            }
                            break;

                        case 'c':

                            if (temp_list.Count == 0)
                            {
                                
                                int min_carb = carbs.Min();

                                for (int i = 0; i < carbs.Length; i++)
                                {
                                    if (carbs[i] == min_carb)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                
                                int temp_var = 999;
                                

                                foreach (int idx in temp_list)
                                {

                                   
                                    if (temp_var > carbs[idx])
                                    {
                                        temp_var = carbs[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == carbs[idx]) 
                                    {
                                      
                                        new_temp_list.Add(idx);
                                    }
                                }

                                
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {

                                    break;
                                }

                            }


                            break;

                        case 'P':
                            if (temp_list.Count == 0)
                            {
                                int max_pro = protein.Max();

                                for (int i = 0; i < protein.Length; i++)
                                {
                                    if (protein[i] == max_pro)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 0;
                                //var new_temp_list = new List<int>();

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var < protein[idx])
                                    {
                                        temp_var = protein[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == protein[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }

                            }
                            break;

                        case 'p':
                            if (temp_list.Count == 0)
                            {
                                int min_pro = protein.Min();

                                for (int i = 0; i < protein.Length; i++)
                                {
                                    if (protein[i] == min_pro)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 999;
                                

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var > protein[idx])
                                    {
                                        temp_var = protein[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == protein[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }

                            }

                            break;

                        case 'F':
                            if (temp_list.Count == 0)
                            {
                                int max_fat = fat.Max();

                                for (int i = 0; i < fat.Length; i++)
                                {
                                    if (fat[i] == max_fat)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                
                                int temp_var=0;
                                
                                
                                foreach (int idx in temp_list)
                                {
                                    
                                    if (temp_var < fat[idx])
                                    { 
                                        temp_var = fat[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);
                                    
                                    }
                                    else if (temp_var == fat[idx])
                                    {
                                        
                                        new_temp_list.Add(idx);
                                    }
                                    
                                }

                                
                                
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                
                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }

                            }
                            

                            break;

                        case 'f':
                            if (temp_list.Count == 0)
                            {
                                int min_fat = fat.Min();

                                for (int i = 0; i < fat.Length; i++)
                                {
                                    if (fat[i] == min_fat)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 999;
                                

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var > fat[idx])
                                    {
                                        temp_var = fat[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == fat[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }

                            }

                            break;

                        case 'T':
                            if (temp_list.Count == 0)
                            {
                                int max_cal = cal.Max();

                                for (int i = 0; i < cal.Length; i++)
                                {
                                    if (cal[i] == max_cal)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 0;
                                

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var < cal[idx])
                                    {
                                        temp_var = cal[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == cal[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {
                                    
                                    break;
                                }

                            }
                            break;

                        case 't':
                            if (temp_list.Count == 0)
                            {
                                
                                int min_cal = cal.Min();

                                for (int i = 0; i < cal.Length; i++)
                                {
                                    if (cal[i] == min_cal)
                                    {
                                        temp_list.Add(i);
                                    }
                                }

                               

                                if (temp_list.Count() == 1)
                                {

                                    
                                    break;
                                }
                            }
                            else if (temp_list.Count > 1)
                            {
                                int temp_var = 999;
                                

                                foreach (int idx in temp_list)
                                {

                                    if (temp_var > cal[idx])
                                    {
                                        temp_var = cal[idx];
                                        new_temp_list.Clear();
                                        new_temp_list.Add(idx);

                                    }
                                    else if (temp_var == cal[idx]) 
                                    {
                                        new_temp_list.Add(idx);
                                    }
                                }
                                temp_list.Clear();
                                temp_list = new List<int>(new_temp_list);
                                new_temp_list.Clear();
                                new_temp_list.Clear();
                                if (temp_list.Count() == 1)
                                {
                                   
                                    break;
                                }

                            }

                            break;






                    }

                    
                }

                Answer[count - 1] = temp_list[0];

                temp_list.Clear();
                new_temp_list.Clear();
            }

            return Answer;   

            throw new NotImplementedException();
        }











            
        }

   
    }

