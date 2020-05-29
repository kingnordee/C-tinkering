using System;
using System.Collections.Generic;
using System.Linq;
using CarNameSpace;
using CollectionDemoConApp;
using InheritanceOverride;
using AlgorithmsNameSpace;
using Tables2NameSpace;

namespace MainProgram{
    public static class Program{
        static Random _random = new Random();
        static List<string> names = new List<string>{
            "Male","Female","King", "Khan", "Shiva", "Kurt", "Tran", "Angeles", "Elisha","Sujatha","Miguel"
        };
        //#3 Continuation...
        static List<Employee> FiveEmployees(){
            List<Employee> employees = new List<Employee>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #3:");
            Console.ResetColor();
            for(var i = 0; i < 5; i++){
                Employee employee = new Employee();
                employee.Id = _random.Next(500, 599);
                employee.Age = _random.Next(21, 50);
                employee.Salary = _random.NextDouble() * (180000 - 50000) + 50000;
                employee.Name = names[_random.Next(2, 11)] + " " + names[_random.Next(2, 11)];
                employee.Gender = names[_random.Next(0, 2)];
                employees.Add(employee);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Employee #: {i+1}");
                Console.ResetColor();
                Console.WriteLine($"Name: {employee.Name}\nAge: {employee.Age}\n" +
                                  $"Gender: {employee.Gender}\nId#: {employee.Id}\n" +
                                  $"Salary: ${String.Format("{0:n}", employee.Salary)}");
            }
            return employees;
        }
        
        //RUN THIS MAIN FUNCTION TO GET THE OUTPUTS FOR ALL OF THE ASSIGNMENT QUESTIONS
        public static void Main(string[] args){//MAIN FUNCTION MAIN FUNCTION
            CityDerivedClass ob = new CityDerivedClass(); ob.Anything();//END OF QUESTION #1
            
            CarOne car = new CarOne();
            Console.WriteLine($"" +
                $"CarColor: {car.CarColor()}\n" +
                $"CarEngine: {car.Engine()}\n" +
                $"CarTyre: {car.Tyre()}\n" +
                $"CarSoundSystem: {car.SoundSystem()}\n"
            );// END OF QUESTION #2
            
            FiveEmployees();// END OF QUESTION #3
            
            Algorithms algo = new Algorithms(); algo.diamond();// END OF QUESTION #4
            
            var vc = algo.CountVowelConsonant("Buffalo NewYork");
            Console.WriteLine($"Vowels: {vc["v"]} Consonants: {vc["c"]}");// END OF QUESTION #5
            
            var cw = algo.countWords("I am King Nordee; Son of Chief Amos A Nordee");
            Console.WriteLine($"wordCount: {cw}");// END OF QUESTION #6
            
            Stack<int> stack = new Stack<int>(); for(int i=0; i<10; i++) stack.Push(i);
            Console.WriteLine($"FoundInStack?: {algo.ProbeStack(stack, 8)}");// END OF QUESTION #7
            
            Console.WriteLine($"NumSum: {algo.NumSum(12345)}");// END OF QUESTION #8
            
            Console.WriteLine($"IsPalindrome: {algo.IsPalindrome(1111)}");// END OF QUESTION #9
            
            Console.WriteLine($"ToBinary: {algo.DecimalToBinary(100)}");// END OF QUESTION #10
            
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #11:");
            Console.ResetColor();
            var table = new Table();
            List<Table> tables = new List<Table>();
            for (int i = 0; i < 5; i++){ 
                var elem = new Table(); tables.Add(elem); 
                Console.WriteLine(elem.ShowData());
            } 
            var coffeeTable = new CoffeeTable();
            List<CoffeeTable> coffeeTables = new List<CoffeeTable>();
            for (int i = 0; i < 5; i++) {
                var elem = new CoffeeTable(); coffeeTables.Add(elem); 
                Console.WriteLine(elem.ShowData());
            }// END OF QUESTION #11
        }
    }
}

// #1
namespace InheritanceOverride{
    public class CityBaseClass{ 
        public virtual void Anything(){
            Console.WriteLine("Base/Parent Class Method");
        }
    }
    public class CityDerivedClass : CityBaseClass{
        public override void Anything(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #1:");
            Console.ResetColor();
            Console.WriteLine($"Overriden Method in Child Class");
        }
    }
}//END OF NUMBER-1

