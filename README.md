# Vanessave

![](Screenshots/Preview.png)

> A **Little Witch Nobeta** save and settings editor

# Documentation

- [Usage](#usage)
- [Features](#features)
- [Compatibility](#compatibility)
- [Self-Hosting](#self-hosting)
  - [Using Docker](#using-docker)
  - [Manually (build from source)](#manually-build-from-source)
- [Bug report and help](#bug-report-and-help)
- [Contributing](#contributing)
- [Used libraries](#used-libraries)
- [Licence](#licence)

## Usage

This save editor is available as a website so no installation is required. Usage is as follow:
- Find your save and settings in the installation directory of the game *(Usually in steamapps/common, you can find this from the game properties in steam -> local files -> browse...)*
- Go to the **[public hosted instance](https://vanessave.ilysix.fr/)** or your own self hosted instance
- Choose which tool you want using the navigation bar on the left
- Load your save/settings by clicking on the upload button or directly drag-and-drop your save into the page
- Apply your modifications
- Download the new modified save using the download button on the bottom-right corner
- Replace your old save with the new one in your game folder

## Features

This save editor can modify nearly all properties of a save via specialized user interfaces with the exception of unlocked save points and dropped items.  
It is still possible to edit any part of a save/settings using the advanced `Extract/Edit/Pack` tool which allows direct modifications *(use at your own risk)*. 

![](Screenshots/Preview-Inventory.png)

> Example of the inventory editor

## Compatibility

The save editor should work for any version of the game but no special compatibility support is provided for older save formats.

## Self-Hosting

If you would prefer to use your own instance of the save editor *(or in case the public one is down)*, you can either use Docker or build from source.

### Using Docker

Here is an example of the compose file used to host the public instance. There is no need for any path mapping as this save editor doesn't save or log any data.

```yml
services:
  vanessave:
    image: eveldee/vanessave:latest
    container_name: vanessave
    restart: unless-stopped
    ports:
      - 8080:8080

version: '3'
```

### Manually (build from source)

To build and run the save editor from source, a few steps are required:
- Clone this repository and make sure .Net 8.0 SDK is installed
- Use the command `dotnet run` inside the project folder *(where `Vanessave.csproj` is located)*
- This will build and run the website on a random port *(check the console logs to get the port)*

Alternatively, it is possible to build the docker image using the `docker-publish.sh` script.

## Bug report and help

If you found a bug, need help with the save editor or want to suggest a new feature, you can either [open a new issue](/../../issues) or you can find me on the [Little Witch Nobeta Speedruns Discord](https://discord.gg/3FMeB4m).

## Contributing

This repository accepts contributions, don't hesitate to [open a new issue](/../../issues) before doing a pull request for major changes or new features.

## Used libraries

This save editor tool couldn't be made without these awesome libraries and tools:
- [Monaco Editor](https://github.com/Microsoft/monaco-editor)  - *licensed under the MIT license*
- [BlazorMonaco](https://github.com/serdarciplak/BlazorMonaco) - *licensed under the MIT license*
- [MudBlazor](https://github.com/MudBlazor/MudBlazor) - *licensed under the MIT license*
- [Toolbelt.Blazor.FileDropZone](https://github.com/jsakamoto/Toolbelt.Blazor.FileDropZone) - *licensed under the MPL-2.0 license*
- [Humanizer](https://github.com/Humanizr/Humanizer) - *licensed under the MIT license*

## Licence

*This software is licensed under the [MIT license](LICENSE), you can modify and redistribute it freely as long as you respect the respective [Used libraries](#used-libraries) licenses*
