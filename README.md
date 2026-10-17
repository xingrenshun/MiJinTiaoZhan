# 密金挑战 / MiJinTiaoZhan —— 游戏源码

《密金挑战》抖音小游戏（发行名：**失重历险** / **宥如秘境闯关**）的完整 Unity 工程源码。

以旋转重力为核心玩法的无尽横版闯关：玩家单指操作旋转整个世界 90°，让双足忍者小队沿着墙壁与天花板行走，穿过程序随机生成的密室长廊，躲避圆锯、压板、旋转刀轴、激光、岩浆与射箭机关，穿越水域时移速变慢但可向上游。沿途拾取金币、加速、巨化、补兵与复活道具，全员阵亡即结束。

## 环境

| 项目 | 说明 |
| --- | --- |
| Unity 版本 | 2021.3.14f1c1 |
| 脚本后端 | IL2CPP |
| 目标平台 | 抖音小游戏（tt-minigame） |
| 屏幕方向 | 横屏（`game.json` → `deviceOrientation: landscape`） |
| 主要第三方 SDK | 抖音小游戏 SDK（ByteGame / TTSDK）、TextMesh Pro、OPS 混淆器 |

## 打开方式

1. Unity Hub 使用 **2021.3.14f1c1** 打开本目录。
2. 首次打开会自动重建 `Library/`（未纳入版本库，属正常构建过程）。
3. TMP 字体资源体积较大（约 258 MB），已用 **Git LFS** 托管；克隆前请先安装 LFS：

   ```bash
   git lfs install
   git clone https://github.com/xingrenshun/MiJinTiaoZhan.git
   ```

   若拉取到的 `*.asset` 只有几百字节，说明 LFS 文件没下全，执行 `git lfs pull` 补齐。

## 目录结构

```
Assets/
  Art/            美术资源（字体、图集、贴图）
  Source/         游戏逻辑脚本
  Scenes/         场景
  Prefabs/        预制体
  Plugins/        平台 SDK 与依赖库
  OPS/            OPS 混淆器配置
  TextMesh Pro/   TMP 字体与材质（LFS 大文件）
Packages/         Unity 包依赖
ProjectSettings/  工程设置（Unity 2021.3.14f1c1）
game.json         抖音小游戏启动配置
project.config.json
宥如秘境闯关_作品介绍.txt
失重历险_作品介绍.txt
```

## 未纳入版本库的内容

以下均为可由构建或编辑器重新生成的文件，不属于源码：

- `Library/`、`Temp/`、`obj/`、`Logs/`、`UserSettings/` —— Unity 缓存与用户设置
- `tt-minigame/` —— 抖音小游戏构建输出（webgl 包体、符号表、打包 zip），由工程重新构建产生
- `*.csproj`、`*.sln` —— Unity 自动生成的 VS 工程文件

## 版权与许可

本工程基于开源项目 **Numerous Ninjas**（作者 Adam Anderson、David Pokora，MIT 协议）二次开发，原始说明见 [README.NumerousNinjas.md](./README.NumerousNinjas.md)，许可条款见 [LICENSE](./LICENSE)。

新增的游戏逻辑、美术与平台接入代码版权归本项目作者所有。
