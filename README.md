# abp-vnext-templates
project templates for abp vnext

# what 

1. use `abp new CName.PName.SName -t module --tiered --no-ui` as init project （abp version 3.0.4）.
1. replace all `Volo.Abp.EntityFrameworkCore.SqlServer` with `Volo.Abp.EntityFrameworkCore.PostgreSql` and rebuild `Migrations`.
1. fix all build errors.
1. add StyleCop Support (custom rules in StyleCop.ruleset).
1. fix all build warnings.

# how

```
git clone https://github.com/personball/abp-vnext-templates.git
cd abp-vnext-templates
rename.ps1 YourCompany YourProject YourService
```

# MIT
