using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public static class Expression
    {
        #region Calcularea unei expresii
        public static double ReturnValueOfExpression(string _expression)
        {
            string expression =_expression;
            string str = "";
            bool numar = true;
            bool paranteza = false;
            bool negativ = false;
            foreach (char c in expression)
            {
                if (c == '\r' || c == '\n')
                    break;
                if (str == "")
                {
                    str += c.ToString();//primul element
                    numar = (c >= '0' && c <= '9') || c == 'P' || c == 'E';
                    negativ = c == '-';
                    if (c == '(')
                    {  paranteza = true; str += " "; }
                }
                else
                    if (numar == true)
                       if ((c >= '0' && c <= '9') || c == 'I' || c == '.')
                           str += c.ToString();
                       else
                       {
                           numar = false;
                           str += " ";
                           str += c.ToString();
                           if (c == '(' || c == ')')
                           { paranteza = true; str += " "; }
                       }
                     else
                       if (c == '(' || c == ')')
                       { if (paranteza == false) str += " "; str += c.ToString() + " "; paranteza = true; }
                       else
                          if (c == 'i' || c == 'n' || c == 'o' || c == 's' || c == 't' || c == 'g' || c == 'a' || c == 'b' || c == 'q' || c == 'r')
                          { str += c.ToString();paranteza = false; }
                          else
                          {
                              if (paranteza == false&&negativ==false)
                                  str += " ";
                              negativ=c=='-';
                              paranteza = false;
                              str += c.ToString();
                              numar = (c >= '0' && c <= '9') || c == 'P' || c == 'E';
                          }
            }
            expression = str;
            StringBuilder formaPoloneza = new StringBuilder();//forma poloneza
            Stack<string> functions = new Stack<string>();//stiva pt. operatori/functii
             //Determina forma poloneza
            string[] termeni = null;
            //despart forma normala in cuvinte
            termeni = expression.Split(' ');
            foreach (string termen in termeni)
            {
                if (termen == "")
                    break;
                //determin daca este operand sau operator
                bool operand = false;
                if (termen == "+" || termen == "-" ||
                    termen == "*" || termen == "/" ||
                    termen == "^" || termen == "sin" ||
                    termen == "cos" || termen == "tan" ||
                    termen == "log" || termen == "(" || termen == "abs"||
                    termen == "sqrt" | termen == ")")
                    operand = false;
                else
                    operand = true;
                //daca este operand
                if (operand)
                {
                //se introduce in forma_poloneza
                if (termen == "E")
                    formaPoloneza.Append(Math.E);
                    else
                        if (termen == "PI")
                        formaPoloneza.Append(Math.PI);
                    else
                        formaPoloneza.Append(termen);
                    formaPoloneza.Append(" ");
                    //poloneza.Text = forma_poloneza;
                }
                //terminat daca este operand

                //daca este operator
                if (operand == false)//este operator
                {
                    //il pun in stiva
                    functions.Push(termen);

                    #region prioritate 1
                    if (termen == "*" && termen == "/" ||
                        termen == "^" || termen == "sin" ||
                        termen == "cos" || termen == "tan" || termen == "abs" ||
                        termen == "log"||termen== "sqrt")
                        ;//nu fac nimic
                    #endregion

                    #region prioritate 2
                    if (termen == "+" || termen == "-")
                    {
                        //il scot temporar din stiva
                        functions.Pop();
                        //mutam in forma_poloneza toti
                        //operatorii de prioritate 1
                        while (functions.Count > 0 && (functions.Peek() == "*" ||
                            functions.Peek() == "/" || functions.Peek() == "^" ||
                            functions.Peek() == "sin" || functions.Peek() == "cos" ||
                            functions.Peek() == "tan" || termen== "sqrt"||
                            functions.Peek() == "log" || termen == "abs"))
                            formaPoloneza.Append(functions.Pop()).Append(" ");
                        //il reintroducem in stiva
                        functions.Push(termen);
                    }
                    #endregion

                    #region prioritate 0 (parantezele)
                    if (termen == ")")
                    //mut in forma_poloneza toti operatorii
                    //pana la paranteza (
                    {
                    functions.Pop();
                        while (functions.Count > 0 && functions.Peek() != "(")
                            formaPoloneza.Append(functions.Pop()).Append(" ");
                        functions.Pop();
                    }
                    # endregion
                }
            }
            while (functions.Count > 0)
                formaPoloneza.Append(functions.Pop()).Append(" ");
            //am creat forma poloneza,ceea ce inseamna a+b devine a b +,
            //iar (a+b)*c devine a b + c *
            termeni = formaPoloneza.ToString().Split(' ');
            
            return Calculeaza(termeni);
        }
        private static bool IsOperator(string str)
        {
            return str == "+" || str == "-" ||
             str == "*" || str == "/" ||
             str == "^" || str == "sin" ||
             str == "cos" || str == "tan" ||
             str == "log" || str == "abs" || str == "sqrt";
        }
        private static short TipDeOperatie(string str)
        {
            if (str == "+" || str == "-" || str == "*" || str == "/" || str == "^")
                return 2;
            if (str == "sin" || str == "cos" || str == "tan" || str == "abs" || str == "sqrt")
                return 1;
            return 0;//este numar
        }
        private static double Calc(double nr2, double nr1, string _operator)
        {
            switch (_operator)
            {
                case "+":
                    return nr1 + nr2;
                case "-":
                    return nr1 - nr2;
                case "*":
                    return nr1 * nr2;
                case "/":
                    return nr1 / nr2;
                case "^":
                    return Math.Pow(nr1, nr2);
                case "log":
                    return Math.Log(nr1, nr2);
            }
            return double.NaN;
        }
        private static double Calc(double nr, string _operator)
        {
            switch (_operator)
            {
                case "sin":
                    return Math.Sin(nr);
                case "cos":
                    return Math.Cos(nr);
                case "tan":
                    return Math.Tan(nr);
                case "abs":
                    return Math.Abs(nr);
                case "sqrt":
                    return Math.Sqrt(nr);
            }
            return double.NaN;
        }
        private static double Calculeaza(string[] termeni)
        {
            Stack<double> stivaCuNumere = new Stack<double>();
            try
            {
                stivaCuNumere.Push(double.Parse(termeni[0]));
                for (int i = 1; i < termeni.Length - 1; i++)
                {
                    if (IsOperator(termeni[i]))
                    {
                        if (TipDeOperatie(termeni[i]) == 2)
                            stivaCuNumere.Push(Calc(stivaCuNumere.Pop(), stivaCuNumere.Pop(), termeni[i]));
                        else
                            stivaCuNumere.Push(Calc(stivaCuNumere.Pop(), termeni[i]));
                    }
                    else
                        stivaCuNumere.Push(double.Parse(termeni[i]));
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return stivaCuNumere.Pop();
        }
        #endregion
    }
}
