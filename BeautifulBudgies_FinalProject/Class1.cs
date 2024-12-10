/*
* Name: Daquan Daniels
* Email: Danieldu@mail.uc.edu
* Assignment Number: Final Project
* Due Date: 12/10/2024
* Course #/Section: IS3050-001
* Semester/Year: Fall 2024
* Brief Description of the assignment: Final Project for the IS 3050 Web Development w/ .NET

* Brief Description of what this module does: This module solves the "Minimum Number of Boxes to Build a Pyramid" problem from LeetCode.
* Citations: https://leetcode.com/problems/building-boxes/
             https://github.com/cole-crooks/crookscl_FinalProject 
             https://chatgpt.com

* Anything else that's relevant: team: Jack Driehaus (driehajl@mail.uc.edu), Derick Bellofatto (bellofdk@mail.uc.edu), and Cole Crooks (crookscl@mail.uc.edu).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crookscl_FinalProject
{
    public class Class1
    {
        public int MinimumBoxes(int N)
        {
            int height = 1, bottom = 1, total = 1;

            // Step 1: Build the pyramid until the total >= N
            while (total < N)
            {
                height++;
                bottom += height;
                total += bottom;
            }

            // Step 2: Backtrack to adjust for any excess boxes
            while (total >= N)
            {
                bottom--;
                total -= height;
                height--;
            }

            // Return the final number of floor boxes
            return bottom + 1;
        }
    }
}