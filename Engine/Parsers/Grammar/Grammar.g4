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
                                                | SLASH command
                                                | action label?
                                                ;

label                                           : COLON STRING
                                                ;

expression                                      : SUBTRACT expression                                               #unaryMinusExpr
                                                | (ADVANTAGE | DISADVANTAGE)* DICE sides=expression                 #modifierRoll
                                                | num=expression DICE sides=expression                              #sumRoll
                                                |<assoc=right> lhs=expression op=POW rhs=expression                 #powExpr
                                                | lhs=expression op=(MULTIPLY | DIVIDE | MOD) rhs=expression        #multiplicationExpr
                                                | lhs=expression op=(PLUS | SUBTRACT) rhs=expression                #additiveExpr
                                                | L_PAREN expression R_PAREN                                        #parenExpr
                                                | INTEGER                                                           #numberExpr
                                                ;

command                                         : 'help'                                                            #helpCmd
                                                | 'theme' theme=WORD                                                #themeCmd
                                                | 'ruleset' ruleset=WORD                                            #rulesetCmd
                                                | 'clear'                                                           #clearCmd
                                                | 'load' encounter=WORD                                             #loadEncCmd
                                                | 'save' encounter=WORD                                             #saveEncCmd
                                                ;


action                                          : NEW creature=WORD                                                 #newCreatureAct
                                                | KILL creature=WORD                                                #delCreatureAct
                                                | HIT creature=WORD counter=WORD? expression                        #hitCreatureAct
                                                | SET creature=WORD counter=WORD? expression                        #setCreatureAct
                                                | ADD creature=WORD COMMA? status=WORD                              #addStatusAct
                                                | REMOVE creature=WORD COMMA? status=WORD                           #remStatusAct
                                                | skill=WORD L_PAREN creature=WORD (COMMA creature=WORD)* R_PAREN   #invokeSkillAct
                                                | creature=WORD DOT action=WORD                                     #invokeActionAct
                                                | RESET creature=WORD DOT action=WORD                               #resetSkillAct

                                                | NEXT TRACK                                                        #nextTrackAct
                                                | NEXT TURN                                                         #nextTurnAct
                                                | NEXT WAVE                                                         #nextWaveAct
                                                | NEXT ENCOUNTER                                                    #nextEncounterAct

                                                | PREV TRACK                                                        #prevTrackAct
                                                | PREV TURN                                                         #prevTurnAct
                                                | PREV WAVE                                                         #prevWaveAct
                                                | PREV ENCOUNTER                                                    #prevEncounterAct
                                                ;

 
/*
 * Lexer Rules
 */

/*
 * Creature Action Keywords
 */
HIT                                             : 'hit' | 'h' ;
ADD                                             : 'add'  | 'a' ;
REMOVE                                          : 'remove' | 'rem' | 'r' ;
NEW                                             : 'new'  | 'n' ;
KILL                                            : 'kill' | 'k' ;
SET                                             : 'set' ;
RESET                                           : 'reset' ;

/*
 * Application State Keywords
 */
NEXT                                            : 'next' ;
PREV                                            : 'prev' | 'previous' ;

WAVE                                            : 'wave' ;
ENCOUNTER                                       : 'enc' | 'encounter' ;
TRACK                                           : 'track' ;
TURN                                            : 'turn' ;


COMMAND                                         : 'command' ;

DICE                                            : 'd' ;

PLUS                                             : '+' ;
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
COMMA                                           : ',' ;
DOT                                             : '.' ;

SLASH                                           : '/' ;


ALPHA_CHAR                                      : [a-zA-Z] ;
WORD                                            : ALPHA_CHAR ALPHA_CHAR ALPHA_CHAR+ ;           // At least 3 letters
STRING                                          : ALPHA_CHAR ALPHA_CHAR ALPHA_CHAR ~[\r\n&]* ;  // At least 3 letters, then any non-new-line/& character
INTEGER                                         : [0-9]+ ;


WHITESPACE                                      : (' '|'\t')+ -> skip ;
NEWLINE                                         : ('\r'? '\n' | '\r')+ ;