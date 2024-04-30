Murderer System:
- In order to attack innocent players, you must be a murderer. 
- To become a murderer, go to the chaos shrine and say "I am ready to embrace chaos." You must have 10000 gold on your person or in your bank account to do this.
- Murderers can not enter many regions unless they're carrying a "Stone of Malice" (or something). These regions include dungeons and some gathering regions.
- A "Stone of Malice" is an item that drops from some evil mobs and can be traded between players.
- A "Stone of Malice" can be traded to any Paladin NPC for some amount of gold or rewards.



# [ServUO]

[![Build Status](https://travis-ci.com/ServUO/ServUO.svg?branch=master)](https://travis-ci.com/ServUO/ServUO)
[![GitHub issues](https://img.shields.io/github/issues/servuo/servuo.svg)](https://github.com/ServUO/ServUO/issues)
[![GitHub release](https://img.shields.io/github/release/servuo/servuo.svg)](https://github.com/ServUO/ServUO/releases)
[![GitHub repo size](https://img.shields.io/github/repo-size/servuo/servuo.svg)](https://github.com/ServUO/ServUO/)
[![Discord](https://img.shields.io/discord/110970849628000256.svg)](https://discord.gg/0cQjvnFUN26nRt7y)
[![GitHub contributors](https://img.shields.io/github/contributors/servuo/servuo.svg)](https://github.com/ServUO/ServUO/graphs/contributors)
[![GitHub](https://img.shields.io/github/license/servuo/servuo.svg?color=a)](https://github.com/ServUO/ServUO/blob/master/LICENSE)


ServUO is a community driven Ultima Online Server Emulator written in C#.


### Website

[ServUO]


#### Windows

Run `Compile.WIN - Debug.bat` for development, attaching a debugger and/or extended output.

Run `Compile.WIN - Release.bat` for production environment (-debug is still a supported parameter for script debugging).

After this you can run the server by executing `ServUO.exe`.


#### OSX
```
brew install mono
make
```


#### Ubuntu
```
apt-get install mono-complete
make
```


### Summary

1. Starting with the `/Config` directory, find and edit `Server.cfg` to set up the essentials.
2. Go through the remaining `*.cfg` files to ensure they suit your needs.
3. For Windows, run `Compile.WIN - Debug.bat` to produce `ServUO.exe`, Linux users may run `Makefile`.
4. Run `ServUO.exe` to make sure everything boots up, if everything went well, you should see your IP adress being listened on the port you specified.
5. Load up UO and login! - If you require instructions on setting up your particular client, visit the Discord and ask!



   [ServUO]: <https://www.servuo.com>
