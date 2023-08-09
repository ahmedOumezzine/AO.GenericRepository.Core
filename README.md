# EF Core Generic Repository

Cette bibliothèque est une implémentation de référentiel générique pour EF Core ORM qui supprimera la douleur des développeurs pour écrire une couche de référentiel pour chaque projet .NET Core et .NET.

## ⭐ Donner une étoile

** Si vous trouvez cette bibliothèque utile, n'oubliez pas de m'encourager à faire encore plus de choses en attribuant une étoile à ce référentiel. Merci.**



## ✈️ Comment démarrer ?

### For full version (both query and command support):
    
Installez d'abord la dernière version du package nuget `AO.GenericRepository.Core` [nuget](https://www.nuget.org/packages/AO.GenericRepository.Core)  dans votre projet comme suit :
**Package Manager Console:**

```C#
Install-Package AO.GenericRepository.Core
```

Then in the ConfirugeServices method of the Startup class:
```// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AO.GenericRepository.Core.Contexts.DbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
            o => {
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                o.Lockout.MaxFailedAccessAttempts = 5;

                o.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<AO.GenericRepository.Core.Contexts.DbContext>()
                .AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
```
    
### Pour une documentation plus détaillée, veuillez visiter [Documentation Wiki]([https://github.com/ahmedOumezzine/AO.GenericRepository.Core](https://github.com/ahmedOumezzine/AO.GenericRepository.Core/wiki)
