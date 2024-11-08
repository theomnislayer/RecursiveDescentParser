namespace RDP
{
    /// <summary>
    /// E -> T E'
    /// E' -> + T E' | End
    /// T -> F T'
    /// T' -> * F T' | End
    /// F -> (E) | id
    /// </summary>
    internal class Rdp
    {
        string Input = string.Empty;
        int Count;

        internal void Parse(string input)
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
            T();
            Ep();
        }

        //E' -> + T E' | End
        private void Ep()
        {
            if (GetToken().Equals('+'))
            {
                Match('+');
                T();
                Ep();
            }
        }

        // T -> F T'
        private void T()
        {
            F();
            Tp();
        }

        //T' -> * F T' | End
        private void Tp()
        {
            if (GetToken().Equals('*'))
            {
                Match('*');
                F();
                Tp();
            }
        }

        // F -> (E) | id
        private void F()
        {
            if (GetToken().Equals('('))
            {
                Match('(');
                E();
                Match(')');
            }
            else
            {
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
}
