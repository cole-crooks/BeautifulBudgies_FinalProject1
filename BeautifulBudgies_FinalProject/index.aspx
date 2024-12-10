<!--
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
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="crookscl_FinalProject.index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="index.css" />
    <title></title>
    <asp:Label ID="lblTitle" runat="server" Text="LeetCode Problem Solver"></asp:Label>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblProblemSelect" runat="server" Text="Select a LeetCode problem to solve." SelectionMode="Single"></asp:Label>
            <asp:DropDownList ID="ProblemSelect" runat="server">
                <asp:ListItem Text="Problem 1106" Value="1"></asp:ListItem>
                <asp:ListItem Text="Problem (2)" Value="2"></asp:ListItem>
                <asp:ListItem Text="Problem 1739" Value="3"></asp:ListItem>
                <asp:ListItem Text="Problem (4)" Value="4"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="cmdProblemSolve" runat="server" Text="Solve" OnClick="cmdProblemSolve_Click" />

            <div>
                <asp:Label ID="lblSelectedProblemDetails" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

