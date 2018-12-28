using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;


namespace Engine.Parsers.Grammer
{
    public class GrammerVisitor : GrammerBaseVisitor<object>
    {
        public List<GrammerLine> Lines = new List<GrammerLine>();
 
        public override object VisitLine(GrammerParser.LineContext context)
        {            
            GrammerParser.NameContext name = context.name();
            GrammerParser.OpinionContext opinion = context.opinion();
    
            GrammerLine line = new GrammerLine() { Person = name.GetText(), Text = opinion.GetText().Trim('"') };
            Lines.Add(line);
    
            return line;
        }
    }
}