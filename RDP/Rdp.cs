namespace RDP;

/// <summary>
/// E -> T E'
/// E' -> + T E' | End
/// T -> F T'
/// T' -> * F T' | End
/// F -> (E) | id
/// </summary>
public class Rdp
{
    string Input = string.Empty;
    int Count;

    public void Parse(string input)
    {
        Input = input.Trim();
        Count = 0;

        try
        {
            E();
            Console.WriteLine("Success!");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error encountered while parsing: {e.Message}");
        }
    }

    //E -> T E'
    private void E()
    {
        Console.WriteLine("E -> T E'");
        T();
        Ep();
    }

    //E' -> + T E' | End
    private void Ep()
    {
        if (GetToken().Equals('+'))
        {
            Console.WriteLine("E' -> + T E'");
            Match('+');
            T();
            Ep();
        }
        else
        {
            Console.WriteLine("E' -> End");
        }
    }

    // T -> F T'
    private void T()
    {
        Console.WriteLine("T -> F T'");
        F();
        Tp();
    }

    //T' -> * F T' | End
    private void Tp()
    {
        if (GetToken().Equals('*'))
        {
            Console.WriteLine("T' -> * F T'");
            Match('*');
            F();
            Tp();
        }
        else
        {
            Console.WriteLine("T' -> End");
        }
    }

    // F -> (E) | id
    private void F()
    {
        if (GetToken().Equals('('))
        {
            Console.WriteLine("F -> (E)");
            Match('(');
            E();
            Match(')');
        }
        else
        {
            Console.WriteLine("F -> id");
            Match('i');
            Match('d');
        }
    }

    private void GetNextToken() => Count += 1;

    private char GetToken()
    {
        if(Count < Input.Length) return Input[Count];
        return '\0'; //Null
    }
    private void Match(char expected)
    {
        if (GetToken().Equals(expected))
            GetNextToken();
        else
            throw new Exception($"The values are not equal Expected:{expected} Actual:{GetToken()}");
    }
}
