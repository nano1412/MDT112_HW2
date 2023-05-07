using System;

class Program{
  static void Main(string[] args){
    // PascalTriangle();
    DNAReplication();
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

  static void DNAReplication(){
    bool option;
    Start:
    string dna = Console.ReadLine();
    if(IsValidSequence(dna)){
      Console.WriteLine("Current half DNA sequence : {0}", dna);
      Console.Write("Do you want to replicate it ? (Y/N) : ");

      option = OptionSelect("Do you want to replicate it ? (Y/N) : ");
      if(option){
        dna = ReplicateSeqeunce(dna);
        Console.WriteLine("Replicated half DNA sequence : {0}", dna);
      }

    } else {
      Console.WriteLine("That half DNA sequence is invalid.");
    }
    Console.Write("Do you want to process another sequence ? (Y/N) : ");

    option = OptionSelect("Do you want to process another sequence ? (Y/N) : ");
    if(option){
      goto Start;
    }

  }

  static bool OptionSelect(string repeatWord){
    while(true){
      string text = Console.ReadLine();
      if(text == "Y"){return true;}
      if(text == "N"){return false;}
      Console.WriteLine("Please input Y or N.");
      Console.Write(repeatWord);
    }
  }

  static bool IsValidSequence(string halfDNASequence)
  {
    foreach(char nucleotide in halfDNASequence)
    {
        if(!"ATCG".Contains(nucleotide))
        {
            return false;
        }
    }
    return true;
  }

  static string ReplicateSeqeunce(string halfDNASequence)
  {
    string result = "";
    foreach(char nucleotide in halfDNASequence)
    {
        result += "TAGC"["ATCG".IndexOf(nucleotide)];
    }
    return result;
  }


}