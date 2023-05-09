using System;

class Program
{
  static void Main(string[] args)
  {
    // PascalTriangle();
    // DNAReplication();
    // LegendaryMatrix();
    MetaverseMarketing();
  }

  // PascalTriangle-----------------------------------------------------------------
  static void PascalTriangle() {
    int row;
    do {
      row = int.Parse(Console.ReadLine());
      if (row >= 0) {
        DoPascalTriangle(row);
      }
      else {
        Console.WriteLine("Invalid Pascal’s triangle row number.");
      }
    } while (row < 0);
  }

  static void DoPascalTriangle(int row) {
    for (int i = 0; i <= row; i++) {
      for (int j = 0; j <= i; j++) {
        int num = Factorial(i) / (Factorial(j) * Factorial(i - j));
        Console.Write(num + " ");
      }
      Console.WriteLine("");
    }
  }

  static int Factorial(int num) {
    int factorial = 1;
    while (num > 0) {
      factorial *= num--;
    }
    return factorial;
  }
  // PascalTriangle-END-------------------------------------------------------------

  // DNAReplication-----------------------------------------------------------------
  static void DNAReplication() {
    string question;
    do {
      string dna = Console.ReadLine();
      if (IsValidSequence(dna)) {
        question = "Do you want to replicate it ? (Y/N) : ";
        Console.WriteLine("Current half DNA sequence : {0}", dna);
        Console.Write(question);
        if (OptionSelect(question)) {
          dna = ReplicateSeqeunce(dna);
          Console.WriteLine("Replicated half DNA sequence : {0}", dna);
        }
      }
      else {
        Console.WriteLine("That half DNA sequence is invalid.");
      }
      question = "Do you want to process another sequence ? (Y/N) : ";
      Console.Write(question);
    } while (OptionSelect(question));
  }

  static bool OptionSelect(string repeatWord) {
    while (true) {
      string text = Console.ReadLine();
      if (text == "Y") { return true; }
      if (text == "N") { return false; }
      Console.WriteLine("Please input Y or N.");
      Console.Write(repeatWord);
    }
  }

  static bool IsValidSequence(string halfDNASequence) {
    foreach (char nucleotide in halfDNASequence) {
      if (!"ATCG".Contains(nucleotide)) {
        return false;
      }
    }
    return true;
  }

  static string ReplicateSeqeunce(string halfDNASequence) {
    string result = "";
    foreach (char nucleotide in halfDNASequence) {
      result += "TAGC"["ATCG".IndexOf(nucleotide)];
    }
    return result;
  }
  // DNAReplication-END-------------------------------------------------------------

  // LegendaryMatrix----------------------------------------------------------------

  static void LegendaryMatrix() {
    string numOperator;
    do {
      numOperator = Console.ReadLine();
      if (numOperator == "+" || numOperator == "-") {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        float[,] numMatrix_1 = new float[m, n];
        float[,] numMatrix_2 = new float[m, n];
        float[,] numMatrix_Ans = new float[m, n];

        numMatrix_1 = MatrixInput(numMatrix_1);
        numMatrix_2 = MatrixInput(numMatrix_2);
        numMatrix_Ans = MatrixOperation(numMatrix_Ans, numMatrix_1, numMatrix_2, numOperator);
        Print2DMatrix(numMatrix_Ans);
      }
    } while (numOperator == "+" || numOperator == "-");
  }
  static float[,] MatrixInput(float[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++) {
      for (int j = 0; j < matrix.GetLength(1); j++) {
        matrix[i, j] = float.Parse(Console.ReadLine());
      }
    }
    return matrix;
  }
  static float[,] MatrixOperation(float[,] ans, float[,] num1, float[,] num2, string numOperator) {
    for (int i = 0; i < ans.GetLength(0); i++) {
      for (int j = 0; j < ans.GetLength(1); j++) {
        switch (numOperator) {
          case "+":
            ans[i, j] = num1[i, j] + num2[i, j];
            break;
          case "-":
            ans[i, j] = num1[i, j] - num2[i, j];
            break;
        }
      }
    }
    return ans;
  }
  static void Print2DMatrix(float[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++) {
      for (int j = 0; j < matrix.GetLength(1); j++) {
        Console.Write("{0:0.0} ", matrix[i, j]);
      }
      Console.WriteLine("");
    }
  }

  // LegendaryMatrix-END------------------------------------------------------------

  // MetaverseMarketing-------------------------------------------------------------
  static void MetaverseMarketing() {
    int road_size = int.Parse(Console.ReadLine());
    int range = int.Parse(Console.ReadLine());
    int[] road = new int[road_size];
    Input(road);
    Console.WriteLine(Sort(road, range));
  }

  static int[] Input(int[] road) {
    for (int i = 0; i < road.Length; i++) {
      road[i] = int.Parse(Console.ReadLine());
    }
    return road;
  }

  static int Sort(int[] road, int range) {
    int max = 0;
    int temp = 0;
    for (int i = range; i < road.Length - range; i++) {
      temp = road[i];
      for (int j = 1; j <= range; j++) {
        temp = temp + road[i - j] + road[i + j];
      }
      max = FindMax(temp, max);
    }
    return max;
  }

  static int FindMax(int a, int b) {
    if (a > b) {
      return a;
    }
    return b;
  }
  // MetaverseMarketing-END---------------------------------------------------------
}