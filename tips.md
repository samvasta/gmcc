## Re-compile all parsers:

From `gmcc\Engine\Parsers`, execute in terminal:

```
.\compileParsers.bat
```


## Run tests with code coverage:

From root directory, execute in terminal:

```
dotnet test EngineTest /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info
```