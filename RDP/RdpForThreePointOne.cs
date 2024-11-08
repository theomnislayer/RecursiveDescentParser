namespace RDP;

/// <summary>
/// <S> ::= a<S>c<b>|<A>| b
/// <A> ::= c<A> | c
/// <B> ::= d | <A>
/// </summary>
public class RdpForThreePointOne
{
    string Input = string.Empty;
    int Count;

    public void Parse(string input)
    {
        Input = input.Trim();
        Count = 0;

        try
        {
            S();
            Console.WriteLine("Success!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error encountered while parsing: {e.Message}");
        }
    }

    // <S> ::= a<S>c<b>|<A>| b
    private void S()
    {
        if (GetToken().Equals('a'))
        {
            Console.WriteLine("<S> ::= a<S>c<b>");
            Match(GetToken());
            S();
            Match('c');
            B();
        }
        else if (GetToken().Equals('b'))
        {
            Console.WriteLine("<S> ::= b");
            Match(GetToken());
        }
        else
        {
            Console.WriteLine("<S> ::= <A>");
            A();
        }
    }

    // <A> ::= c<A> | c
    private void A()
    {
        Console.Write("<A> ::= c");
        Match('c');
        if (!LookAhead().Equals('\0'))
        {
            Console.Write("<A>\n");
            A();
        }
    }

    //<B> ::= d | <A>
    private void B()
    {
        if (GetToken().Equals('d'))
        {
            Console.WriteLine("<B> ::= d");
            Match(GetToken());
        }
        else
        {
            Console.WriteLine("<B> ::= <A>");
            A();
        }
    }

    private void GetNextToken() => Count += 1;

    private char GetToken()
    {
        if (Count < Input.Length) return Input[Count];
        return '\0'; //Null
    }

    private void Match(char expected)
    {
        if (GetToken().Equals(expected))
            GetNextToken();
        else
            throw new Exception($"The values are not equal Expected:{expected} Actual:{GetToken()}");
    }
    
    private char LookAhead()
    {
        if (Count + 1 < Input.Length) return Input[Count + 1];
        return '\0';
    }
}
