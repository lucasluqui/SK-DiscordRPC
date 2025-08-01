# SK-DiscordRPC
[Discord RPC](https://discord.com/developers/docs/topics/rpc) implementation to interface with the game Spiral Knights and post live game info onto your Discord status, bundled with [Knight Launcher](https://github.com/lucasluqui/KnightLauncher) as one of it's modules. Windows only.

## Downloading
SK-DiscordRPC isn't available as a standalone download and install. To use it you must download [Knight Launcher](https://github.com/lucasluqui/KnightLauncher) and enable the "Discord Integration" setting in its Settings menu.

## Building
1. Prerequisites
   - A device that runs Windows 10/11.
   - [Visual Studio](https://visualstudio.microsoft.com/downloads/) installed.
   - After Visual Studio installs, select the ".NET desktop development" workload and install it as well.
2. Clone the repository within Visual Studio. Get Started → Clone a repository.
3. Open the `SK-DiscordRPC.sln` solution file.
4. Build → Build Solution (or press CTRL + SHIFT + B).
5. You will find the built executable at `<Your Project Folder>\bin\Debug` or `<Your Project Folder>\bin\Release` depending on which configuration you've selected.
