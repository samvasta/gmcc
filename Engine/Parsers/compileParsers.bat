@ECHO OFF

REM For each .g4 file in the current directory
for /R %%f in (*.g4) do (
    @echo Found g4 file '%%f'

    REM Delete all files in the output folder
    REM del /q "%%~nf\Generated\*"
    REM for /d %%x in (%%~nf\Generated\*) do @rd /s /q "%%x"

    REM Compile grammer with Antlr4
    java -jar ..\Antlr4\antlr-4.7.2-complete.jar -Dlanguage=CSharp -o "Generated\%%~nf" "%%f" -visitor
    @echo Successfully compiled '%%f'
)