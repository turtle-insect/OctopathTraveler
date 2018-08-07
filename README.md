[![Build status](https://ci.appveyor.com/api/projects/status/p0qp4jhksi2j0ktq?svg=true)](https://ci.appveyor.com/project/turtle-insect/octopathtraveler)

# 概要
Switch OCTOPATH TRAVELER(オクトパス トラベラー)のセーブデータ編集Tool

# ソフト
http://www.jp.square-enix.com/octopathtraveler/

# 実行に必要
* Windows マシン
* .NET Framework 4.7.1の導入
* セーブデータの吸い出し
* セーブデータの書き戻し

# Build環境
* Windows 10(64bit)
* Visual Studio 2017

# 編集時の手順
* saveDataを吸い出す
   * 結果、以下が取得可能
      * KSSaveData0(KSSaveData1、KSSaveData2、、、)
      * KSSystemData
* KSSaveData0(KSSaveData1、KSSaveData2、、、)を読み込む
* 任意の編集を行う
* KSSaveData0(KSSaveData1、KSSaveData2、、、)を書き出す
* saveDataを書き戻す

# Special Thanks
* https://gbatemp.net/threads/octopath-traveler-save-editing.511125/
   * [SleepyPrince](https://gbatemp.net/members/sleepyprince.94652/)
   * [Takumah](https://gbatemp.net/members/takumah.456165/)
   * [Translate English by gen212](https://github.com/gen212/OctopathTraveler)
