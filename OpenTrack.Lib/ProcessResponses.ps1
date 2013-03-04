$Root  = (Split-Path -Path $MyInvocation.MyCommand.Path -Parent);

Set-Alias xsd $Root\xsd.exe

pushd Responses

ls *.xml | foreach-object { xsd $_ }
ls *.xsd | foreach-object { xsd $_  /classes}

popd