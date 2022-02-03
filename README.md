For starting working you need:
1. Need to generate certificate for http
    Run powershell.exe and execute commands:
        dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\ApiService.WepApi.pfx -p {{YOUR_PASSWORD}}
        dotnet dev-certs https --trust
2. Generate secret
    Go to the folder "\src\WebApi\" of current project and execute command
        dotnet user-secrets set "Kestrel:Certificates:Development:Password" "{{YOUR_PASSWORD}}"
