#!/usr/bin/env pwsh
# Find the latest coverage file
$coverageFile = Get-ChildItem -Path "TestResults" -Filter "coverage.cobertura.xml" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Generate the report
reportgenerator -reports:"$($coverageFile.FullName)" -targetdir:"coveragereport" -reporttypes:Html