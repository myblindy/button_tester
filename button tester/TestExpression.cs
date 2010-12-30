using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace button_tester
{
    [Serializable]
    public class TestExpression
    {
        public TestExpression() { }
        public TestExpression(string e) { Expression = e; }

        public string Expression { get; set; }

        public static bool Validate(string expr, Settings settings)
        {
            bool valid;
            Parse(expr, true, out valid, null, null, settings);

            return valid;
        }

        public bool Validate(Settings settings)
        {
            return Validate(Expression, settings);
        }

        public bool Evaluate(int[] dstate, double[] astate, Settings settings)
        {
            bool valid;
            return Parse(Expression, false, out valid, dstate, astate, settings).Value;
        }

        private enum OperandType
        {
            And,
            Or,
            First,
            NotFirst
        }

        private static string ReplaceAll(string haystack, string needle, string replacement)
        {
            int pos;
            // Avoid a possible infinite loop
            if (needle == replacement) return haystack;
            while ((pos = haystack.IndexOf(needle, 0, StringComparison.CurrentCultureIgnoreCase)) >= 0)
                haystack = haystack.Substring(0, pos) + replacement + haystack.Substring(pos + needle.Length);
            return haystack;
        }

        private static string PreProcess(string expr, Dictionary<string, string> names,
            string strdu, string strdd, string strds)
        {
            StringBuilder sb = new StringBuilder(expr.Length * 2);

            for (int i = 0; i < expr.Length; ++i)
            {
                char c = expr[i];

                if (c == 'd' || c=='D')
                {
                    string rest = expr.Substring(i);
                    if (rest.StartsWith("doorup", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sb.Append(strdu);
                        i += 5;
                    }
                    else if (rest.StartsWith("doordown", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sb.Append(strdd);
                        i += 7;
                    }
                    else if (rest.StartsWith("doorstill", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sb.Append(strds);
                        i += 8;
                    }
                    else
                        sb.Append(c);
                }
                else if (c == '[')
                {
                    int end = expr.IndexOf(']', i);
                    if (end >= 0)
                    {
                        string val = expr.Substring(i + 1, end - i-1);
                        if (names.ContainsValue(val))
                        {
                            sb.Append(names.First(w=>w.Value==val).Key);
                            i += end - i;
                        }
                        else
                            sb.Append(c);
                    }
                    else
                        sb.Append(c);
                }
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        private static bool? Parse(string expr, bool validateOnly, out bool valid, int[] dstate, double[] astate,
            Settings settings)
        {
//            foreach (var redefinition in AutoCompleteExpressionBox.GetRedefitionions(settings))
//            {
//                string key = "[" + redefinition.Value + "]";
//                expr = ReplaceAll(expr, key, " " + redefinition.Key + " ");
//            }

            expr += " ";

            valid = true;
            bool? result = null;
            OperandType ot = OperandType.First;
            int index = 0;

            // handle doorup/down/still
            string strdu = "(a1>" + settings.Payload.ZeroToleranceHigh + ")",
                strdd = "(a1<" + settings.Payload.ZeroToleranceLow + ")",
                strds = "(a1>=" + settings.Payload.ZeroToleranceLow + " and a1<=" + settings.Payload.ZeroToleranceHigh + ")";
//            expr = ReplaceAll(ReplaceAll(ReplaceAll(expr, "doorup", strdu), "doordown", strdd), "doorstill", strds);
            expr = PreProcess(expr, 
                AutoCompleteExpressionBox.GetRedefitionions(settings),
                strdu, strdd, strds);

            while (true)
            {
                // eat space
                while (index < expr.Length && char.IsWhiteSpace(expr[index]))
                    ++index;

                if (index >= expr.Length)
                    break;

                // (...) and (...) or (...)
                if (expr[index] == '(')
                {
                    if (ot == OperandType.NotFirst)
                    {
                        valid = false; return null;
                    }

                    // find the end of the subexpression
                    int balance = 1, ending;
                    for (ending = index + 1; ending < expr.Length && balance != 0; ++ending)
                        if (expr[ending] == '(')
                            ++balance;
                        else if (expr[ending] == ')')
                            --balance;

                    if (balance != 0)
                    {
                        valid = false;
                        return null;
                    }

                    bool? res = Parse(expr.Substring(index + 1, ending - index - 2), validateOnly,
                        out valid, dstate, astate, settings);
                    index = ending;
                    if (!valid)
                        return null;

                    if (ot == OperandType.First)
                    {
                        if (!validateOnly) result = res;
                    }
                    else if (ot == OperandType.And)
                    {
                        if (!validateOnly) result &= res;
                    }
                    else if (ot == OperandType.Or)
                    {
                        if (!validateOnly) result |= res;
                    }

                    ot = OperandType.NotFirst;
                }
                else if (string.Compare("and", 0, expr, index, 3, true) == 0
                    || string.Compare("or", 0, expr, index, 2, true) == 0)
                {
                    // and
                    // or

                    if (ot != OperandType.NotFirst)
                    {
                        valid = false;
                        return null;
                    }

                    if (expr[index] == 'a' || expr[index] == 'A')
                    {
                        ot = OperandType.And;
                        index += 3;
                    }
                    else
                    {
                        ot = OperandType.Or;
                        index += 2;
                    }
                }
                else
                {
                    // channel comparison number
                    // channel:==a[1..1]|d[1..16]

                    if (ot == OperandType.NotFirst)
                    {
                        valid = false;
                        return null;
                    }

                    int ending = index + 1;
                    if (expr[index] == 'a' || expr[index] == 'A' || expr[index] == 'd' || expr[index] == 'D')
                    {
                        while (ending < expr.Length && char.IsNumber(expr[ending]))
                            ++ending;

                        if (ending == index + 1)
                        {
                            valid = false;
                            return null;
                        }

                        // further tests
                    }
                    else
                    {
                        valid = false;
                        return null;
                    }
                    string channel = expr.Substring(index, ending - index);
                    index = ending;

                    // eat space
                    while (index < expr.Length && char.IsWhiteSpace(expr[index]))
                        ++index;

                    if (index >= expr.Length)
                    {
                        valid = false;
                        return null;
                    }

                    // comparison
                    ending = index;
                    if (expr[index] == '<' || expr[index] == '>' || expr[index] == '='
                        || expr[index] == '!')
                        if (index + 1 < expr.Length)
                            if (expr[index + 1] == '=')
                                ++ending;
                    string comparison = expr.Substring(index, ending - index + 1);
                    index = ending + 1;

                    // eat space
                    while (index < expr.Length && char.IsWhiteSpace(expr[index]))
                        ++index;

                    if (index >= expr.Length)
                    {
                        valid = false;
                        return null;
                    }

                    // number
                    for (ending = index; ending < expr.Length && !char.IsWhiteSpace(expr[ending]); ++ending)
                        ;

                    if (channel[0] == 'a' || channel[0] == 'A')
                    {
                        double number;
                        if (!double.TryParse(expr.Substring(index, ending - index + 1), out number))
                        {
                            valid = false;
                            return null;
                        }

                        if (!validateOnly)
                        {
                            bool res;
                            try
                            {
                                int cn = int.Parse(channel.Substring(1));
                                double cv = astate[cn - 1];

                                switch (comparison)
                                {
                                    case "<": res = cv < number; break;
                                    case ">": res = cv > number; break;
                                    case "=": res = cv == number; break;
                                    case "==": res = cv == number; break;
                                    case "<=": res = cv <= number; break;
                                    case ">=": res = cv >= number; break;
                                    default: valid = false; return null;
                                }
                            }
                            catch
                            {
                                valid = false;
                                return null;
                            }

                            if (ot == OperandType.First)
                            {
                                if (!validateOnly) result = res;
                            }
                            else if (ot == OperandType.And)
                            {
                                if (!validateOnly) result &= res;
                            }
                            else if (ot == OperandType.Or)
                            {
                                if (!validateOnly) result |= res;
                            }
                        }

                        ot = OperandType.NotFirst;

                        // eat the number
                        index = ending;
                    }
                    else
                    {
                        int number;
                        if (!int.TryParse(expr.Substring(index, ending - index + 1), out number))
                        {
                            valid = false;
                            return null;
                        }

                        if (!validateOnly)
                        {
                            bool res;
                            try
                            {
                                int cn = int.Parse(channel.Substring(1));
                                int cv = dstate[cn - 1];

                                switch (comparison)
                                {
                                    case "<": res = cv < number; break;
                                    case ">": res = cv > number; break;
                                    case "=": res = cv == number; break;
                                    case "==": res = cv == number; break;
                                    case "<=": res = cv <= number; break;
                                    case ">=": res = cv >= number; break;
                                    default: valid = false; return null;
                                }
                            }
                            catch
                            {
                                valid = false;
                                return null;
                            }

                            if (ot == OperandType.First)
                            {
                                if (!validateOnly) result = res;
                            }
                            else if (ot == OperandType.And)
                            {
                                if (!validateOnly) result &= res;
                            }
                            else if (ot == OperandType.Or)
                            {
                                if (!validateOnly) result |= res;
                            }
                        }

                        ot = OperandType.NotFirst;

                        // eat the number
                        index = ending;
                    }
                }
            }

            return validateOnly ? result : result ?? true;
        }
    }
}
