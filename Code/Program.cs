using System;

class Program{
  static void Main(string[] args){
    PascalTriangle();
  }

// PascalTriangle-----------------------------------------------------------------
  static void PascalTriangle(){
    int row;

    do{
      row = int.Parse(Console.ReadLine());
      if(row >= 0){
        DoPascalTriangle(row);
      } else {
        Console.WriteLine("Invalid Pascal’s triangle row number.");
      }
    } while (row < 0);
  } 

  static void DoPascalTriangle(int row){
    for(int i = 0; i <= row; i++){
      for(int j = 0; j <= i; j++){
        int num = Factorial(i)/(Factorial(j) * Factorial(i - j));
        Console.Write("{0} ", num);
      }
      Console.WriteLine("");
    }
  }

  static int Factorial(int num){
    int factorial = 1;
    while(num > 0){
      factorial *= num--;
    }
    return factorial;
  }
// PascalTriangle-END-------------------------------------------------------------
}