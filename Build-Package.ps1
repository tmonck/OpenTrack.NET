$BaseDir = Split-Path (Resolve-Path $MyInvocation.MyCommand.Path)

mkdir "$BaseDir\Artifacts" -Force

& "$BaseDir\.NuGet\NuGet.exe" Pack OpenTrack.nuspec -OutputDirectory "$BaseDir\artifacts\"