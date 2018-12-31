@ECHO OFF

REM For each .g4 file in the current directory
for /R %%f in (*.g4) do (
    @echo Found g4 file '%%f'

    REM Delete all files in the output folder
    del /q "Generated\%%~nf\*"
    for /d %%x in (Generated\%%~nf\*) do @rd /s /q "%%x"

    REM Compile grammar with Antlr4
    java -jar ..\Antlr4\antlr-4.7.2-complete.jar -Dlanguage=CSharp -o "Generated\%%~nf" "%%f" -no-listener -visitor -package "Engine.Parsers.Generated.%%~nf"
    @echo Successfully compiled '%%f'
)