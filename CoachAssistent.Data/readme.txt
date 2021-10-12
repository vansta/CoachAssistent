
**Create Migration**
dotnet ef migrations add InitialCreate --startup-project "../CoachAssistent.Api"

**Remove migration**
dotnet ef migrations remove --startup-project "../CoachAssistent.Api"

**Update database**
dotnet ef database update --startup-project "../CoachAssistent.Api"