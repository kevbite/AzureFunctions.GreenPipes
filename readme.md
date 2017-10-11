# AzureFunctions.GreenPipes

Little example of how to use [GreenPipes](https://github.com/phatboyg/GreenPipes) with Azure Function.

## Examples

### Start hosting functions

```powershell
PS > func host start
Http Function Function1: http://localhost:7071/api/Function1
Http Function Function2: http://localhost:7071/api/Function2
```

### Unauthorized requests

```powershell
PS > Invoke-RestMethod http://localhost:7071/api/Function1
Invoke-RestMethod : The remote server returned an error: (401) Unauthorized.
At line:1 char:1
+ Invoke-RestMethod http://localhost:7071/api/Function1
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (System.Net.HttpWebRequest:HttpWebRequest) [Invoke-RestMethod], WebExc
   eption
    + FullyQualifiedErrorId : WebCmdletWebResponseException,Microsoft.PowerShell.Commands.InvokeRestMethodCommand

PS > Invoke-RestMethod http://localhost:7071/api/Function2
Invoke-RestMethod : The remote server returned an error: (401) Unauthorized.
At line:1 char:1
+ Invoke-RestMethod http://localhost:7071/api/Function2
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (System.Net.HttpWebRequest:HttpWebRequest) [Invoke-RestMethod], WebExc
   eption
    + FullyQualifiedErrorId : WebCmdletWebResponseException,Microsoft.PowerShell.Commands.InvokeRestMethodCommand

```

Authorized requests

```powershell
PS > Invoke-RestMethod -Headers @{Authorization="abc-token"} http://localhost:7071/api/Function1
Hello World from Function1

PS > Invoke-RestMethod -Headers @{Authorization="abc-token"} http://localhost:7071/api/Function2
Hello World from Function2

```

## Contributing

1. Fork
1. Hack!
1. Pull Request