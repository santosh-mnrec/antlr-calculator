using System;
using System.IO;
using Antlr4.Runtime;

public class Run {
    public static void Main(String[] args)  {
        var data=File.ReadAllText("input.txt");
        var input = new AntlrInputStream(data);
        CalculatorLexer lexer = new CalculatorLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        CalculatorParser parser = new CalculatorParser(tokens);
        var tree = parser.input();

        CalculatorBaseVisitorImpl calcVisitor = new CalculatorBaseVisitorImpl();
        double result = calcVisitor.Visit(tree);
        Console.WriteLine("Result: " + result);
    }
}