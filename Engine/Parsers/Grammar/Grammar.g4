grammar Grammar;
 
options
{
    language=CSharp;
}

/*
 * Parser Rules
 */

statements                                      : statement (AND statement)* EOF
                                                ;

statement                                       : expression
                                                | command
                                                | action
                                                ;

expression                                      :<assoc=right> lhs=expression op=POW rhs=expression                 #powExpr
                                                | SUBTRACT expression                                               #unaryMinusExpr
                                                | lhs=expression op=(MULTIPLY | DIVIDE | MOD) rhs=expression        #multiplicationExpr
                                                | lhs=expression op=(ADD | SUBTRACT) rhs=expression                 #additiveExpr
                                                | value                                                             #valueExpr
                                                | L_PAREN expression R_PAREN                                        #parenExpr
                                                ;

value                                           : INTEGER                                                           #numberValue
                                                | roll                                                              #rollValue
                                                ;

roll                                            : modifier* DICE INTEGER
                                                | INTEGER DICE INTEGER
                                                ;

modifier                                        : ADVANTAGE
                                                | DISADVANTAGE
                                                ;


command                                         : COMMAND;
action                                          : ACTION;

 
/*
 * Lexer Rules
 */

ADD                                             : '+' ;
SUBTRACT                                        : '-' ;
MULTIPLY                                        : '*' ;
DIVIDE                                          : '/' ;
MOD                                             : '%' ;
POW                                             : '^' ;


AND                                             : '&' ;

DICE                                            : 'd' ;
ADVANTAGE                                       : '!' ;
DISADVANTAGE                                    : '~' ;

INTEGER                                         : [0-9]+ ;


L_PAREN                                         : '(' ;
R_PAREN                                         : ')' ;


WHITESPACE          : (' '|'\t')+ -> skip ;
NEWLINE             : ('\r'? '\n' | '\r')+ ;

COMMAND             : 'command' ;

ACTION              : 'action' ;