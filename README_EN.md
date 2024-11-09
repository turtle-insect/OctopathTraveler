[![Build status](https://ci.appveyor.com/api/projects/status/p0qp4jhksi2j0ktq?svg=true)](https://ci.appveyor.com/project/turtle-insect/octopathtraveler)

# 言語
[日本語](README.md)

# Overview
Nintendo Switch OCTOPATH TRAVELER save data editing tool

# Official Game Site
https://octopathtraveler.nintendo.com/

# Prerequisites
* Windows machine
* .NET Framework 4.7.1 runtime
* Octopath Traveler save file

# Build environment
* Windows 10 (64 bit)
* Visual Studio 2017

# Steps to edit
* Acquire save data from Nintendo Switch console.
* You should have a set of files that look similar to this:
      * KSSaveData1(KSSaveData2、KSSaveData3、、、)
      * KSSystemData
* Save editor will read in KSSaveData1(KSSaveData2、KSSaveData3、、、)
* Perform any editing
* Write out KSSaveData1(KSSaveData2、KSSaveData3、、、)
* Import newly edited saveData to Nintendo Switch console

# Special Thanks
* https://gbatemp.net/threads/octopath-traveler-save-editing.511125/
   * [SleepyPrince](https://gbatemp.net/members/sleepyprince.94652/)
   * [Takumah](https://gbatemp.net/members/takumah.456165/)
   * [Translate English by gen212](https://github.com/gen212/OctopathTraveler)
