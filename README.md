# abp-vnext-templates
project templates for abp vnext

# what 

1. use `abp new CName.PName.SName -t module --tiered --no-ui` as init project.
1. replace all `Volo.Abp.EntityFrameworkCore.SqlServer` with `Volo.Abp.EntityFrameworkCore.PostgreSql` and rebuild `Migrations`.
1. fix all build issues.
1. add StyleCop Support (custom rules in StyleCop.ruleset).

# how

```
git clone https://github.com/personball/abp-vnext-templates.git
cd abp-vnext-templates
rename.ps1 YourCompany YourProject YourService
```

# MIT
