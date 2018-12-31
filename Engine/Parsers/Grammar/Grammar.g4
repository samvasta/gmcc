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

statement                                       : expression label?
                                                | command label?
                                                | action label?
                                                ;

label                                           : COLON STRING
                                                ;

expression                                      : SUBTRACT expression                                               #unaryMinusExpr
                                                | (ADVANTAGE | DISADVANTAGE)* DICE sides=expression                 #modifierRoll
                                                | num=expression DICE sides=expression                              #sumRoll
                                                |<assoc=right> lhs=expression op=POW rhs=expression                 #powExpr
                                                | lhs=expression op=(MULTIPLY | DIVIDE | MOD) rhs=expression        #multiplicationExpr
                                                | lhs=expression op=(ADD | SUBTRACT) rhs=expression                 #additiveExpr
                                                | L_PAREN expression R_PAREN                                        #parenExpr
                                                | INTEGER                                                           #numberExpr
                                                ;

command                                         : COMMAND;
action                                          : ACTION;

 
/*
 * Lexer Rules
 */

COMMAND             : 'command' ;
ACTION              : 'action' ;

DICE                                            : 'd' ;

ADD                                             : '+' ;
SUBTRACT                                        : '-' ;
MULTIPLY                                        : '*' ;
DIVIDE                                          : '/' ;
MOD                                             : '%' ;
POW                                             : '^' ;


AND                                             : '&' ;

ADVANTAGE                                       : '!' ;
DISADVANTAGE                                    : '~' ;



L_PAREN                                         : '(' ;
R_PAREN                                         : ')' ;

COLON                                           : ':' ;

ALPHA_CHAR                                      : [a-zA-Z] ;
STRING                                          : ALPHA_CHAR ALPHA_CHAR ALPHA_CHAR ~[\r\n&]* ;
INTEGER                                         : [0-9]+ ;


WHITESPACE          : (' '|'\t')+ -> skip ;
NEWLINE             : ('\r'? '\n' | '\r')+ ;