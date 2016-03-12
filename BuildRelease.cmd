echo Copy files ...
copy TPDev.SmsApi\bin\Release\SMSApi.dll TPDev.SmsFactory\bin\Release
copy TPDev.WebSMS\bin\Release\WebsmsToolkitCS.dll TPDev.SmsFactory\bin\Release


echo Building Project ...
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SmsInterface\TPDev.SmsInterface.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.SmsFactory\TPDev.SmsFactory.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.MailInterface\TPDev.MailInterface.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" TPDev.MailFactory\TPDev.MailFactory.csproj /p:Configuration=Release;TargetFrameworkVersion=v4.5;TargetFrameworkProfile="";OutputPath=..\Binaries /t:Rebuild


echo Cleanup Release folder ...
del Release\*.*  /s /q


echo Copy new dll files ...
copy TPDev.SmsFactory\bin\Release*.dll Binaries
copy TPDev.SmsFactory\bin\Release*.pdb Binaries
copy TPDev.MailFactory\bin\Release*.dll Binaries
copy TPDev.MailFactory\bin\Release*.pdb Binaries

copy Binaries\SMSApi.dll Release
copy Binaries\WebsmsToolkitCS.dll Release


echo Merging Binaries ...
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe" /ndebug /copyattrs /targetplatform:4.0,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319" /out:Release\TPDev.MessageFactory.dll Binaries\TPDev.SmsFactory.dll Binaries\TPDev.SmsInterface.dll Binaries\TPDev.SmsApi.dll Binaries\TPDev.WebSMS.dll Binaries\TPDev.MailFactory.dll Binaries\TPDev.MailInterface.dll Binaries\TPDev.MailSender.dll

echo finished!
pause

