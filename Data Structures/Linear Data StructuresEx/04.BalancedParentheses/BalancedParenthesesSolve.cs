namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 == 1)
            {
                return false;
            }
            var stack = new Stack<char>(parentheses.Length / 2);

            foreach (var currentChar in parentheses)
            {
                char expectedCharacter = default;
                switch (currentChar)
                {
                    case ')':
                        expectedCharacter = '(';
                        break;
                    case ']':
                        expectedCharacter = '[';
                        break;
                    case '}':
                        expectedCharacter = '{';
                        break;
                    default:
                        stack.Push(currentChar);
                        break;
                }

                if (expectedCharacter == default)
                {
                    continue;
                }

                if (stack.Pop() != expectedCharacter)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
