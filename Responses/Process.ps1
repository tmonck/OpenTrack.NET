$Root  = (Split-Path -Path (Split-Path -Path (Split-Path -Path (Split-Path -Path $MyInvocation.MyCommand.Path -Parent) -Parent) -Parent) -Parent);

Set-Alias xsd $Root\Apps\xsd.exe

ls *.xml | foreach-object { xsd $_ }
ls *.xsd | foreach-object { xsd $_  /classes}