//#2
namespace CarNameSpace{
    public class Car{//BASE CAR
        public virtual string Engine(){
            return "Twin Turbo";
        }
        public virtual string Tyre(){
            return "Michelin";
        }
        public virtual string SoundSystem(){
            return "Bose";
        }
    }
    interface ICar{//COLOR INTERFACE
        string CarColor();
    }
    class CarOne : Car, ICar{//CUSTOM CAR
        public string CarColor(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #2:");
            Console.ResetColor();
            return "Silver";
        }
    }
}//END OF NUMBER-2

//#3
namespace CollectionDemoConApp{
    public class Employee{
        public int Id;
        public int Age;
        public double Salary;
        public string Name;
        public string Gender;
    }
}//END OF NUMBER-3

namespace AlgorithmsNameSpace{
    //#4
    public class Algorithms{
        public void diamond(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #4:");
            Console.ResetColor();
            int stars = 1; int space = 4;
            bool asc = false; bool desc = false;
            
            while (!desc){
                if(!asc){//ASCEND
                    Console.WriteLine($"{new string(' ', space)}{new string('*', stars)}" +
                                      $"{new string(' ', space)}");
                    if (stars == 9){stars -= 2; space += 1;asc = true;}
                    else{stars += 2; space -= 1;}
                }else{//DESCEND
                    Console.WriteLine($"{new string(' ', space)}{new string('*', stars)}" +
                                      $"{new string(' ', space)}");
                    if(stars == 1) desc = true;
                    else {stars -= 2; space += 1;}
                }
            }
        }//END OF NUMBER-4
        
        //#5
        public Dictionary<string, int> CountVowelConsonant(string word){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #5:");
            Console.ResetColor();
            string vowels = "aeoui";
            Dictionary<string, int> counts = new Dictionary<string, int>(){{"v", 0}, {"c", 0}};
            foreach (char character in word){
                if (character >= 'a' && character <= 'z' ||
                    character >= 'A' && character <= 'Z'){
                    if (vowels.Contains(character)) counts["v"] += 1;
                    else counts["c"] += 1;
                }
            }
            return counts;
        }//END OF NUMBER-5
        
        //#6
        public int countWords(string words){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #6:");
            Console.ResetColor();
            int count = 0; string temp = "";
            for (var i=0; i<words.Length; i++){
                if (words[i] == ' '){
                    if(temp.Length > 0 ){ count++; temp = ""; }
                }else temp += words[i];
                if(i == words.Length-1){ count++; temp = ""; }
            }
            return count;
        }//END OF NUMBER-6
        
        //#7
        public bool ProbeStack(Stack<int> stack, int item){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #7:");
            Console.ResetColor();
            return stack.Contains(item);
        }//END OF NUMBER-7
        
        //#8
        public int NumSum(int num){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #8:");
            Console.ResetColor();
            int sum = 0;
            foreach (char c in num.ToString()){
                sum += int.Parse(c.ToString());
            }
            return sum;
        }//END OF NUMBER-8
        
        //#9
        public bool IsPalindrome(int num){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #9:");
            Console.ResetColor();
            string rev = num.ToString();
            var arr = rev.ToArray();
            var arr2 = arr.Reverse();
            string arr3 = string.Join("", arr2);
            return num == Convert.ToInt32(arr3);
        }//END OF NUMBER-9
        
        //#10
        public string DecimalToBinary(int num){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nQuestion #10:");
            Console.ResetColor();
            int nunum = num; string binary = "";
            while (nunum>0){
                if (nunum % 2 > 0) { binary += '1'; }
                else{ binary += '0'; }
                nunum /= 2;
            }
            if(binary.Length < 4) binary += new string('0', 4-binary.Length);
            var retval = binary.ToArray().Reverse();
            return string.Join("", retval);
        }//END OF NUMBER-10
        
    }//END OF ALGORITHMS CLASS
    
}//END OF ALGORITHMS NAME SPACE

//#11
namespace Tables2NameSpace{
    public class Table{
        public static int _random(int min, int max){
            Random ran = new Random();
            return ran.Next(min, max);
        }
        public virtual int  height(){
            return _random(50, 200);
        }
        public virtual int  width(){
            return _random(50, 200);
        }
        public virtual string ShowData(){
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Table: ");
            Console.ResetColor();
            return $"Height: {height()}, Width: {width()}";
        }
    }

    public class CoffeeTable : Table{
        public override int height(){
            return _random(40, 120);
        }
        public override int width(){
            return _random(40, 120);
        }
        public override string ShowData(){
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Coffee Table: ");
            Console.ResetColor();
            return $"Height: {height()}, Width: {width()}";
        }
    }

}//END OF NUMBER-11