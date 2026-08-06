# TRACE

*An [osu!](https://github.com/ppy/osu) ruleset. Sweeping beats with your scythe.*

[Original](https://www.roblox.com/games/119886179319425/TRACE) idea belonging to *SleepyyTofu*.  
This is a fork of [tau ruleset](https://github.com/taulazer/tau)

## Running the Gamemode
We have [prebuilt libraries](https://github.com/ariflan159/trace/releases) for users looking to play the mode without creating a development environment. All releases will work on all operating systems that *osu!* supports.

| [Latest Releases](https://github.com/ariflan159/trace/releases)
| ------------- |

### Instructions

- From the osu settings menu scroll down till you see `Open osu! folder`, that button should take you under `%appdata%/osu`.

- Copy the ruleset file into the `rulesets` directory, do make sure that duplicate copies of the ruleset is overwritten.

- Once done, restart osu!lazer, if lazer is already open. Once lazer is started, you should see the ruleset alongside the standard rulesets on the toolbar at the top.

###### Do note that this instruction will only work with desktop devices.

## Development
When developing or debugging the Trace codebase, a few prerequisites are required as following:
* An IDE that supports the C# language in automatic completion, and syntax highlighting; examples of such being [Visual Studio](https://visualstudio.microsoft.com/vs/) and above, or [JetBrains Rider](https://www.jetbrains.com/rider/).
* The [osu!framework](https://github.com/ppy/osu-framework/tree/master/osu.Framework), and [osu!](https://github.com/ppy/osu) codebases are added as dependencies for building

### Source Code
You are able to clone the repository over command line, or by downloading it. Updating this code to the latest commit would be done with `git pull`, inside the Trace directory.
```sh
git clone https://github.com/ariflan159/trace.git
cd trace
```

### Building the Gamemode From Source
To build Trace, you will need to have [.NET 8.0](https://dotnet.microsoft.com/download) installed on your computer.

First, open a terminal and navigate to wherever you have the Trace source code downloaded. Once you are in the root of the repository, enter the directory named `osu.Game.Rulesets.Trace`.

Next, run the command `dotnet build` and wait for the project to be built. This shouldn't take very long.

Once the project has finished building, dotnet should tell you where the binary was built to (usually somewhere along the lines of `./trace/osu.Game.Rulesets.Trace/bin/Debug/net-8.0/`). Find the .dll binary in the given location and follow the installation instructions above.

## Contributions
All contributions are appreciated, as to improve the mode on its playability and functionality. As this gamemode isn't perfect, we would enjoy all additions to the code through bugfixing and ideas. Contributions should be done over an issue or a pull request, to give maintainers a chance to review changes to the codebase.

For new ideas and features, we would prefer for you to write an issue before trying to add it to show the maintainers.

## License
Tau and Trace are licenced under the [MIT](https://opensource.org/licenses/MIT) License. For licensing information, refer to the [license file](https://github.com/ariflan159/trace/blob/master/LICENSE) regarding what is permitted regarding the codebase.

The licensing here does not directly apply to [osu!](https://github.com/ppy/osu), as it is bound to its own licensing. What is reflected in our licensing *may* not be allowed in the [osu!](https://github.com/ppy/osu) github repository.
