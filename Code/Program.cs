using System;

class Program
{
  static void Main(string[] args)
  {
    // PascalTriangle();
    // DNAReplication();
    // LegendaryMatrix();
    // MetaverseMarketing();

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
        Console.Write(num + " ");
      }
      Console.WriteLine("");
    }
  }

  static int Factorial(int num)
  {
    if (num <= 1) { return 1; }
    return num * Factorial(num - 1);
  }
  // PascalTriangle-END-------------------------------------------------------------

  // DNAReplication-----------------------------------------------------------------
  static void DNAReplication()
  {
    do
    {
      string dna = Console.ReadLine();
      if (IsValidSequence(dna))
      {
        Console.WriteLine("Current half DNA sequence : {0}", dna);
        if (OptionSelect("Do you want to replicate it ? (Y/N) : "))
        {
          dna = ReplicateSeqeunce(dna);
          Console.WriteLine("Replicated half DNA sequence : {0}", dna);
        }
      }
      else
      {
        Console.WriteLine("That half DNA sequence is invalid.");
      }
    } while (OptionSelect("Do you want to process another sequence ? (Y/N) : "));
  }

  static bool OptionSelect(string repeatWord)
  {
    while (true)
    {
      Console.Write(repeatWord);
      string text = Console.ReadLine();
      if (text == "Y") { return true; }
      if (text == "N") { return false; }
      Console.WriteLine("Please input Y or N.");
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
    char numOperator;
    do
    {
      numOperator = char.Parse(Console.ReadLine());
      if (numOperator == '+' || numOperator == '-')
      {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        float[,] numMatrix_1 = new float[m, n];
        float[,] numMatrix_2 = new float[m, n];
        float[,] numMatrix_Ans = new float[m, n];

        MatrixInput(ref numMatrix_1);
        MatrixInput(ref numMatrix_2);
        MatrixOperation(ref numMatrix_Ans, numMatrix_1, numMatrix_2, numOperator);
        Print2DMatrix(numMatrix_Ans);
      }
    } while (numOperator == '+' || numOperator == '-');
  }
  static void MatrixInput(ref float[,] matrix)
  {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        matrix[i, j] = float.Parse(Console.ReadLine());
      }
    }
  }
  static void MatrixOperation(ref float[,] ans, float[,] num1, float[,] num2, char numOperator)
  {
    for (int i = 0; i < ans.GetLength(0); i++)
    {
      for (int j = 0; j < ans.GetLength(1); j++)
      {
        switch (numOperator)
        {
          case '+':
            ans[i, j] = num1[i, j] + num2[i, j];
            break;
          case '-':
            ans[i, j] = num1[i, j] - num2[i, j];
            break;
        }
      }
    }
  }
  static void Print2DMatrix(float[,] matrix)
  {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.Write("{0:0.0} ", matrix[i, j]);
      }
      Console.WriteLine("");
    }
  }
  // LegendaryMatrix-END------------------------------------------------------------

  // MetaverseMarketing-------------------------------------------------------------
  static void MetaverseMarketing()
  {
    int road_size = int.Parse(Console.ReadLine());
    int range = int.Parse(Console.ReadLine());
    int[] road = new int[road_size];
    Input(ref road);
    Console.WriteLine(Sort(road, range));
  }

  static void Input(ref int[] road)
  {
    for (int i = 0; i < road.Length; i++)
    {
      road[i] = int.Parse(Console.ReadLine());
    }
  }

  static int Sort(int[] road, int range)
  {
    int max = 0;
    int temp = 0;
    for (int i = range; i < road.Length - range; i++)
    {
      temp = road[i];
      for (int j = 1; j <= range; j++)
      {
        temp = temp + road[i - j] + road[i + j];
      }
      max = FindMax(temp, max);
    }
    return max;
  }

  static int FindMax(int a, int b)
  {
    if (a > b)
    {
      return a;
    }
    return b;
  }
  // MetaverseMarketing-END---------------------------------------------------------
}