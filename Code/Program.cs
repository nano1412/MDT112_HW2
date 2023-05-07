using System;

class Program
{
  static void Main(string[] args)
  {
    // PascalTriangle();
    // DNAReplication();
    // LegendaryMatrix();
  }

  // PascalTriangle-----------------------------------------------------------------
  static void PascalTriangle()
  {
    int row;

    do
    {
      row = int.Parse(Console.ReadLine());
      if (row >= 0)
      {
        DoPascalTriangle(row);
      }
      else
      {
        Console.WriteLine("Invalid Pascal’s triangle row number.");
      }
    } while (row < 0);
  }

  static void DoPascalTriangle(int row)
  {
    for (int i = 0; i <= row; i++)
    {
      for (int j = 0; j <= i; j++)
      {
        int num = Factorial(i) / (Factorial(j) * Factorial(i - j));
        Console.Write("{0} ", num);
      }
      Console.WriteLine("");
    }
  }

  static int Factorial(int num)
  {
    int factorial = 1;
    while (num > 0)
    {
      factorial *= num--;
    }
    return factorial;
  }
  // PascalTriangle-END-------------------------------------------------------------

  // DNAReplication-----------------------------------------------------------------
  static void DNAReplication()
  {
    string repeatWord;
  Start:
    string dna = Console.ReadLine();
    if (IsValidSequence(dna))
    {
      repeatWord = "Do you want to replicate it ? (Y/N) : ";
      Console.WriteLine("Current half DNA sequence : {0}", dna);
      Console.Write(repeatWord);
      if (OptionSelect(repeatWord))
      {
        dna = ReplicateSeqeunce(dna);
        Console.WriteLine("Replicated half DNA sequence : {0}", dna);
      }
    }
    else
    {
      Console.WriteLine("That half DNA sequence is invalid.");
    }
    repeatWord = "Do you want to process another sequence ? (Y/N) : ";
    Console.Write(repeatWord);
    if (OptionSelect(repeatWord))
    {
      goto Start;
    }

  }

  static bool OptionSelect(string repeatWord)
  {
    while (true)
    {
      string text = Console.ReadLine();
      if (text == "Y") { return true; }
      if (text == "N") { return false; }
      Console.WriteLine("Please input Y or N.");
      Console.Write(repeatWord);
    }
  }

  static bool IsValidSequence(string halfDNASequence)
  {
    foreach (char nucleotide in halfDNASequence)
    {
      if (!"ATCG".Contains(nucleotide))
      {
        return false;
      }
    }
    return true;
  }

  static string ReplicateSeqeunce(string halfDNASequence)
  {
    string result = "";
    foreach (char nucleotide in halfDNASequence)
    {
      result += "TAGC"["ATCG".IndexOf(nucleotide)];
    }
    return result;
  }
  // DNAReplication-END-------------------------------------------------------------

  // LegendaryMatrix----------------------------------------------------------------

  static void LegendaryMatrix()
  {
  Start:
    string numOperator = Console.ReadLine();
    if (numOperator == "+" || numOperator == "-")
    {
      int m = int.Parse(Console.ReadLine());
      int n = int.Parse(Console.ReadLine());
      float[,] numMatrix_1 = new float[m, n];
      float[,] numMatrix_2 = new float[m, n];
      float[,] numMatrix_Ans = new float[m, n];

      numMatrix_1 = MatrixInput(m, n);
      numMatrix_2 = MatrixInput(m, n);
      numMatrix_Ans = MatrixOperation(numMatrix_1, numMatrix_2, m, n, numOperator);
      Print2DMatrix(numMatrix_Ans, m, n);
      goto Start;
    }
  }
  static float[,] MatrixInput(int m, int n)
  {
    float[,] matrix = new float[m, n];
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        matrix[i, j] = float.Parse(Console.ReadLine());
      }
    }
    return matrix;
  }
  static float[,] MatrixOperation(float[,] num1, float[,] num2, int m, int n, string numOperator)
  {
    float[,] ans = new float[m, n];
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        switch (numOperator)
        {
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
  static void Print2DMatrix(float[,] matrix, int m, int n)
  {
    for (int i = 0; i < m; i++)
    {
      for (int j = 0; j < n; j++)
      {
        Console.Write("{0:.0} ", matrix[i, j]);
      }
      Console.WriteLine("");
    }
  }

  // LegendaryMatrix-END------------------------------------------------------------

}