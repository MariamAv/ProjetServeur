Write-Host "Creation des domaines"
scaffold-DbContext "server=localhost;port=3310;user=root;password=root;database=revues" Pomelo.EntityFrameworkCore.MySql -OutputDir Domaine -f