#!/bin/sh

dotnet.exe publish -c Release -r linux-x64 -p:PublishProfile=DefaultContainer
