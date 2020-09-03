
using System;
using System.Collections.Generic;

public class CalculatorBaseVisitorImpl : CalculatorBaseVisitor<double>
{
    private Dictionary<String, Double> variables = new Dictionary<String, Double>();


    public override Double VisitPlus(CalculatorParser.PlusContext ctx)
    {
        return Visit(ctx.plusOrMinus()) + Visit(ctx.multOrDiv());

    }


    public override Double VisitMinus(CalculatorParser.MinusContext ctx)
    {
        return Visit(ctx.plusOrMinus()) - Visit(ctx.multOrDiv());
    }


    public override Double VisitMultiplication(CalculatorParser.MultiplicationContext ctx)
    {
        return Visit(ctx.multOrDiv()) * Visit(ctx.pow());
    }


    public override Double VisitDivision(CalculatorParser.DivisionContext ctx)
    {
        return Visit(ctx.multOrDiv()) / Visit(ctx.pow());
    }


    public override Double VisitSetVariable(CalculatorParser.SetVariableContext ctx)
    {
        Double value = Visit(ctx.plusOrMinus());
        variables.Add(ctx.ID().GetText(), value);
        return value;
    }


    public override Double VisitPower(CalculatorParser.PowerContext ctx)
    {
        if (ctx.pow() != null)
            return Math.Pow(Visit(ctx.unaryMinus()), Visit(ctx.pow()));
        return Visit(ctx.unaryMinus());
    }


    public override Double VisitChangeSign(CalculatorParser.ChangeSignContext ctx)
    {
        return -1 * Visit(ctx.unaryMinus());
    }


    public override Double VisitBraces(CalculatorParser.BracesContext ctx)
    {
        return Visit(ctx.plusOrMinus());
    }


    public override Double VisitConstantPI(CalculatorParser.ConstantPIContext ctx)
    {
        return Math.PI;
    }


    public override Double VisitConstantE(CalculatorParser.ConstantEContext ctx)
    {
        return Math.E;
    }


    public override Double VisitInt(CalculatorParser.IntContext ctx)
    {
        return Double.Parse(ctx.INT().GetText());
    }


    public override Double VisitVariable(CalculatorParser.VariableContext ctx)
    {
        //return variablesctx.ID().GetText());

     return variables[ctx.ID().GetText()];
    }


    public override Double VisitDouble(CalculatorParser.DoubleContext ctx)
    {
        return Double.Parse(ctx.DOUBLE().GetText());
    }


    public override Double VisitCalculate(CalculatorParser.CalculateContext ctx)
    {
        return Visit(ctx.plusOrMinus());
    }
}