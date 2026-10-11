param([string]$Server = 'localhost', [string]$Database = 'GuestData', [string]$User = 'sa')
$ErrorActionPreference = 'Stop'
# Windows PowerShell needs the framework assembly loaded explicitly.
# PowerShell 7 uses the separate ProtectedData assembly.
if ($PSVersionTable.PSEdition -eq 'Core') {
    Add-Type -AssemblyName System.Security.Cryptography.ProtectedData
} else {
    Add-Type -AssemblyName System.Security
}
$password = Read-Host 'SQL password' -AsSecureString
$credential = [PSCredential]::new($User, $password)
$connection = [System.Data.SqlClient.SqlConnectionStringBuilder]::new()
$connection['Data Source'] = $Server
$connection['Initial Catalog'] = $Database
$connection['User ID'] = $User
$connection['Password'] = $credential.GetNetworkCredential().Password
$connection['Encrypt'] = $true
$connection['TrustServerCertificate'] = $true
$connection['Connect Timeout'] = 5
$root = Split-Path $PSScriptRoot -Parent
$folder = Join-Path $root 'VisitorData/Data'
New-Item -ItemType Directory -Force $folder | Out-Null
$bytes = [System.Text.Encoding]::UTF8.GetBytes($connection.ConnectionString)
$protected = [System.Security.Cryptography.ProtectedData]::Protect($bytes,$null,[System.Security.Cryptography.DataProtectionScope]::CurrentUser)
[System.IO.File]::WriteAllBytes((Join-Path $folder 'database.secret'),$protected)
[Array]::Clear($bytes,0,$bytes.Length)
Write-Output 'Database connection saved for the current Windows account.'
