
## 说明
需求是支持多种文件格式（**Word PPT Excel**）转为**Pdf**的同时打上水印。
分为服务端与客户端 服务端提供Asp.Net Api 接受文件并处理，返回Url。客户端下载并回调清除服务端文件。
尝试了Spire Aspose Office官方组件 三种转换方式，水印使用itextSharp。
项目包含破解版Spire与Aspose破解无水印dll
分别封装了三个Util 为OfficeToPdf  SpireToPdf AsposeToPdf
尝试使用Spire 但Spire转换出的pdf发生了页脚换行问题，效果达不到标准。
Office组件相当于打开了一个隐藏的本机的word ppt等应用，在后台进行操作。速度一般，不支持直接打水印，需要部署的服务器带Office环境。
推荐使用Aspose Word转换速度快于Office组件 PPT略慢，转换效果达标，不需要服务器安装Office
