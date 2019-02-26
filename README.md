# 艦これ魔法使い

*用C#重写的舰娘脚本*

## 目录介绍

- **assets**为用到的静态资源，包括素材图片和大漠插件
- **KankoreMahoutsukai**里为程序源码
- **KankoreMahoutsukai/bin/Debug/bmp**为**assets/bmp**，调试时一定要保证该文件夹存在
- **KankoreMahoutsukai/bin/Debug/bmp/debug**为调试时使用的文件夹，每次查图都会保存搜寻的图
- **KankoreMahoutsukaiSetup**里为安装程序项目

## 源码使用方法

- 运行**assets/damo 3.1233/注册大漠插件到系统.bat**
- 使用VS打开**KankoreMahoutsukai.sln**
- 仅需要运行程序，运行**KankoreMahoutsukai/bin/Debug/KankoreMahoutsukai.exe**

## 安装方法

安装包在 **KankoreMahoutsukaiSetup/Debug/setup.exe**，正常安装即可。

## 使用须知

- 目前版本请使用poi浏览器，游戏分辨率固定**1153*692**。
- 请使用**1920*1080**屏幕最大化poi浏览器，且windows缩放必须为**100%**，后期加入定位游戏窗口的功能。
- 停止脚本会有短暂延迟，但绝不会进行下一步动作。


## 项目进度
- 自动收远征 √
- 自动出击 √
- 自动补给 √
- 识别游戏界面窗口 ×
- 自动远征 ×
- 挂机远征 ×
- 自动修理 ×