# abp-vnext-templates
project templates for abp vnext

# what 

1. use `abp new CName.PName.SName -t module --tiered --no-ui` as init project （abp version 3.0.4）.
1. replace all `Volo.Abp.EntityFrameworkCore.SqlServer` with `Volo.Abp.EntityFrameworkCore.PostgreSql` and rebuild `Migrations`.
1. update *ConnectionStrings* in appSettings.json and fix all build errors.
1. add StyleCop Support (custom rules in StyleCop.ruleset).
1. fix all build warnings.
1. Create ConventionalControllers(webapi) for `SNameApplicationModule`.
1. make `SNameHttpApiHostMigrationsDbContext` implements `ISNameDbContext` to avoid [table name pluralization problem](https://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization).
1. Use `SnakeCaseNamingConvention` for postgreSql table names and column names.
1. config swagger doc IncludeXmlComments to load comment xmls (SNameApplicationContractsModule,SNameApplicationModule,SNameDomainSharedModule)
1. config `AddSwaggerGenNewtonsoftSupport` to make SwaggerDoc enable `StringEnumConverter`
1. disable SnakeCaseNamingConvention as it didnt deal with PropertyName from base types or interfaces.
1. remove docker compose ymls, and update Dockerfile for projects in /host, adapt to k8s.

# how

```
git clone https://github.com/personball/abp-vnext-templates.git
cd abp-vnext-templates
rename.ps1 YourCompany YourProject YourService
```

# MIT
