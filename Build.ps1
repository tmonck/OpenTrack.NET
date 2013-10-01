param($Targets="Build")

$ScriptPath = Split-Path $MyInvocation.MyCommand.Path

$ProjectFile = Join-Path $ScriptPath OpenTrack.NET.sln
 
& "$(Get-Content ENV:WINDIR)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" $ProjectFile /maxcpucount /p:Configuration=Release /verbosity:Minimal /target:"$Targets"