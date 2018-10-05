# HiRecastnavigation


## 未完成

Solution for using recastnavigation in unity and server side, they both use same logic and navigation data, so that the path finding result will be matched.


##### 本项目基于recastnavigation,官方源码链接:[https://github.com/recastnavigation/recastnavigation](https://github.com/recastnavigation/recastnavigation)
##### 为了防止官方源码一直持续更新造成的接口不兼容问题,迁出官方1.5.0版本,本项目基于recastnavigation 1.5.0版本创建.
##### recastnavigation 1.5.0源码链接:[https://github.com/hiramtan/recastnavigation](https://github.com/hiramtan/recastnavigation)

#### 在recastnavigation源码基础上额外做了哪些功能?
- 导入引用类库,cmake编译RecastDemo工程,用户可以直接拿来使用
- 转换unity坐标系,导出unity场景数据为obj文件.
- 封装recastnavigation c++源码
- unity中加载导航数据
- 制作unity plugins,在unity中使用recastnavigation
- 编译不同平台dll(pc,mac,android,ios)
- 验证导航逻辑在各平台可用

#### 如何使用?
1.在unity编辑器菜单栏中点击导出场景数据

2.打开RecastDemo,选择导出的场景数据.

3.编辑参数(半径,爬坡高度等等)

4.导出导航数据

5.将导航数据一份给客户端,一份给服务器

6.加载导航数据,使用导航逻辑

7.结束

