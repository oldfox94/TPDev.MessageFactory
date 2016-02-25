echo Copy files ...


echo Building Project ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SmsInterface\TPDev.SmsInterface.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SmsFactory\TPDev.SmsFactory.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.MailInterface\TPDev.MailInterface.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.MailFactory\TPDev.MailFactory.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild

echo Cleanup Release folder ...
del Release\*.*  /s /q


echo Merging Binaries ...
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /ndebug /copyattrs /targetplatform:4.0,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319" /out:Release\TPDev.MessageFactory.dll Binaries\TPDev.SmsFactory.dll Binaries\TPDev.SmsInterface.dll Binaries\TPDev.MailFactory.dll Binaries\TPDev.MailInterface.dll

echo finished!
pause

