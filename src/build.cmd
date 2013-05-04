@echo off
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "ToEE World Builder.sln" /p:Configuration=Release /verbosity:quiet
if %errorlevel% neq 0 pause