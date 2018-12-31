//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Sam\Documents\Visual Studio 2017\Projects\gmcc\Engine\Parsers\Grammar\Grammar.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Engine.Parsers.Generated.Grammar {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class GrammarParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		ADD=1, SUBTRACT=2, MULTIPLY=3, DIVIDE=4, MOD=5, POW=6, AND=7, DICE=8, 
		ADVANTAGE=9, DISADVANTAGE=10, INTEGER=11, L_PAREN=12, R_PAREN=13, WHITESPACE=14, 
		NEWLINE=15, COMMAND=16, ACTION=17;
	public const int
		RULE_statements = 0, RULE_statement = 1, RULE_expression = 2, RULE_value = 3, 
		RULE_roll = 4, RULE_modifier = 5, RULE_command = 6, RULE_action = 7;
	public static readonly string[] ruleNames = {
		"statements", "statement", "expression", "value", "roll", "modifier", 
		"command", "action"
	};

	private static readonly string[] _LiteralNames = {
		null, "'+'", "'-'", "'*'", "'/'", "'%'", "'^'", "'&'", "'d'", "'!'", "'~'", 
		null, "'('", "')'", null, null, "'command'", "'action'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "ADD", "SUBTRACT", "MULTIPLY", "DIVIDE", "MOD", "POW", "AND", "DICE", 
		"ADVANTAGE", "DISADVANTAGE", "INTEGER", "L_PAREN", "R_PAREN", "WHITESPACE", 
		"NEWLINE", "COMMAND", "ACTION"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Grammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static GrammarParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public GrammarParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public GrammarParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class StatementsContext : ParserRuleContext {
		public StatementContext[] statement() {
			return GetRuleContexts<StatementContext>();
		}
		public StatementContext statement(int i) {
			return GetRuleContext<StatementContext>(i);
		}
		public ITerminalNode Eof() { return GetToken(GrammarParser.Eof, 0); }
		public ITerminalNode[] AND() { return GetTokens(GrammarParser.AND); }
		public ITerminalNode AND(int i) {
			return GetToken(GrammarParser.AND, i);
		}
		public StatementsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statements; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatements(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementsContext statements() {
		StatementsContext _localctx = new StatementsContext(Context, State);
		EnterRule(_localctx, 0, RULE_statements);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16; statement();
			State = 21;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==AND) {
				{
				{
				State = 17; Match(AND);
				State = 18; statement();
				}
				}
				State = 23;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 24; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public CommandContext command() {
			return GetRuleContext<CommandContext>(0);
		}
		public ActionContext action() {
			return GetRuleContext<ActionContext>(0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 2, RULE_statement);
		try {
			State = 29;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case SUBTRACT:
			case DICE:
			case ADVANTAGE:
			case DISADVANTAGE:
			case INTEGER:
			case L_PAREN:
				EnterOuterAlt(_localctx, 1);
				{
				State = 26; expression(0);
				}
				break;
			case COMMAND:
				EnterOuterAlt(_localctx, 2);
				{
				State = 27; command();
				}
				break;
			case ACTION:
				EnterOuterAlt(_localctx, 3);
				{
				State = 28; action();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ValueExprContext : ExpressionContext {
		public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public ValueExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitValueExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UnaryMinusExprContext : ExpressionContext {
		public ITerminalNode SUBTRACT() { return GetToken(GrammarParser.SUBTRACT, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public UnaryMinusExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUnaryMinusExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MultiplicationExprContext : ExpressionContext {
		public ExpressionContext lhs;
		public IToken op;
		public ExpressionContext rhs;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode MULTIPLY() { return GetToken(GrammarParser.MULTIPLY, 0); }
		public ITerminalNode DIVIDE() { return GetToken(GrammarParser.DIVIDE, 0); }
		public ITerminalNode MOD() { return GetToken(GrammarParser.MOD, 0); }
		public MultiplicationExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplicationExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AdditiveExprContext : ExpressionContext {
		public ExpressionContext lhs;
		public IToken op;
		public ExpressionContext rhs;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode ADD() { return GetToken(GrammarParser.ADD, 0); }
		public ITerminalNode SUBTRACT() { return GetToken(GrammarParser.SUBTRACT, 0); }
		public AdditiveExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAdditiveExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PowExprContext : ExpressionContext {
		public ExpressionContext lhs;
		public IToken op;
		public ExpressionContext rhs;
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode POW() { return GetToken(GrammarParser.POW, 0); }
		public PowExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPowExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ParenExprContext : ExpressionContext {
		public ITerminalNode L_PAREN() { return GetToken(GrammarParser.L_PAREN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode R_PAREN() { return GetToken(GrammarParser.R_PAREN, 0); }
		public ParenExprContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 4;
		EnterRecursionRule(_localctx, 4, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case SUBTRACT:
				{
				_localctx = new UnaryMinusExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 32; Match(SUBTRACT);
				State = 33; expression(5);
				}
				break;
			case DICE:
			case ADVANTAGE:
			case DISADVANTAGE:
			case INTEGER:
				{
				_localctx = new ValueExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 34; value();
				}
				break;
			case L_PAREN:
				{
				_localctx = new ParenExprContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 35; Match(L_PAREN);
				State = 36; expression(0);
				State = 37; Match(R_PAREN);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 52;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,4,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 50;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
					case 1:
						{
						_localctx = new PowExprContext(new ExpressionContext(_parentctx, _parentState));
						((PowExprContext)_localctx).lhs = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 41;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 42; ((PowExprContext)_localctx).op = Match(POW);
						State = 43; ((PowExprContext)_localctx).rhs = expression(6);
						}
						break;
					case 2:
						{
						_localctx = new MultiplicationExprContext(new ExpressionContext(_parentctx, _parentState));
						((MultiplicationExprContext)_localctx).lhs = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 44;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 45;
						((MultiplicationExprContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MULTIPLY) | (1L << DIVIDE) | (1L << MOD))) != 0)) ) {
							((MultiplicationExprContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 46; ((MultiplicationExprContext)_localctx).rhs = expression(5);
						}
						break;
					case 3:
						{
						_localctx = new AdditiveExprContext(new ExpressionContext(_parentctx, _parentState));
						((AdditiveExprContext)_localctx).lhs = _prevctx;
						PushNewRecursionContext(_localctx, _startState, RULE_expression);
						State = 47;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 48;
						((AdditiveExprContext)_localctx).op = TokenStream.LT(1);
						_la = TokenStream.LA(1);
						if ( !(_la==ADD || _la==SUBTRACT) ) {
							((AdditiveExprContext)_localctx).op = ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 49; ((AdditiveExprContext)_localctx).rhs = expression(4);
						}
						break;
					}
					} 
				}
				State = 54;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,4,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
	 
		public ValueContext() { }
		public virtual void CopyFrom(ValueContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class RollValueContext : ValueContext {
		public RollContext roll() {
			return GetRuleContext<RollContext>(0);
		}
		public RollValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRollValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class NumberValueContext : ValueContext {
		public ITerminalNode INTEGER() { return GetToken(GrammarParser.INTEGER, 0); }
		public NumberValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumberValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 6, RULE_value);
		try {
			State = 57;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				_localctx = new NumberValueContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 55; Match(INTEGER);
				}
				break;
			case 2:
				_localctx = new RollValueContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 56; roll();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RollContext : ParserRuleContext {
		public ITerminalNode DICE() { return GetToken(GrammarParser.DICE, 0); }
		public ITerminalNode[] INTEGER() { return GetTokens(GrammarParser.INTEGER); }
		public ITerminalNode INTEGER(int i) {
			return GetToken(GrammarParser.INTEGER, i);
		}
		public ModifierContext[] modifier() {
			return GetRuleContexts<ModifierContext>();
		}
		public ModifierContext modifier(int i) {
			return GetRuleContext<ModifierContext>(i);
		}
		public RollContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_roll; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRoll(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public RollContext roll() {
		RollContext _localctx = new RollContext(Context, State);
		EnterRule(_localctx, 8, RULE_roll);
		int _la;
		try {
			State = 70;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case DICE:
			case ADVANTAGE:
			case DISADVANTAGE:
				EnterOuterAlt(_localctx, 1);
				{
				State = 62;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==ADVANTAGE || _la==DISADVANTAGE) {
					{
					{
					State = 59; modifier();
					}
					}
					State = 64;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 65; Match(DICE);
				State = 66; Match(INTEGER);
				}
				break;
			case INTEGER:
				EnterOuterAlt(_localctx, 2);
				{
				State = 67; Match(INTEGER);
				State = 68; Match(DICE);
				State = 69; Match(INTEGER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ModifierContext : ParserRuleContext {
		public ITerminalNode ADVANTAGE() { return GetToken(GrammarParser.ADVANTAGE, 0); }
		public ITerminalNode DISADVANTAGE() { return GetToken(GrammarParser.DISADVANTAGE, 0); }
		public ModifierContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_modifier; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitModifier(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ModifierContext modifier() {
		ModifierContext _localctx = new ModifierContext(Context, State);
		EnterRule(_localctx, 10, RULE_modifier);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 72;
			_la = TokenStream.LA(1);
			if ( !(_la==ADVANTAGE || _la==DISADVANTAGE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CommandContext : ParserRuleContext {
		public ITerminalNode COMMAND() { return GetToken(GrammarParser.COMMAND, 0); }
		public CommandContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_command; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCommand(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CommandContext command() {
		CommandContext _localctx = new CommandContext(Context, State);
		EnterRule(_localctx, 12, RULE_command);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 74; Match(COMMAND);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ActionContext : ParserRuleContext {
		public ITerminalNode ACTION() { return GetToken(GrammarParser.ACTION, 0); }
		public ActionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_action; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IGrammarVisitor<TResult> typedVisitor = visitor as IGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAction(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ActionContext action() {
		ActionContext _localctx = new ActionContext(Context, State);
		EnterRule(_localctx, 14, RULE_action);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 76; Match(ACTION);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 6);
		case 1: return Precpred(Context, 4);
		case 2: return Precpred(Context, 3);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x13', 'Q', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\a', 
		'\x2', '\x16', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '\x19', '\v', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x5', '\x3', ' ', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x5', '\x4', '*', '\n', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\a', '\x4', '\x35', '\n', '\x4', '\f', '\x4', '\xE', '\x4', 
		'\x38', '\v', '\x4', '\x3', '\x5', '\x3', '\x5', '\x5', '\x5', '<', '\n', 
		'\x5', '\x3', '\x6', '\a', '\x6', '?', '\n', '\x6', '\f', '\x6', '\xE', 
		'\x6', '\x42', '\v', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x5', '\x6', 'I', '\n', '\x6', '\x3', '\a', 
		'\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x2', '\x3', '\x6', '\n', '\x2', '\x4', '\x6', '\b', '\n', '\f', 
		'\xE', '\x10', '\x2', '\x5', '\x3', '\x2', '\x5', '\a', '\x3', '\x2', 
		'\x3', '\x4', '\x3', '\x2', '\v', '\f', '\x2', 'S', '\x2', '\x12', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x6', 
		')', '\x3', '\x2', '\x2', '\x2', '\b', ';', '\x3', '\x2', '\x2', '\x2', 
		'\n', 'H', '\x3', '\x2', '\x2', '\x2', '\f', 'J', '\x3', '\x2', '\x2', 
		'\x2', '\xE', 'L', '\x3', '\x2', '\x2', '\x2', '\x10', 'N', '\x3', '\x2', 
		'\x2', '\x2', '\x12', '\x17', '\x5', '\x4', '\x3', '\x2', '\x13', '\x14', 
		'\a', '\t', '\x2', '\x2', '\x14', '\x16', '\x5', '\x4', '\x3', '\x2', 
		'\x15', '\x13', '\x3', '\x2', '\x2', '\x2', '\x16', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x17', '\x15', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', 
		'\x3', '\x2', '\x2', '\x2', '\x18', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\x19', '\x17', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1B', '\a', '\x2', 
		'\x2', '\x3', '\x1B', '\x3', '\x3', '\x2', '\x2', '\x2', '\x1C', ' ', 
		'\x5', '\x6', '\x4', '\x2', '\x1D', ' ', '\x5', '\xE', '\b', '\x2', '\x1E', 
		' ', '\x5', '\x10', '\t', '\x2', '\x1F', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x1E', '\x3', 
		'\x2', '\x2', '\x2', ' ', '\x5', '\x3', '\x2', '\x2', '\x2', '!', '\"', 
		'\b', '\x4', '\x1', '\x2', '\"', '#', '\a', '\x4', '\x2', '\x2', '#', 
		'*', '\x5', '\x6', '\x4', '\a', '$', '*', '\x5', '\b', '\x5', '\x2', '%', 
		'&', '\a', '\xE', '\x2', '\x2', '&', '\'', '\x5', '\x6', '\x4', '\x2', 
		'\'', '(', '\a', '\xF', '\x2', '\x2', '(', '*', '\x3', '\x2', '\x2', '\x2', 
		')', '!', '\x3', '\x2', '\x2', '\x2', ')', '$', '\x3', '\x2', '\x2', '\x2', 
		')', '%', '\x3', '\x2', '\x2', '\x2', '*', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '+', ',', '\f', '\b', '\x2', '\x2', ',', '-', '\a', '\b', '\x2', 
		'\x2', '-', '\x35', '\x5', '\x6', '\x4', '\b', '.', '/', '\f', '\x6', 
		'\x2', '\x2', '/', '\x30', '\t', '\x2', '\x2', '\x2', '\x30', '\x35', 
		'\x5', '\x6', '\x4', '\a', '\x31', '\x32', '\f', '\x5', '\x2', '\x2', 
		'\x32', '\x33', '\t', '\x3', '\x2', '\x2', '\x33', '\x35', '\x5', '\x6', 
		'\x4', '\x6', '\x34', '+', '\x3', '\x2', '\x2', '\x2', '\x34', '.', '\x3', 
		'\x2', '\x2', '\x2', '\x34', '\x31', '\x3', '\x2', '\x2', '\x2', '\x35', 
		'\x38', '\x3', '\x2', '\x2', '\x2', '\x36', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\x36', '\x37', '\x3', '\x2', '\x2', '\x2', '\x37', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'<', '\a', '\r', '\x2', '\x2', ':', '<', '\x5', '\n', '\x6', '\x2', ';', 
		'\x39', '\x3', '\x2', '\x2', '\x2', ';', ':', '\x3', '\x2', '\x2', '\x2', 
		'<', '\t', '\x3', '\x2', '\x2', '\x2', '=', '?', '\x5', '\f', '\a', '\x2', 
		'>', '=', '\x3', '\x2', '\x2', '\x2', '?', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '@', '>', '\x3', '\x2', '\x2', '\x2', '@', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '\x41', '\x43', '\x3', '\x2', '\x2', '\x2', '\x42', '@', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x44', '\a', '\n', '\x2', '\x2', 
		'\x44', 'I', '\a', '\r', '\x2', '\x2', '\x45', '\x46', '\a', '\r', '\x2', 
		'\x2', '\x46', 'G', '\a', '\n', '\x2', '\x2', 'G', 'I', '\a', '\r', '\x2', 
		'\x2', 'H', '@', '\x3', '\x2', '\x2', '\x2', 'H', '\x45', '\x3', '\x2', 
		'\x2', '\x2', 'I', '\v', '\x3', '\x2', '\x2', '\x2', 'J', 'K', '\t', '\x4', 
		'\x2', '\x2', 'K', '\r', '\x3', '\x2', '\x2', '\x2', 'L', 'M', '\a', '\x12', 
		'\x2', '\x2', 'M', '\xF', '\x3', '\x2', '\x2', '\x2', 'N', 'O', '\a', 
		'\x13', '\x2', '\x2', 'O', '\x11', '\x3', '\x2', '\x2', '\x2', '\n', '\x17', 
		'\x1F', ')', '\x34', '\x36', ';', '@', 'H',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Engine.Parsers.Generated.Grammar