/*
* Name: Cole Crooks
* email:  crookscl@mail.uc.edu
* Assignment Number: Final Project
* Due Date:   12/10/2024
* Course #/Section:   IS3050-001
* Semester/Year:   Fall 2024
* Brief Description of the assignment:  Final Project for the IS 3050 Web Development w/ .NET

* Brief Description of what this module does. Demonstrating all that we've learned this year, solve one (1) hard leetcode problem per person with class knowledge and Github
* Citations:https://leetcode.com/problems/parsing-a-boolean-expression/description/
            https://github.com/cole-crooks/crookscl_FinalProject          
* Anything else that's relevant: My collaborators on this project are Jack Driehaus (driehajl@mail.uc.edu), Derick Bellofatto (bellofdk@mail.uc.edu), and LAST GUY (HIS EMAIL)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crookscl_FinalProject
{
    public class Problem1106Solution
    {
        /// <summary>
        /// Solves Proplem 1106 on leetcode
        /// Evaluates a boolean expression represented as a string
        /// </summary>
        /// <param name="expression">The boolean expression to evaluate</param>
        /// <returns>A boolean value representing the result of the evaluated expression</returns>
        public bool ParseBoolExpr(string expression)
        {
            Stack<char> operators = new Stack<char>();
            Stack<Stack<char>> operands = new Stack<Stack<char>>();

            operands.Push(new Stack<char>());

            foreach (char c in expression)
            {
                if (c == 't' || c == 'f')
                {
                    operands.Peek().Push(c);
                }
                else if (c == '&' || c == '|' || c == '!')
                {
                    operators.Push(c);
                }
                else if (c == '(')
                {
                    operands.Push(new Stack<char>());
                }
                else if (c == ')')
                {
                    var operatorChar = operators.Pop();
                    var currentOperands = operands.Pop();
                    char result = Evaluate(operatorChar, currentOperands);
                    operands.Peek().Push(result);
                }
            }

            return operands.Peek().Pop() == 't';
        }

        private char Evaluate(char operatorChar, Stack<char> currentOperands)
        {
            if (operatorChar == '!')
            {
                return currentOperands.Pop() == 't' ? 'f' : 't';
            }
            else if (operatorChar == '&')
            {
                while (currentOperands.Count > 0)
                {
                    if (currentOperands.Pop() == 'f')
                    {
                        return 'f';
                    }
                }
                return 't';
            }
            else if (operatorChar == '|')
            {
                while (currentOperands.Count > 0)
                {
                    if (currentOperands.Pop() == 't')
                    {
                        return 't';
                    }
                }
                return 'f';
            }

            throw new InvalidOperationException("Invalid operator");
        }
    }
}