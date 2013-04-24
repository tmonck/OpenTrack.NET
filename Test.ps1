$ScriptPath = Split-Path $MyInvocation.MyCommand.Path

Set-Alias xunit "$(Join-Path $ScriptPath 'packages\xunit.runners.1.9.1\tools\xunit.console.clr4.exe')"

$ProjectFile = Join-Path $ScriptPath "OpenTrack.Tests\bin\Debug\OpenTrack.Tests.dll"

& "$ScriptPath\Build.ps1"
 
xunit $ProjectFile