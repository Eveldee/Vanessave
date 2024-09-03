#!/bin/sh

dotnet.exe publish Vanessave -c Release -r linux-x64 -p:PublishProfile=DefaultContainer -p:InvariantGlobalization=true -p:ContainerFamily=alpine -p:ContainerRepository=eveldee/vanessave
