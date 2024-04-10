#!/bin/bash

if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    xdg-open coveragereport/index.html
elif [[ "$OSTYPE" == "darwin"* ]]; then
    open coveragereport/index.html
elif [[ "$OSTYPE" == "cygwin" ]]; then
    cygstart coveragereport/index.html
elif [[ "$OSTYPE" == "msys" ]]; then
    start coveragereport/index.html
elif [[ "$OSTYPE" == "win32" ]]; then
    start coveragereport/index.html
else
    echo "Platform not supported"
fi